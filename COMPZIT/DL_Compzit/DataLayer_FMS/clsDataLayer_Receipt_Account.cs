using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_FMS;
using CL_Compzit;
using EL_Compzit;
namespace DL_Compzit.DataLayer_FMS
{
   public class clsDataLayer_Receipt_Account
    {
       clsDataLayer objDatatLayer = new clsDataLayer();
       clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();

       public DataTable ReadCurrency(clsEntity_Receipt_Account objEntity)
       {
           string strQueryReadRcpt = "RECEIPT_ACCOUNT.SP_READ_CURRENCY";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
           cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }

       public DataTable ReadOepningBalById(clsEntity_Receipt_Account objEntity)
       {
           string strQueryReadRcpt = "RECEIPT_ACCOUNT.SP_READ_OB_BY_LEDID";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           cmdReadRcpt.Parameters.Add("R_LEDGERID", OracleDbType.Int32).Value = objEntity.LedId;
           cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadRcpt.Parameters.Add("R_RECEPTID", OracleDbType.Int32).Value = objEntity.ReceiptId;
           cmdReadRcpt.Parameters.Add("R_RECPTLDGRID", OracleDbType.Int32).Value = objEntity.ReceiptLedgrId;
           cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }

       public DataTable ReadDefualtCurrency(clsEntity_Receipt_Account objEntity)
       {
           string strQueryReadRcpt = "RECEIPT_ACCOUNT.SP_READDEFLT_CURRENCY";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
           cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }

       public DataTable ReadAccountLedger(clsEntity_Receipt_Account objEntity)
       {
           string strQueryReadRcpt = "RECEIPT_ACCOUNT.SP_ACCNT_LEDGER_READ";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
           cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }

       public DataTable ReadLeadgerReceipt(clsEntity_Receipt_Account objEntity)
       {
           string strQueryReadRcpt = "RECEIPT_ACCOUNT.SP_READ_RECEIPT_LEDGER";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
           cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }
       public DataTable ReadCostCenter(clsEntity_Receipt_Account objEntity)
       {
           string strQueryReadRcpt = "RECEIPT_ACCOUNT.SP_READ_COSTCENTER";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
           cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }
       public DataTable ReadCostGroup1(clsEntity_Receipt_Account objEntity)
       {
           string strQueryReadRcpt = "RECEIPT_ACCOUNT.SP_READ_COSTGRP1";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
           cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }
       public DataTable ReadCostGroup2(clsEntity_Receipt_Account objEntity)
       {
           string strQueryReadRcpt = "RECEIPT_ACCOUNT.SP_READ_COSTGRP2";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
           cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }

       public DataTable ReadSalesbyId(clsEntity_Receipt_Account objEntity)
       {
           string strQueryReadRcpt = "RECEIPT_ACCOUNT.SP_READ_SALES_BY_LEDID";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           cmdReadRcpt.Parameters.Add("R_LEDGERID", OracleDbType.Int32).Value = objEntity.LedgerId;
           cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadRcpt.Parameters.Add("R_RCPTID", OracleDbType.Int32).Value = objEntity.ReceiptId;
           cmdReadRcpt.Parameters.Add("R_RECPTLDGRID", OracleDbType.Int32).Value = objEntity.ReceiptLedgrId;
           cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }

       public DataTable AccntBalancebyId(clsEntity_Receipt_Account objEntity)
       {
           string strQueryReadRcpt = "RECEIPT_ACCOUNT.SP_READ_ACCNTBALANCE_BYID";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
           cmdReadRcpt.Parameters.Add("R_LEDGERID", OracleDbType.Int32).Value = objEntity.LedgerId;
           cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }
       public DataTable ReadReceptDetailsById(clsEntity_Receipt_Account objEntity)
       {
           string strQueryReadRcpt = "RECEIPT_ACCOUNT.SP_READ_RECEIPT_DTLS_BYID";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
           cmdReadRcpt.Parameters.Add("R_RECPT_ID", OracleDbType.Int32).Value = objEntity.ReceiptId;
           cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }
       public DataTable ReadReceptLedgerDetailsById(clsEntity_Receipt_Account objEntity)
       {
           string strQueryReadRcpt = "RECEIPT_ACCOUNT.SP_READ_RECEIPT_LDGR_DTLS_BYID";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
           cmdReadRcpt.Parameters.Add("R_RECPT_ID", OracleDbType.Int32).Value = objEntity.ReceiptId;
           cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadRcpt.Parameters.Add("R_STATUS", OracleDbType.Int32).Value = objEntity.Status;
           cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }
       public DataTable ReadReceptLedgerDetailsByIdforPrint(clsEntity_Receipt_Account objEntity)
       {
           string strQueryReadRcpt = "RECEIPT_ACCOUNT.SP_READ_LDGR_DTLS_BYID_PRNT";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
           cmdReadRcpt.Parameters.Add("R_RECPT_ID", OracleDbType.Int32).Value = objEntity.ReceiptId;
           cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadRcpt.Parameters.Add("R_STATUS", OracleDbType.Int32).Value = objEntity.Status;
           cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }
       public DataTable ReadReceptCostcntrDetailsById(clsEntity_Receipt_Account objEntity)
       {
           string strQueryReadRcpt = "RECEIPT_ACCOUNT.SP_READ_RCPT_CSTCNTR_DTLS_BYID";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           cmdReadRcpt.Parameters.Add("R_RECPT_ID", OracleDbType.Int32).Value = objEntity.ReceiptId;
           cmdReadRcpt.Parameters.Add("R_LEDGR_ID", OracleDbType.Int32).Value = objEntity.LedgerId;
           cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadRcpt.Parameters.Add("R_STATUS", OracleDbType.Int32).Value = objEntity.Status;
           cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }
       public DataTable ReadReceiptList(clsEntity_Receipt_Account objEntity)
       {
           string strQueryReadRcpt = "RECEIPT_ACCOUNT.SP_READ_RECEIPT_LIST";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
           cmdReadRcpt.Parameters.Add("R_LEDGERID", OracleDbType.Int32).Value = objEntity.LedgerId;
           cmdReadRcpt.Parameters.Add("R_ACID", OracleDbType.Int32).Value = objEntity.AccntNameId;
         
           if (objEntity.FromDate != DateTime.MinValue)
           {
               cmdReadRcpt.Parameters.Add("R_FROMDATE", OracleDbType.Date).Value = objEntity.FromDate;
           }
           else
           {
               cmdReadRcpt.Parameters.Add("R_FROMDATE", OracleDbType.Date).Value = null;
           }
           if (objEntity.ToDate != DateTime.MinValue)
           {
               cmdReadRcpt.Parameters.Add("R_TODATE", OracleDbType.Date).Value = objEntity.ToDate;
           }
           else
           {
               cmdReadRcpt.Parameters.Add("R_TODATE", OracleDbType.Date).Value = null;
           }
           if (objEntity.StartDate != DateTime.MinValue)
           {
               cmdReadRcpt.Parameters.Add("S_START_DATE", OracleDbType.Date).Value = objEntity.StartDate;
           }
           else
           {
               cmdReadRcpt.Parameters.Add("S_START_DATE", OracleDbType.Date).Value = null;
           }

           if (objEntity.EndDate != DateTime.MinValue)
           {
               cmdReadRcpt.Parameters.Add("S_END_DATE", OracleDbType.Date).Value = objEntity.EndDate;
           }
           else
           {
               cmdReadRcpt.Parameters.Add("S_END_DATE", OracleDbType.Date).Value = null;
           }

           cmdReadRcpt.Parameters.Add("R_CNCL_STATUS", OracleDbType.Int32).Value = objEntity.cncl_sts;

           cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadRcpt.Parameters.Add("R_RCPT_STATUS", OracleDbType.Int32).Value = objEntity.RcptSts;
           cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }

       //public void InsertReceiptDtls(clsEntity_Receipt_Account ObjEntityReceipt, List<clsEntity_Receipt_Account> ObjEntityReceiptLedger, List<clsEntity_Receipt_Account> ObjEntityReceiptCostCenter)
  
       //{
       //    clsDataLayer objDatatLayer = new clsDataLayer();
       //    string strQueryLeaveTyp = "FMS_PAYMENT_ACCOUNT.SP_INS_PAYMENT_MSTR";
       //    OracleTransaction tran;
       //    //insert to main register table
       //    clsEntityCommon objEntCommon = new clsEntityCommon();
       //    using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
       //    {
       //        con.Open();
       //        tran = con.BeginTransaction();

       //        try
       //        {
       //            using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp, con))
       //            {
       //                cmdAddService.Transaction = tran;
       //                cmdAddService.CommandType = CommandType.StoredProcedure;

                     
       //                objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.RECEIPT);
       //                objEntCommon.CorporateID = ObjEntityReceipt.Corporate_id;
       //                objEntCommon.Organisation_Id = ObjEntityReceipt.Organisation_id;
       //                string strNextId = objDatatLayer.ReadNextNumberWebForUI(objEntCommon);
       //                ObjEntityReceipt.ReceiptId = Convert.ToInt32(strNextId);
       //                string year = DateTime.Today.Year.ToString();
       //                ObjEntityReceipt.RefNum = "REF#" + year + strNextId;
       //                cmdAddService.CommandText = strQueryLeaveTyp;
       //                cmdAddService.CommandType = CommandType.StoredProcedure;
       //                cmdAddService.Parameters.Add("R_RECEIPT_ID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
       //                cmdAddService.Parameters.Add("R_REF", OracleDbType.Varchar2).Value = ObjEntityReceipt.RefNum;
       //                cmdAddService.Parameters.Add("P_ACCID", OracleDbType.Int32).Value = ObjEntityReceipt.AccntNameId;
       //                cmdAddService.Parameters.Add("P_DATE", OracleDbType.Date).Value = ObjEntityReceipt.FromDate;
       //                cmdAddService.Parameters.Add("P_CURNCY", OracleDbType.Int32).Value = ObjEntityReceipt.CurrcyId;
       //                cmdAddService.Parameters.Add("P_TOTALAMT", OracleDbType.Decimal).Value = ObjEntityReceipt.TotalAmnt;
       //                cmdAddService.Parameters.Add("P_DESRTN", OracleDbType.Varchar2).Value = ObjEntityReceipt.Description;
       //                cmdAddService.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = ObjEntityReceipt.Organisation_id;
       //                cmdAddService.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = ObjEntityReceipt.Corporate_id;
       //                cmdAddService.Parameters.Add("P_USRID", OracleDbType.Int32).Value = ObjEntityReceipt.User_Id;
       //                if (ObjEntityReceipt.ExchangeRate != 0)
       //                {
       //                    cmdAddService.Parameters.Add("R_EXCHNG_RATE", OracleDbType.Decimal).Value = ObjEntityReceipt.ExchangeRate;
       //                }
       //                else
       //                {
       //                    cmdAddService.Parameters.Add("R_EXCHNG_RATE", OracleDbType.Decimal).Value = null;
       //                }
       //                cmdAddService.ExecuteNonQuery();
       //            }
       //            foreach (clsEntity_Receipt_Account objrecptLedgrList in ObjEntityReceiptLedger)
       //            {

       //                objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.RECEIPT_LEDGER);
       //                objEntCommon.CorporateID = ObjEntityReceipt.Corporate_id;
       //                objEntCommon.Organisation_Id = ObjEntityReceipt.Organisation_id;
       //                string strGrpNextId = objDatatLayer.ReadNextNumberWebForUI(objEntCommon);
       //                string strQueryInsertGrp = "RECEIPT_ACCOUNT.SP_INSERT_RECEIPT_LEDGER";
       //                using (OracleCommand cmdInsertprdt = new OracleCommand())
       //                {
       //                    cmdInsertprdt.Transaction = tran;
       //                    cmdInsertprdt.Connection = con;
       //                    cmdInsertprdt.CommandText = strQueryInsertGrp;
       //                    cmdInsertprdt.CommandType = CommandType.StoredProcedure;
       //                    cmdInsertprdt.Parameters.Add("R_RECPT_LD_ID", OracleDbType.Int32).Value = strGrpNextId;
       //                    cmdInsertprdt.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objrecptLedgrList.LedgerId;
       //                    cmdInsertprdt.Parameters.Add("R_RECEIPT_ID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
       //                    cmdInsertprdt.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = objrecptLedgrList.LedgerAmnt;

       //                    cmdInsertprdt.ExecuteNonQuery();
       //                }

       //                foreach (clsEntity_Receipt_Account objrecptCostCntrList in ObjEntityReceiptCostCenter)
       //                {

       //                    if (objrecptCostCntrList.LedgerId == objrecptLedgrList.LedgerId)
       //                    {
       //                        if (objrecptCostCntrList.CostCtrId != 0)
       //                        {
       //                            string strQueryInsertcostCntr = "RECEIPT_ACCOUNT.SP_INSERT_RECEIPT_COSTCNTR";
       //                            using (OracleCommand cmdInsertCostCntr = new OracleCommand())
       //                            {
       //                                cmdInsertCostCntr.Transaction = tran;
       //                                cmdInsertCostCntr.Connection = con;
       //                                cmdInsertCostCntr.CommandText = strQueryInsertcostCntr;
       //                                cmdInsertCostCntr.CommandType = CommandType.StoredProcedure;
       //                                cmdInsertCostCntr.Parameters.Add("R_COST_CNTR_ID", OracleDbType.Int32).Value = objrecptCostCntrList.CostCtrId;
       //                                cmdInsertCostCntr.Parameters.Add("R_RECEIPT_ID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
       //                                cmdInsertCostCntr.Parameters.Add("R_COSTCNTR_AMT", OracleDbType.Decimal).Value = objrecptCostCntrList.CstCntrAmnt;
       //                                cmdInsertCostCntr.Parameters.Add("R_RECPT_LD_ID", OracleDbType.Int32).Value = strGrpNextId;
       //                                cmdInsertCostCntr.Parameters.Add("R_STATUS", OracleDbType.Int32).Value = objrecptCostCntrList.Status;

       //                                cmdInsertCostCntr.ExecuteNonQuery();
       //                            }
       //                        }
       //                    }

       //                }
       //            }

       //            tran.Commit();

       //        }

       //        catch (Exception e)
       //        {
       //            tran.Rollback();
       //            throw e;

       //        }


       //    }
       //}




       public void InsertReceiptDtls(clsEntity_Receipt_Account ObjEntityReceipt, List<clsEntity_Receipt_Account> ObjEntityReceiptLedger, List<clsEntity_Receipt_Account> ObjEntityReceiptCostCenter)
       {
           OracleTransaction tran;

           using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
           {
               con.Open();
               tran = con.BeginTransaction();
               try
               {
                   clsCommonLibrary objCommon = new clsCommonLibrary();
                   clsEntityCommon objEntityCommon = new clsEntityCommon();
                   objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.RECEIPT);
                   objEntityCommon.CorporateID = ObjEntityReceipt.Corporate_id;
                   objEntityCommon.Organisation_Id = ObjEntityReceipt.Organisation_id;
                   string strNextId1 = objDatatLayer.ReadNextNumber(objEntityCommon);
                   string strNextId = "";

                   int intCorpId = ObjEntityReceipt.Corporate_id;
                   int intOrgId = ObjEntityReceipt.Organisation_id;
                   int intusrId = ObjEntityReceipt.User_Id;
                   DataTable dtFormate = readRefFormate(objEntityCommon);
                   int intUsrRolMstrId = 0;
                   string strRefAccountCls = "0";
                   intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Receipt);
                   clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.REFNUM_ACCNTCLS_STS
                                                              };
                   DataTable dtCorpDetail = new DataTable();
                   string strColumns = "";
                   for (int intcount = 0; intcount < arrEnumer.Length; intcount++)
                   {
                       if (intcount == 0)
                       {
                           strColumns = arrEnumer[intcount].ToString();
                       }
                       else
                       {
                           strColumns = strColumns + "," + arrEnumer[intcount].ToString();
                       }
                   }
                   dtCorpDetail = objDatatLayer.LoadGlobalDetail(strColumns, intCorpId);
                   if (dtCorpDetail.Rows.Count > 0)
                   {
                       strRefAccountCls = dtCorpDetail.Rows[0]["REFNUM_ACCNTCLS_STS"].ToString();
                   }


                   clsDataLayerDateAndTime objDataLayerDateTime = new clsDataLayerDateAndTime();
                   string CurrentDate = objDataLayerDateTime.DateAndTime().ToString("dd-MM-yyyy");
                   DateTime dtCurrentDate = objCommon.textToDateTime(CurrentDate);
                   int DtYear = dtCurrentDate.Year;
                   int DtMonth = dtCurrentDate.Month;
                   string dtyy = dtCurrentDate.ToString("yy");

                   clsDataLayer objBusinessLayer = new clsDataLayer();
                   //clsEntityCommon objEntityCommon = new clsEntityCommon();

                   //objEntityCommon.Organisation_Id = objEntityShortList.Org_Id;
                   //objEntityCommon.CorporateID = objEntityShortList.Corp_Id;
                   objEntityCommon.FinancialYrId = ObjEntityReceipt.FinancialYrId;

                   DataTable dtCurrentFiscalYr = objBusinessLayer.ReadFinancialYearById(objEntityCommon);
                   DateTime dtFinStartDate = new DateTime();
                   DateTime dtFinEndDate = new DateTime();
                   if (dtCurrentFiscalYr.Rows.Count > 0)
                   {
                       dtFinStartDate = objCommon.textToDateTime(dtCurrentFiscalYr.Rows[0]["FINCYR_START_DT"].ToString());
                       dtFinEndDate = objCommon.textToDateTime(dtCurrentFiscalYr.Rows[0]["FINCYR_END_DT"].ToString());
                   }

                   string refFormatByDiv = "";
                   string strRealFormat = "";
                   string strRefnxt = "";



                   strNextId = objDatatLayer.ReadNextNumberSequanceForUI(objEntityCommon);


                   ObjEntityReceipt.RefNextNum = Convert.ToInt32(strNextId);


