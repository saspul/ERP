using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using DL_Compzit;
using EL_Compzit.EntityLayer_FMS;
using CL_Compzit;
using EL_Compzit;

namespace DL_Compzit.DataLayer_FMS
{
  public  class clsDalaLayerLedger
    {
      public DataTable ReadTDS(clsEntityLedger objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_LEDGER.SP_READ_TDS";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
          cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
          cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtEmpSlry = new DataTable();
          dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
          return dtEmpSlry;
      }
      public DataTable ReadTCS(clsEntityLedger objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_LEDGER.SP_READ_TCS";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
          cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
          cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtEmpSlry = new DataTable();
          dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
          return dtEmpSlry;
      }

      public DataTable ReadAccountGrps(clsEntityLedger objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_LEDGER.SP_READ_ACCONT_GRPS";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
          cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
          cmdReadPayGrd.Parameters.Add("L_ACNT_MODE_ID", OracleDbType.Int32).Value = objEntityEmpSlry.ActModeId;
          cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtEmpSlry = new DataTable();
          dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
          return dtEmpSlry;
      }
      public DataTable ReadAccountGrpsLedgr(clsEntityLedger objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_LEDGER.SP_READ_ACCONT_GRPS_FOR_LDGR";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
          cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
          cmdReadPayGrd.Parameters.Add("L_ACNT_MODE_ID", OracleDbType.Int32).Value = objEntityEmpSlry.ActModeId;
          cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtEmpSlry = new DataTable();
          dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
          return dtEmpSlry;
      }
      public DataTable ReadLedgers(clsEntityLedger objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_LEDGER.SP_LEDGER_READ";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerId;
          cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
          cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
          cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtEmpSlry = new DataTable();
          dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
          return dtEmpSlry;
      }
      public DataTable ReadCurrencies(clsEntityLedger objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_LEDGER.SP_READ_CURRENCIES";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
          cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
          cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtEmpSlry = new DataTable();
          dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
          return dtEmpSlry;
      }
      public DataTable CheckLedgerCnclSts(clsEntityLedger objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_LEDGER.SP_CHECK_CNCL_STS";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerId;
          cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
          cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
          cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtEmpSlry = new DataTable();
          dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
          return dtEmpSlry;
      }
      public DataTable ReadLedgerDtlsById(clsEntityLedger objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_LEDGER.SP_READ_LEDGER_DTLS";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerId;
          cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
          cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
          cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtEmpSlry = new DataTable();
          dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
          return dtEmpSlry;
      }
      public DataTable ReadLedgerList(clsEntityLedger objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_LEDGER.SP_READ_LIST";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("L_STS", OracleDbType.Int32).Value = objEntityEmpSlry.Status;
          cmdReadPayGrd.Parameters.Add("L_CNCL_STS", OracleDbType.Int32).Value = objEntityEmpSlry.CostCenterSts;
          cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
          cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
          cmdReadPayGrd.Parameters.Add("L_ACCNT_GRP_ID", OracleDbType.Int32).Value = objEntityEmpSlry.AccountGrpId;

          //----------pagination--------//
          cmdReadPayGrd.Parameters.Add("P_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityEmpSlry.CommonSearchTerm;
          cmdReadPayGrd.Parameters.Add("P_SEARCH_NAME", OracleDbType.Varchar2).Value = objEntityEmpSlry.SearchName;
          cmdReadPayGrd.Parameters.Add("P_SEARCH_GROUP", OracleDbType.Varchar2).Value = objEntityEmpSlry.SearchCode;
          cmdReadPayGrd.Parameters.Add("P_SEARCH_LEDGER", OracleDbType.Varchar2).Value = objEntityEmpSlry.SearchAddress;
        
          cmdReadPayGrd.Parameters.Add("P_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityEmpSlry.OrderColumn;
          cmdReadPayGrd.Parameters.Add("P_ORDER_METHOD", OracleDbType.Int32).Value = objEntityEmpSlry.OrderMethod;
          cmdReadPayGrd.Parameters.Add("P_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityEmpSlry.PageMaxSize;
          cmdReadPayGrd.Parameters.Add("P_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityEmpSlry.PageNumber;
          //---------------pagination------------//

          cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtEmpSlry = new DataTable();
          dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
          return dtEmpSlry;
      }
      public void AddLedger(clsEntityLedger objEntityEmpSlry, List<clsEntityLedger> objEntitySubLdgrList)
      {
          
          //---ledger code--
          //commented by evm 0044 21/01/2020
          //if (objEntityEmpSlry.CodePrsntSts == 1)//allow add code
          //{
          //    if (objEntityEmpSlry.CodeSts == 0)//code format automatically
          //    {
          //        clsCommonLibrary objCommon = new clsCommonLibrary();
          //        clsEntityCommon objEntityCommon = new clsEntityCommon();
          //        clsEntityLedger objEntityLedger = new clsEntityLedger();

          //        clsDataLayer ObjDataLayer = new clsDataLayer();
          //        if (objEntityEmpSlry.Corp_Id != null)
          //        {
          //            objEntityCommon.CorporateID = objEntityEmpSlry.Corp_Id;
          //            objEntityLedger.Corp_Id = objEntityEmpSlry.Corp_Id;
          //        }

          //        if (objEntityEmpSlry.Org_Id != null)
          //        {
          //            objEntityCommon.Organisation_Id = objEntityEmpSlry.Org_Id;
          //            objEntityLedger.Org_Id = objEntityEmpSlry.Org_Id;
          //        }

          //        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.FMS_LEDGER_MASTER);
          //        DataTable dtFormate = ObjDataLayer.ReadCodeFormate(objEntityCommon);
          //        string refFormatByDiv = "";
          //        string strRealFormat = "";

          //        DataTable dt = new DataTable();
          //        if (objEntityEmpSlry.SubLedgerId == 0)
          //        {
          //            if (objEntityEmpSlry.AccountGrpId != 0)
          //            {
          //                objEntityLedger.LedgerId = objEntityEmpSlry.AccountGrpId;
          //            }
          //            objEntityLedger.LedgerAcntGrpSts = 0;
          //            dt = ReadAccountGrp_Of_Ledgr(objEntityLedger);
          //        }
          //        else
          //        {
          //            if (objEntityEmpSlry.SubLedgerId != 0)
          //            {
          //                objEntityLedger.LedgerId = objEntityEmpSlry.SubLedgerId;
          //                objEntityLedger.LedgerAcntGrpSts = 1;
          //                dt = ReadAccountGrp_Of_Ledgr(objEntityLedger);
          //            }
          //        }

          //        string dtNextNumber = ObjDataLayer.ReadNextNumberSequanceForUI(objEntityCommon);

          //        if (dtFormate.Rows.Count > 0)
          //        {
          //            if (dt.Rows.Count > 0)
          //            {
          //                if (objEntityEmpSlry.CodeFormatNumber == 0)
          //                {
          //                    string StrAcntGrpId = "";
          //                    int NaureCode = 0;
          //                    string CodeFormate = "";
          //                    int intNature = Convert.ToInt32(dt.Rows[0]["ACNT_NATURE_STS"].ToString());
          //                    StrAcntGrpId = dt.Rows[0]["ACNT_GRP_ID"].ToString();

          //                    if (intNature == 0)
          //                    {
          //                        NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Asset);
          //                    }
          //                    else if (intNature == 1)
          //                    {
          //                        NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Liability);
          //                    }
          //                    else if (intNature == 2)
          //                    {
          //                        NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Expense);
          //                    }
          //                    else if (intNature == 3)
          //                    {
          //                        NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Income);
          //                    }

          //                    if (dtFormate.Rows[0]["CODE_FORMATE"].ToString() != "")
          //                    {
          //                        refFormatByDiv = dtFormate.Rows[0]["CODE_FORMATE"].ToString();
          //                        string strReferenceFormat = "";
          //                        strReferenceFormat = refFormatByDiv;
          //                        string[] arrReferenceSplit = strReferenceFormat.Split('*');
          //                        int intArrayRowCount = arrReferenceSplit.Length;
          //                        int Codecount = 0;
          //                        strRealFormat = refFormatByDiv.ToString();
          //                        if (dtFormate.Rows[0]["CODE_COUNT"].ToString() != "")
          //                        {
          //                            Codecount = Convert.ToInt32(dtFormate.Rows[0]["CODE_COUNT"].ToString());
          //                        }

          //                        if (strRealFormat.Contains("#NAT#"))
          //                        {
          //                            strRealFormat = strRealFormat.Replace("#NAT#", NaureCode.ToString());
          //                        }
          //                        if (strRealFormat.Contains("#ACNTGRP#"))
          //                        {
          //                            strRealFormat = strRealFormat.Replace("#ACNTGRP#", StrAcntGrpId);
          //                        }
          //                        if (strRealFormat.Contains("#NUM#"))
          //                        {
          //                            strRealFormat = strRealFormat.Replace("#NUM#", dtNextNumber);
          //                        }

          //                        int k = strRealFormat.Length;
          //                        if (k < Codecount)
          //                        {
          //                            int Difrnce = Codecount - k;
          //                            k = k + Difrnce;
          //                            //  hello.PadLeft(50, '#');
          //                            strRealFormat = strRealFormat.PadLeft(k, '0');
          //                        }

          //                        objEntityEmpSlry.LdgrCode = strRealFormat;
          //                    }
          //                    else
          //                    {
          //                        strRealFormat = dtNextNumber;
          //                    }
          //                }
          //                else
          //                {
          //                    objEntityEmpSlry.LdgrCode = dtNextNumber;
          //                }
          //            }
          //        }
          //        else
          //        {
          //            objEntityEmpSlry.LdgrCode = dtNextNumber;
          //        }
          //    }
          //}
          //else
          //{
          //    objEntityEmpSlry.LdgrCode = null;
          //}
          //---ledger code--


          OracleTransaction tran;

          using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
          {
              con.Open();
              tran = con.BeginTransaction();

              try
              {
                  string strQueryReadEmpSlry = "FMS_LEDGER.SP_ADD_LEDGER";
                  using (OracleCommand cmdReadPayGrd = new OracleCommand(strQueryReadEmpSlry, con))
                  {
                      cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
                      cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                      cmdReadPayGrd.Transaction = tran;

                      cmdReadPayGrd.Parameters.Add("L_NAME", OracleDbType.Varchar2).Value = objEntityEmpSlry.LedgerName;
                      if (objEntityEmpSlry.AccountGrpId == 0)
                      {
                          cmdReadPayGrd.Parameters.Add("L_ACCNT_GRP_ID", OracleDbType.Int32).Value = DBNull.Value;
                      }
                      else
                      {
                          cmdReadPayGrd.Parameters.Add("L_ACCNT_GRP_ID", OracleDbType.Int32).Value = objEntityEmpSlry.AccountGrpId;
                      }
                      //cmdReadPayGrd.Parameters.Add("L_CURRENCY_ID", OracleDbType.Int32).Value = objEntityEmpSlry.CurrencyId;
                      cmdReadPayGrd.Parameters.Add("L_STS", OracleDbType.Int32).Value = objEntityEmpSlry.Status;
                      cmdReadPayGrd.Parameters.Add("L_TDS_STS", OracleDbType.Int32).Value = objEntityEmpSlry.TDSstatus;
                      cmdReadPayGrd.Parameters.Add("L_TCS_STS", OracleDbType.Int32).Value = objEntityEmpSlry.TCSstatus;
                      cmdReadPayGrd.Parameters.Add("L_COST_STS", OracleDbType.Int32).Value = objEntityEmpSlry.CostCenterSts;
                      cmdReadPayGrd.Parameters.Add("L_COMM_NAME", OracleDbType.Varchar2).Value = objEntityEmpSlry.ContactName;
                      if (objEntityEmpSlry.LedgerZIP != 0)
                      {
                          cmdReadPayGrd.Parameters.Add("L_PIN", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerZIP;
                      }
                      else
                      {
                          cmdReadPayGrd.Parameters.Add("L_PIN", OracleDbType.Int32).Value = DBNull.Value;
                      }
                      cmdReadPayGrd.Parameters.Add("L_TAX", OracleDbType.Varchar2).Value = objEntityEmpSlry.LedgerTax;
                      cmdReadPayGrd.Parameters.Add("L_ADDRESS", OracleDbType.Varchar2).Value = objEntityEmpSlry.LedgerAddess;
                      cmdReadPayGrd.Parameters.Add("L_USER_ID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
                      cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
                      cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
                      if (objEntityEmpSlry.TxEnabledSts == 0)
                      {
                          cmdReadPayGrd.Parameters.Add("L_TDSID", OracleDbType.Int32).Value = DBNull.Value;
                          cmdReadPayGrd.Parameters.Add("L_TCSID", OracleDbType.Int32).Value = DBNull.Value;
                      }
                      else
                      {
                          if (objEntityEmpSlry.TDSstatus == 0)
                          {
                              cmdReadPayGrd.Parameters.Add("L_TDSID", OracleDbType.Int32).Value = objEntityEmpSlry.TDSid;
                          }
                          else
                          {
                              cmdReadPayGrd.Parameters.Add("L_TDSID", OracleDbType.Int32).Value = DBNull.Value;
                          }
                          if (objEntityEmpSlry.TCSstatus == 0)
                          {
                              cmdReadPayGrd.Parameters.Add("L_TCSID", OracleDbType.Int32).Value = objEntityEmpSlry.TCSid;
                          }
                          else
                          {
                              cmdReadPayGrd.Parameters.Add("L_TCSID", OracleDbType.Int32).Value = DBNull.Value;
                          }
                      }
                      if (objEntityEmpSlry.DebitBalance != 0)
                      {
                          cmdReadPayGrd.Parameters.Add("L_OPEN_BAL", OracleDbType.Decimal).Value = objEntityEmpSlry.DebitBalance;
                      }
                      else
                      {
                          cmdReadPayGrd.Parameters.Add("L_OPEN_BAL", OracleDbType.Decimal).Value = DBNull.Value;
                      }
                      //if (objEntityEmpSlry.CreditBalance != 0)
                      //{
                      //    cmdReadPayGrd.Parameters.Add("L_CURRENT_BAL", OracleDbType.Decimal).Value = objEntityEmpSlry.CreditBalance;
                      //}
                      //else
                      //{
                      //    cmdReadPayGrd.Parameters.Add("L_CURRENT_BAL", OracleDbType.Decimal).Value = DBNull.Value;
                      //}
                      cmdReadPayGrd.Parameters.Add("L_LDGR_MODE", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerStatus;

                      cmdReadPayGrd.Parameters.Add("L_PAGE_STS", OracleDbType.Int32).Value = objEntityEmpSlry.PageSts;
                      if (objEntityEmpSlry.EffectiveDate != DateTime.MinValue)
                      {
                          cmdReadPayGrd.Parameters.Add("L_EFFECTVE_DATE", OracleDbType.Date).Value = objEntityEmpSlry.EffectiveDate;
                      }
                      else
                      {
                          cmdReadPayGrd.Parameters.Add("L_EFFECTVE_DATE", OracleDbType.Date).Value = DBNull.Value;
                      }
                      if (objEntityEmpSlry.CostCenterID != 0)
                      {
                          cmdReadPayGrd.Parameters.Add("L_COSTID", OracleDbType.Int32).Value = objEntityEmpSlry.CostCenterID;
                      }
                      else
                      {
                          cmdReadPayGrd.Parameters.Add("L_COSTID", OracleDbType.Int32).Value = DBNull.Value;
                      }
                      cmdReadPayGrd.Parameters.Add("L_SUB_LDGR_STS", OracleDbType.Int32).Value = objEntityEmpSlry.SubLedgerStatus;
                      if (objEntityEmpSlry.SubLedgerId == 0)
                      {
                          cmdReadPayGrd.Parameters.Add("L_SUB_LDGR_ID", OracleDbType.Int32).Value = DBNull.Value;
                      }
                      else
                      {
                          cmdReadPayGrd.Parameters.Add("L_SUB_LDGR_ID", OracleDbType.Int32).Value = objEntityEmpSlry.SubLedgerId;
                      }
                      cmdReadPayGrd.Parameters.Add("L_BANK_ID", OracleDbType.Int32).Value = objEntityEmpSlry.BankId;
                      cmdReadPayGrd.Parameters.Add("L_CSTMRSUPLRSTS", OracleDbType.Int32).Value = objEntityEmpSlry.CustmrSupplierSts;
                      cmdReadPayGrd.Parameters.Add("L_CODE", OracleDbType.Varchar2).Value = objEntityEmpSlry.LdgrCode;
                      if (objEntityEmpSlry.CreditLimit != 0)
                      {
                          cmdReadPayGrd.Parameters.Add("L_CRDTLMT", OracleDbType.Decimal).Value = objEntityEmpSlry.CreditLimit;
                      }
                      else
                      {
                          cmdReadPayGrd.Parameters.Add("L_CRDTLMT", OracleDbType.Decimal).Value = DBNull.Value;
                      }
                      cmdReadPayGrd.Parameters.Add("L_CRDTLMT_RESTRICT", OracleDbType.Int32).Value = objEntityEmpSlry.CreditLimitRestrict;
                      cmdReadPayGrd.Parameters.Add("L_CRDTLMT_WARN", OracleDbType.Int32).Value = objEntityEmpSlry.CreditLimitWarn;
                      if (objEntityEmpSlry.CreditPeriod != 0)
                      {
                          cmdReadPayGrd.Parameters.Add("L_CRDTPRD", OracleDbType.Int32).Value = objEntityEmpSlry.CreditPeriod;
                      }
                      else
                      {
                          cmdReadPayGrd.Parameters.Add("L_CRDTPRD", OracleDbType.Int32).Value = DBNull.Value;
                      }
                      cmdReadPayGrd.Parameters.Add("L_CRDTPRD_RESTRICT", OracleDbType.Int32).Value = objEntityEmpSlry.CreditPeriodRestrict;
                      cmdReadPayGrd.Parameters.Add("L_CRDTPRD_WARN", OracleDbType.Int32).Value = objEntityEmpSlry.CreditPeriodWarn;

                      cmdReadPayGrd.Parameters.Add("L_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;

                      cmdReadPayGrd.ExecuteScalar();
                      string strReturn = cmdReadPayGrd.Parameters["L_ID"].Value.ToString();
                      cmdReadPayGrd.Dispose();
                      objEntityEmpSlry.LedgerId= Convert.ToInt32(strReturn);
                     
                    
                  }

                  if (objEntitySubLdgrList.Count > 0)
                  {
                      foreach (clsEntityLedger objSubDetail in objEntitySubLdgrList)
                      {
                          string strQueryReadEmpSlryDtl = "FMS_LEDGER.SP_INSERT_SUBLEDGERDTLS";
                          using (OracleCommand cmdReadPayGrd = new OracleCommand(strQueryReadEmpSlryDtl, con))
                          {
                              cmdReadPayGrd.Transaction = tran;
                              cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                              cmdReadPayGrd.Parameters.Add("L_LDGRID", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerId;
                              cmdReadPayGrd.Parameters.Add("L_SUBLDGRID", OracleDbType.Int32).Value = objSubDetail.SubLedgerId;
                              cmdReadPayGrd.Parameters.Add("L_LEVEL", OracleDbType.Int32).Value = objSubDetail.Level;
                              cmdReadPayGrd.ExecuteNonQuery();
                          }
                      }

                      string strQueryReadEmpSlryDtl1 = "FMS_LEDGER.SP_INSERT_SUBLEDGERDTLS";
                      using (OracleCommand cmdReadPayGrd = new OracleCommand(strQueryReadEmpSlryDtl1, con))
                      {
                          cmdReadPayGrd.Transaction = tran;
                          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                          cmdReadPayGrd.Parameters.Add("L_LDGRID", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerId;
                          cmdReadPayGrd.Parameters.Add("L_SUBLDGRID", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerId;
                          cmdReadPayGrd.Parameters.Add("L_LEVEL", OracleDbType.Int32).Value = 0;
                          cmdReadPayGrd.ExecuteNonQuery();
                      }
                  }
                  else
                  {
                      string strQueryReadEmpSlryDtl = "FMS_LEDGER.SP_INSERT_SUBLEDGERDTLS";
                      using (OracleCommand cmdReadPayGrd = new OracleCommand(strQueryReadEmpSlryDtl, con))
                      {
                          cmdReadPayGrd.Transaction = tran;
                          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                          cmdReadPayGrd.Parameters.Add("L_LDGRID", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerId;
                          cmdReadPayGrd.Parameters.Add("L_SUBLDGRID", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerId;
                          cmdReadPayGrd.Parameters.Add("L_LEVEL", OracleDbType.Int32).Value = 0;
                          cmdReadPayGrd.ExecuteNonQuery();
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
      //evm 0044------
      public void UpdateLedgerId(int ledgerId)
      {
            OracleTransaction tran;

            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {

                    string strQueryUpdateLedgerId = "FMS_LEDGER.SP_UPD_LEDGER_ID";
                    using (OracleCommand cmdUpdtLdgrId = new OracleCommand(strQueryUpdateLedgerId, con))
                    {
                        cmdUpdtLdgrId.Transaction = tran;
                        cmdUpdtLdgrId.CommandType = CommandType.StoredProcedure;
                        cmdUpdtLdgrId.Parameters.Add("L_LDGRID", OracleDbType.Int32).Value = ledgerId;
                        cmdUpdtLdgrId.ExecuteNonQuery();
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
      //-----------------
      public void UpdateLedger(clsEntityLedger objEntityEmpSlry, List<clsEntityLedger> objEntitySubLdgrList)
      {

          //if (objEntityEmpSlry.CodePrsntSts == 1)//allow add code
          //{
          //    if (objEntityEmpSlry.CodeSts == 0)//code format automatically
          //    {
          //        DataTable CheckNatureChange = ReadLedgerDtlsById(objEntityEmpSlry);
          //        if (CheckNatureChange.Rows.Count > 0)
          //        {
          //            if ((objEntityEmpSlry.AccountGrpId != 0 && (Convert.ToInt32(CheckNatureChange.Rows[0]["ACNT_GRP_ID"].ToString()) != objEntityEmpSlry.AccountGrpId)) || (objEntityEmpSlry.SubLedgerId != 0 && (Convert.ToInt32(CheckNatureChange.Rows[0]["SUBLEDGERID"].ToString()) != objEntityEmpSlry.SubLedgerId)))
          //            {
          //                clsCommonLibrary objCommon = new clsCommonLibrary();
          //                clsEntityCommon objEntityCommon = new clsEntityCommon();
          //                clsEntityLedger objEntityLedger = new clsEntityLedger();

          //                clsDataLayer ObjDataLayer = new clsDataLayer();
          //                if (objEntityEmpSlry.Corp_Id != null)
          //                {
          //                    objEntityCommon.CorporateID = objEntityEmpSlry.Corp_Id;
          //                    objEntityLedger.Corp_Id = objEntityEmpSlry.Corp_Id;
          //                }

          //                if (objEntityEmpSlry.Org_Id != null)
          //                {
          //                    objEntityCommon.Organisation_Id = objEntityEmpSlry.Org_Id;
          //                    objEntityLedger.Org_Id = objEntityEmpSlry.Org_Id;
          //                }

          //                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.FMS_LEDGER_MASTER);
          //                DataTable dtFormate = ObjDataLayer.ReadCodeFormate(objEntityCommon);
          //                string refFormatByDiv = "";
          //                string strRealFormat = "";

          //                DataTable dt = new DataTable();
          //                if (objEntityEmpSlry.SubLedgerId == 0)
          //                {
          //                    if (objEntityEmpSlry.AccountGrpId != 0)
          //                    {
          //                        objEntityLedger.LedgerId = objEntityEmpSlry.AccountGrpId;
          //                    }
          //                    objEntityLedger.LedgerAcntGrpSts = 0;
          //                    dt = ReadAccountGrp_Of_Ledgr(objEntityLedger);
          //                }
          //                else
          //                {
          //                    if (objEntityEmpSlry.SubLedgerId != 0)
          //                    {
          //                        objEntityLedger.LedgerId = objEntityEmpSlry.SubLedgerId;
          //                        objEntityLedger.LedgerAcntGrpSts = 1;
          //                        dt = ReadAccountGrp_Of_Ledgr(objEntityLedger);
          //                    }
          //                }

          //                string dtNextNumber = ObjDataLayer.ReadNextNumberSequanceForUI(objEntityCommon);

          //                if (dtFormate.Rows.Count > 0)
          //                {
          //                    if (dt.Rows.Count > 0)
          //                    {
          //                        if (objEntityEmpSlry.CodeFormatNumber == 0)
          //                        {
          //                            string StrAcntGrpId = "";
          //                            int NaureCode = 0;
          //                            int intNature = Convert.ToInt32(dt.Rows[0]["ACNT_NATURE_STS"].ToString());
          //                            StrAcntGrpId = dt.Rows[0]["ACNT_GRP_ID"].ToString();

          //                            if (intNature == 0)
          //                            {
          //                                NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Asset);
          //                            }
          //                            else if (intNature == 1)
          //                            {
          //                                NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Liability);
          //                            }
          //                            else if (intNature == 2)
          //                            {
          //                                NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Expense);
          //                            }
          //                            else if (intNature == 3)
          //                            {
          //                                NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Income);
          //                            }

          //                            if (dtFormate.Rows[0]["CODE_FORMATE"].ToString() != "")
          //                            {
          //                                refFormatByDiv = dtFormate.Rows[0]["CODE_FORMATE"].ToString();
          //                                string strReferenceFormat = "";
          //                                strReferenceFormat = refFormatByDiv;
          //                                string[] arrReferenceSplit = strReferenceFormat.Split('*');
          //                                int intArrayRowCount = arrReferenceSplit.Length;
          //                                int Codecount = 0;
          //                                strRealFormat = refFormatByDiv.ToString();

          //                                if (dtFormate.Rows[0]["CODE_COUNT"].ToString() != "")
          //                                {
          //                                    Codecount = Convert.ToInt32(dtFormate.Rows[0]["CODE_COUNT"].ToString());
          //                                }

          //                                if (strRealFormat.Contains("#NAT#"))
          //                                {
          //                                    strRealFormat = strRealFormat.Replace("#NAT#", NaureCode.ToString());
          //                                }
          //                                if (strRealFormat.Contains("#ACNTGRP#"))
          //                                {
          //                                    strRealFormat = strRealFormat.Replace("#ACNTGRP#", StrAcntGrpId);
          //                                }
          //                                if (strRealFormat.Contains("#NUM#"))
          //                                {
          //                                    strRealFormat = strRealFormat.Replace("#NUM#", dtNextNumber);
          //                                }

          //                                int k = strRealFormat.Length;
          //                                if (k < Codecount)
          //                                {
          //                                    int Difrnce = Codecount - k;
          //                                    k = k + Difrnce;
          //                                    //  hello.PadLeft(50, '#');
          //                                    strRealFormat = strRealFormat.PadLeft(k, '0');
          //                                }
          //                                objEntityEmpSlry.LdgrCode = strRealFormat;
          //                            }
          //                            else
          //                            {
          //                                objEntityEmpSlry.LdgrCode = dtNextNumber;
          //                            }
          //                        }
          //                        else
          //                        {
          //                            objEntityEmpSlry.LdgrCode = dtNextNumber;
          //                        }
          //                    }
          //                }
          //                else
          //                {
          //                    objEntityEmpSlry.LdgrCode = dtNextNumber;
          //                }
          //            }
          //        }
          //    }
          //}
          //else
          //{
          //    objEntityEmpSlry.LdgrCode = null;
          //}
          //---ledger code--


          OracleTransaction tran;

          using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
          {
              con.Open();
              tran = con.BeginTransaction();

              try
              {
                  string strQueryReadEmpSlry = "FMS_LEDGER.SP_UPD_LEDGER";
                  using (OracleCommand cmdReadPayGrd = new OracleCommand(strQueryReadEmpSlry, con))
                  {
                      cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
                      cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                      cmdReadPayGrd.Transaction = tran;

                      cmdReadPayGrd.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerId;
                      cmdReadPayGrd.Parameters.Add("L_NAME", OracleDbType.Varchar2).Value = objEntityEmpSlry.LedgerName;
                      // cmdReadPayGrd.Parameters.Add("L_ACCNT_GRP_ID", OracleDbType.Int32).Value = objEntityEmpSlry.AccountGrpId;

                      if (objEntityEmpSlry.AccountGrpId == 0)
                      {
                          cmdReadPayGrd.Parameters.Add("L_ACCNT_GRP_ID", OracleDbType.Int32).Value = null;
                      }
                      else
                      {
                          cmdReadPayGrd.Parameters.Add("L_ACCNT_GRP_ID", OracleDbType.Int32).Value = objEntityEmpSlry.AccountGrpId;
                      }
                      //cmdReadPayGrd.Parameters.Add("L_CURRENCY_ID", OracleDbType.Int32).Value = objEntityEmpSlry.CurrencyId;
                      cmdReadPayGrd.Parameters.Add("L_STS", OracleDbType.Int32).Value = objEntityEmpSlry.Status;
                      cmdReadPayGrd.Parameters.Add("L_TDS_STS", OracleDbType.Int32).Value = objEntityEmpSlry.TDSstatus;
                      cmdReadPayGrd.Parameters.Add("L_TCS_STS", OracleDbType.Int32).Value = objEntityEmpSlry.TCSstatus;
                      cmdReadPayGrd.Parameters.Add("L_COST_STS", OracleDbType.Int32).Value = objEntityEmpSlry.CostCenterSts;
                      cmdReadPayGrd.Parameters.Add("L_COMM_NAME", OracleDbType.Varchar2).Value = objEntityEmpSlry.ContactName;
                      if (objEntityEmpSlry.LedgerZIP != 0)
                      {
                          cmdReadPayGrd.Parameters.Add("L_PIN", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerZIP;
                      }
                      else
                      {
                          cmdReadPayGrd.Parameters.Add("L_PIN", OracleDbType.Int32).Value = DBNull.Value;
                      }
                      cmdReadPayGrd.Parameters.Add("L_TAX", OracleDbType.Varchar2).Value = objEntityEmpSlry.LedgerTax;
                      cmdReadPayGrd.Parameters.Add("L_ADDRESS", OracleDbType.Varchar2).Value = objEntityEmpSlry.LedgerAddess;


                      cmdReadPayGrd.Parameters.Add("L_USER_ID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;

                      if (objEntityEmpSlry.TxEnabledSts == 0)
                      {
                          cmdReadPayGrd.Parameters.Add("L_TDSID", OracleDbType.Int32).Value = DBNull.Value;
                          cmdReadPayGrd.Parameters.Add("L_TCSID", OracleDbType.Int32).Value = DBNull.Value;
                      }
                      else
                      {

                          if (objEntityEmpSlry.TDSstatus == 0)
                          {
                              cmdReadPayGrd.Parameters.Add("L_TDSID", OracleDbType.Int32).Value = objEntityEmpSlry.TDSid;
                          }
                          else
                          {
                              cmdReadPayGrd.Parameters.Add("L_TDSID", OracleDbType.Int32).Value = DBNull.Value;
                          }
                          if (objEntityEmpSlry.TCSstatus == 0)
                          {
                              cmdReadPayGrd.Parameters.Add("L_TCSID", OracleDbType.Int32).Value = objEntityEmpSlry.TCSid;
                          }
                          else
                          {
                              cmdReadPayGrd.Parameters.Add("L_TCSID", OracleDbType.Int32).Value = DBNull.Value;
                          }
                      }
                      if (objEntityEmpSlry.CostCenterID != 0)
                      {
                          cmdReadPayGrd.Parameters.Add("L_COSTID", OracleDbType.Int32).Value = objEntityEmpSlry.CostCenterID;
                      }
                      else
                      {
                          cmdReadPayGrd.Parameters.Add("L_COSTID", OracleDbType.Int32).Value = DBNull.Value;
                      }

                      if (objEntityEmpSlry.DebitBalance != 0)
                      {
                          cmdReadPayGrd.Parameters.Add("L_OPEN_BAL", OracleDbType.Decimal).Value = objEntityEmpSlry.DebitBalance;
                      }
                      else
                      {
                          cmdReadPayGrd.Parameters.Add("L_OPEN_BAL", OracleDbType.Decimal).Value = DBNull.Value;
                      }
                      //if (objEntityEmpSlry.CreditBalance != 0)
                      //{
                      //    cmdReadPayGrd.Parameters.Add("L_CURRENT_BAL", OracleDbType.Decimal).Value = objEntityEmpSlry.CreditBalance;
                      //}
                      //else
                      //{
                      //    cmdReadPayGrd.Parameters.Add("L_CURRENT_BAL", OracleDbType.Decimal).Value = DBNull.Value;
                      //}
                      cmdReadPayGrd.Parameters.Add("L_LDGR_MODE", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerStatus;
                      if (objEntityEmpSlry.EffectiveDate != DateTime.MinValue)
                      {
                          cmdReadPayGrd.Parameters.Add("L_EFFECTVE_DATE", OracleDbType.Date).Value = objEntityEmpSlry.EffectiveDate;
                      }
                      else
                      {
                          cmdReadPayGrd.Parameters.Add("L_EFFECTVE_DATE", OracleDbType.Date).Value = DBNull.Value;
                      }
                      cmdReadPayGrd.Parameters.Add("L_SUB_LDGR_STS", OracleDbType.Int32).Value = objEntityEmpSlry.SubLedgerStatus;
                      if (objEntityEmpSlry.SubLedgerId == 0)
                      {
                          cmdReadPayGrd.Parameters.Add("L_SUB_LDGR_ID", OracleDbType.Int32).Value = null;
                      }
                      else
                      {
                          cmdReadPayGrd.Parameters.Add("L_SUB_LDGR_ID", OracleDbType.Int32).Value = objEntityEmpSlry.SubLedgerId;
                      }
                      cmdReadPayGrd.Parameters.Add("L_BANK_ID", OracleDbType.Int32).Value = objEntityEmpSlry.BankId;
                      cmdReadPayGrd.Parameters.Add("L_CSTMRSUPLRSTS", OracleDbType.Int32).Value = objEntityEmpSlry.CustmrSupplierSts;
                      cmdReadPayGrd.Parameters.Add("L_CODE", OracleDbType.Varchar2).Value = objEntityEmpSlry.LdgrCode;
                      cmdReadPayGrd.Parameters.Add("L_VOCHRID", OracleDbType.Int32).Value = objEntityEmpSlry.VouchrId;
                      if (objEntityEmpSlry.CreditLimit != 0)
                      {
                          cmdReadPayGrd.Parameters.Add("L_CRDTLMT", OracleDbType.Decimal).Value = objEntityEmpSlry.CreditLimit;
                      }
                      else
                      {
                          cmdReadPayGrd.Parameters.Add("L_CRDTLMT", OracleDbType.Decimal).Value = DBNull.Value;
                      }
                      cmdReadPayGrd.Parameters.Add("L_CRDTLMT_RESTRICT", OracleDbType.Int32).Value = objEntityEmpSlry.CreditLimitRestrict;
                      cmdReadPayGrd.Parameters.Add("L_CRDTLMT_WARN", OracleDbType.Int32).Value = objEntityEmpSlry.CreditLimitWarn;
                      if (objEntityEmpSlry.CreditPeriod != 0)
                      {
                          cmdReadPayGrd.Parameters.Add("L_CRDTPRD", OracleDbType.Int32).Value = objEntityEmpSlry.CreditPeriod;
                      }
                      else
                      {
                          cmdReadPayGrd.Parameters.Add("L_CRDTPRD", OracleDbType.Int32).Value = DBNull.Value;
                      }
                      cmdReadPayGrd.Parameters.Add("L_CRDTPRD_RESTRICT", OracleDbType.Int32).Value = objEntityEmpSlry.CreditPeriodRestrict;
                      cmdReadPayGrd.Parameters.Add("L_CRDTPRD_WARN", OracleDbType.Int32).Value = objEntityEmpSlry.CreditPeriodWarn;

                      cmdReadPayGrd.ExecuteNonQuery();
                  }

                  string strQueryReadEmpSlryDel = "FMS_LEDGER.SP_DELETE_SUBLDGR";
                  OracleCommand cmdReadPayGrdDel = new OracleCommand();
                  cmdReadPayGrdDel.CommandText = strQueryReadEmpSlryDel;
                  cmdReadPayGrdDel.CommandType = CommandType.StoredProcedure;
                  cmdReadPayGrdDel.Parameters.Add("L_LDGRID", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerId;
                  clsDataLayer.ExecuteNonQuery(cmdReadPayGrdDel);

                  if (objEntitySubLdgrList.Count > 0)
                  {
                      foreach (clsEntityLedger objSubDetail in objEntitySubLdgrList)
                      {
                          string strQueryReadEmpSlryDtl = "FMS_LEDGER.SP_INSERT_SUBLEDGERDTLS";
                          using (OracleCommand cmdReadPayGrd = new OracleCommand(strQueryReadEmpSlryDtl, con))
                          {
                              cmdReadPayGrd.Transaction = tran;
                              cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                              cmdReadPayGrd.Parameters.Add("L_LDGRID", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerId;
                              cmdReadPayGrd.Parameters.Add("L_SUBLDGRID", OracleDbType.Int32).Value = objSubDetail.SubLedgerId;
                              cmdReadPayGrd.Parameters.Add("L_LEVEL", OracleDbType.Int32).Value = objSubDetail.Level;
                              cmdReadPayGrd.ExecuteNonQuery();
                          }
                      }

                      string strQueryReadEmpSlryDtl1 = "FMS_LEDGER.SP_INSERT_SUBLEDGERDTLS";
                      using (OracleCommand cmdReadPayGrd = new OracleCommand(strQueryReadEmpSlryDtl1, con))
                      {
                          cmdReadPayGrd.Transaction = tran;
                          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                          cmdReadPayGrd.Parameters.Add("L_LDGRID", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerId;
                          cmdReadPayGrd.Parameters.Add("L_SUBLDGRID", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerId;
                          cmdReadPayGrd.Parameters.Add("L_LEVEL", OracleDbType.Int32).Value = 0;
                          cmdReadPayGrd.ExecuteNonQuery();
                      }
                  }
                  else
                  {
                      string strQueryReadEmpSlryDtl = "FMS_LEDGER.SP_INSERT_SUBLEDGERDTLS";
                      using (OracleCommand cmdReadPayGrd = new OracleCommand(strQueryReadEmpSlryDtl, con))
                      {
                          cmdReadPayGrd.Transaction = tran;
                          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                          cmdReadPayGrd.Parameters.Add("L_LDGRID", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerId;
                          cmdReadPayGrd.Parameters.Add("L_SUBLDGRID", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerId;
                          cmdReadPayGrd.Parameters.Add("L_LEVEL", OracleDbType.Int32).Value = 0;
                          cmdReadPayGrd.ExecuteNonQuery();
                      }
                  }

                  if (objEntityEmpSlry.CostCenterID != 0)
                  {
                      string strQueryReadEmpSlry1 = "FMS_LEDGER.SP_UPD_CSTCNTR";
                      OracleCommand cmdReadPayGrd1 = new OracleCommand();
                      cmdReadPayGrd1.CommandText = strQueryReadEmpSlry1;
                      cmdReadPayGrd1.CommandType = CommandType.StoredProcedure;
                      cmdReadPayGrd1.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerId;
                      cmdReadPayGrd1.Parameters.Add("L_CID", OracleDbType.Int32).Value = objEntityEmpSlry.CostCenterID;
                      clsDataLayer.ExecuteNonQuery(cmdReadPayGrd1);
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

      public void CancelLedger(clsEntityLedger objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_LEDGER.SP_CANCEL_LEDGER";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerId;
          cmdReadPayGrd.Parameters.Add("L_CNCL_REASON", OracleDbType.Varchar2).Value = objEntityEmpSlry.Cancel_Reason;
          cmdReadPayGrd.Parameters.Add("L_USER_ID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
          clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
      }
      public DataTable CheckDupName(clsEntityLedger objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_LEDGER.SP_CHECK_DUP_NAME";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerId;
          cmdReadPayGrd.Parameters.Add("L_NAME", OracleDbType.Varchar2).Value = objEntityEmpSlry.LedgerName;
          cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
          cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
          cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtEmpSlry = new DataTable();
          dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
          return dtEmpSlry;
      }

      public DataTable ReadLedgerTaxationSystem(clsEntityLedger objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_LEDGER.SP_READ_TAXATION_TYPE";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
          cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
          cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtEmpSlry = new DataTable();
          dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
          return dtEmpSlry;
      }
      public DataTable ReadAddressApplicable(clsEntityLedger objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_LEDGER.SP_READ_ADRS_APLICABLE";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
          cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
          cmdReadPayGrd.Parameters.Add("L_ACCNT_GRP_ID", OracleDbType.Int32).Value = objEntityEmpSlry.AccountGrpId;
          cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtEmpSlry = new DataTable();
          dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
          return dtEmpSlry;
      }
      public DataTable CheckAccountGroup(clsEntityLedger objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_LEDGER.SP_CHK_ACCOUNT_GROUP";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
          cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
          if (objEntityEmpSlry.AccountGrpId != 0)
          {
              cmdReadPayGrd.Parameters.Add("L_ACCNT_GRP_ID", OracleDbType.Int32).Value = objEntityEmpSlry.AccountGrpId;
          }
          else
          {
              cmdReadPayGrd.Parameters.Add("L_ACCNT_GRP_ID", OracleDbType.Int32).Value = DBNull.Value;
          }
          if (objEntityEmpSlry.SubLedgerId != 0)
          {
              cmdReadPayGrd.Parameters.Add("L_SUBLDGRID", OracleDbType.Int32).Value = objEntityEmpSlry.SubLedgerId;
          }
          else
          {
              cmdReadPayGrd.Parameters.Add("L_SUBLDGRID", OracleDbType.Int32).Value = DBNull.Value;
          }
          cmdReadPayGrd.Parameters.Add("L_PRMRYGRP", OracleDbType.Int32).Value = objEntityEmpSlry.PrimaryGrp;
          cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtEmpSlry = new DataTable();
          dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
          return dtEmpSlry;
      }
      public DataTable ReadAccountGrp_Of_Ledgr(clsEntityLedger objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_LEDGER.SP_RD_ACCOUNT_GROUP_FOR_LDGR";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
          cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
          cmdReadPayGrd.Parameters.Add("L_LDGR_ID", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerId;
          cmdReadPayGrd.Parameters.Add("L_STS", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerAcntGrpSts;

          cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtEmpSlry = new DataTable();
          dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
          return dtEmpSlry;
      }

      public string CheckCodeDuplicatn(clsEntityLedger objEntityAccountGroup)
      {
          string strQueryAddBank = "FMS_LEDGER.SP_CHECK_DUP_CODE";
          OracleCommand cmdAddBankName = new OracleCommand();
          cmdAddBankName.CommandText = strQueryAddBank;
          cmdAddBankName.CommandType = CommandType.StoredProcedure;
          cmdAddBankName.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityAccountGroup.LedgerId;
          cmdAddBankName.Parameters.Add("B_CODE", OracleDbType.Varchar2).Value = objEntityAccountGroup.LdgrCode;
          cmdAddBankName.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityAccountGroup.Corp_Id;
          cmdAddBankName.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityAccountGroup.Org_Id;
          cmdAddBankName.Parameters.Add("B_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
          clsDataLayer.ExecuteScalar(ref cmdAddBankName);
          string strReturn = cmdAddBankName.Parameters["B_COUNT"].Value.ToString();
          cmdAddBankName.Dispose();
          return strReturn;
      }

      public DataTable ReadSubLedgers(clsEntityLedger objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_LEDGER.SP_READ_HIERACHY";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("L_LDGRID", OracleDbType.Int32).Value = objEntityEmpSlry.LedgerId;
          cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtEmpSlry = new DataTable();
          dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
          return dtEmpSlry;
      }

      //em 0044 
      public DataTable LoadLedgerById(clsEntityLedger  objEntityLedger)
      {
          DataTable dtAccountGroup = new DataTable();
          using (OracleCommand cmdReadAccountGroupById = new OracleCommand())
          {
              cmdReadAccountGroupById.CommandText = "FMS_LEDGER.LOAD_LEDGER_BYID";
              cmdReadAccountGroupById.CommandType = CommandType.StoredProcedure;
              cmdReadAccountGroupById.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLedger.Org_Id;
              cmdReadAccountGroupById.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityLedger.Corp_Id;
              cmdReadAccountGroupById.Parameters.Add("L_LDGRID", OracleDbType.Int32).Value = objEntityLedger.SubLedgerId;
              cmdReadAccountGroupById.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
              dtAccountGroup = clsDataLayer.SelectDataTable(cmdReadAccountGroupById);
          }
          return dtAccountGroup;
      }
    }
}