                   if (dtFormate.Rows.Count > 0)
                   {
                       if (dtFormate.Rows[0]["REF_FORMATE"].ToString() != "")
                       {
                           refFormatByDiv = dtFormate.Rows[0]["REF_FORMATE"].ToString();
                           string strReferenceFormat = "";
                           strReferenceFormat = refFormatByDiv;


                           string[] arrReferenceSplit = strReferenceFormat.Split('*');
                           int intArrayRowCount = arrReferenceSplit.Length;


                           strRealFormat = refFormatByDiv.ToString();
                           if (strRealFormat.Contains("#ORG#"))
                           {
                               strRealFormat = strRealFormat.Replace("#ORG#", intOrgId.ToString());
                           }
                           if (strRealFormat.Contains("#COR#"))
                           {
                               strRealFormat = strRealFormat.Replace("#COR#", intCorpId.ToString());
                           }

                           if (strRealFormat.Contains("#USR#"))
                           {
                               strRealFormat = strRealFormat.Replace("#USR#", intusrId.ToString());
                           }

                           //2019
                           if (strRealFormat.Contains("#YER#"))
                           {
                               strRealFormat = strRealFormat.Replace("#YER#", DtYear.ToString());
                           }
                           if (strRealFormat.Contains("#FYERS#"))
                           {
                               strRealFormat = strRealFormat.Replace("#FYERS#", dtFinStartDate.Year.ToString());
                           }
                           if (strRealFormat.Contains("#FYERE#"))
                           {
                               strRealFormat = strRealFormat.Replace("#FYERE#", dtFinEndDate.Year.ToString());
                           }

                           //19
                           if (strRealFormat.Contains("#YY#"))
                           {
                               strRealFormat = strRealFormat.Replace("#YY#", dtyy.ToString());
                           }
                           if (strRealFormat.Contains("#FYYS#"))
                           {
                               strRealFormat = strRealFormat.Replace("#FYYS#", dtFinStartDate.ToString("yy"));
                           }
                           if (strRealFormat.Contains("#FYYE#"))
                           {
                               strRealFormat = strRealFormat.Replace("#FYYE#", dtFinEndDate.ToString("yy"));
                           }

                           if (strRealFormat.Contains("#MON#"))
                           {
                               strRealFormat = strRealFormat.Replace("#MON#", DtMonth.ToString());
                           }
                           //strRealFormat = strRealFormat + "/" + strNextNum;
                           if (strRealFormat.Contains("#NUM#"))
                           {
                               strRealFormat = strRealFormat.Replace("#NUM#", strNextId);
                           }
                           else
                           {
                               strRealFormat = strRealFormat + "/" + strNextId;
                           }


                           strRealFormat = strRealFormat.Replace("#", "");
                           strRealFormat = strRealFormat.Replace("*", "");
                           strRealFormat = strRealFormat.Replace("%", "");


                       }
                       ObjEntityReceipt.RefNum = strRealFormat;
                   }
                   else
                   {

                       ObjEntityReceipt.RefNum = strNextId;
                   }

                   //CHECKING SUB REF NUMBER
                   string Ref = ""; int SubRef = 1;
                   if (strRefAccountCls == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                   {
                       clsDataLayer_Account_Close objEmpAccntCls = new clsDataLayer_Account_Close();
                       clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
                       clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
                       clsDataLayer_Audit_Closing objEmpAuditCls = new clsDataLayer_Audit_Closing();
                       clsEntity_Receipt_Account ObjEntityRequest = new clsEntity_Receipt_Account();

                       objEntityAccnt.FromDate = ObjEntityReceipt.FromDate;
                       objEntityAudit.FromDate = ObjEntityReceipt.FromDate;
                       ObjEntityReceipt.FromDate = ObjEntityReceipt.FromDate;
                       objEntityAccnt.Corporate_id = intCorpId;
                       ObjEntityReceipt.Corporate_id = intCorpId;
                       objEntityAccnt.Organisation_id = intOrgId;
                       ObjEntityReceipt.Organisation_id = intOrgId;

                       objEntityAudit.Organisation_id = intOrgId;
                       objEntityAudit.Corporate_id = intCorpId;

                       DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
                       DataTable dtAuditCls = objEmpAuditCls.CheckAuditClosingDate(objEntityAudit);

                       if (dtAccntCls.Rows.Count > 0 || dtAuditCls.Rows.Count > 0)
                       {
                           DataTable dtRefFormat1 = ReadRefNumberByDate(ObjEntityReceipt);
                           if (dtRefFormat1.Rows.Count > 0)
                           {
                               string strRef = "";
                               if (dtRefFormat1.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString() != "")
                               {
                                   if (Convert.ToInt32(dtRefFormat1.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString()) != 1)
                                   {
                                       strRef = dtRefFormat1.Rows[0]["RECPT_REF"].ToString();
                                       strRef = strRef.TrimEnd('/');
                                       strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                   }
                                   else
                                   {
                                       strRef = dtRefFormat1.Rows[0]["RECPT_REF"].ToString();
                                   }
                               }
                               else
                               {
                                   strRef = dtRefFormat1.Rows[0]["RECPT_REF"].ToString();
                               }
                               ObjEntityReceipt.RefNum = strRef;
                               DataTable dtRefFormat = ReadRefNumberByDateLast(ObjEntityReceipt);
                               if (dtRefFormat.Rows.Count > 0)
                               {
                                   Ref = dtRefFormat.Rows[0]["RECPT_REF"].ToString();
                                   if (dtRefFormat.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString() != null)
                                   {
                                       SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString());
                                   }
                                   if (SubRef != 1)
                                   {
                                       Ref = Ref.TrimEnd('/');
                                       Ref = Ref.Remove(Ref.LastIndexOf('/') + 1);
                                   }
                                   else
                                   {
                                       Ref += "/";
                                   }
                                   Ref = Ref + "" + SubRef;
                                   ObjEntityReceipt.RefNum = Ref;

                                   SubRef++;
                                   if (dtRefFormat.Rows[0]["RECPT_REF_NEXTNUM"].ToString() != "")
                                       ObjEntityReceipt.RefNextNum = Convert.ToInt32(dtRefFormat.Rows[0]["RECPT_REF_NEXTNUM"].ToString());
                               }
                           }

                       }
                   }
                   ObjEntityReceipt.ReceiptId = Convert.ToInt32(strNextId1);

                   //INSERT TO RECEIPT MASTER TABLE
                   string strQueryInsertUser = "RECEIPT_ACCOUNT.SP_INSERT_RECEIPT_DTLS";
                   using (OracleCommand cmdInsertSales = new OracleCommand())
                   {
                       cmdInsertSales.Transaction = tran;
                       cmdInsertSales.Connection = con;
                       cmdInsertSales.CommandText = strQueryInsertUser;
                       cmdInsertSales.CommandType = CommandType.StoredProcedure;
                       cmdInsertSales.Parameters.Add("R_RECEIPT_ID", OracleDbType.Int32).Value = strNextId1;
                       cmdInsertSales.Parameters.Add("R_ACNT_LDGR_ID", OracleDbType.Int32).Value = ObjEntityReceipt.LedgerId;
                       cmdInsertSales.Parameters.Add("R_DATE", OracleDbType.Date).Value = ObjEntityReceipt.FromDate;
                       cmdInsertSales.Parameters.Add("R_CRNCMST_ID", OracleDbType.Int32).Value = ObjEntityReceipt.CurrcyId;
                       if (ObjEntityReceipt.ExchangeRate != 0)
                       {
                           cmdInsertSales.Parameters.Add("R_EXCHNG_RATE", OracleDbType.Int32).Value = ObjEntityReceipt.ExchangeRate;
                       }
                       else
                       {
                           cmdInsertSales.Parameters.Add("R_EXCHNG_RATE", OracleDbType.Int32).Value = DBNull.Value;
                       }
                       cmdInsertSales.Parameters.Add("R_REF", OracleDbType.Varchar2).Value = ObjEntityReceipt.RefNum;
                       cmdInsertSales.Parameters.Add("R_TOTEL_AMT", OracleDbType.Decimal).Value = ObjEntityReceipt.TotalAmnt;
                       cmdInsertSales.Parameters.Add("R_DESCPTN", OracleDbType.Varchar2).Value = ObjEntityReceipt.Description;
                       cmdInsertSales.Parameters.Add("ORGID", OracleDbType.Int32).Value = ObjEntityReceipt.Organisation_id;
                       cmdInsertSales.Parameters.Add("CORPID", OracleDbType.Int32).Value = ObjEntityReceipt.Corporate_id;
                       cmdInsertSales.Parameters.Add("USRID", OracleDbType.Int32).Value = ObjEntityReceipt.User_Id;

                       cmdInsertSales.Parameters.Add("R_PAY_MOD", OracleDbType.Int32).Value = ObjEntityReceipt.PaymentMod;
                       if (ObjEntityReceipt.PaymentMod != 3)
                       {
                           if (ObjEntityReceipt.Bank_Name != "")
                           {
                               cmdInsertSales.Parameters.Add("R_BNK", OracleDbType.Varchar2).Value = ObjEntityReceipt.Bank_Name;
                           }
                           else
                           {
                               cmdInsertSales.Parameters.Add("R_BNK", OracleDbType.Varchar2).Value = DBNull.Value; ;
                           }
                           if (ObjEntityReceipt.IbanNo != "")
                           {
                               cmdInsertSales.Parameters.Add("R_IBAN_NO", OracleDbType.Varchar2).Value = ObjEntityReceipt.IbanNo;
                           }
                           else
                           {
                               cmdInsertSales.Parameters.Add("R_IBAN_NO", OracleDbType.Varchar2).Value = DBNull.Value; ;
                           }
                           cmdInsertSales.Parameters.Add("R_PAYMENT_DATE", OracleDbType.Date).Value = ObjEntityReceipt.PaymentDate;
                           if (ObjEntityReceipt.PaymentMod == 0)
                           {
                               cmdInsertSales.Parameters.Add("R_DD_NO", OracleDbType.Int32).Value = DBNull.Value;
                               cmdInsertSales.Parameters.Add("R_TRNSFR_MOD", OracleDbType.Int32).Value = DBNull.Value;
                               cmdInsertSales.Parameters.Add("R_CHEQUE", OracleDbType.Varchar2).Value = ObjEntityReceipt.ChequeBook_No;
                           }
                           else if (ObjEntityReceipt.PaymentMod == 1)
                           {
                               cmdInsertSales.Parameters.Add("R_DD_NO", OracleDbType.Varchar2).Value = ObjEntityReceipt.DDNumber;
                               cmdInsertSales.Parameters.Add("R_TRNSFR_MOD", OracleDbType.Int32).Value = DBNull.Value;
                               cmdInsertSales.Parameters.Add("R_CHEQUE", OracleDbType.Int32).Value = DBNull.Value;
                           }
                           else if (ObjEntityReceipt.PaymentMod == 2)
                           {
                               cmdInsertSales.Parameters.Add("R_DD_NO", OracleDbType.Int32).Value = DBNull.Value;
                               cmdInsertSales.Parameters.Add("R_TRNSFR_MOD", OracleDbType.Int32).Value = ObjEntityReceipt.TransferModId;
                               cmdInsertSales.Parameters.Add("R_CHEQUE", OracleDbType.Int32).Value = DBNull.Value;
                           }
                       }
                       else
                       {
                           cmdInsertSales.Parameters.Add("R_BNK", OracleDbType.Varchar2).Value = DBNull.Value; ;
                           cmdInsertSales.Parameters.Add("R_IBAN_NO", OracleDbType.Varchar2).Value = DBNull.Value; ;
                           cmdInsertSales.Parameters.Add("R_PAYMENT_DATE", OracleDbType.Date).Value = DBNull.Value; ;
                           cmdInsertSales.Parameters.Add("R_DD_NO", OracleDbType.Int32).Value = DBNull.Value; ;
                           cmdInsertSales.Parameters.Add("R_TRNSFR_MOD", OracleDbType.Int32).Value = DBNull.Value;
                           cmdInsertSales.Parameters.Add("R_CHEQUE", OracleDbType.Int32).Value = DBNull.Value;
                       }
                       if (SubRef == 1)
                       {
                           cmdInsertSales.Parameters.Add("R_SUBREFID", OracleDbType.Int32).Value = DBNull.Value;
                       }
                       else
                       {
                           cmdInsertSales.Parameters.Add("R_SUBREFID", OracleDbType.Int32).Value = SubRef;
                       }
                       cmdInsertSales.Parameters.Add("R_REF_NEXTNUM", OracleDbType.Int32).Value = ObjEntityReceipt.RefNextNum;

                       if (ObjEntityReceipt.RecurPeriodId != 0)
                       {
                           cmdInsertSales.Parameters.Add("R_REC_PERIOD", OracleDbType.Int32).Value = ObjEntityReceipt.RecurPeriodId;
                           cmdInsertSales.Parameters.Add("R_REC_REMIND_DAYS", OracleDbType.Int32).Value = ObjEntityReceipt.RecurRemindDays;
                       }
                       else
                       {
                           cmdInsertSales.Parameters.Add("R_REC_PERIOD", OracleDbType.Int32).Value = DBNull.Value;
                           cmdInsertSales.Parameters.Add("R_REC_REMIND_DAYS", OracleDbType.Int32).Value = DBNull.Value;
                       }
                       cmdInsertSales.Parameters.Add("R_REC_SUBID", OracleDbType.Int32).Value = ObjEntityReceipt.RecurSubId;

                       if (ObjEntityReceipt.RecurMasterId != 0)
                       {
                           cmdInsertSales.Parameters.Add("R_POST_CHQ_DTL_ID", OracleDbType.Int32).Value = ObjEntityReceipt.RecurMasterId;
                       }
                       else
                       {
                           cmdInsertSales.Parameters.Add("R_POST_CHQ_DTL_ID", OracleDbType.Int32).Value = DBNull.Value;
                       }
                       cmdInsertSales.ExecuteNonQuery();
                   }

                   foreach (clsEntity_Receipt_Account objrecptLedgrList in ObjEntityReceiptLedger)
                   {
                       objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.RECEIPT_LEDGER);
                       objEntityCommon.CorporateID = ObjEntityReceipt.Corporate_id;
                       objEntityCommon.Organisation_Id = ObjEntityReceipt.Organisation_id;
                       string strGrpNextId = objDatatLayer.ReadNextNumberWebForUI(objEntityCommon);
                       objrecptLedgrList.ReceiptLedgrId = Convert.ToInt32(strGrpNextId);

                       //INSERT TO RECEIPT-LEDGER SUB  TABLE -CREATING ROWS TO CORRESPONG LEDGERS
                       string strQueryInsertGrp = "RECEIPT_ACCOUNT.SP_INSERT_RECEIPT_LEDGER";
                       using (OracleCommand cmdInsertprdt = new OracleCommand())
                       {
                           cmdInsertprdt.Transaction = tran;
                           cmdInsertprdt.Connection = con;
                           cmdInsertprdt.CommandText = strQueryInsertGrp;
                           cmdInsertprdt.CommandType = CommandType.StoredProcedure;
                           cmdInsertprdt.Parameters.Add("R_RECPT_LD_ID", OracleDbType.Int32).Value = objrecptLedgrList.ReceiptLedgrId;
                           cmdInsertprdt.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objrecptLedgrList.LedgerId;
                           cmdInsertprdt.Parameters.Add("R_RECEIPT_ID", OracleDbType.Int32).Value = strNextId1;
                           cmdInsertprdt.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = objrecptLedgrList.LedgerAmnt;
                           cmdInsertprdt.Parameters.Add("R_LDGR_REMARKS", OracleDbType.Varchar2).Value = objrecptLedgrList.Remarks;
                           cmdInsertprdt.ExecuteNonQuery();
                       }

                       foreach (clsEntity_Receipt_Account objrecptCostCntrList in ObjEntityReceiptCostCenter)
                       {
                           if (objrecptCostCntrList.LedgerId == objrecptLedgrList.LedgerId && objrecptCostCntrList.LedgerRow == objrecptLedgrList.LedgerRow)
                           {
                               //INSERT TO RECEIPT-COSTCENTER SUB  TABLE IF THERE IS COST CENTER DETAILS OR OPENING BALANCE 
                               string strQueryInsertcostCntr = "RECEIPT_ACCOUNT.SP_INSERT_RECEIPT_COSTCNTR";
                               using (OracleCommand cmdInsertCostCntr = new OracleCommand())
                               {
                                   cmdInsertCostCntr.Transaction = tran;
                                   cmdInsertCostCntr.Connection = con;
                                   cmdInsertCostCntr.CommandText = strQueryInsertcostCntr;
                                   cmdInsertCostCntr.CommandType = CommandType.StoredProcedure;
                                   if (objrecptCostCntrList.CostCtrId != 0)
                                   {
                                       cmdInsertCostCntr.Parameters.Add("R_COST_CNTR_ID", OracleDbType.Int32).Value = objrecptCostCntrList.CostCtrId;
                                   }
                                   else
                                   {
                                       cmdInsertCostCntr.Parameters.Add("R_COST_CNTR_ID", OracleDbType.Int32).Value = null;
                                   }
                                   cmdInsertCostCntr.Parameters.Add("R_RECEIPT_ID", OracleDbType.Int32).Value = strNextId1;
                                   cmdInsertCostCntr.Parameters.Add("R_COSTCNTR_AMT", OracleDbType.Decimal).Value = objrecptCostCntrList.CstCntrAmnt;
                                   cmdInsertCostCntr.Parameters.Add("R_RECPT_LD_ID", OracleDbType.Int32).Value = objrecptLedgrList.ReceiptLedgrId;
                                   cmdInsertCostCntr.Parameters.Add("R_STATUS", OracleDbType.Int32).Value = objrecptCostCntrList.Status;
                                   if (objrecptCostCntrList.CostGrp1Id != 0)
                                   {
                                       cmdInsertCostCntr.Parameters.Add("R_COST_GRP_ID_ONE", OracleDbType.Int32).Value = objrecptCostCntrList.CostGrp1Id;
                                   }
                                   else
                                   {
                                       cmdInsertCostCntr.Parameters.Add("R_COST_GRP_ID_ONE", OracleDbType.Int32).Value = null;
                                   }
                                   if (objrecptCostCntrList.CostGrp2Id != 0)
                                   {
                                       cmdInsertCostCntr.Parameters.Add("R_COST_GRP_ID_TWO", OracleDbType.Int32).Value = objrecptCostCntrList.CostGrp2Id;
                                   }
                                   else
                                   {
                                       cmdInsertCostCntr.Parameters.Add("R_COST_GRP_ID_TWO", OracleDbType.Int32).Value = null;
                                   }
                                   if (objrecptCostCntrList.AccntNameId != 0)
                                   {
                                       cmdInsertCostCntr.Parameters.Add("R_CREDITNOTE_LEDID", OracleDbType.Int32).Value = objrecptCostCntrList.AccntNameId;
                                   }
                                   else
                                   {
                                       cmdInsertCostCntr.Parameters.Add("R_CREDITNOTE_LEDID", OracleDbType.Int32).Value = null;
                                   }
                                   if (objrecptCostCntrList.BalanceAmount != 0)
                                   {
                                       cmdInsertCostCntr.Parameters.Add("R_CREDITNOTE_BAL", OracleDbType.Decimal).Value = objrecptCostCntrList.BalanceAmount;
                                   }
                                   else
                                   {
                                       cmdInsertCostCntr.Parameters.Add("R_CREDITNOTE_BAL", OracleDbType.Decimal).Value = null;
                                   }
                                   if (objrecptCostCntrList.LedgerAmnt != 0)
                                   {
                                       cmdInsertCostCntr.Parameters.Add("R_CREDITNOTE_SETLAMNT", OracleDbType.Decimal).Value = objrecptCostCntrList.LedgerAmnt;
                                   }
                                   else
                                   {
                                       cmdInsertCostCntr.Parameters.Add("R_CREDITNOTE_SETLAMNT", OracleDbType.Decimal).Value = null;
                                   }
                                   cmdInsertCostCntr.Parameters.Add("OB_PAIDAMT", OracleDbType.Decimal).Value = objrecptCostCntrList.PaidAmt;
                                   cmdInsertCostCntr.Parameters.Add("OB_BALAMT", OracleDbType.Decimal).Value = objrecptCostCntrList.BalnceAmt;
                                   cmdInsertCostCntr.ExecuteNonQuery();
                               }
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

       public void CancelReceiptById(clsEntity_Receipt_Account ObjEntityReceipt)
       {
           string strQueryMemoRsnCncl = " RECEIPT_ACCOUNT.SP_CANCEL_RECEIPT";
           using (OracleCommand cmdPerfmncTmplt = new OracleCommand())
           {
               cmdPerfmncTmplt.CommandText = strQueryMemoRsnCncl;
               cmdPerfmncTmplt.CommandType = CommandType.StoredProcedure;
               cmdPerfmncTmplt.Parameters.Add("RCPTID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
               cmdPerfmncTmplt.Parameters.Add("CNCL_USR_ID", OracleDbType.Int32).Value = ObjEntityReceipt.User_Id;
               cmdPerfmncTmplt.Parameters.Add("P_RSN_CNSL_RSN", OracleDbType.Varchar2).Value = ObjEntityReceipt.CancelReason;
               clsDataLayer.ExecuteNonQuery(cmdPerfmncTmplt);
           }
       }
       public void ConfirmReceiptById(clsEntity_Receipt_Account ObjEntityReceipt)
       {
           string strQueryMemoRsnCncl = " RECEIPT_ACCOUNT.SP_CONFIRM_RECEIPT";
           using (OracleCommand cmdPerfmncTmplt = new OracleCommand())
           {
               cmdPerfmncTmplt.CommandText = strQueryMemoRsnCncl;
               cmdPerfmncTmplt.CommandType = CommandType.StoredProcedure;
               cmdPerfmncTmplt.Parameters.Add("RCPTID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
               cmdPerfmncTmplt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = ObjEntityReceipt.Organisation_id;
               cmdPerfmncTmplt.Parameters.Add("R_CORP_ID", OracleDbType.Varchar2).Value = ObjEntityReceipt.Corporate_id;
               cmdPerfmncTmplt.Parameters.Add("R_USR_ID", OracleDbType.Varchar2).Value = ObjEntityReceipt.User_Id;
               clsDataLayer.ExecuteNonQuery(cmdPerfmncTmplt);
           }
       }


       public void updateReceiptDtls(clsEntity_Receipt_Account ObjEntityReceipt, List<clsEntity_Receipt_Account> ObjEntityReceiptLedger, List<clsEntity_Receipt_Account> ObjEntityReceiptCostCenter, List<clsEntity_Receipt_Account> ObjEntityReceipLedger_Insert, List<clsEntity_Receipt_Account> ObjEntityReceiptLedger_Update, List<clsEntity_Receipt_Account> ObjEntityReceiptLedger_Delete, List<clsEntity_Receipt_Account> ObjEntityReceiptCostCenter_Insert, List<clsEntity_Receipt_Account> ObjEntityReceiptCostCenter_update, List<clsEntity_Receipt_Account> ObjEntityReceiptCostCenter_Delete)
       {
           clsDataLayer objDatatLayer = new clsDataLayer();
           string strQueryLeaveTyp = "RECEIPT_ACCOUNT.SP_UPDATE_RECEIPT_DTLS";
           OracleTransaction tran;
           //insert to main register table
           clsEntityCommon objEntityCommon = new clsEntityCommon();
           using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
           {
               con.Open();
               tran = con.BeginTransaction();

               try
               {
                   int SubRef = 1;
                   int FLGSALE = 0;
                   string strReturn = "";
                   string strReturnLdgr = "";
                   if (ObjEntityReceipt.FromDate != ObjEntityReceipt.RcptUpdateDate)
                   {

                       clsCommonLibrary objCommon = new clsCommonLibrary();

                       objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.RECEIPT);
                       objEntityCommon.CorporateID = ObjEntityReceipt.Corporate_id;
                       objEntityCommon.Organisation_Id = ObjEntityReceipt.Organisation_id;
                       int intCorpId = ObjEntityReceipt.Corporate_id;
                       int intOrgId = ObjEntityReceipt.Organisation_id;
                       int intusrId = ObjEntityReceipt.User_Id;

                       DataTable dtFormate = readRefFormate(objEntityCommon);
                       int intUsrRolMstrId = 0;
                       string strRefAccountCls = "0";

                       intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Receipt);
                       clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.REFNUM_ACCNTCLS_STS
                                                              };
                       DataTable dtCorpDetail = new DataTable();
                       string strColumns = "";
                       for (int intcount = 0; intcount < arrEnumer.Length; intcount++)
                       {
                           if (intcount == 0)
                           {
                               strColumns = arrEnumer[intcount].ToString();
                           }
                           else
                           {
                               strColumns = strColumns + "," + arrEnumer[intcount].ToString();
                           }
                       }
                       dtCorpDetail = objDatatLayer.LoadGlobalDetail(strColumns, intCorpId);
                       if (dtCorpDetail.Rows.Count > 0)
                       {
                           strRefAccountCls = dtCorpDetail.Rows[0]["REFNUM_ACCNTCLS_STS"].ToString();
                       }


                       clsDataLayerDateAndTime objDataLayerDateTime = new clsDataLayerDateAndTime();
                       string CurrentDate = objDataLayerDateTime.DateAndTime().ToString("dd-MM-yyyy");
                       DateTime dtCurrentDate = objCommon.textToDateTime(CurrentDate);
                       int DtYear = dtCurrentDate.Year;
                       int DtMonth = dtCurrentDate.Month;


                       //CHECKING SUB REF NUMBER
                       string Ref = "";
                       if (strRefAccountCls == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                       {


                           clsDataLayer_Account_Close objEmpAccntCls = new clsDataLayer_Account_Close();
                           clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
                           objEntityAccnt.FromDate = ObjEntityReceipt.FromDate;
                           //   clsEntityJournal objEntityLayerStock1 = new clsEntityJournal();
                           // clsdAJournal objBusinessLayerStock1 = new clsBusinessJournal();
                           ObjEntityReceipt.FromDate = ObjEntityReceipt.FromDate;
                           objEntityAccnt.Corporate_id = intCorpId;
                           ObjEntityReceipt.Corporate_id = intCorpId;
                           objEntityAccnt.Organisation_id = intOrgId;
                           ObjEntityReceipt.Organisation_id = intOrgId;
                           string RcptDate = ObjEntityReceipt.RcptUpdateDate.ToString();

                           clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
                           clsDataLayer_Audit_Closing objEmpAuditCls = new clsDataLayer_Audit_Closing();

                           objEntityAudit.Organisation_id = intOrgId;
                           objEntityAudit.Corporate_id = intCorpId;
                           objEntityAudit.FromDate = ObjEntityReceipt.FromDate;

                           DataTable dtAuditCls = objEmpAuditCls.CheckAuditClosingDate(objEntityAudit);
                           DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
                           if (dtAccntCls.Rows.Count > 0 || dtAuditCls.Rows.Count > 0)
                           {
                               DataTable dtRefFormat1 = ReadRefNumberByDate(ObjEntityReceipt);
                               if (dtRefFormat1.Rows.Count > 0)
                               {
                                   string strRef = "";
                                   if (dtRefFormat1.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString() != "")
                                   {
                                       if (Convert.ToInt32(dtRefFormat1.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString()) != 1)
                                       {
                                           strRef = dtRefFormat1.Rows[0]["RECPT_REF"].ToString();
                                           strRef = strRef.TrimEnd('/');
                                           strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                       }
                                       else
                                       {
                                           strRef = dtRefFormat1.Rows[0]["RECPT_REF"].ToString();
                                       }
                                   }
                                   else
                                   {
                                       strRef = dtRefFormat1.Rows[0]["RECPT_REF"].ToString();
                                   }
                                   ObjEntityReceipt.RefNum = strRef;
                                   DataTable dtRefFormat = ReadRefNumberByDateLast(ObjEntityReceipt);
                                   if (dtRefFormat.Rows.Count > 0)
                                   {
                                       if (ObjEntityReceipt.ReceiptId != Convert.ToInt32(dtRefFormat.Rows[0]["RECPT_ID"].ToString()))
                                       {
                                           Ref = dtRefFormat.Rows[0]["RECPT_REF"].ToString();
                                           if (dtRefFormat.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString() != null)
                                           {
                                               SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString());
                                           }
                                           if (SubRef != 1)
                                           {
                                               Ref = Ref.TrimEnd('/');
                                               Ref = Ref.Remove(Ref.LastIndexOf('/') + 1);
                                           }
                                           else
                                           {
                                               Ref += "/";
                                           }
                                           Ref = Ref + "" + SubRef;
                                           ObjEntityReceipt.RefNum = Ref;
                                           SubRef++;
                                       }
                                       if (dtRefFormat.Rows[0]["RECPT_REF_NEXTNUM"].ToString() != "")
                                           ObjEntityReceipt.RefNextNum = Convert.ToInt32(dtRefFormat.Rows[0]["RECPT_REF_NEXTNUM"].ToString());

                                   }
                               }


                           }
                       }
                   }
                   //UPDATING RECEIPT DETAILS TO RECEIPT MASTER TABLE
                   using (OracleCommand cmdUpdReceiptDtls = new OracleCommand(strQueryLeaveTyp, con))
                   {
                       cmdUpdReceiptDtls.Transaction = tran;
                       cmdUpdReceiptDtls.CommandType = CommandType.StoredProcedure;
                       cmdUpdReceiptDtls.CommandText = strQueryLeaveTyp;
                       cmdUpdReceiptDtls.CommandType = CommandType.StoredProcedure;
                       cmdUpdReceiptDtls.Parameters.Add("R_RECPT_ID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                       cmdUpdReceiptDtls.Parameters.Add("R_ACNT_LDGR_ID", OracleDbType.Int32).Value = ObjEntityReceipt.AccntNameId;
                       cmdUpdReceiptDtls.Parameters.Add("R_DATE", OracleDbType.Date).Value = ObjEntityReceipt.FromDate;
                       cmdUpdReceiptDtls.Parameters.Add("R_CRNCMST_ID", OracleDbType.Int32).Value = ObjEntityReceipt.CurrcyId;
                       cmdUpdReceiptDtls.Parameters.Add("R_REF", OracleDbType.Varchar2).Value = ObjEntityReceipt.RefNum;

                       if (SubRef == 1)
                       {
                           cmdUpdReceiptDtls.Parameters.Add("R_SUBREFID", OracleDbType.Int32).Value = DBNull.Value;
                       }
                       else
                       {
                           cmdUpdReceiptDtls.Parameters.Add("R_SUBREFID", OracleDbType.Int32).Value = SubRef;
                       }
                       cmdUpdReceiptDtls.Parameters.Add("R_TOTEL_AMT", OracleDbType.Decimal).Value = ObjEntityReceipt.TotalAmnt;
                       cmdUpdReceiptDtls.Parameters.Add("R_DESCPTN", OracleDbType.Varchar2).Value = ObjEntityReceipt.Description;
                       cmdUpdReceiptDtls.Parameters.Add("R_CNFIRM_STS", OracleDbType.Int32).Value = ObjEntityReceipt.ConfirmStatus;
                       cmdUpdReceiptDtls.Parameters.Add("ORGID", OracleDbType.Int32).Value = ObjEntityReceipt.Organisation_id;
                       cmdUpdReceiptDtls.Parameters.Add("CORPID", OracleDbType.Int32).Value = ObjEntityReceipt.Corporate_id;
                       cmdUpdReceiptDtls.Parameters.Add("USRID", OracleDbType.Int32).Value = ObjEntityReceipt.User_Id;
                       cmdUpdReceiptDtls.Parameters.Add("R_PAY_MOD", OracleDbType.Int32).Value = ObjEntityReceipt.PaymentMod;
                       if (ObjEntityReceipt.PaymentMod != 3)
                       {
                           if (ObjEntityReceipt.Bank_Name != "")
                           {
                               cmdUpdReceiptDtls.Parameters.Add("R_BNK", OracleDbType.Varchar2).Value = ObjEntityReceipt.Bank_Name;
                           }
                           else
                           {
                               cmdUpdReceiptDtls.Parameters.Add("R_BNK", OracleDbType.Varchar2).Value = DBNull.Value; ;
                           }
                           if (ObjEntityReceipt.IbanNo != "")
                           {
                               cmdUpdReceiptDtls.Parameters.Add("R_IBAN_NO", OracleDbType.Varchar2).Value = ObjEntityReceipt.IbanNo;
                           }
                           else
                           {
                               cmdUpdReceiptDtls.Parameters.Add("R_IBAN_NO", OracleDbType.Varchar2).Value = DBNull.Value; ;
                           }
                           cmdUpdReceiptDtls.Parameters.Add("R_PAYMENT_DATE", OracleDbType.Date).Value = ObjEntityReceipt.PaymentDate;
                           if (ObjEntityReceipt.PaymentMod == 0)
                           {
                               cmdUpdReceiptDtls.Parameters.Add("R_DD_NO", OracleDbType.Int32).Value = DBNull.Value;
                               cmdUpdReceiptDtls.Parameters.Add("R_TRNSFR_MOD", OracleDbType.Int32).Value = DBNull.Value;
                               cmdUpdReceiptDtls.Parameters.Add("R_CHEQUE", OracleDbType.Varchar2).Value = ObjEntityReceipt.ChequeBook_No;
                           }
                           else if (ObjEntityReceipt.PaymentMod == 1)
                           {
                               cmdUpdReceiptDtls.Parameters.Add("R_DD_NO", OracleDbType.Varchar2).Value = ObjEntityReceipt.DDNumber;
                               cmdUpdReceiptDtls.Parameters.Add("R_TRNSFR_MOD", OracleDbType.Int32).Value = DBNull.Value;
                               cmdUpdReceiptDtls.Parameters.Add("R_CHEQUE", OracleDbType.Int32).Value = DBNull.Value;
                           }
                           else if (ObjEntityReceipt.PaymentMod == 2)
                           {
                               cmdUpdReceiptDtls.Parameters.Add("R_DD_NO", OracleDbType.Int32).Value = DBNull.Value;
                               cmdUpdReceiptDtls.Parameters.Add("R_TRNSFR_MOD", OracleDbType.Int32).Value = ObjEntityReceipt.TransferModId;
                               cmdUpdReceiptDtls.Parameters.Add("R_CHEQUE", OracleDbType.Int32).Value = DBNull.Value;
                           }
                       }
                       else
                       {
                           cmdUpdReceiptDtls.Parameters.Add("R_BNK_ID", OracleDbType.Int32).Value = DBNull.Value; ;
                           cmdUpdReceiptDtls.Parameters.Add("R_IBAN_NO", OracleDbType.Varchar2).Value = DBNull.Value; ;
                           cmdUpdReceiptDtls.Parameters.Add("R_PAYMENT_DATE", OracleDbType.Date).Value = DBNull.Value; ;
                           cmdUpdReceiptDtls.Parameters.Add("R_DD_NO", OracleDbType.Int32).Value = DBNull.Value; ;
                           cmdUpdReceiptDtls.Parameters.Add("R_TRNSFR_MOD", OracleDbType.Int32).Value = DBNull.Value;
                           cmdUpdReceiptDtls.Parameters.Add("R_CHEQUE", OracleDbType.Int32).Value = DBNull.Value;
                       }
                       cmdUpdReceiptDtls.Parameters.Add("R_REF_NEXTNUM", OracleDbType.Int32).Value = ObjEntityReceipt.RefNextNum;
                       if (ObjEntityReceipt.RecurPeriodId != 0)
                       {
                           cmdUpdReceiptDtls.Parameters.Add("R_REC_PERIOD", OracleDbType.Int32).Value = ObjEntityReceipt.RecurPeriodId;
                           cmdUpdReceiptDtls.Parameters.Add("R_REC_REMIND_DAYS", OracleDbType.Int32).Value = ObjEntityReceipt.RecurRemindDays;
                       }
                       else
                       {
                           cmdUpdReceiptDtls.Parameters.Add("R_REC_PERIOD", OracleDbType.Int32).Value = DBNull.Value;
                           cmdUpdReceiptDtls.Parameters.Add("R_REC_REMIND_DAYS", OracleDbType.Int32).Value = DBNull.Value;
                       }
                       cmdUpdReceiptDtls.ExecuteNonQuery();
                   }

                   //on confirm
                   if (ObjEntityReceipt.ConfirmStatus == 1)
                   {
                       //UPDATE LEDGER balance - ACCOUNT BOOK
                       string strQueryUpdateLedger = "RECEIPT_ACCOUNT.SP_UPDATE_ACCOUNT_MASTR";
                       using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryUpdateLedger, con))
                       {
                           cmdAddSubDetail.Transaction = tran;
                           cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                           cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityReceipt.AccntNameId;
                           cmdAddSubDetail.Parameters.Add("R_TOTEL_AMT", OracleDbType.Decimal).Value = ObjEntityReceipt.TotalAmnt;
                           cmdAddSubDetail.ExecuteNonQuery();
                       }
                       //INSERT TO VOCHER TABLE - ACCOUNT BOOK  
                       string strQueryInsertVoucher = "RECEIPT_ACCOUNT.SP_INS_VOUCHER_ACCOUNT";
                       using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                       {
                           cmdAddSubDetail.Transaction = tran;
                           cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                           cmdAddSubDetail.Parameters.Add("P_PID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                           cmdAddSubDetail.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = ObjEntityReceipt.RefNum;
                           cmdAddSubDetail.Parameters.Add("P_DATE", OracleDbType.Date).Value = ObjEntityReceipt.FromDate;
                           cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityReceipt.AccntNameId;
                           cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = ObjEntityReceipt.TotalAmnt;
                           cmdAddSubDetail.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = ObjEntityReceipt.Organisation_id;
                           cmdAddSubDetail.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = ObjEntityReceipt.Corporate_id;
                           cmdAddSubDetail.Parameters.Add("P_VOCHR", OracleDbType.Int32).Value = 0;
                           cmdAddSubDetail.Parameters.Add("P_DESC", OracleDbType.Varchar2).Value = ObjEntityReceipt.Description;
                           cmdAddSubDetail.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = ObjEntityReceipt.FinancialYrId;
                           cmdAddSubDetail.Parameters.Add("P_BANKSTS", OracleDbType.Int32).Value = 1;
                           cmdAddSubDetail.Parameters.Add("P_VOCHR_STS", OracleDbType.Int32).Value = 0;
                           cmdAddSubDetail.Parameters.Add("L_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                           cmdAddSubDetail.ExecuteNonQuery();
                           strReturn = cmdAddSubDetail.Parameters["L_OUT"].Value.ToString();
                           cmdAddSubDetail.Dispose();
                       }
                   }

                   if (ObjEntityReceiptLedger.Count > 0)
                   {
                       //receipt ledgers INSERT
                       foreach (clsEntity_Receipt_Account ObjEntityLedger_insertList in ObjEntityReceipLedger_Insert)
                       {
                           objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.RECEIPT_LEDGER);
                           objEntityCommon.CorporateID = ObjEntityReceipt.Corporate_id;
                           objEntityCommon.Organisation_Id = ObjEntityReceipt.Organisation_id;
                           string strGrpNextId = objDatatLayer.ReadNextNumberWebForUI(objEntityCommon);
                           ObjEntityLedger_insertList.ReceiptLedgrId = Convert.ToInt32(strGrpNextId);

                           string strQuerySubDetails = "RECEIPT_ACCOUNT.SP_INSERT_RECEIPT_LEDGER";
                           using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetails, con))
                           {
                               cmdAddSubDetail.Transaction = tran;
                               cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                               cmdAddSubDetail.Parameters.Add("R_RECPT_LD_ID", OracleDbType.Int32).Value = ObjEntityLedger_insertList.ReceiptLedgrId;
                               cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityLedger_insertList.LedgerId;
                               cmdAddSubDetail.Parameters.Add("R_RECEIPT_ID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                               cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = ObjEntityLedger_insertList.LedgerAmnt;
                               cmdAddSubDetail.Parameters.Add("R_LDGR_REMARKS", OracleDbType.Varchar2).Value = ObjEntityLedger_insertList.Remarks;
                               cmdAddSubDetail.ExecuteNonQuery();
                           }

                           //on confirm
                           if (ObjEntityReceipt.ConfirmStatus == 1)
                           {
                               //update ledger balance
                               string strQueryUpdateLedger = "RECEIPT_ACCOUNT.SP_UPDATE_LEDGER_MASTR";
                               using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryUpdateLedger, con))
                               {
                                   cmdAddSubDetail.Transaction = tran;
                                   cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                   cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityLedger_insertList.LedgerId;
                                   cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = ObjEntityLedger_insertList.LedgerAmnt;
                                   cmdAddSubDetail.ExecuteNonQuery();
                               }

                               //insert ledger details into voucher account
                               string strQueryInsertVoucher = "RECEIPT_ACCOUNT.SP_INS_VOUCHER_ACCOUNT";
                               using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                               {
                                   cmdAddSubDetail.Transaction = tran;
                                   cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                   cmdAddSubDetail.Parameters.Add("P_PID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                                   cmdAddSubDetail.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = ObjEntityReceipt.RefNum;
                                   cmdAddSubDetail.Parameters.Add("P_DATE", OracleDbType.Date).Value = ObjEntityReceipt.FromDate;
                                   cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityLedger_insertList.LedgerId;
                                   cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = ObjEntityLedger_insertList.LedgerAmnt;
                                   cmdAddSubDetail.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = ObjEntityReceipt.Organisation_id;
                                   cmdAddSubDetail.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = ObjEntityReceipt.Corporate_id;
                                   cmdAddSubDetail.Parameters.Add("P_VOCHR", OracleDbType.Int32).Value = 0;
                                   cmdAddSubDetail.Parameters.Add("P_DESC", OracleDbType.Varchar2).Value = ObjEntityLedger_insertList.Remarks;
                                   cmdAddSubDetail.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = ObjEntityReceipt.FinancialYrId;
                                   cmdAddSubDetail.Parameters.Add("P_BANKSTS", OracleDbType.Int32).Value = 0;
                                   cmdAddSubDetail.Parameters.Add("P_VOCHR_STS", OracleDbType.Int32).Value = 1;
                                   cmdAddSubDetail.Parameters.Add("L_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                   cmdAddSubDetail.ExecuteNonQuery();
                                   strReturnLdgr = cmdAddSubDetail.Parameters["L_OUT"].Value.ToString();
                                   cmdAddSubDetail.Dispose();
                               }

                               //insert into voucher details table
                               string strQueryInsertVoucherLdgr1 = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                               using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucherLdgr1, con))
                               {
                                   cmdAddSubDetail.Transaction = tran;
                                   cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                   cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityReceipt.AccntNameId;
                                   cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturnLdgr);
                                   cmdAddSubDetail.ExecuteNonQuery();
                               }

                               string strQueryInsertVoucherLdgr = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS  ";
                               using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucherLdgr, con))
                               {
                                   cmdAddSubDetail.Transaction = tran;
                                   cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                   cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityLedger_insertList.LedgerId;
                                   cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturn);
                                   cmdAddSubDetail.ExecuteNonQuery();
                               }

                               //opening balance settlement
                               if (ObjEntityReceipt.VoucherCategory == 1)
                               {
                                   if (ObjEntityLedger_insertList.PaidAmt > 0)
                                   {
                                       //update voucher table opening balance row
                                       string strQueryInsertVoucher1 = "RECEIPT_ACCOUNT.SP_UPDATE_VOUCHER_ACCOUNT";
                                       using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher1, con))
                                       {
                                           cmdAddSubDetail.Transaction = tran;
                                           cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                           cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityLedger_insertList.LedgerId;
                                           cmdAddSubDetail.Parameters.Add("P_VOUCHR_CAT", OracleDbType.Int32).Value = ObjEntityLedger_insertList.VoucherCategory;
                                           cmdAddSubDetail.Parameters.Add("R_OBPAID_AMT", OracleDbType.Decimal).Value = ObjEntityLedger_insertList.BalnceAmt;//balancamt
                                           cmdAddSubDetail.Parameters.Add("L_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                           cmdAddSubDetail.ExecuteNonQuery();
                                       }

                                       //insert opening balance settlement to voucher settelemnt table
                                       string strQueryInsertVoucherSettleDtls = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";  //Add settle amount details
                                       using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherSettleDtls, con))
                                       {
                                           cmdAddVoucher.Transaction = tran;
                                           cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                           cmdAddVoucher.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = strReturnLdgr;
                                           cmdAddVoucher.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = ObjEntityLedger_insertList.LedgerId;
                                           cmdAddVoucher.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = ObjEntityLedger_insertList.PaidAmt;//paid amt
                                           cmdAddVoucher.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 4;
                                           cmdAddVoucher.Parameters.Add("C_USRID", OracleDbType.Int32).Value = ObjEntityReceipt.User_Id;
                                           cmdAddVoucher.Parameters.Add("C_SALID", OracleDbType.Int32).Value = ObjEntityLedger_insertList.LedgerId;
                                           cmdAddVoucher.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                                           cmdAddVoucher.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = ObjEntityLedger_insertList.BalnceAmt;
                                           cmdAddVoucher.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = ObjEntityLedger_insertList.ReceiptLedgrId;
                                           cmdAddVoucher.ExecuteNonQuery();
                                       }
                                   }
                               }
                           }

                           //delete all values in cost centre table by receipt id
                           if (FLGSALE == 0)
                           {
                               FLGSALE = 1;
                               string strQueryChangeStatus = "RECEIPT_ACCOUNT.DETETE_RECEIPT_SALES";
                               using (OracleCommand cmdChangeStatus = new OracleCommand(strQueryChangeStatus, con))
                               {
                                   FLGSALE = 1;
                                   cmdChangeStatus.Transaction = tran;
                                   cmdChangeStatus.CommandType = CommandType.StoredProcedure;
                                   cmdChangeStatus.Parameters.Add("R_RECPT_ID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                                   cmdChangeStatus.Parameters.Add("USRID", OracleDbType.Int32).Value = ObjEntityReceipt.User_Id;
                                   cmdChangeStatus.ExecuteNonQuery();
                               }
                           }

                           //cost centre details
                           foreach (clsEntity_Receipt_Account ObjEntitycstcntr_insert in ObjEntityReceiptCostCenter_Insert)
                           {
                               if (ObjEntitycstcntr_insert.LedgerId == ObjEntityLedger_insertList.LedgerId && ObjEntitycstcntr_insert.LedgerRow == ObjEntityLedger_insertList.LedgerRow)
                               {
                                   string strQuerycstSubDetails = "RECEIPT_ACCOUNT.SP_INSERT_RECEIPT_COSTCNTR";
                                   using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerycstSubDetails, con))
                                   {
                                       cmdAddSubDetail.Transaction = tran;
                                       cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                       if (ObjEntitycstcntr_insert.CostCtrId != 0)
                                       {
                                           cmdAddSubDetail.Parameters.Add("R_COST_CNTR_ID", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.CostCtrId;
                                       }
                                       else
                                       {
                                           cmdAddSubDetail.Parameters.Add("R_COST_CNTR_ID", OracleDbType.Int32).Value = null;
                                       }
                                       cmdAddSubDetail.Parameters.Add("R_RECEIPT_ID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                                       cmdAddSubDetail.Parameters.Add("R_COSTCNTR_AMT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.CstCntrAmnt;
                                       cmdAddSubDetail.Parameters.Add("R_RECPT_LD_ID", OracleDbType.Int32).Value = ObjEntityLedger_insertList.ReceiptLedgrId;
                                       cmdAddSubDetail.Parameters.Add("R_STATUS", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.Status;
                                       if (ObjEntitycstcntr_insert.CostGrp1Id != 0)
                                       {
                                           cmdAddSubDetail.Parameters.Add("R_COST_GRP_ID_ONE", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.CostGrp1Id;
                                       }
                                       else
                                       {
                                           cmdAddSubDetail.Parameters.Add("R_COST_GRP_ID_ONE", OracleDbType.Int32).Value = null;
                                       }
                                       if (ObjEntitycstcntr_insert.CostGrp2Id != 0)
                                       {
                                           cmdAddSubDetail.Parameters.Add("R_COST_GRP_ID_TWO", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.CostGrp2Id;
                                       }
                                       else
                                       {
                                           cmdAddSubDetail.Parameters.Add("R_COST_GRP_ID_TWO", OracleDbType.Int32).Value = null;
                                       }
                                       if (ObjEntitycstcntr_insert.AccntNameId != 0)
                                       {
                                           cmdAddSubDetail.Parameters.Add("R_CREDITNOTE_LEDID", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.AccntNameId;
                                       }
                                       else
                                       {
                                           cmdAddSubDetail.Parameters.Add("R_CREDITNOTE_LEDID", OracleDbType.Int32).Value = null;
                                       }
                                       if (ObjEntitycstcntr_insert.BalanceAmount != 0)
                                       {
                                           cmdAddSubDetail.Parameters.Add("R_CREDITNOTE_BAL", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.BalanceAmount;
                                       }
                                       else
                                       {
                                           cmdAddSubDetail.Parameters.Add("R_CREDITNOTE_BAL", OracleDbType.Decimal).Value = null;
                                       }
                                       if (ObjEntitycstcntr_insert.LedgerAmnt != 0)
                                       {
                                           cmdAddSubDetail.Parameters.Add("R_CREDITNOTE_SETLAMNT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.LedgerAmnt;
                                       }
                                       else
                                       {
                                           cmdAddSubDetail.Parameters.Add("R_CREDITNOTE_SETLAMNT", OracleDbType.Decimal).Value = null;
                                       }
                                       cmdAddSubDetail.Parameters.Add("OB_PAIDAMT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.PaidAmt;
                                       cmdAddSubDetail.Parameters.Add("OB_BALAMT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.BalnceAmt;

                                       cmdAddSubDetail.ExecuteNonQuery();
                                   }

                                   //on confirm
                                   if (ObjEntityReceipt.ConfirmStatus == 1)
                                   {
                                       string strQuerySubSalesUpdate = "RECEIPT_ACCOUNT.SP_UPDATE_SAL_OR_COSTCNTR";
                                       using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubSalesUpdate, con))
                                       {
                                           cmdAddSubDetail.Transaction = tran;
                                           cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                           cmdAddSubDetail.Parameters.Add("R_COST_CNTR_ID", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.CostCtrId;
                                           cmdAddSubDetail.Parameters.Add("R_COSTCNTR_AMT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.CstCntrAmnt;
                                           cmdAddSubDetail.Parameters.Add("R_STATUS", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.Status;
                                           cmdAddSubDetail.Parameters.Add("R_AC_LD_ID", OracleDbType.Int32).Value = ObjEntityReceipt.AccntNameId;
                                           cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityLedger_insertList.LedgerId;
                                           cmdAddSubDetail.Parameters.Add("R_CREDITNOTE_LEDID", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.AccntNameId;
                                           cmdAddSubDetail.Parameters.Add("R_CREDITNOTE_SETLAMNT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.LedgerAmnt;
                                           cmdAddSubDetail.ExecuteNonQuery();
                                       }

                                       if (ObjEntitycstcntr_insert.Status == 0)
                                       {
                                           //insert to cost centre voucher table
                                           string strQueryInsertVoucher = "FMS_COMMON.SP_INS_CSTCNTR_VOUCHER_ACCOUNT";
                                           using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                                           {
                                               cmdAddSubDetail.Transaction = tran;
                                               cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                               cmdAddSubDetail.Parameters.Add("P_PID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                                               cmdAddSubDetail.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = ObjEntityReceipt.RefNum;
                                               cmdAddSubDetail.Parameters.Add("P_DATE", OracleDbType.Date).Value = ObjEntityReceipt.FromDate;
                                               cmdAddSubDetail.Parameters.Add("P_LD_ID", OracleDbType.Int32).Value = ObjEntityLedger_insertList.LedgerId;
                                               cmdAddSubDetail.Parameters.Add("P_COST_CNTR_ID", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.CostCtrId;
                                               if (ObjEntitycstcntr_insert.CostGrp1Id != 0)
                                               {
                                                   cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_ONE", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.CostGrp1Id;
                                               }
                                               else
                                               {
                                                   cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_ONE", OracleDbType.Int32).Value = null;
                                               }
                                               if (ObjEntitycstcntr_insert.CostGrp2Id != 0)
                                               {
                                                   cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_TWO", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.CostGrp2Id;
                                               }
                                               else
                                               {
                                                   cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_TWO", OracleDbType.Int32).Value = null;
                                               }
                                               cmdAddSubDetail.Parameters.Add("P_LDGR_AMT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.CstCntrAmnt;
                                               cmdAddSubDetail.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = ObjEntityReceipt.Organisation_id;
                                               cmdAddSubDetail.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = ObjEntityReceipt.Corporate_id;
                                               cmdAddSubDetail.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = ObjEntityReceipt.FinancialYrId;
                                               cmdAddSubDetail.Parameters.Add("P_VOCHR_STS", OracleDbType.Int32).Value = 1;
                                               cmdAddSubDetail.Parameters.Add("P_CRNC_MST_ID", OracleDbType.Int32).Value = ObjEntityReceipt.CurrcyId;
                                               cmdAddSubDetail.Parameters.Add("P_VOCHR_TYPE", OracleDbType.Int32).Value = 0;
                                               cmdAddSubDetail.Parameters.Add("P_VOCHR_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturn);
                                               cmdAddSubDetail.ExecuteNonQuery();
                                               cmdAddSubDetail.Dispose();
                                           }
                                       }
                                       else
                                       {
                                           string strQueryInsertVoucher = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";
                                           //insert sale settlemnt to voucher settlement table
                                           if (ObjEntitycstcntr_insert.CostCtrId != 0 && ObjEntitycstcntr_insert.CstCntrAmnt != 0)
                                           {
                                               using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                                               {
                                                   if (ObjEntitycstcntr_insert.CostCtrId != 0 && ObjEntitycstcntr_insert.CstCntrAmnt != 0 && ObjEntitycstcntr_insert.AccntNameId == 0)
                                                   {
                                                       cmdAddSubDetail.Transaction = tran;
                                                       cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                       cmdAddSubDetail.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = strReturnLdgr;
                                                       cmdAddSubDetail.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = ObjEntityLedger_insertList.LedgerId;
                                                       cmdAddSubDetail.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.CstCntrAmnt;
                                                       cmdAddSubDetail.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 0;
                                                       cmdAddSubDetail.Parameters.Add("C_USRID", OracleDbType.Int32).Value = ObjEntityReceipt.User_Id;
                                                       cmdAddSubDetail.Parameters.Add("C_SALID", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.CostCtrId;
                                                       cmdAddSubDetail.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                                                       cmdAddSubDetail.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.SettlmntAmmnt;
                                                       cmdAddSubDetail.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = ObjEntityLedger_insertList.ReceiptLedgrId;
                                                       cmdAddSubDetail.ExecuteNonQuery();
                                                       cmdAddSubDetail.Dispose();
                                                   }
                                               }
                                           }
                                           //insert debit note settlemnt to voucher settlement table
                                           if (ObjEntitycstcntr_insert.AccntNameId != 0 && ObjEntitycstcntr_insert.LedgerAmnt != 0)
                                           {
                                               using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                                               {
                                                   cmdAddSubDetail.Transaction = tran;
                                                   cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                   cmdAddSubDetail.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = strReturnLdgr;
                                                   cmdAddSubDetail.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = ObjEntityLedger_insertList.LedgerId;
                                                   cmdAddSubDetail.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.LedgerAmnt;
                                                   cmdAddSubDetail.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 3;
                                                   cmdAddSubDetail.Parameters.Add("C_USRID", OracleDbType.Int32).Value = ObjEntityReceipt.User_Id;
                                                   cmdAddSubDetail.Parameters.Add("C_SALID", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.CostCtrId;
                                                   cmdAddSubDetail.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                                                   cmdAddSubDetail.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.BalanceAmount;
                                                   cmdAddSubDetail.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = ObjEntityLedger_insertList.ReceiptLedgrId;
                                                   cmdAddSubDetail.ExecuteNonQuery();
                                                   cmdAddSubDetail.Dispose();
                                               }
                                           }


                                       }

                                   }

                               }

                           }
                       }

                       //receipt ledgers UPDATE
                       foreach (clsEntity_Receipt_Account ObjEntityRcptupdate in ObjEntityReceiptLedger_Update)
                       {
                           string strQuerySubDetails = "RECEIPT_ACCOUNT.SP_UPDATE_RECEIPT_LEDGER";
                           using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetails, con))
                           {
                               cmdAddSubDetail.Transaction = tran;
                               cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                               cmdAddSubDetail.Parameters.Add("R_RECPT_ID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                               cmdAddSubDetail.Parameters.Add("R_RECPT_LD_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.ReceiptLedgrId;
                               cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;
                               cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = ObjEntityRcptupdate.LedgerAmnt;
                               cmdAddSubDetail.Parameters.Add("R_LDGR_REMARKS", OracleDbType.Varchar2).Value = ObjEntityRcptupdate.Remarks;
                               cmdAddSubDetail.ExecuteNonQuery();
                           }

                           //on confirm
                           if (ObjEntityReceipt.ConfirmStatus == 1)
                           {
                               //update ledger balance
                               string strQueryUpdateLedger = "RECEIPT_ACCOUNT.SP_UPDATE_LEDGER_MASTR";
                               using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryUpdateLedger, con))
                               {
                                   cmdAddSubDetail.Transaction = tran;
                                   cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                   cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;
                                   cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = ObjEntityRcptupdate.LedgerAmnt;
                                   cmdAddSubDetail.ExecuteNonQuery();
                               }
                               //insert ledger details to voucher table
                               string strQueryInsertVoucher = "RECEIPT_ACCOUNT.SP_INS_VOUCHER_ACCOUNT";
                               using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                               {
                                   cmdAddSubDetail.Transaction = tran;
                                   cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                   cmdAddSubDetail.Parameters.Add("P_PID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                                   cmdAddSubDetail.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = ObjEntityReceipt.RefNum;
                                   cmdAddSubDetail.Parameters.Add("P_DATE", OracleDbType.Date).Value = ObjEntityReceipt.FromDate;
                                   cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;
                                   cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = ObjEntityRcptupdate.LedgerAmnt;
                                   cmdAddSubDetail.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = ObjEntityReceipt.Organisation_id;
                                   cmdAddSubDetail.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = ObjEntityReceipt.Corporate_id;
                                   cmdAddSubDetail.Parameters.Add("P_VOCHR", OracleDbType.Int32).Value = 0;
                                   cmdAddSubDetail.Parameters.Add("P_DESC", OracleDbType.Varchar2).Value = ObjEntityRcptupdate.Remarks;
                                   cmdAddSubDetail.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = ObjEntityReceipt.FinancialYrId;
                                   cmdAddSubDetail.Parameters.Add("P_BANKSTS", OracleDbType.Int32).Value = 0;
                                   cmdAddSubDetail.Parameters.Add("P_VOCHR_STS", OracleDbType.Int32).Value = 1;
                                   cmdAddSubDetail.Parameters.Add("L_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                   cmdAddSubDetail.ExecuteNonQuery();
                                   strReturnLdgr = cmdAddSubDetail.Parameters["L_OUT"].Value.ToString();
                                   cmdAddSubDetail.Dispose();
                               }

                               //insert into voucher details table
                               string strQueryInsertVoucherLdgr1 = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                               using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucherLdgr1, con))
                               {
                                   cmdAddSubDetail.Transaction = tran;
                                   cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                   cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityReceipt.AccntNameId;
                                   cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturnLdgr);
                                   cmdAddSubDetail.ExecuteNonQuery();
                               }

                               string strQueryInsertVoucherLdgr = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                               using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucherLdgr, con))
                               {
                                   cmdAddSubDetail.Transaction = tran;
                                   cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                   cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;
                                   cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturn);
                                   cmdAddSubDetail.ExecuteNonQuery();
                               }

                               //opening balance settlement
                               if (ObjEntityReceipt.VoucherCategory == 1)
                               {
                                   if (ObjEntityRcptupdate.PaidAmt > 0)
                                   {
                                       //update voucher table opening balance row
                                       string strQueryInsertVoucher1 = "RECEIPT_ACCOUNT.SP_UPDATE_VOUCHER_ACCOUNT";
                                       using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher1, con))
                                       {
                                           cmdAddSubDetail.Transaction = tran;
                                           cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                           cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;
                                           cmdAddSubDetail.Parameters.Add("P_VOUCHR_CAT", OracleDbType.Int32).Value = ObjEntityReceipt.VoucherCategory;
                                           cmdAddSubDetail.Parameters.Add("R_OBPAID_AMT", OracleDbType.Decimal).Value = ObjEntityRcptupdate.BalnceAmt;//balancamt
                                           cmdAddSubDetail.Parameters.Add("L_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                           cmdAddSubDetail.ExecuteNonQuery();
                                       }
                                       //insert opening balance settlement into voucher table
                                       if (ObjEntityRcptupdate.PaidAmt > 0)
                                       {
                                           string strQueryInsertVoucherSettleDtls = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";  //Add settle amount details
                                           using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherSettleDtls, con))
                                           {
                                               cmdAddVoucher.Transaction = tran;
                                               cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                               cmdAddVoucher.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = strReturnLdgr;
                                               cmdAddVoucher.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;
                                               cmdAddVoucher.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = ObjEntityRcptupdate.PaidAmt;//paid amt
                                               cmdAddVoucher.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 4;
                                               cmdAddVoucher.Parameters.Add("C_USRID", OracleDbType.Int32).Value = ObjEntityReceipt.User_Id;
                                               cmdAddVoucher.Parameters.Add("C_SALID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;
                                               cmdAddVoucher.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                                               cmdAddVoucher.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = ObjEntityRcptupdate.BalnceAmt;
                                               cmdAddVoucher.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = ObjEntityRcptupdate.ReceiptLedgrId;
                                               cmdAddVoucher.ExecuteNonQuery();
                                           }
                                       }
                                   }
                               }
                           }

                           if (ObjEntityReceiptCostCenter_Insert.Count > 0 || ObjEntityReceiptCostCenter_update.Count == 0)
                           {
                               //delete all values in cost centre table by receipt id
                               if (FLGSALE == 0)
                               {
                                   FLGSALE = 1;
                                   string strQueryChangeStatus = "RECEIPT_ACCOUNT.DETETE_RECEIPT_SALES";
                                   using (OracleCommand cmdChangeStatus = new OracleCommand(strQueryChangeStatus, con))
                                   {
                                       cmdChangeStatus.Transaction = tran;
                                       cmdChangeStatus.CommandType = CommandType.StoredProcedure;
                                       cmdChangeStatus.Parameters.Add("R_RECPT_ID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                                       cmdChangeStatus.Parameters.Add("USRID", OracleDbType.Int32).Value = ObjEntityReceipt.User_Id;
                                       cmdChangeStatus.ExecuteNonQuery();
                                   }
                               }
                           }

                           //insert cost centre details
                           foreach (clsEntity_Receipt_Account ObjEntitycstcntr_insert in ObjEntityReceiptCostCenter_Insert)
                           {
                               if (ObjEntitycstcntr_insert.LedgerId == ObjEntityRcptupdate.LedgerId && ObjEntitycstcntr_insert.LedgerRow == ObjEntityRcptupdate.LedgerRow)
                               {
                                   string strQuerySubDetailscstins = "RECEIPT_ACCOUNT.SP_INSERT_RECEIPT_COSTCNTR";
                                   using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailscstins, con))
                                   {
                                       cmdAddSubDetail.Transaction = tran;
                                       cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                       if (ObjEntitycstcntr_insert.CostCtrId > 0)
                                       {
                                           cmdAddSubDetail.Parameters.Add("R_COST_CNTR_ID", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.CostCtrId;
                                       }
                                       else
                                       {
                                           cmdAddSubDetail.Parameters.Add("R_COST_CNTR_ID", OracleDbType.Int32).Value = null;
                                       }
                                       cmdAddSubDetail.Parameters.Add("R_RECEIPT_ID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                                       cmdAddSubDetail.Parameters.Add("R_COSTCNTR_AMT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.CstCntrAmnt;
                                       cmdAddSubDetail.Parameters.Add("R_RECPT_LD_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.ReceiptLedgrId;
                                       cmdAddSubDetail.Parameters.Add("R_STATUS", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.Status;
                                       if (ObjEntitycstcntr_insert.CostGrp1Id != 0)
                                       {
                                           cmdAddSubDetail.Parameters.Add("R_COST_GRP_ID_ONE", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.CostGrp1Id;
                                       }
                                       else
                                       {
                                           cmdAddSubDetail.Parameters.Add("R_COST_GRP_ID_ONE", OracleDbType.Int32).Value = null;
                                       }
                                       if (ObjEntitycstcntr_insert.CostGrp2Id != 0)
                                       {
                                           cmdAddSubDetail.Parameters.Add("R_COST_GRP_ID_TWO", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.CostGrp2Id;
                                       }
                                       else
                                       {
                                           cmdAddSubDetail.Parameters.Add("R_COST_GRP_ID_TWO", OracleDbType.Int32).Value = null;
                                       }
                                       if (ObjEntitycstcntr_insert.AccntNameId != 0)
                                       {
                                           cmdAddSubDetail.Parameters.Add("R_CREDITNOTE_LEDID", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.AccntNameId;
                                       }
                                       else
                                       {
                                           cmdAddSubDetail.Parameters.Add("R_CREDITNOTE_LEDID", OracleDbType.Int32).Value = null;
                                       }
                                       if (ObjEntitycstcntr_insert.BalanceAmount != 0)
                                       {
                                           cmdAddSubDetail.Parameters.Add("R_CREDITNOTE_BAL", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.BalanceAmount;
                                       }
                                       else
                                       {
                                           cmdAddSubDetail.Parameters.Add("R_CREDITNOTE_BAL", OracleDbType.Decimal).Value = null;
                                       }
                                       if (ObjEntitycstcntr_insert.LedgerAmnt != 0)
                                       {
                                           cmdAddSubDetail.Parameters.Add("R_CREDITNOTE_SETLAMNT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.LedgerAmnt;
                                       }
                                       else
                                       {
                                           cmdAddSubDetail.Parameters.Add("R_CREDITNOTE_SETLAMNT", OracleDbType.Decimal).Value = null;
                                       }
                                       cmdAddSubDetail.Parameters.Add("OB_PAIDAMT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.PaidAmt;
                                       cmdAddSubDetail.Parameters.Add("OB_BALAMT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.BalnceAmt;

                                       cmdAddSubDetail.ExecuteNonQuery();
                                   }

                                   //on confirm
                                   if (ObjEntityReceipt.ConfirmStatus == 1)
                                   {
                                       string strQuerySubSalesUpdate = "RECEIPT_ACCOUNT.SP_UPDATE_SAL_OR_COSTCNTR";
                                       using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubSalesUpdate, con))
                                       {
                                           cmdAddSubDetail.Transaction = tran;
                                           cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                           cmdAddSubDetail.Parameters.Add("R_COST_CNTR_ID", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.CostCtrId;
                                           cmdAddSubDetail.Parameters.Add("R_COSTCNTR_AMT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.CstCntrAmnt;
                                           cmdAddSubDetail.Parameters.Add("R_STATUS", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.Status;
                                           cmdAddSubDetail.Parameters.Add("R_AC_LD_ID", OracleDbType.Int32).Value = ObjEntityReceipt.AccntNameId;
                                           cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;
                                           cmdAddSubDetail.Parameters.Add("R_CREDITNOTE_LEDID", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.AccntNameId;
                                           cmdAddSubDetail.Parameters.Add("R_CREDITNOTE_SETLAMNT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.LedgerAmnt;
                                           cmdAddSubDetail.ExecuteNonQuery();
                                       }

                                       if (ObjEntitycstcntr_insert.Status == 0)
                                       {
                                           //insert into cost centre voucher table
                                           string strQueryInsertVoucher = "FMS_COMMON.SP_INS_CSTCNTR_VOUCHER_ACCOUNT";
                                           using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                                           {
                                               cmdAddSubDetail.Transaction = tran;
                                               cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                               cmdAddSubDetail.Parameters.Add("P_PID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                                               cmdAddSubDetail.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = ObjEntityReceipt.RefNum;
                                               cmdAddSubDetail.Parameters.Add("P_DATE", OracleDbType.Date).Value = ObjEntityReceipt.FromDate;
                                               cmdAddSubDetail.Parameters.Add("P_LD_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;
                                               cmdAddSubDetail.Parameters.Add("P_COST_CNTR_ID", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.CostCtrId;
                                               if (ObjEntitycstcntr_insert.CostGrp1Id != 0)
                                               {
                                                   cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_ONE", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.CostGrp1Id;
                                               }
                                               else
                                               {
                                                   cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_ONE", OracleDbType.Int32).Value = null;
                                               }
                                               if (ObjEntitycstcntr_insert.CostGrp2Id != 0)
                                               {
                                                   cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_TWO", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.CostGrp2Id;
                                               }
                                               else
                                               {
                                                   cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_TWO", OracleDbType.Int32).Value = null;
                                               }
                                               cmdAddSubDetail.Parameters.Add("P_LDGR_AMT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.CstCntrAmnt;
                                               cmdAddSubDetail.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = ObjEntityReceipt.Organisation_id;
                                               cmdAddSubDetail.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = ObjEntityReceipt.Corporate_id;
                                               cmdAddSubDetail.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = ObjEntityReceipt.FinancialYrId;
                                               cmdAddSubDetail.Parameters.Add("P_VOCHR_STS", OracleDbType.Int32).Value = 1;
                                               cmdAddSubDetail.Parameters.Add("P_CRNC_MST_ID", OracleDbType.Int32).Value = ObjEntityReceipt.CurrcyId;
                                               cmdAddSubDetail.Parameters.Add("P_VOCHR_TYPE", OracleDbType.Int32).Value = 0;
                                               cmdAddSubDetail.Parameters.Add("P_VOCHR_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturn);
                                               cmdAddSubDetail.ExecuteNonQuery();
                                           }
                                       }
                                       else
                                       {
                                           string strQueryInsertVoucher = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";
                                           //insert sale settlement into voucher settelemnt table
                                           if (ObjEntitycstcntr_insert.CostCtrId != 0 && ObjEntitycstcntr_insert.CstCntrAmnt != 0 && ObjEntitycstcntr_insert.AccntNameId == 0)
                                           {
                                               using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                                               {
                                                   cmdAddSubDetail.Transaction = tran;
                                                   cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                   cmdAddSubDetail.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = strReturnLdgr;
                                                   cmdAddSubDetail.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;
                                                   cmdAddSubDetail.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.CstCntrAmnt;
                                                   cmdAddSubDetail.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 0;
                                                   cmdAddSubDetail.Parameters.Add("C_USRID", OracleDbType.Int32).Value = ObjEntityReceipt.User_Id;
                                                   cmdAddSubDetail.Parameters.Add("C_SALID", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.CostCtrId;
                                                   cmdAddSubDetail.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                                                   cmdAddSubDetail.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.SettlmntAmmnt;
                                                   cmdAddSubDetail.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = ObjEntityRcptupdate.ReceiptLedgrId;
                                                   cmdAddSubDetail.ExecuteNonQuery();
                                                   cmdAddSubDetail.Dispose();
                                               }
                                           }
                                           //insert debit note settlement into voucher settelemnt table
                                           if (ObjEntitycstcntr_insert.AccntNameId != 0 && ObjEntitycstcntr_insert.LedgerAmnt != 0)
                                           {
                                               using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                                               {
                                                   cmdAddSubDetail.Transaction = tran;
                                                   cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                   cmdAddSubDetail.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = strReturnLdgr;
                                                   cmdAddSubDetail.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;
                                                   cmdAddSubDetail.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.LedgerAmnt;
                                                   cmdAddSubDetail.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 3;
                                                   cmdAddSubDetail.Parameters.Add("C_USRID", OracleDbType.Int32).Value = ObjEntityReceipt.User_Id;
                                                   cmdAddSubDetail.Parameters.Add("C_SALID", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.CostCtrId;
                                                   cmdAddSubDetail.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                                                   cmdAddSubDetail.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.BalanceAmount;
                                                   cmdAddSubDetail.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = ObjEntityRcptupdate.ReceiptLedgrId;
                                                   cmdAddSubDetail.ExecuteNonQuery();
                                                   cmdAddSubDetail.Dispose();
                                               }
                                           }
                                       }
                                   }

                               }
                           }

                           //update cost centre details
                           foreach (clsEntity_Receipt_Account ObjEntityRcptCstCntr in ObjEntityReceiptCostCenter_update)
                           {
                               if (ObjEntityRcptCstCntr.LedgerId == ObjEntityRcptupdate.LedgerId && ObjEntityRcptCstCntr.LedgerRow == ObjEntityRcptupdate.LedgerRow)
                               {
                                   string strQuerySubDetailsupd = "RECEIPT_ACCOUNT.SP_UPDATE_RECEIPT_COSTCNTR";
                                   using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsupd, con))
                                   {
                                       cmdAddSubDetail.Transaction = tran;
                                       cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                       cmdAddSubDetail.Parameters.Add("R_RECPT_ID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                                       cmdAddSubDetail.Parameters.Add("R_RCPT_CST_CNTR_ID", OracleDbType.Int32).Value = ObjEntityRcptCstCntr.ReceiptCstCntrId;
                                       cmdAddSubDetail.Parameters.Add("R_COST_CNTR_ID", OracleDbType.Int32).Value = ObjEntityRcptCstCntr.CostCtrId;
                                       cmdAddSubDetail.Parameters.Add("R_COSTCNTR_AMT", OracleDbType.Decimal).Value = ObjEntityRcptCstCntr.CstCntrAmnt;
                                       cmdAddSubDetail.Parameters.Add("R_STATUS", OracleDbType.Int32).Value = ObjEntityRcptCstCntr.Status;
                                       if (ObjEntityRcptCstCntr.CostGrp1Id != 0)
                                       {
                                           cmdAddSubDetail.Parameters.Add("R_COST_GRP_ID_ONE", OracleDbType.Int32).Value = ObjEntityRcptCstCntr.CostGrp1Id;
                                       }
                                       else
                                       {
                                           cmdAddSubDetail.Parameters.Add("R_COST_GRP_ID_ONE", OracleDbType.Int32).Value = null;
                                       }
                                       if (ObjEntityRcptCstCntr.CostGrp2Id != 0)
                                       {
                                           cmdAddSubDetail.Parameters.Add("R_COST_GRP_ID_TWO", OracleDbType.Int32).Value = ObjEntityRcptCstCntr.CostGrp2Id;
                                       }
                                       else
                                       {
                                           cmdAddSubDetail.Parameters.Add("R_COST_GRP_ID_TWO", OracleDbType.Int32).Value = null;
                                       }
                                       cmdAddSubDetail.ExecuteNonQuery();
                                   }

                                   //on confirm
                                   if (ObjEntityReceipt.ConfirmStatus == 1)
                                   {
                                       string strQuerySubSalesUpdate = "RECEIPT_ACCOUNT.SP_UPDATE_SAL_OR_COSTCNTR";
                                       using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubSalesUpdate, con))
                                       {
                                           cmdAddSubDetail.Transaction = tran;
                                           cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                           cmdAddSubDetail.Parameters.Add("R_COST_CNTR_ID", OracleDbType.Int32).Value = ObjEntityRcptCstCntr.CostCtrId;
                                           cmdAddSubDetail.Parameters.Add("R_COSTCNTR_AMT", OracleDbType.Decimal).Value = ObjEntityRcptCstCntr.CstCntrAmnt;
                                           cmdAddSubDetail.Parameters.Add("R_STATUS", OracleDbType.Int32).Value = ObjEntityRcptCstCntr.Status;
                                           cmdAddSubDetail.Parameters.Add("R_AC_LD_ID", OracleDbType.Int32).Value = ObjEntityReceipt.AccntNameId;
                                           cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;
                                           cmdAddSubDetail.Parameters.Add("R_CREDITNOTE_LEDID", OracleDbType.Int32).Value = 0;
                                           cmdAddSubDetail.Parameters.Add("R_CREDITNOTE_SETLAMNT", OracleDbType.Decimal).Value = 0;
                                           cmdAddSubDetail.ExecuteNonQuery();
                                       }

                                       if (ObjEntityRcptCstCntr.Status == 0)
                                       {
                                           //insert into cost centre voucher table
                                           string strQueryInsertVoucher = "FMS_COMMON.SP_INS_CSTCNTR_VOUCHER_ACCOUNT";
                                           using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                                           {
                                               cmdAddSubDetail.Transaction = tran;
                                               cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                               cmdAddSubDetail.Parameters.Add("P_PID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                                               cmdAddSubDetail.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = ObjEntityReceipt.RefNum;
                                               cmdAddSubDetail.Parameters.Add("P_DATE", OracleDbType.Date).Value = ObjEntityReceipt.FromDate;
                                               cmdAddSubDetail.Parameters.Add("P_LD_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;
                                               cmdAddSubDetail.Parameters.Add("P_COST_CNTR_ID", OracleDbType.Int32).Value = ObjEntityRcptCstCntr.CostCtrId;
                                               if (ObjEntityRcptupdate.CostGrp1Id != 0)
                                               {
                                                   cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_ONE", OracleDbType.Int32).Value = ObjEntityRcptCstCntr.CostGrp1Id;
                                               }
                                               else
                                               {
                                                   cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_ONE", OracleDbType.Int32).Value = null;
                                               }
                                               if (ObjEntityRcptupdate.CostGrp2Id != 0)
                                               {
                                                   cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_TWO", OracleDbType.Int32).Value = ObjEntityRcptCstCntr.CostGrp2Id;
                                               }
                                               else
                                               {
                                                   cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_TWO", OracleDbType.Int32).Value = null;
                                               }
                                               cmdAddSubDetail.Parameters.Add("P_LDGR_AMT", OracleDbType.Decimal).Value = ObjEntityRcptCstCntr.CstCntrAmnt;
                                               cmdAddSubDetail.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = ObjEntityReceipt.Organisation_id;
                                               cmdAddSubDetail.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = ObjEntityReceipt.Corporate_id;
                                               cmdAddSubDetail.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = ObjEntityReceipt.FinancialYrId;
                                               cmdAddSubDetail.Parameters.Add("P_VOCHR_STS", OracleDbType.Int32).Value = 1;
                                               cmdAddSubDetail.Parameters.Add("P_CRNC_MST_ID", OracleDbType.Int32).Value = ObjEntityReceipt.CurrcyId;
                                               cmdAddSubDetail.Parameters.Add("P_VOCHR_TYPE", OracleDbType.Int32).Value = 0;
                                               cmdAddSubDetail.Parameters.Add("P_VOCHR_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturn);
                                               cmdAddSubDetail.ExecuteNonQuery();
                                               cmdAddSubDetail.Dispose();
                                           }
                                       }
                                       else
                                       {
                                           string strQueryInsertVoucher = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";
                                           //insert sale settlement into voucher settelemnt table
                                           if (ObjEntityRcptupdate.CostCtrId != 0 && ObjEntityRcptupdate.CstCntrAmnt != 0 && ObjEntityRcptupdate.AccntNameId == 0)
                                           {
                                               using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                                               {
                                                   cmdAddSubDetail.Transaction = tran;
                                                   cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                   cmdAddSubDetail.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = strReturnLdgr;
                                                   cmdAddSubDetail.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;
                                                   cmdAddSubDetail.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = ObjEntityRcptupdate.CstCntrAmnt;
                                                   cmdAddSubDetail.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 0;
                                                   cmdAddSubDetail.Parameters.Add("C_USRID", OracleDbType.Int32).Value = ObjEntityReceipt.User_Id;
                                                   cmdAddSubDetail.Parameters.Add("C_SALID", OracleDbType.Int32).Value = ObjEntityRcptupdate.CostCtrId;
                                                   cmdAddSubDetail.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                                                   cmdAddSubDetail.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = ObjEntityRcptupdate.SettlmntAmmnt;
                                                   cmdAddSubDetail.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = ObjEntityRcptupdate.ReceiptLedgrId;
                                                   cmdAddSubDetail.ExecuteNonQuery();
                                                   cmdAddSubDetail.Dispose();
                                               }
                                           }
                                           //insert debit note settlement into voucher settelemnt table
                                           if (ObjEntityRcptupdate.AccntNameId != 0 && ObjEntityRcptupdate.LedgerAmnt != 0)
                                           {
                                               using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                                               {
                                                   cmdAddSubDetail.Transaction = tran;
                                                   cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                   cmdAddSubDetail.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = strReturnLdgr;
                                                   cmdAddSubDetail.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;
                                                   cmdAddSubDetail.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = ObjEntityRcptupdate.LedgerAmnt;
                                                   cmdAddSubDetail.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 3;
                                                   cmdAddSubDetail.Parameters.Add("C_USRID", OracleDbType.Int32).Value = ObjEntityReceipt.User_Id;
                                                   cmdAddSubDetail.Parameters.Add("C_SALID", OracleDbType.Int32).Value = ObjEntityRcptupdate.CostCtrId;
                                                   cmdAddSubDetail.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                                                   cmdAddSubDetail.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = ObjEntityRcptupdate.BalanceAmount;
                                                   cmdAddSubDetail.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = ObjEntityRcptupdate.ReceiptLedgrId;
                                                   cmdAddSubDetail.ExecuteNonQuery();
                                                   cmdAddSubDetail.Dispose();
                                               }
                                           }

                                       }
                                   }
                               }
                           }
                       }


                       //delete receipt ledgers
                       foreach (clsEntity_Receipt_Account objSubDetail in ObjEntityReceiptLedger_Delete)
                       {
                           {
                               string strQueryChangeStatus = "RECEIPT_ACCOUNT.DETETE_RECEIPT_LEDGER";
                               using (OracleCommand cmdChangeStatus = new OracleCommand())
                               {
                                   cmdChangeStatus.CommandText = strQueryChangeStatus;
                                   cmdChangeStatus.CommandType = CommandType.StoredProcedure;
                                   cmdChangeStatus.Parameters.Add("R_RECPT_ID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                                   cmdChangeStatus.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objSubDetail.ReceiptLedgrId;
                                   cmdChangeStatus.Parameters.Add("USRID", OracleDbType.Int32).Value = ObjEntityReceipt.User_Id;
                                   clsDataLayer.ExecuteNonQuery(cmdChangeStatus);
                               }
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

       public void ConfirmReceiptDtls(clsEntity_Receipt_Account ObjEntityReceipt, List<clsEntity_Receipt_Account> ObjEntityReceiptLedger, List<clsEntity_Receipt_Account> ObjEntityReceiptCostCenter, List<clsEntity_Receipt_Account> ObjEntityReceipLedger_Insert, List<clsEntity_Receipt_Account> ObjEntityReceiptLedger_Update, List<clsEntity_Receipt_Account> ObjEntityReceiptCostCenter_Insert, List<clsEntity_Receipt_Account> ObjEntityReceiptCostCenter_update, List<clsEntity_Receipt_Account> objEntityUpdateOB)
       {
           clsDataLayer objDatatLayer = new clsDataLayer();
           string strQueryLeaveTyp = "RECEIPT_ACCOUNT.SP_CONFIRM_RECEIPT";
           OracleTransaction tran;
           //insert to main register table
           clsEntityCommon objEntityCommon = new clsEntityCommon();
           using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
           {
               con.Open();
               tran = con.BeginTransaction();

               try
               {
                   int SubRef = 1;
                   int FLGSALE = 0;
                   string strReturn = "";
                   string strReturnLdgr = "";


                   clsCommonLibrary objCommon = new clsCommonLibrary();

                   objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.RECEIPT);
                   objEntityCommon.CorporateID = ObjEntityReceipt.Corporate_id;
                   objEntityCommon.Organisation_Id = ObjEntityReceipt.Organisation_id;
                   //  string strNextId = objDatatLayer.ReadNextNumberSequanceForUI(objEntityCommon);
                   //  string strNextId = objDatatLayer.ReadNextNumberWebForUI(objEntityCommon);

                   int intCorpId = ObjEntityReceipt.Corporate_id;
                   int intOrgId = ObjEntityReceipt.Organisation_id;
                   int intusrId = ObjEntityReceipt.User_Id;

                   //   objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Receipt);
                   DataTable dtFormate = readRefFormate(objEntityCommon);
                   int intUsrRolMstrId = 0;
                   string strRefAccountCls = "0";

                   intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Receipt);
                   clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.REFNUM_ACCNTCLS_STS
                                                              };
                   DataTable dtCorpDetail = new DataTable();
                   string strColumns = "";
                   for (int intcount = 0; intcount < arrEnumer.Length; intcount++)
                   {
                       if (intcount == 0)
                       {
                           strColumns = arrEnumer[intcount].ToString();
                       }
                       else
                       {
                           strColumns = strColumns + "," + arrEnumer[intcount].ToString();
                       }
                   }
                   dtCorpDetail = objDatatLayer.LoadGlobalDetail(strColumns, intCorpId);
                   if (dtCorpDetail.Rows.Count > 0)
                   {
                       strRefAccountCls = dtCorpDetail.Rows[0]["REFNUM_ACCNTCLS_STS"].ToString();
                   }


                   clsDataLayerDateAndTime objDataLayerDateTime = new clsDataLayerDateAndTime();
                   string CurrentDate = objDataLayerDateTime.DateAndTime().ToString("dd-MM-yyyy");
                   DateTime dtCurrentDate = objCommon.textToDateTime(CurrentDate);
                   int DtYear = dtCurrentDate.Year;
                   int DtMonth = dtCurrentDate.Month;


                   //CHECKING SUB REF NUMBER
                   string Ref = "";
                   if (strRefAccountCls == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                   {


                       clsDataLayer_Account_Close objEmpAccntCls = new clsDataLayer_Account_Close();
                       clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
                       clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
                       clsDataLayer_Audit_Closing objEmpAuditCls = new clsDataLayer_Audit_Closing();


                       objEntityAccnt.FromDate = ObjEntityReceipt.FromDate;
                       objEntityAudit.FromDate = ObjEntityReceipt.FromDate;
                       //   clsEntityJournal objEntityLayerStock1 = new clsEntityJournal();
                       // clsdAJournal objBusinessLayerStock1 = new clsBusinessJournal();
                       ObjEntityReceipt.FromDate = ObjEntityReceipt.FromDate;
                       objEntityAccnt.Corporate_id = intCorpId;
                       ObjEntityReceipt.Corporate_id = intCorpId;
                       objEntityAccnt.Organisation_id = intOrgId;
                       ObjEntityReceipt.Organisation_id = intOrgId;
                       string RcptDate = ObjEntityReceipt.RcptUpdateDate.ToString();
                       objEntityAudit.Organisation_id = intOrgId;
                       objEntityAudit.Corporate_id = intCorpId;
                       int SubFlg = 0;
                       DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
                       DataTable dtAuditCls = objEmpAuditCls.CheckAuditClosingDate(objEntityAudit);
                       if (dtAccntCls.Rows.Count > 0 || dtAuditCls.Rows.Count > 0)
                       {

                           DateTime lastUpdateDate = ObjEntityReceipt.RcptUpdateDate;
                           if (dtAccntCls.Rows.Count > 0)
                           {
                               if (objCommon.textToDateTime(dtAccntCls.Rows[0]["ACCNT_CLS_DATE"].ToString()) > lastUpdateDate)
                               {
                                   SubFlg = 1;
                               }
                           }
                           if (dtAuditCls.Rows.Count > 0)
                           {
                               if (objCommon.textToDateTime(dtAuditCls.Rows[0]["AUDIT_CLS_DATE"].ToString()) > lastUpdateDate)
                               {
                                   SubFlg = 1;
                               }
                           }

                           if (SubFlg == 1)
                           {
                               DataTable dtRefFormat1 = ReadRefNumberByDate(ObjEntityReceipt);
                               if (dtRefFormat1.Rows.Count > 0)
                               {
                                   string strRef = "";
                                   if (dtRefFormat1.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString() != "")
                                   {
                                       if (Convert.ToInt32(dtRefFormat1.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString()) != 1)
                                       {
                                           strRef = dtRefFormat1.Rows[0]["RECPT_REF"].ToString();
                                           strRef = strRef.TrimEnd('/');
                                           strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                       }
                                       else
                                       {
                                           strRef = dtRefFormat1.Rows[0]["RECPT_REF"].ToString();
                                       }
                                   }
                                   else
                                   {
                                       strRef = dtRefFormat1.Rows[0]["RECPT_REF"].ToString();
                                   }
                                   ObjEntityReceipt.RefNum = strRef;
                                   DataTable dtRefFormat = ReadRefNumberByDateLast(ObjEntityReceipt);
                                   if (dtRefFormat.Rows.Count > 0)
                                   {
                                       //  if (ObjEntityReceipt.ReceiptId != Convert.ToInt32(dtRefFormat.Rows[0]["RECPT_ID"].ToString()))
                                       // {
                                       Ref = dtRefFormat.Rows[0]["RECPT_REF"].ToString();
                                       if (dtRefFormat.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString() != null)
                                       {
                                           SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString());
                                       }
                                       if (SubRef != 1)
                                       {
                                           Ref = Ref.TrimEnd('/');
                                           Ref = Ref.Remove(Ref.LastIndexOf('/') + 1);
                                       }
                                       else
                                       {
                                           Ref += "/";
                                       }
                                       Ref = Ref + "" + SubRef;
                                       ObjEntityReceipt.RefNum = Ref;
                                       SubRef++;
                                       // }
                                       if (dtRefFormat.Rows[0]["RECPT_REF_NEXTNUM"].ToString() != "")
                                           ObjEntityReceipt.RefNextNum = Convert.ToInt32(dtRefFormat.Rows[0]["RECPT_REF_NEXTNUM"].ToString());

                                   }
                               }

                           }
                       }
                   }

                   using (OracleCommand cmdUpdReceiptDtls = new OracleCommand(strQueryLeaveTyp, con))
                   {
                       cmdUpdReceiptDtls.Transaction = tran;

                       cmdUpdReceiptDtls.CommandType = CommandType.StoredProcedure;
                       cmdUpdReceiptDtls.CommandText = strQueryLeaveTyp;
                       cmdUpdReceiptDtls.CommandType = CommandType.StoredProcedure;
                       cmdUpdReceiptDtls.Parameters.Add("R_RECPT_ID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                       cmdUpdReceiptDtls.Parameters.Add("R_REF", OracleDbType.Varchar2).Value = ObjEntityReceipt.RefNum;

                       if (SubRef == 1)
                       {
                           cmdUpdReceiptDtls.Parameters.Add("R_SUBREFID", OracleDbType.Int32).Value = DBNull.Value;
                       }
                       else
                       {
                           cmdUpdReceiptDtls.Parameters.Add("R_SUBREFID", OracleDbType.Int32).Value = SubRef;
                       }

                       cmdUpdReceiptDtls.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = ObjEntityReceipt.Organisation_id;
                       cmdUpdReceiptDtls.Parameters.Add("R_CORP_ID", OracleDbType.Int32).Value = ObjEntityReceipt.Corporate_id;
                       cmdUpdReceiptDtls.Parameters.Add("R_USR_ID", OracleDbType.Int32).Value = ObjEntityReceipt.User_Id;
                       cmdUpdReceiptDtls.Parameters.Add("R_REF_NEXTNUM", OracleDbType.Int32).Value = ObjEntityReceipt.RefNextNum;
                       cmdUpdReceiptDtls.ExecuteNonQuery();
                   }

                   if (ObjEntityReceipt.ConfirmStatus == 1)
                   {
                       string strQueryUpdateLedger = "RECEIPT_ACCOUNT.SP_UPDATE_ACCOUNT_MASTR";
                       using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryUpdateLedger, con))
                       {

                           cmdAddSubDetail.Transaction = tran;
                           cmdAddSubDetail.CommandType = CommandType.StoredProcedure;

                           cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityReceipt.AccntNameId;
                           cmdAddSubDetail.Parameters.Add("R_TOTEL_AMT", OracleDbType.Decimal).Value = ObjEntityReceipt.TotalAmnt;
                           cmdAddSubDetail.ExecuteNonQuery();
                       }
                       string strQueryInsertVoucher = "RECEIPT_ACCOUNT.SP_INS_VOUCHER_ACCOUNT";
                       using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                       {
                           cmdAddSubDetail.Transaction = tran;
                           cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                           cmdAddSubDetail.Parameters.Add("P_PID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                           cmdAddSubDetail.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = ObjEntityReceipt.RefNum;
                           cmdAddSubDetail.Parameters.Add("P_DATE", OracleDbType.Date).Value = ObjEntityReceipt.FromDate;
                           cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityReceipt.AccntNameId;
                           cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = ObjEntityReceipt.TotalAmnt;
                           cmdAddSubDetail.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = ObjEntityReceipt.Organisation_id;
                           cmdAddSubDetail.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = ObjEntityReceipt.Corporate_id;
                           cmdAddSubDetail.Parameters.Add("P_VOCHR", OracleDbType.Int32).Value = 0;
                           cmdAddSubDetail.Parameters.Add("P_DESC", OracleDbType.Varchar2).Value = ObjEntityReceipt.Description;
                           cmdAddSubDetail.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = ObjEntityReceipt.FinancialYrId;

                           cmdAddSubDetail.Parameters.Add("P_BANKSTS", OracleDbType.Int32).Value = 1;
                           cmdAddSubDetail.Parameters.Add("P_VOCHR_STS", OracleDbType.Int32).Value = 0;
                           cmdAddSubDetail.Parameters.Add("L_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                           cmdAddSubDetail.ExecuteNonQuery();
                           strReturn = cmdAddSubDetail.Parameters["L_OUT"].Value.ToString();

                           cmdAddSubDetail.Dispose();
                       }
                   }
                   //Update to sub table
                   //ledger insert
                   if (ObjEntityReceiptLedger.Count > 0)
                   {
                       foreach (clsEntity_Receipt_Account ObjEntityRcptupdate in ObjEntityReceiptLedger_Update)
                       {

                           if (ObjEntityReceipt.ConfirmStatus == 1)
                           {
                               string strQueryUpdateLedger = "RECEIPT_ACCOUNT.SP_UPDATE_LEDGER_MASTR";
                               using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryUpdateLedger, con))
                               {
                                   cmdAddSubDetail.Transaction = tran;
                                   cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                   cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;
                                   cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = ObjEntityRcptupdate.LedgerAmnt;
                                   cmdAddSubDetail.ExecuteNonQuery();
                               }

                               string strQueryInsertVoucher = "RECEIPT_ACCOUNT.SP_INS_VOUCHER_ACCOUNT";
                               using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                               {
                                   cmdAddSubDetail.Transaction = tran;
                                   cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                   cmdAddSubDetail.Parameters.Add("P_PID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                                   cmdAddSubDetail.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = ObjEntityReceipt.RefNum;
                                   cmdAddSubDetail.Parameters.Add("P_DATE", OracleDbType.Date).Value = ObjEntityReceipt.FromDate;
                                   cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;
                                   cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = ObjEntityRcptupdate.LedgerAmnt;
                                   cmdAddSubDetail.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = ObjEntityReceipt.Organisation_id;
                                   cmdAddSubDetail.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = ObjEntityReceipt.Corporate_id;
                                   cmdAddSubDetail.Parameters.Add("P_VOCHR", OracleDbType.Int32).Value = 0;
                                   cmdAddSubDetail.Parameters.Add("P_DESC", OracleDbType.Varchar2).Value = ObjEntityRcptupdate.Remarks;
                                   cmdAddSubDetail.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = ObjEntityReceipt.FinancialYrId;
                                   cmdAddSubDetail.Parameters.Add("P_BANKSTS", OracleDbType.Int32).Value = 0;
                                   cmdAddSubDetail.Parameters.Add("P_VOCHR_STS", OracleDbType.Int32).Value = 1;
                                   cmdAddSubDetail.Parameters.Add("L_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;

                                   cmdAddSubDetail.ExecuteNonQuery();
                                   strReturnLdgr = cmdAddSubDetail.Parameters["L_OUT"].Value.ToString();

                                   cmdAddSubDetail.Dispose();
                               }

                               //EVM-0027 Aug 13

                               if (ObjEntityReceipt.VoucherCategory == 1)
                               {
                                   if (ObjEntityRcptupdate.PaidAmt > 0)
                                   {
                                       string strQueryInsertVoucher1 = "RECEIPT_ACCOUNT.SP_UPDATE_VOUCHER_ACCOUNT";
                                       using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher1, con))
                                       {
                                           cmdAddSubDetail.Transaction = tran;
                                           cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                           cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;
                                           cmdAddSubDetail.Parameters.Add("P_VOUCHR_CAT", OracleDbType.Int32).Value = ObjEntityRcptupdate.VoucherCategory;
                                           cmdAddSubDetail.Parameters.Add("R_OBPAID_AMT", OracleDbType.Decimal).Value = ObjEntityRcptupdate.BalnceAmt;//balancamt
                                           cmdAddSubDetail.Parameters.Add("L_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                           cmdAddSubDetail.ExecuteNonQuery();
                                       }
                                       string strQueryInsertVoucherSettleDtls = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";  //Add settle amount details
                                       using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherSettleDtls, con))
                                       {
                                           cmdAddVoucher.Transaction = tran;
                                           cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                           cmdAddVoucher.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = strReturnLdgr;
                                           cmdAddVoucher.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;
                                           cmdAddVoucher.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = ObjEntityRcptupdate.PaidAmt;//paid amt
                                           cmdAddVoucher.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 4;
                                           cmdAddVoucher.Parameters.Add("C_USRID", OracleDbType.Int32).Value = ObjEntityReceipt.User_Id;
                                           cmdAddVoucher.Parameters.Add("C_SALID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;
                                           cmdAddVoucher.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                                           cmdAddVoucher.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = ObjEntityRcptupdate.BalnceAmt;
                                           cmdAddVoucher.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = ObjEntityRcptupdate.ReceiptLedgrId;

                                           cmdAddVoucher.ExecuteNonQuery();
                                       }
                                   }
                               }
                               //END

                               string strQueryInsertVoucherLdgr1 = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                               using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucherLdgr1, con))
                               {
                                   cmdAddSubDetail.Transaction = tran;
                                   cmdAddSubDetail.CommandType = CommandType.StoredProcedure;

                                   cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityReceipt.AccntNameId;
                                   cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturnLdgr);

                                   cmdAddSubDetail.ExecuteNonQuery();
                               }

                               string strQueryInsertVoucherLdgr = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                               using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucherLdgr, con))
                               {
                                   cmdAddSubDetail.Transaction = tran;
                                   cmdAddSubDetail.CommandType = CommandType.StoredProcedure;

                                   cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;
                                   cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturn);

                                   cmdAddSubDetail.ExecuteNonQuery();
                               }
                           }

                           foreach (clsEntity_Receipt_Account ObjEntitycstcntr_insert in ObjEntityReceiptCostCenter_Insert)
                           {

                               if (ObjEntitycstcntr_insert.ReceiptLedgrId == ObjEntityRcptupdate.ReceiptLedgrId)
                               {
                                   if (ObjEntityReceipt.ConfirmStatus == 1)
                                   {
                                       string strQuerySubSalesUpdate = "RECEIPT_ACCOUNT.SP_UPDATE_SAL_OR_COSTCNTR";
                                       using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubSalesUpdate, con))
                                       {
                                           cmdAddSubDetail.Transaction = tran;
                                           cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                           cmdAddSubDetail.Parameters.Add("R_COST_CNTR_ID", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.CostCtrId;
                                           cmdAddSubDetail.Parameters.Add("R_COSTCNTR_AMT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.CstCntrAmnt;
                                           cmdAddSubDetail.Parameters.Add("R_STATUS", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.Status;
                                           cmdAddSubDetail.Parameters.Add("R_AC_LD_ID", OracleDbType.Int32).Value = ObjEntityReceipt.AccntNameId;
                                           cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;


                                           cmdAddSubDetail.Parameters.Add("R_CREDITNOTE_LEDID", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.AccntNameId;
                                           cmdAddSubDetail.Parameters.Add("R_CREDITNOTE_SETLAMNT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.LedgerAmnt;
                                           cmdAddSubDetail.ExecuteNonQuery();
                                       }

                                       if (ObjEntitycstcntr_insert.Status == 0)
                                       {

                                           string strQueryInsertVoucher = "FMS_COMMON.SP_INS_CSTCNTR_VOUCHER_ACCOUNT";
                                           using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                                           {
                                               cmdAddSubDetail.Transaction = tran;
                                               cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                               cmdAddSubDetail.Parameters.Add("P_PID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                                               cmdAddSubDetail.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = ObjEntityReceipt.RefNum;
                                               cmdAddSubDetail.Parameters.Add("P_DATE", OracleDbType.Date).Value = ObjEntityReceipt.FromDate;
                                               cmdAddSubDetail.Parameters.Add("P_LD_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;
                                               cmdAddSubDetail.Parameters.Add("P_COST_CNTR_ID", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.CostCtrId;
                                               if (ObjEntitycstcntr_insert.CostGrp1Id != 0)
                                               {
                                                   cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_ONE", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.CostGrp1Id;
                                               }
                                               else
                                               {
                                                   cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_ONE", OracleDbType.Int32).Value = null;

                                               }
                                               if (ObjEntitycstcntr_insert.CostGrp2Id != 0)
                                               {
                                                   cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_TWO", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.CostGrp2Id;
                                               }
                                               else
                                               {
                                                   cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_TWO", OracleDbType.Int32).Value = null;

                                               }

                                               cmdAddSubDetail.Parameters.Add("P_LDGR_AMT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.CstCntrAmnt;
                                               cmdAddSubDetail.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = ObjEntityReceipt.Organisation_id;
                                               cmdAddSubDetail.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = ObjEntityReceipt.Corporate_id;
                                               cmdAddSubDetail.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = ObjEntityReceipt.FinancialYrId;
                                               cmdAddSubDetail.Parameters.Add("P_VOCHR_STS", OracleDbType.Int32).Value = 1;
                                               cmdAddSubDetail.Parameters.Add("P_CRNC_MST_ID", OracleDbType.Int32).Value = ObjEntityReceipt.CurrcyId;
                                               cmdAddSubDetail.Parameters.Add("P_VOCHR_TYPE", OracleDbType.Int32).Value = 0;
                                               cmdAddSubDetail.Parameters.Add("P_VOCHR_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturn);
                                               cmdAddSubDetail.ExecuteNonQuery();

                                           }
                                       }
                                       else
                                       {


                                           string strQueryInsertVoucher = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";
                                           //insert sale settlemnt to voucher settlement table
                                           if (ObjEntitycstcntr_insert.CostCtrId != 0 && ObjEntitycstcntr_insert.CstCntrAmnt != 0)
                                           {
                                               using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                                               {
                                                   if (ObjEntitycstcntr_insert.CostCtrId != 0 && ObjEntitycstcntr_insert.CstCntrAmnt != 0 && ObjEntitycstcntr_insert.AccntNameId == 0)
                                                   {
                                                       cmdAddSubDetail.Transaction = tran;
                                                       cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                       cmdAddSubDetail.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = strReturnLdgr;
                                                       cmdAddSubDetail.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;
                                                       cmdAddSubDetail.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.CstCntrAmnt;
                                                       cmdAddSubDetail.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 0;
                                                       cmdAddSubDetail.Parameters.Add("C_USRID", OracleDbType.Int32).Value = ObjEntityReceipt.User_Id;
                                                       cmdAddSubDetail.Parameters.Add("C_SALID", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.CostCtrId;
                                                       cmdAddSubDetail.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                                                       cmdAddSubDetail.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.SettlmntAmmnt;
                                                       cmdAddSubDetail.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = ObjEntityRcptupdate.ReceiptLedgrId;
                                                       cmdAddSubDetail.ExecuteNonQuery();
                                                       cmdAddSubDetail.Dispose();
                                                   }
                                               }
                                           }
                                           //insert debit note settlemnt to voucher settlement table
                                           if (ObjEntitycstcntr_insert.AccntNameId != 0 && ObjEntitycstcntr_insert.LedgerAmnt != 0)
                                           {
                                               using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                                               {
                                                   cmdAddSubDetail.Transaction = tran;
                                                   cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                   cmdAddSubDetail.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = strReturnLdgr;
                                                   cmdAddSubDetail.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;
                                                   cmdAddSubDetail.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.LedgerAmnt;
                                                   cmdAddSubDetail.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 3;
                                                   cmdAddSubDetail.Parameters.Add("C_USRID", OracleDbType.Int32).Value = ObjEntityReceipt.User_Id;
                                                   cmdAddSubDetail.Parameters.Add("C_SALID", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.CostCtrId;
                                                   cmdAddSubDetail.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                                                   cmdAddSubDetail.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.BalanceAmount;
                                                   cmdAddSubDetail.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = ObjEntityRcptupdate.ReceiptLedgrId;
                                                   cmdAddSubDetail.ExecuteNonQuery();
                                                   cmdAddSubDetail.Dispose();
                                               }
                                           }

                                       }
                                   }


                               }

                           }


                           foreach (clsEntity_Receipt_Account ObjEntityRcptCstCntr in ObjEntityReceiptCostCenter_update)
                           {
                               if (ObjEntityRcptCstCntr.LedgerId == ObjEntityRcptupdate.LedgerId && ObjEntityRcptCstCntr.ReceiptLedgrId == ObjEntityRcptupdate.ReceiptLedgrId)
                               {

                                   if (ObjEntityReceipt.ConfirmStatus == 1)
                                   {
                                       string strQuerySubSalesUpdate = "RECEIPT_ACCOUNT.SP_UPDATE_SAL_OR_COSTCNTR";
                                       using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubSalesUpdate, con))
                                       {
                                           cmdAddSubDetail.Transaction = tran;
                                           cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                           cmdAddSubDetail.Parameters.Add("R_COST_CNTR_ID", OracleDbType.Int32).Value = ObjEntityRcptCstCntr.CostCtrId;
                                           cmdAddSubDetail.Parameters.Add("R_COSTCNTR_AMT", OracleDbType.Decimal).Value = ObjEntityRcptCstCntr.CstCntrAmnt;
                                           cmdAddSubDetail.Parameters.Add("R_STATUS", OracleDbType.Int32).Value = ObjEntityRcptCstCntr.Status;
                                           cmdAddSubDetail.Parameters.Add("R_AC_LD_ID", OracleDbType.Int32).Value = ObjEntityReceipt.AccntNameId;
                                           cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;


                                           cmdAddSubDetail.Parameters.Add("R_CREDITNOTE_LEDID", OracleDbType.Int32).Value = 0;
                                           cmdAddSubDetail.Parameters.Add("R_CREDITNOTE_SETLAMNT", OracleDbType.Decimal).Value = 0;

                                           cmdAddSubDetail.ExecuteNonQuery();
                                       }

                                       if (ObjEntityRcptCstCntr.Status == 0)
                                       {

                                           string strQueryInsertVoucher = "FMS_COMMON.SP_INS_CSTCNTR_VOUCHER_ACCOUNT";
                                           using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                                           {
                                               cmdAddSubDetail.Transaction = tran;
                                               cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                               cmdAddSubDetail.Parameters.Add("P_PID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                                               cmdAddSubDetail.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = ObjEntityReceipt.RefNum;
                                               cmdAddSubDetail.Parameters.Add("P_DATE", OracleDbType.Date).Value = ObjEntityReceipt.FromDate;
                                               cmdAddSubDetail.Parameters.Add("P_LD_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;
                                               cmdAddSubDetail.Parameters.Add("P_COST_CNTR_ID", OracleDbType.Int32).Value = ObjEntityRcptCstCntr.CostCtrId;
                                               if (ObjEntityRcptupdate.CostGrp1Id != 0)
                                               {
                                                   cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_ONE", OracleDbType.Int32).Value = ObjEntityRcptCstCntr.CostGrp1Id;
                                               }
                                               else
                                               {
                                                   cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_ONE", OracleDbType.Int32).Value = null;

                                               }
                                               if (ObjEntityRcptupdate.CostGrp2Id != 0)
                                               {
                                                   cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_TWO", OracleDbType.Int32).Value = ObjEntityRcptCstCntr.CostGrp2Id;
                                               }
                                               else
                                               {
                                                   cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_TWO", OracleDbType.Int32).Value = null;

                                               }

                                               cmdAddSubDetail.Parameters.Add("P_LDGR_AMT", OracleDbType.Decimal).Value = ObjEntityRcptCstCntr.CstCntrAmnt;
                                               cmdAddSubDetail.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = ObjEntityReceipt.Organisation_id;
                                               cmdAddSubDetail.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = ObjEntityReceipt.Corporate_id;


                                               cmdAddSubDetail.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = ObjEntityReceipt.FinancialYrId;

                                               cmdAddSubDetail.Parameters.Add("P_VOCHR_STS", OracleDbType.Int32).Value = 1;
                                               cmdAddSubDetail.Parameters.Add("P_CRNC_MST_ID", OracleDbType.Int32).Value = ObjEntityReceipt.CurrcyId;
                                               cmdAddSubDetail.Parameters.Add("P_VOCHR_TYPE", OracleDbType.Int32).Value = 0;
                                               cmdAddSubDetail.Parameters.Add("P_VOCHR_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturn);

                                               cmdAddSubDetail.ExecuteNonQuery();


                                               cmdAddSubDetail.Dispose();
                                           }
                                       }
                                       else
                                       {

                                           string strQueryInsertVoucher = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";
                                           //insert sale settlemnt to voucher settlement table
                                           if (ObjEntityRcptCstCntr.CostCtrId != 0 && ObjEntityRcptCstCntr.CstCntrAmnt != 0)
                                           {
                                               using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                                               {
                                                   if (ObjEntityRcptCstCntr.CostCtrId != 0 && ObjEntityRcptCstCntr.CstCntrAmnt != 0 && ObjEntityRcptCstCntr.AccntNameId == 0)
                                                   {
                                                       cmdAddSubDetail.Transaction = tran;
                                                       cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                       cmdAddSubDetail.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = strReturnLdgr;
                                                       cmdAddSubDetail.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;
                                                       cmdAddSubDetail.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = ObjEntityRcptCstCntr.CstCntrAmnt;
                                                       cmdAddSubDetail.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 0;
                                                       cmdAddSubDetail.Parameters.Add("C_USRID", OracleDbType.Int32).Value = ObjEntityReceipt.User_Id;
                                                       cmdAddSubDetail.Parameters.Add("C_SALID", OracleDbType.Int32).Value = ObjEntityRcptCstCntr.CostCtrId;
                                                       cmdAddSubDetail.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                                                       cmdAddSubDetail.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = ObjEntityRcptCstCntr.SettlmntAmmnt;
                                                       cmdAddSubDetail.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = ObjEntityRcptupdate.ReceiptLedgrId;
                                                       cmdAddSubDetail.ExecuteNonQuery();
                                                       cmdAddSubDetail.Dispose();
                                                   }
                                               }
                                           }
                                           //insert debit note settlemnt to voucher settlement table
                                           if (ObjEntityRcptCstCntr.AccntNameId != 0 && ObjEntityRcptCstCntr.LedgerAmnt != 0)
                                           {
                                               using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                                               {
                                                   cmdAddSubDetail.Transaction = tran;
                                                   cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                   cmdAddSubDetail.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = strReturnLdgr;
                                                   cmdAddSubDetail.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = ObjEntityRcptupdate.LedgerId;
                                                   cmdAddSubDetail.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = ObjEntityRcptCstCntr.LedgerAmnt;
                                                   cmdAddSubDetail.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 3;
                                                   cmdAddSubDetail.Parameters.Add("C_USRID", OracleDbType.Int32).Value = ObjEntityReceipt.User_Id;
                                                   cmdAddSubDetail.Parameters.Add("C_SALID", OracleDbType.Int32).Value = ObjEntityRcptCstCntr.CostCtrId;
                                                   cmdAddSubDetail.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                                                   cmdAddSubDetail.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = ObjEntityRcptCstCntr.BalanceAmount;
                                                   cmdAddSubDetail.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = ObjEntityRcptupdate.ReceiptLedgrId;
                                                   cmdAddSubDetail.ExecuteNonQuery();
                                                   cmdAddSubDetail.Dispose();
                                               }
                                           }

                                       }
                                   }
                               }
                           }
                       }



                   }
                   ////EVM-0027 Aug 13

                   //if(objEntityUpdateOB.Count>0)
                   //{
                   //      foreach (clsEntity_Receipt_Account objEntityUpdate in objEntityUpdateOB)
                   //      {
                   //         if (ObjEntityReceipt.VoucherCategory == 1)
                   //            {
                   //                string strQueryInsertVoucher1 = "RECEIPT_ACCOUNT.SP_UPDATE_VOUCHER_ACCOUNT";
                   //                using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher1, con))
                   //                {
                   //                    cmdAddSubDetail.Transaction = tran;
                   //                    cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                   //                    cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objEntityUpdate.LedgerId;
                   //                    cmdAddSubDetail.Parameters.Add("P_VOUCHR_CAT", OracleDbType.Int32).Value = objEntityUpdate.VoucherCategory;
                   //                    cmdAddSubDetail.Parameters.Add("R_OBPAID_AMT", OracleDbType.Decimal).Value = objEntityUpdate.PaidAmt;//balancamt
                   //                    cmdAddSubDetail.Parameters.Add("L_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                   //                    cmdAddSubDetail.ExecuteNonQuery();
                   //                }
                   //                string strQueryInsertVoucherSettleDtls = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";  //Add settle amount details
                   //                using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherSettleDtls, con))
                   //                {
                   //                    cmdAddVoucher.Transaction = tran;
                   //                    cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                   //                    cmdAddVoucher.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = strReturnLdgr;
                   //                    cmdAddVoucher.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = objEntityUpdate.LedgerId;
                   //                    cmdAddVoucher.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = objEntityUpdate.PaidAmt;//paid amt
                   //                    cmdAddVoucher.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 4;
                   //                    cmdAddVoucher.Parameters.Add("C_USRID", OracleDbType.Int32).Value = ObjEntityReceipt.User_Id;
                   //                    cmdAddVoucher.Parameters.Add("C_SALID", OracleDbType.Int32).Value = objEntityUpdate.LedgerId;
                   //                    cmdAddVoucher.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                   //                    cmdAddVoucher.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = ObjEntityReceipt.SettlmntAmmnt;
                   //                    cmdAddVoucher.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = objEntityUpdate.ReceiptLedgrId;

                   //                    cmdAddVoucher.ExecuteNonQuery();
                   //                }
                   //            }
                   //      }
                   //}


                   ////END




                   tran.Commit();

               }

               catch (Exception e)
               {
                   tran.Rollback();
                   throw e;

               }

           }
       }


       public DataTable ReadAcntClsingDate(clsEntity_Receipt_Account objEntityList)
       {
           string strQueryReadRcpt = "RECEIPT_ACCOUNT.SP_READ_ACNT_CLS_DATE";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityList.Organisation_id;
           cmdReadRcpt.Parameters.Add("R_CORP_ID", OracleDbType.Int32).Value = objEntityList.Corporate_id;
           cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }
       public void ReOpenById(clsEntity_Receipt_Account ObjEntityReceipt, List<clsEntity_Receipt_Account> ObjEntityReceiptLedger, List<clsEntity_Receipt_Account> ObjEntityReceiptCostCenter, List<clsEntity_Receipt_Account> objEntityUpdateOB)
       {

           OracleTransaction tran;
           using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
           {
               con.Open();
               tran = con.BeginTransaction();

               try
               {
                   string strQueryMemoRsnCncl = " RECEIPT_ACCOUNT.SP_REOPEN_RECEIPT";
                   using (OracleCommand cmdPerfmncTmplt = new OracleCommand(strQueryMemoRsnCncl, con))
                   {
                       //  cmdPerfmncTmplt.CommandText = strQueryMemoRsnCncl;
                       cmdPerfmncTmplt.Transaction = tran;
                       cmdPerfmncTmplt.CommandType = CommandType.StoredProcedure;
                       cmdPerfmncTmplt.Parameters.Add("RCPTID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                       cmdPerfmncTmplt.Parameters.Add("R_USR_ID", OracleDbType.Int32).Value = ObjEntityReceipt.User_Id;
                       cmdPerfmncTmplt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = ObjEntityReceipt.Organisation_id;
                       cmdPerfmncTmplt.Parameters.Add("R_CORP_ID", OracleDbType.Int32).Value = ObjEntityReceipt.Corporate_id;
                       // clsDataLayer.ExecuteNonQuery(cmdPerfmncTmplt);
                       cmdPerfmncTmplt.ExecuteNonQuery();
                   }
                   string strQueryVoucherDel = " RECEIPT_ACCOUNT.SP_DEL_VOUCHER_ACCOUNT_REOPEN";
                   using (OracleCommand cmdPerfmncTmplt = new OracleCommand(strQueryVoucherDel, con))
                   {
                       //cmdPerfmncTmplt.CommandText = strQueryVoucherDel;
                       cmdPerfmncTmplt.Transaction = tran;
                       cmdPerfmncTmplt.CommandType = CommandType.StoredProcedure;
                       cmdPerfmncTmplt.Parameters.Add("P_PID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                       cmdPerfmncTmplt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = ObjEntityReceipt.Organisation_id;
                       cmdPerfmncTmplt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = ObjEntityReceipt.Corporate_id;
                       /// clsDataLayer.ExecuteNonQuery(cmdPerfmncTmplt);
                       cmdPerfmncTmplt.ExecuteNonQuery();
                       /// 
                   }
                   string strQueryccVoucherDel = "FMS_COMMON.SP_DEL_CC_VOUCHER_ACNT_REOPEN";
                   using (OracleCommand cmdPerfmncTmplt = new OracleCommand(strQueryccVoucherDel, con))
                   {
                       //cmdPerfmncTmplt.CommandText = strQueryVoucherDel;
                       cmdPerfmncTmplt.Transaction = tran;
                       cmdPerfmncTmplt.CommandType = CommandType.StoredProcedure;
                       cmdPerfmncTmplt.Parameters.Add("P_PID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                       cmdPerfmncTmplt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = ObjEntityReceipt.Organisation_id;
                       cmdPerfmncTmplt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = ObjEntityReceipt.Corporate_id;
                       /// clsDataLayer.ExecuteNonQuery(cmdPerfmncTmplt);
                       cmdPerfmncTmplt.ExecuteNonQuery();
                       /// 
                   }

                   if (ObjEntityReceiptLedger.Count > 0)
                   {
                       foreach (clsEntity_Receipt_Account ObjEntityRcptLedgr in ObjEntityReceiptLedger)
                       {
                           string strQuerySubDetails = "RECEIPT_ACCOUNT.UPDLDGRAMT_REOPN";
                           using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetails, con))
                           {

                               cmdAddSubDetail.Transaction = tran;
                               cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                               cmdAddSubDetail.Parameters.Add("RCPTID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                               cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityRcptLedgr.LedgerId;
                               cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = ObjEntityRcptLedgr.LedgerAmnt;
                               cmdAddSubDetail.ExecuteNonQuery();
                           }

                           foreach (clsEntity_Receipt_Account ObjEntitycstcntr_insert in ObjEntityReceiptCostCenter)
                           {
                               if (ObjEntitycstcntr_insert.ReceiptLedgrId == ObjEntityRcptLedgr.ReceiptLedgrId)
                               {
                                   string strQuerycstSubDetails = "RECEIPT_ACCOUNT.UPDCSTCNTRAMT_REOPN";
                                   using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerycstSubDetails, con))
                                   {
                                       cmdAddSubDetail.Transaction = tran;
                                       cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                       cmdAddSubDetail.Parameters.Add("R_COST_CNTR_ID", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.CostCtrId;
                                       cmdAddSubDetail.Parameters.Add("R_RECEIPT_ID", OracleDbType.Int32).Value = ObjEntityReceipt.ReceiptId;
                                       cmdAddSubDetail.Parameters.Add("R_COSTCNTR_AMT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.CstCntrAmnt;
                                       cmdAddSubDetail.Parameters.Add("R_RECPT_LD_ID", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.ReceiptLedgrId;
                                       cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.LedgerId;
                                       cmdAddSubDetail.Parameters.Add("R_AC_LD_ID", OracleDbType.Int32).Value = ObjEntityReceipt.AccntNameId;
                                       cmdAddSubDetail.Parameters.Add("R_LLD_ID", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.LedId;
                                       cmdAddSubDetail.Parameters.Add("R_STATUS", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.Status;//cost centre or sales
                                       cmdAddSubDetail.Parameters.Add("R_CREDITNOTE_LEDID", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.AccntNameId;
                                       cmdAddSubDetail.Parameters.Add("R_CREDITNOTE_BAL", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.BalanceAmount;
                                       cmdAddSubDetail.Parameters.Add("R_CREDITNOTE_SETLAMNT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.LedgerCreditAmt;
                                       cmdAddSubDetail.ExecuteNonQuery();
                                   }
                               }
                           }

                       }
                   }

                   if (objEntityUpdateOB.Count > 0)
                   {
                       foreach (clsEntity_Receipt_Account ObjEntitycstcntr_insert in objEntityUpdateOB)
                       {
                           //EVM-0027 AUG 8
                           string strQueryUpdateVoucherTable = "RECEIPT_ACCOUNT.SP_UPDATE_VOUCHER_ACCOUNT";
                           using (OracleCommand CmdUpdateVT = new OracleCommand(strQueryUpdateVoucherTable, con))
                           {
                               CmdUpdateVT.Transaction = tran;
                               CmdUpdateVT.CommandType = CommandType.StoredProcedure;
                               CmdUpdateVT.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.LedId;
                               CmdUpdateVT.Parameters.Add("P_VOUCHR_CAT", OracleDbType.Int32).Value = ObjEntitycstcntr_insert.VoucherCategory;
                               CmdUpdateVT.Parameters.Add("R_OBPAID_AMT", OracleDbType.Decimal).Value = ObjEntitycstcntr_insert.BalnceAmt;//balancamt
                               CmdUpdateVT.Parameters.Add("L_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                               CmdUpdateVT.ExecuteNonQuery();
                           }
                       }
                       //END
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

       public DataTable ReadCrncyAbrvtn(clsEntity_Receipt_Account objEntity)
       {
           string strQueryReadRcpt = "RECEIPT_ACCOUNT.SP_READ_CURRENCY_ABRVTN";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
           cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadRcpt.Parameters.Add("R_CRNCY_ID", OracleDbType.Int32).Value = objEntity.CurrcyId;
           cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }


       public DataTable ReadBank(clsEntity_Receipt_Account objEntity)
       {
           string strQueryReadRcpt = "RECEIPT_ACCOUNT.SP_READ_BANK";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
           cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadRcpt.Parameters.Add("R_USR_ID", OracleDbType.Int32).Value = objEntity.User_Id;
           cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }
       public DataTable readRefFormate(clsEntityCommon ObjEntitySales)
       {
           string strQueryReadCustomerLdger = "RECEIPT_ACCOUNT.SP_RD_REF_FORMAT";
           OracleCommand cmdReadCustomerLdger = new OracleCommand();
           cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
           cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
           cmdReadCustomerLdger.Parameters.Add("S_MOD_ID", OracleDbType.Int32).Value = ObjEntitySales.SectionId;
           cmdReadCustomerLdger.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.CorporateID;
           cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCustomerLdger = new DataTable();
           dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
           return dtCustomerLdger;
       }

       public DataTable readFinancialYear(clsEntity_Receipt_Account ObjEntitySales)
       {
           string strQueryReadCustomerLdger = "RECEIPT_ACCOUNT.SP_RD_FINSCAL_YEAR";
           OracleCommand cmdReadCustomerLdger = new OracleCommand();
           cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
           cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
           cmdReadCustomerLdger.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
           cmdReadCustomerLdger.Parameters.Add("PR_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
           cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCustomerLdger = new DataTable();
           dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
           return dtCustomerLdger;
       }
       public DataTable readAcntClsDate(clsEntity_Receipt_Account ObjEntitySales)
       {
           string strQueryReadCustomerLdger = "RECEIPT_ACCOUNT.SP_RD_ACNT_CLS_DATE";
           OracleCommand cmdReadCustomerLdger = new OracleCommand();
           cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
           cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
           cmdReadCustomerLdger.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
           cmdReadCustomerLdger.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
           cmdReadCustomerLdger.Parameters.Add("S_FROM_DATE", OracleDbType.Date).Value = ObjEntitySales.StartDate;
           cmdReadCustomerLdger.Parameters.Add("S_TO_DATE", OracleDbType.Date).Value = ObjEntitySales.EndDate;

           cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCustomerLdger = new DataTable();
           dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
           return dtCustomerLdger;
       }
       public DataTable ReadRefNumberByDate(clsEntity_Receipt_Account ObjEntitySales)
       {
           string strQueryReadCustomerLdger = "RECEIPT_ACCOUNT.SP_RD_REF_BYDATE";
           OracleCommand cmdReadCustomerLdger = new OracleCommand();
           cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
           cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
           cmdReadCustomerLdger.Parameters.Add("S_DATE", OracleDbType.Date).Value = ObjEntitySales.FromDate;
           cmdReadCustomerLdger.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id ;
           cmdReadCustomerLdger.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
           cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCustomerLdger = new DataTable();
           dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
           return dtCustomerLdger;
       }
       public DataTable ReadRefNumberByDateLast(clsEntity_Receipt_Account ObjEntitySales)
       {
           string strQueryReadCustomerLdger = "RECEIPT_ACCOUNT.SP_RD_REF_BYDATE_LAST";
           OracleCommand cmdReadCustomerLdger = new OracleCommand();
           cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
           cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
           cmdReadCustomerLdger.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
           cmdReadCustomerLdger.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
           cmdReadCustomerLdger.Parameters.Add("S_REF", OracleDbType.Varchar2).Value = ObjEntitySales.RefNum;
           cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCustomerLdger = new DataTable();
           dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
           return dtCustomerLdger;
       }
       public DataTable ReadCorpDtls(clsEntity_Receipt_Account ObjEntitySales)
       {
           string strQueryReadTcs = "RECEIPT_ACCOUNT.SP_READ_CORP_DTLS";
           OracleCommand cmdReadTcs = new OracleCommand();
           cmdReadTcs.CommandText = strQueryReadTcs;
           cmdReadTcs.CommandType = CommandType.StoredProcedure;
           cmdReadTcs.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
           cmdReadTcs.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
           cmdReadTcs.Parameters.Add("S_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtLeav = new DataTable();
           dtLeav = clsDataLayer.ExecuteReader(cmdReadTcs);
           return dtLeav;
       }
       public DataTable ReadUserName(clsEntity_Receipt_Account ObjEntitySales)
       {
           string strQueryReadTcs = "RECEIPT_ACCOUNT.SP_READ_USR_DTLS";
           OracleCommand cmdReadTcs = new OracleCommand();
           cmdReadTcs.CommandText = strQueryReadTcs;
           cmdReadTcs.CommandType = CommandType.StoredProcedure;
           cmdReadTcs.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
           cmdReadTcs.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
           cmdReadTcs.Parameters.Add("S_USRID", OracleDbType.Int32).Value = ObjEntitySales.User_Id;
           cmdReadTcs.Parameters.Add("S_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtLeav = new DataTable();
           dtLeav = clsDataLayer.ExecuteReader(cmdReadTcs);
           return dtLeav;
       }

       public DataTable CheckReceiptCnclSts(clsEntity_Receipt_Account objEntityEmpSlry)
       {
           string strQueryReadEmpSlry = "RECEIPT_ACCOUNT.SP_CHECK_CNCL_STS";
           OracleCommand cmdReadPayGrd = new OracleCommand();
           cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
           cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
           cmdReadPayGrd.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityEmpSlry.ReceiptId;
           cmdReadPayGrd.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtEmpSlry = new DataTable();
           dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
           return dtEmpSlry;
       }
       public DataTable ReadSalesBalance(clsEntity_Receipt_Account objEntity)
       {
           string strQueryReadRcpt = "RECEIPT_ACCOUNT.SP_READ_SALES_BALANCE";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           cmdReadRcpt.Parameters.Add("F_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadRcpt.Parameters.Add("F_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadRcpt.Parameters.Add("F_LDGRID", OracleDbType.Int32).Value = objEntity.CostCtrId;
           cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }

       public void DeleteSaleLedgers(List<clsEntity_Receipt_Account> ObjEntityReceiptLedger)
       {
           foreach (clsEntity_Receipt_Account objEntity in ObjEntityReceiptLedger)
           {
               string strCommandText = "RECEIPT_ACCOUNT.SP_DELETE_ADDEDSALE";
               OracleCommand cmdReadRcpt = new OracleCommand();
               cmdReadRcpt.CommandText = strCommandText;
               cmdReadRcpt.CommandType = CommandType.StoredProcedure;
               cmdReadRcpt.Parameters.Add("R_CST_SALE_ID", OracleDbType.Int32).Value = objEntity.ReceiptCstCntrId;
               clsDataLayer.ExecuteNonQuery(cmdReadRcpt);
           }
       }


       public DataTable ReadCreditNoteList(clsEntity_Receipt_Account objEntity)
       {
           string strQueryReadRcpt = "RECEIPT_ACCOUNT.SP_READ_CREDITNOTE_LIST";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           cmdReadRcpt.Parameters.Add("R_LEDGERID", OracleDbType.Int32).Value = objEntity.LedgerId;
           cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }

       public DataTable ReadCreditNoteDtls(clsEntity_Receipt_Account objEntity)
       {
           string strQueryReadRcpt = "RECEIPT_ACCOUNT.SP_READ_CREDITNOTE_DTLS";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           cmdReadRcpt.Parameters.Add("R_LEDGERID", OracleDbType.Int32).Value = objEntity.LedgerId;
           cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }

       public DataTable CheckDupBankAcNum(clsEntity_Receipt_Account objEntityCheque)
       {
           string strQueryReadRcpt = "RECEIPT_ACCOUNT.SP_CHK_CHEQUE_DUP";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           cmdReadRcpt.Parameters.Add("P_BANK", OracleDbType.Varchar2).Value = objEntityCheque.Bank_Name;
           cmdReadRcpt.Parameters.Add("P_ACNUM", OracleDbType.Varchar2).Value = objEntityCheque.CancelReason;
           cmdReadRcpt.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityCheque.ReceiptId;
           //cmdReadRcpt.Parameters.Add("P_TYPE", OracleDbType.Int32).Value = 0;
           cmdReadRcpt.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }


       //public DataTable CheckDupBankAcNum(clsEntity_Receipt_Account objEntity)
       //{
       //    string strQueryReadRcpt = "FMS_POSTDATED_CHEQUE.SP_CHK_CHEQUE_DUP";
       //    OracleCommand cmdReadRcpt = new OracleCommand();
       //    cmdReadRcpt.CommandText = strQueryReadRcpt;
       //    cmdReadRcpt.CommandType = CommandType.StoredProcedure;
       //    cmdReadRcpt.Parameters.Add("P_BANK", OracleDbType.Varchar2).Value = objEntity.Bank_Name;
       //    cmdReadRcpt.Parameters.Add("P_ACNUM", OracleDbType.Varchar2).Value = objEntity.CancelReason;
       //    cmdReadRcpt.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntity.ReceiptId;
       //    cmdReadRcpt.Parameters.Add("P_TYPE", OracleDbType.Int32).Value = 1;
       //    cmdReadRcpt.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
       //    DataTable dtCategory = new DataTable();
       //    dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
       //    return dtCategory;
       //}


       public DataTable ReadDebitNoteList(clsEntity_Receipt_Account objEntity)
       {
           string strQueryReadRcpt = "RECEIPT_ACCOUNT.SP_READ_DEBITNOTE_LIST";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           cmdReadRcpt.Parameters.Add("R_LEDGERID", OracleDbType.Int32).Value = objEntity.LedgerId;
           cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }

       public DataTable ReadDebitNoteDtls(clsEntity_Receipt_Account objEntity)
       {
           string strQueryReadRcpt = "RECEIPT_ACCOUNT.SP_READ_DEBITNOTE_DTLS";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           cmdReadRcpt.Parameters.Add("R_LEDGERID", OracleDbType.Int32).Value = objEntity.LedgerId;
           cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }

       public DataTable ReadPurchaseReturnbyId(clsEntity_Receipt_Account objEntity)
       {
           string strQueryReadRcpt = "RECEIPT_ACCOUNT.SP_READ_PURCHS_RETURN_BY_LEDID";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadRcpt.Parameters.Add("R_LEDGERID", OracleDbType.Int32).Value = objEntity.LedgerId;
           cmdReadRcpt.Parameters.Add("R_DBNTID", OracleDbType.Int32).Value = objEntity.ReceiptId;
           cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }


       public DataTable ReadSalesReturnBalance(clsEntity_Receipt_Account objEntity)
       {
           string strQueryReadRcpt = "RECEIPT_ACCOUNT.SP_READ_PRCHS_RETURN_BALANCE";
           OracleCommand cmdReadRcpt = new OracleCommand();
           cmdReadRcpt.CommandText = strQueryReadRcpt;
           cmdReadRcpt.CommandType = CommandType.StoredProcedure;
           cmdReadRcpt.Parameters.Add("F_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
           cmdReadRcpt.Parameters.Add("F_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
           cmdReadRcpt.Parameters.Add("F_LDGRID", OracleDbType.Int32).Value = objEntity.CostCtrId;
           cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
           return dtCategory;
       }


    }
}
