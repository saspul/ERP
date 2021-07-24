using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using DL_Compzit;
using EL_Compzit.EntityLayer_FMS;
using EL_Compzit;
using CL_Compzit;


namespace DL_Compzit.DataLayer_FMS
{
  public  class clsDataLayerJournal
    {
      public DataTable ReadPurchaseBalance(clsEntityJournal objEntity,clsEntityJournalCostCntrDtl objEntityDtl )
      {
          string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_PURCHASE_BALANCE";
          OracleCommand cmdReadRcpt = new OracleCommand();
          cmdReadRcpt.CommandText = strQueryReadRcpt;
          cmdReadRcpt.CommandType = CommandType.StoredProcedure;
          cmdReadRcpt.Parameters.Add("F_ORGID", OracleDbType.Int32).Value = objEntity.Org_Id;
          cmdReadRcpt.Parameters.Add("F_CORPID", OracleDbType.Int32).Value = objEntity.Corp_Id;
          cmdReadRcpt.Parameters.Add("F_LDGRID", OracleDbType.Int32).Value = objEntityDtl.CostCenterId;
          cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtCategory = new DataTable();
          dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
          return dtCategory;
      }
      public DataTable ReadSalesBalance(clsEntityJournal objEntity, clsEntityJournalCostCntrDtl objEntityDtl)
      {
          string strQueryReadRcpt = "RECEIPT_ACCOUNT.SP_READ_SALES_BALANCE";
          OracleCommand cmdReadRcpt = new OracleCommand();
          cmdReadRcpt.CommandText = strQueryReadRcpt;
          cmdReadRcpt.CommandType = CommandType.StoredProcedure;
          cmdReadRcpt.Parameters.Add("F_ORGID", OracleDbType.Int32).Value = objEntity.Org_Id;
          cmdReadRcpt.Parameters.Add("F_CORPID", OracleDbType.Int32).Value = objEntity.Corp_Id;
          cmdReadRcpt.Parameters.Add("F_LDGRID", OracleDbType.Int32).Value = objEntityDtl.CostCenterId;
          cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtCategory = new DataTable();
          dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
          return dtCategory;
      }
      public DataTable ReadLedgerDdl(clsEntityJournal objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_JOURNAL.SP_READ_LEDGER_DDL";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
          cmdReadPayGrd.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
          cmdReadPayGrd.Parameters.Add("J_STS", OracleDbType.Int32).Value = objEntityEmpSlry.ConfirmSts;
          cmdReadPayGrd.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtEmpSlry = new DataTable();
          dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
          return dtEmpSlry;
      }
      public DataTable ReadCostCentrDdl(clsEntityJournal objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_JOURNAL.SP_READ_COSTCNTR_DDL";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
          cmdReadPayGrd.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
          cmdReadPayGrd.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtEmpSlry = new DataTable();
          dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
          return dtEmpSlry;
      }
      public DataTable ReadSelectList(clsEntityJournal objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_JOURNAL.SP_READ_SELECTION_LIST";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
          cmdReadPayGrd.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
          cmdReadPayGrd.Parameters.Add("J_LEDGRID", OracleDbType.Int32).Value = objEntityEmpSlry.JournlLedgerId;
          cmdReadPayGrd.Parameters.Add("J_STS", OracleDbType.Int32).Value = objEntityEmpSlry.ConfirmSts;
          cmdReadPayGrd.Parameters.Add("J_VIEWSTS", OracleDbType.Int32).Value = objEntityEmpSlry.ViewStatus;
          cmdReadPayGrd.Parameters.Add("J_JRNLID", OracleDbType.Int32).Value = objEntityEmpSlry.JournalId;
          cmdReadPayGrd.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtEmpSlry = new DataTable();
          dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
          return dtEmpSlry;
      }
      public DataTable ReadSelectListById(clsEntityJournal objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_JOURNAL.SP_READ_SELECTION_LIST_ID";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
          cmdReadPayGrd.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
          cmdReadPayGrd.Parameters.Add("J_LEDGRID", OracleDbType.Int32).Value = objEntityEmpSlry.JournalId;
          cmdReadPayGrd.Parameters.Add("J_STS", OracleDbType.Int32).Value = objEntityEmpSlry.ConfirmSts;
          cmdReadPayGrd.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtEmpSlry = new DataTable();
          dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
          return dtEmpSlry;
      }
      public DataTable ReadJournlList(clsEntityJournal objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_JOURNAL.SP_READ_JOURNL_LIST";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
          cmdReadPayGrd.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
          cmdReadPayGrd.Parameters.Add("J_LEDGRID", OracleDbType.Int32).Value = objEntityEmpSlry.JournalId;
          cmdReadPayGrd.Parameters.Add("J_CNCL_STS", OracleDbType.Int32).Value = objEntityEmpSlry.ConfirmSts;
          cmdReadPayGrd.Parameters.Add("J_FROM_DATE", OracleDbType.Date).Value = objEntityEmpSlry.FromDate;
          cmdReadPayGrd.Parameters.Add("J_TO_DATE", OracleDbType.Date).Value = objEntityEmpSlry.JournalDate;
          if (objEntityEmpSlry.FromPeriod == DateTime.MinValue)
          {
              cmdReadPayGrd.Parameters.Add("J_FROM_PERIOD", OracleDbType.Date).Value = null;
          }
          else
          cmdReadPayGrd.Parameters.Add("J_FROM_PERIOD", OracleDbType.Date).Value = objEntityEmpSlry.FromPeriod;
          if (objEntityEmpSlry.ToPeriod==DateTime.MinValue)
              cmdReadPayGrd.Parameters.Add("J_TO_PERIOD", OracleDbType.Date).Value = null ;
              else
          cmdReadPayGrd.Parameters.Add("J_TO_PERIOD", OracleDbType.Date).Value = objEntityEmpSlry.ToPeriod;
          cmdReadPayGrd.Parameters.Add("J_JRNL_STATUS", OracleDbType.Int32).Value = objEntityEmpSlry.JrnltSts;

          cmdReadPayGrd.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtEmpSlry = new DataTable();
          dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
          return dtEmpSlry;
      }
      public DataTable ReadLedgrListDdl(clsEntityJournal objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_JOURNAL.SP_READ_LEDGR_DDL_LIST";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
          cmdReadPayGrd.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
          cmdReadPayGrd.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtEmpSlry = new DataTable();
          dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
          return dtEmpSlry;
      }
      public DataTable CheckJournlCnclSts(clsEntityJournal objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_JOURNAL.SP_CHECK_CNCL_STS";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityEmpSlry.JournalId;
          cmdReadPayGrd.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtEmpSlry = new DataTable();
          dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
          return dtEmpSlry;
      }
      public DataTable ReadJournalDtlsById(clsEntityJournal objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_JOURNAL.SP_READ_JRNL_DTLS";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityEmpSlry.JournalId;
          cmdReadPayGrd.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtEmpSlry = new DataTable();
          dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
          return dtEmpSlry;
      }
      public DataTable ReadJrnlLedgrDtlsById(clsEntityJournal objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_JOURNAL.SP_READ_JRNL_LEDGR_DTLS";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityEmpSlry.JournalId;
          cmdReadPayGrd.Parameters.Add("J_STS", OracleDbType.Int32).Value = objEntityEmpSlry.ConfirmSts;
          cmdReadPayGrd.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtEmpSlry = new DataTable();
          dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
          return dtEmpSlry;
      }
      public DataTable ReadJrnlCostCntrDtlsById(clsEntityJournal objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_JOURNAL.SP_READ_JRNL_COSTCNTR_DTLS";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityEmpSlry.JournalId;
          cmdReadPayGrd.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtEmpSlry = new DataTable();
          dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
          return dtEmpSlry;
      }
      public DataTable ReadLedgrBal(clsEntityJournal objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_JOURNAL.SP_READ_LEDGR_BAL_DTLS";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityEmpSlry.JournlLedgerId;
          cmdReadPayGrd.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtEmpSlry = new DataTable();
          dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
          return dtEmpSlry;
      }
      public void CancelJournal(clsEntityJournal objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_JOURNAL.SP_CANCEL_JOURNAL";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityEmpSlry.JournalId;
          cmdReadPayGrd.Parameters.Add("J_CNCL_REASON", OracleDbType.Varchar2).Value = objEntityEmpSlry.Cancel_Reason;
          cmdReadPayGrd.Parameters.Add("J_USER_ID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
          clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
      }
      public void ReopenJournalDtls(clsEntityJournal objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_JOURNAL.SP_REOPEN_JOURNAL";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityEmpSlry.JournalId;
          cmdReadPayGrd.Parameters.Add("J_USER_ID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
          clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
      }
      public void AddJournalDtls(clsEntityJournal objEntityShortList, List<clsEntityJournalLedgerDtl> objEntityJrnlLedgrList, List<clsEntityJournalCostCntrDtl> objEntityJrnlCostcentrList)
      {
          clsDataLayer objDatatLayer = new clsDataLayer();
          string strQueryLeaveTyp = "FMS_JOURNAL.SP_INS_JOURNL_MASTER";
          OracleTransaction tran;
          //insert to main register table
          using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
          {
              con.Open();
              tran = con.BeginTransaction();

              try
              {
                  using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp, con))
                  {
                      cmdAddService.Transaction = tran;
                      cmdAddService.CommandType = CommandType.StoredProcedure;
                      clsEntityCommon objEntCommon = new clsEntityCommon();
                      objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.JOURNAL);
                      objEntCommon.CorporateID = objEntityShortList.Corp_Id;

                      string strNextId1 = objDatatLayer.ReadNextNumber(objEntCommon);
                      string strNextId = objDatatLayer.ReadNextNumberSequanceForUI(objEntCommon);

                      objEntityShortList.JournalId = Convert.ToInt32(strNextId1);
                      //CHECKING FOR CORP GLOBAL SUB REF STATUS
                      int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intCorpId = 0; string strRefAccountCls = "0";
                      intCorpId = objEntityShortList.Corp_Id;
                      intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Journal);
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
                          {     strColumns = strColumns + "," + arrEnumer[intcount].ToString();
                          }
                      }
                      dtCorpDetail = objDatatLayer.LoadGlobalDetail(strColumns, intCorpId);
                      if (dtCorpDetail.Rows.Count > 0)
                      {
                                strRefAccountCls = dtCorpDetail.Rows[0]["REFNUM_ACCNTCLS_STS"].ToString();
                      }

                 
                      // string year = DateTime.Today.Year.ToString();
                      // objEntityPayment.RefNum = "REF#" + year + strNextNum;
                       intCorpId = objEntityShortList.Corp_Id;
                      int intOrgId = objEntityShortList.Org_Id;

                  //    objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Journal);
                      DataTable dtFormate = readRefFormate(objEntCommon);

                      clsDataLayerDateAndTime objDataLayerDateTime = new clsDataLayerDateAndTime();
                      string CurrentDate = objDataLayerDateTime.DateAndTime().ToString("dd-MM-yyyy");
                      clsCommonLibrary objCommon = new clsCommonLibrary();
                      DateTime dtCurrentDate = objCommon.textToDateTime(CurrentDate);
                      int DtYear = dtCurrentDate.Year;
                      int DtMonth = dtCurrentDate.Month;
                      string dtyy = dtCurrentDate.ToString("yy");

                      clsDataLayer objBusinessLayer = new clsDataLayer();
                      clsEntityCommon objEntityCommon = new clsEntityCommon();

                      objEntityCommon.Organisation_Id = objEntityShortList.Org_Id;
                      objEntityCommon.CorporateID = objEntityShortList.Corp_Id;
                      objEntityCommon.FinancialYrId = objEntityShortList.FinancialYrId;

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
                      if (dtFormate.Rows.Count > 0)
                      {
                          if (dtFormate.Rows[0]["REF_FORMATE"].ToString() != "")
                          {
                              refFormatByDiv = dtFormate.Rows[0]["REF_FORMATE"].ToString();
                              string strReferenceFormat = "";
                              strReferenceFormat = refFormatByDiv;

                              int flag = 0;
                              string[] arrReferenceSplit = strReferenceFormat.Split('*');
                              int intArrayRowCount = arrReferenceSplit.Length;

                              if (flag == 1)
                              {
                                  refFormatByDiv = "#COR#*/*#USR#";
                              }
                              if (refFormatByDiv == "" || refFormatByDiv == null)
                              {
                                  strRealFormat = intCorpId + "/" + strNextId;
                              }
                              else
                              {
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
                                      strRealFormat = strRealFormat.Replace("#USR#", objEntityShortList.User_Id.ToString());
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
                                  

                                  //if (strRealFormat == "")
                                  //{
                                  //    strRealFormat = intOrgId.ToString() + "/" + intCorpId.ToString() + "/" + strNextNum;
                                  //}
                                  strRealFormat = strRealFormat.Replace("#", "");
                                 // strRealFormat = strRealFormat.Replace("*", "");
                                 // strRealFormat = strRealFormat.Replace("%", "");


                              }
                              objEntityShortList.RefNum = strRealFormat;
                          }
                      }
                      else
                      {
                          objEntityShortList.RefNum = strNextId;
                      }
                      objEntityShortList.RefSeqNo = Convert.ToInt32(strNextId);

                      //CHECKING SUB REF NUMBER
                      string Ref = ""; int SubRef = 0;
                      if (strRefAccountCls == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                      {


                          clsDataLayer_Account_Close objEmpAccntCls = new clsDataLayer_Account_Close();
                          clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
                          clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
                          clsDataLayer_Audit_Closing objEmpAuditCls = new clsDataLayer_Audit_Closing();

                          objEntityAudit.FromDate = objEntityShortList.JournalDate;
                          objEntityAudit.Organisation_id = intOrgId;
                          objEntityAudit.Corporate_id = intCorpId;

                          objEntityAccnt.FromDate = objEntityShortList.JournalDate;
                          clsEntityJournal objEntityLayerStock1 = new clsEntityJournal();
                          // clsdAJournal objBusinessLayerStock1 = new clsBusinessJournal();
                          objEntityLayerStock1.FromDate = objEntityShortList.JournalDate;
                          objEntityAccnt.Corporate_id = intCorpId;
                          objEntityLayerStock1.Corp_Id = intCorpId;
                          objEntityAccnt.Organisation_id = intOrgId;
                          objEntityLayerStock1.Org_Id = intOrgId;

                          DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
                          DataTable dtAuditCls = objEmpAuditCls.CheckAuditClosingDate(objEntityAudit);
                          if (dtAccntCls.Rows.Count > 0 || dtAuditCls.Rows.Count > 0)
                          {



                              DataTable dtRefFormat1 = ReadRefNumberByDate(objEntityLayerStock1);
                              if (dtRefFormat1.Rows.Count > 0)
                              {
                                  string strRef = "";
                                  if (dtRefFormat1.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString() != "")
                                  {
                                      if (Convert.ToInt32(dtRefFormat1.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString()) != 1)
                                      {
                                          strRef = dtRefFormat1.Rows[0]["JURNL_REF"].ToString();
                                          strRef = strRef.TrimEnd('/');
                                          strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                      }
                                      else
                                      {
                                          strRef = dtRefFormat1.Rows[0]["JURNL_REF"].ToString();
                                      }

                                  }
                                  else
                                  {
                                      strRef = dtRefFormat1.Rows[0]["JURNL_REF"].ToString();
                                  }
                                  objEntityLayerStock1.RefNum = strRef;
                                  DataTable dtRefFormat = ReadRefNumberByDateLast(objEntityLayerStock1);

                                  if (dtRefFormat.Rows.Count > 0)
                                  {
                                      SubRef = 1;
                                      Ref = dtRefFormat.Rows[0]["JURNL_REF"].ToString();
                                      if (dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString() != null)
                                      {
                                          SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString());
                                          objEntityShortList.RefSeqNo = Convert.ToInt32(dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString());
                                      }
                                      if (SubRef != 1)
                                      {
                                          Ref = Ref.TrimEnd('/');
                                          Ref = Ref.Remove(Ref.LastIndexOf('/') + 1);

                                          Ref = Ref + "" + SubRef;
                                      }
                                      else
                                      {
                                          Ref = Ref + "/" + SubRef;
                                      }
                                      objEntityShortList.RefNum = Ref;
                                      SubRef++;
                                  }
                              }
                          }
                      }
                      cmdAddService.CommandText = strQueryLeaveTyp;
                      cmdAddService.CommandType = CommandType.StoredProcedure;
                      cmdAddService.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityShortList.JournalId;
                      cmdAddService.Parameters.Add("J_REF", OracleDbType.Varchar2).Value = objEntityShortList.RefNum;
                      cmdAddService.Parameters.Add("J_DATE", OracleDbType.Date).Value = objEntityShortList.JournalDate;
                      cmdAddService.Parameters.Add("J_CURRID", OracleDbType.Int32).Value = objEntityShortList.CurrencyId;
                      cmdAddService.Parameters.Add("J_DESC", OracleDbType.Varchar2).Value = objEntityShortList.Description;
                      cmdAddService.Parameters.Add("J_AMNT", OracleDbType.Decimal).Value = objEntityShortList.JournalTotAmnt;
                      cmdAddService.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityShortList.Org_Id;
                      cmdAddService.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityShortList.Corp_Id;
                      cmdAddService.Parameters.Add("J_USRID", OracleDbType.Int32).Value = objEntityShortList.User_Id;
                      if (objEntityShortList.ExchangeRate != 0)
                          cmdAddService.Parameters.Add("J_EXC", OracleDbType.Decimal).Value = objEntityShortList.ExchangeRate;
                      else
                          cmdAddService.Parameters.Add("J_EXC", OracleDbType.Decimal).Value = DBNull.Value;
                      if (SubRef!=0)
                      cmdAddService.Parameters.Add("J_SUBREFID", OracleDbType.Int32).Value = SubRef;
                      else
                          cmdAddService.Parameters.Add("J_SUBREFID", OracleDbType.Int32).Value = null;
                      cmdAddService.Parameters.Add("J_REFNEXTSEQ", OracleDbType.Int32).Value = objEntityShortList.RefSeqNo;
                      if (objEntityShortList.PostdateChqDtlId != 0)
                      {
                          cmdAddService.Parameters.Add("J_PSTDTCHQ_DTLID", OracleDbType.Int32).Value = objEntityShortList.PostdateChqDtlId;
                      }
                      else
                      {
                          cmdAddService.Parameters.Add("J_PSTDTCHQ_DTLID", OracleDbType.Int32).Value = null;
                      }

                      cmdAddService.ExecuteNonQuery();
                  }

                  foreach (clsEntityJournalLedgerDtl objDetail in objEntityJrnlLedgrList)
                  {
                      string strQueryInsertDetails = "FMS_JOURNAL.SP_INS_LEDGR_DTL";
                      using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                      {
                          cmdAddInsertDetail.Transaction = tran;
                          cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                          cmdAddInsertDetail.Parameters.Add("J_JRNLID", OracleDbType.Int32).Value = objEntityShortList.JournalId;
                          cmdAddInsertDetail.Parameters.Add("J_LEDGRID", OracleDbType.Int32).Value = objDetail.LedgerId;
                          cmdAddInsertDetail.Parameters.Add("J_AMNT", OracleDbType.Decimal).Value = objDetail.LedgerTotAmnt;
                          cmdAddInsertDetail.Parameters.Add("J_STS", OracleDbType.Int32).Value = objDetail.TabMode;
                          cmdAddInsertDetail.Parameters.Add("J_REMARKS", OracleDbType.Varchar2).Value = objDetail.Remarks;

                          cmdAddInsertDetail.Parameters.Add("J_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                          cmdAddInsertDetail.ExecuteNonQuery();
                          string strReturn = cmdAddInsertDetail.Parameters["J_ID"].Value.ToString();
                          objDetail.JournlLedgerId = Convert.ToInt32(strReturn);

                          foreach (clsEntityJournalCostCntrDtl objDetailSub in objEntityJrnlCostcentrList)
                          {

                              if (objDetail.TabMode == objDetailSub.TabMode && objDetail.MainTabId == objDetailSub.MainTabId)
                              {
                                  string strQueryInsertDetailsub = "FMS_JOURNAL.SP_INS_COSTCNTR_DTL";
                                  using (OracleCommand cmdAddInsertDetailS = new OracleCommand(strQueryInsertDetailsub, con))
                                  {
                                      cmdAddInsertDetailS.Transaction = tran;
                                      cmdAddInsertDetailS.CommandType = CommandType.StoredProcedure;
                                      cmdAddInsertDetailS.Parameters.Add("J_JRNLID", OracleDbType.Int32).Value = objEntityShortList.JournalId;
                                      cmdAddInsertDetailS.Parameters.Add("J_JRNLLEDGRID", OracleDbType.Int32).Value = objDetail.JournlLedgerId;
                                      cmdAddInsertDetailS.Parameters.Add("J_AMNT", OracleDbType.Decimal).Value = objDetailSub.CostCntrAmnt;

                                      if (objDetailSub.CostCenterId != 0)
                                      {
                                          if (objDetailSub.PurSaleRefNum == "")
                                          {
                                              cmdAddInsertDetailS.Parameters.Add("J_COSTCENTRID", OracleDbType.Int32).Value = objDetailSub.CostCenterId;

                                              cmdAddInsertDetailS.Parameters.Add("J_PURID", OracleDbType.Int32).Value = DBNull.Value;
                                              cmdAddInsertDetailS.Parameters.Add("J_SALEID", OracleDbType.Int32).Value = DBNull.Value;
                                          }
                                          else if (objDetailSub.PurSaleRefNum == "Deb")
                                          {
                                              cmdAddInsertDetailS.Parameters.Add("J_COSTCENTRID", OracleDbType.Int32).Value = DBNull.Value;
                                              cmdAddInsertDetailS.Parameters.Add("J_PURID", OracleDbType.Int32).Value = objDetailSub.CostCenterId;
                                              cmdAddInsertDetailS.Parameters.Add("J_SALEID", OracleDbType.Int32).Value = DBNull.Value;
                                          }
                                          else
                                          {
                                              cmdAddInsertDetailS.Parameters.Add("J_COSTCENTRID", OracleDbType.Int32).Value = DBNull.Value;
                                              cmdAddInsertDetailS.Parameters.Add("J_PURID", OracleDbType.Int32).Value = DBNull.Value;
                                              cmdAddInsertDetailS.Parameters.Add("J_SALEID", OracleDbType.Int32).Value = objDetailSub.CostCenterId;
                                          }

                                          if (objDetailSub.CostGrp1Id != 0)
                                          {
                                              cmdAddInsertDetailS.Parameters.Add("R_COST_GRP_ID_ONE", OracleDbType.Int32).Value = objDetailSub.CostGrp1Id;
                                          }
                                          else
                                          {
                                              cmdAddInsertDetailS.Parameters.Add("R_COST_GRP_ID_ONE", OracleDbType.Int32).Value = null;

                                          }
                                          if (objDetailSub.CostGrp2Id != 0)
                                          {
                                              cmdAddInsertDetailS.Parameters.Add("R_COST_GRP_ID_TWO", OracleDbType.Int32).Value = objDetailSub.CostGrp2Id;
                                          }
                                          else
                                          {
                                              cmdAddInsertDetailS.Parameters.Add("R_COST_GRP_ID_TWO", OracleDbType.Int32).Value = null;
                                          }
                                      }
                                      else
                                      {
                                          cmdAddInsertDetailS.Parameters.Add("J_COSTCENTRID", OracleDbType.Int32).Value = DBNull.Value;
                                          cmdAddInsertDetailS.Parameters.Add("J_PURID", OracleDbType.Int32).Value = DBNull.Value;
                                          cmdAddInsertDetailS.Parameters.Add("J_SALEID", OracleDbType.Int32).Value = DBNull.Value;
                                          cmdAddInsertDetailS.Parameters.Add("R_COST_GRP_ID_ONE", OracleDbType.Int32).Value = null;
                                          cmdAddInsertDetailS.Parameters.Add("R_COST_GRP_ID_TWO", OracleDbType.Int32).Value = null;
                                      }

                                      if (objDetailSub.Expense_Id != 0)
                                      {
                                          cmdAddInsertDetailS.Parameters.Add("J_EXPENSE_ID", OracleDbType.Int32).Value = objDetailSub.Expense_Id;//040
                                          cmdAddInsertDetailS.Parameters.Add("J_EXPENSE_AMT", OracleDbType.Decimal).Value = objDetailSub.Expense_Amount;//040
                                      }
                                      else
                                      {
                                          cmdAddInsertDetailS.Parameters.Add("J_EXPENSE_ID", OracleDbType.Int32).Value = null;//040
                                          cmdAddInsertDetailS.Parameters.Add("J_EXPENSE_AMT", OracleDbType.Decimal).Value = null;//040
                                      }


                                      cmdAddInsertDetailS.ExecuteNonQuery();
                                  }
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

      public void EditJournalDtls(clsEntityJournal objEntityShortList, List<clsEntityJournalLedgerDtl> objEntityJrnlLedgrList, List<clsEntityJournalCostCntrDtl> objEntityJrnlCostcentrList)
      {
          clsDataLayer objDatatLayer = new clsDataLayer();
          string strQueryLeaveTyp = "FMS_JOURNAL.SP_UPD_JOURNL_MASTER";
          OracleTransaction tran;
          //insert to main register table
          using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
          {
              con.Open();
              tran = con.BeginTransaction();

              try
              {
                  using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp, con))
                  {
                      cmdAddService.Transaction = tran;
                      int SubRef = 0;
                      if (objEntityShortList.ViewStatus == 1)
                      {
                          clsEntityCommon objEntCommon = new clsEntityCommon();
                          objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.JOURNAL);
                          objEntCommon.CorporateID = objEntityShortList.Corp_Id;
                      //    string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                      //   objEntityShortList.JournalId = Convert.ToInt32(strNextNum);
                          //CHECKING FOR CORP GLOBAL SUB REF STATUS
                          int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intCorpId = 0; string strRefAccountCls = "0";
                          intCorpId = objEntityShortList.Corp_Id;
                          intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Journal);
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


                          // string year = DateTime.Today.Year.ToString();
                          // objEntityPayment.RefNum = "REF#" + year + strNextNum;
                          intCorpId = objEntityShortList.Corp_Id;
                          int intOrgId = objEntityShortList.Org_Id;

                         // objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Journal);
                          DataTable dtFormate = readRefFormate(objEntCommon);

                          clsDataLayerDateAndTime objDataLayerDateTime = new clsDataLayerDateAndTime();
                          string CurrentDate = objDataLayerDateTime.DateAndTime().ToString("dd-MM-yyyy");
                          clsCommonLibrary objCommon = new clsCommonLibrary();
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

                              objEntityAudit.FromDate = objEntityShortList.JournalDate;
                              objEntityAudit.Organisation_id = intOrgId;
                              objEntityAudit.Corporate_id = intCorpId;

                              objEntityAccnt.FromDate = objEntityShortList.JournalDate;
                              clsEntityJournal objEntityLayerStock1 = new clsEntityJournal();
                              // clsdAJournal objBusinessLayerStock1 = new clsBusinessJournal();
                              objEntityLayerStock1.FromDate = objEntityShortList.JournalDate;
                              objEntityAccnt.Corporate_id = intCorpId;
                              objEntityLayerStock1.Corp_Id = intCorpId;
                              objEntityAccnt.Organisation_id = intOrgId;
                              objEntityLayerStock1.Org_Id = intOrgId;

                              DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
                              DataTable dtAuditCls = objEmpAuditCls.CheckAuditClosingDate(objEntityAudit);
                              if (dtAccntCls.Rows.Count > 0 || dtAuditCls.Rows.Count > 0)
                              {

                                  DataTable dtRefFormat1 = ReadRefNumberByDate(objEntityLayerStock1);
                                  if (dtRefFormat1.Rows.Count > 0)
                                  {
                                      string strRef = "";
                                      if (dtRefFormat1.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString() != "")
                                      {

                                          if (Convert.ToInt32(dtRefFormat1.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString()) != 1)
                                          {
                                              strRef = dtRefFormat1.Rows[0]["JURNL_REF"].ToString();
                                              strRef = strRef.TrimEnd('/');
                                              strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                          }
                                          else
                                          {
                                              strRef = dtRefFormat1.Rows[0]["JURNL_REF"].ToString();
                                          }

                                      }
                                      else
                                      {
                                          strRef = dtRefFormat1.Rows[0]["JURNL_REF"].ToString();
                                      }
                                      objEntityLayerStock1.RefNum = strRef;
                                      DataTable dtRefFormat = ReadRefNumberByDateLast(objEntityLayerStock1);

                                      if (dtRefFormat.Rows.Count > 0)
                                      {
                                          SubRef = 1;
                                          if (objEntityShortList.JournalId != Convert.ToInt32(dtRefFormat.Rows[0]["JURNL_ID"].ToString()))
                                          {
                                              Ref = dtRefFormat.Rows[0]["JURNL_REF"].ToString();
                                              if (dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString() != null)
                                              {
                                                  SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString());
                                                  objEntityShortList.RefSeqNo = Convert.ToInt32(dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString());                                              
                                              }
                                              if (SubRef != 1)
                                              {
                                                  Ref = Ref.TrimEnd('/');
                                                  Ref = Ref.Remove(Ref.LastIndexOf('/') + 1);
                                                  Ref = Ref + "" + SubRef;
                                              }
                                              else
                                              {
                                                  Ref = Ref + "/" + SubRef;
                                              }

                                              objEntityShortList.RefNum = Ref;
                                              SubRef++;
                                          }
                                      }
                                  }
                              }
                          }
                      }
                      cmdAddService.CommandType = CommandType.StoredProcedure;
                      cmdAddService.CommandText = strQueryLeaveTyp;
                      cmdAddService.CommandType = CommandType.StoredProcedure;
                      cmdAddService.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityShortList.JournalId;
                      cmdAddService.Parameters.Add("J_DATE", OracleDbType.Date).Value = objEntityShortList.JournalDate;
                      cmdAddService.Parameters.Add("J_CURRID", OracleDbType.Int32).Value = objEntityShortList.CurrencyId;
                      cmdAddService.Parameters.Add("J_DESC", OracleDbType.Varchar2).Value = objEntityShortList.Description;
                      cmdAddService.Parameters.Add("J_AMNT", OracleDbType.Decimal).Value = objEntityShortList.JournalTotAmnt;
                      cmdAddService.Parameters.Add("J_USRID", OracleDbType.Int32).Value = objEntityShortList.User_Id;
                      cmdAddService.Parameters.Add("J_STS", OracleDbType.Int32).Value = objEntityShortList.ConfirmSts;

                      if (objEntityShortList.ExchangeRate != 0)
                          cmdAddService.Parameters.Add("J_EXC", OracleDbType.Decimal).Value = objEntityShortList.ExchangeRate;
                      else
                          cmdAddService.Parameters.Add("J_EXC", OracleDbType.Decimal).Value = DBNull.Value;



                      if (SubRef != 0)
                          cmdAddService.Parameters.Add("J_SUBREFID", OracleDbType.Int32).Value = SubRef;
                      else
                          cmdAddService.Parameters.Add("J_SUBREFID", OracleDbType.Int32).Value = null;
                      cmdAddService.Parameters.Add("J_REF", OracleDbType.Varchar2).Value = objEntityShortList.RefNum;
                      cmdAddService.Parameters.Add("J_REFSTS", OracleDbType.Int32).Value = objEntityShortList.ViewStatus;
                      cmdAddService.Parameters.Add("J_REFNEXTSEQ", OracleDbType.Int32).Value = objEntityShortList.RefSeqNo;
                      cmdAddService.ExecuteNonQuery();
                  }

                  foreach (clsEntityJournalLedgerDtl objDetail in objEntityJrnlLedgrList)
                  {
                      string strQueryInsertDetails = "FMS_JOURNAL.SP_INS_LEDGR_DTL";
                      using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                      {
                          cmdAddInsertDetail.Transaction = tran;
                          cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                          cmdAddInsertDetail.Parameters.Add("J_JRNLID", OracleDbType.Int32).Value = objEntityShortList.JournalId;
                          cmdAddInsertDetail.Parameters.Add("J_LEDGRID", OracleDbType.Int32).Value = objDetail.LedgerId;
                          cmdAddInsertDetail.Parameters.Add("J_AMNT", OracleDbType.Decimal).Value = objDetail.LedgerTotAmnt;
                          cmdAddInsertDetail.Parameters.Add("J_STS", OracleDbType.Int32).Value = objDetail.TabMode;
                          cmdAddInsertDetail.Parameters.Add("J_REMARKS", OracleDbType.Varchar2).Value = objDetail.Remarks;

                          cmdAddInsertDetail.Parameters.Add("J_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                          cmdAddInsertDetail.ExecuteNonQuery();
                          string strReturn = cmdAddInsertDetail.Parameters["J_ID"].Value.ToString();
                          objDetail.JournlLedgerId = Convert.ToInt32(strReturn);

                          foreach (clsEntityJournalCostCntrDtl objDetailSub in objEntityJrnlCostcentrList)
                          {

                              if (objDetail.TabMode == objDetailSub.TabMode && objDetail.MainTabId == objDetailSub.MainTabId)
                              {
                                  string strQueryInsertDetailsub = "FMS_JOURNAL.SP_INS_COSTCNTR_DTL";
                                  using (OracleCommand cmdAddInsertDetailS = new OracleCommand(strQueryInsertDetailsub, con))
                                  {
                                      cmdAddInsertDetailS.Transaction = tran;
                                      cmdAddInsertDetailS.CommandType = CommandType.StoredProcedure;
                                      cmdAddInsertDetailS.Parameters.Add("J_JRNLID", OracleDbType.Int32).Value = objEntityShortList.JournalId;
                                      cmdAddInsertDetailS.Parameters.Add("J_JRNLLEDGRID", OracleDbType.Int32).Value = objDetail.JournlLedgerId;
                                      cmdAddInsertDetailS.Parameters.Add("J_AMNT", OracleDbType.Decimal).Value = objDetailSub.CostCntrAmnt;

                                      if (objDetailSub.CostCenterId != 0)
                                      {
                                          if (objDetailSub.PurSaleRefNum == "")
                                          {
                                              cmdAddInsertDetailS.Parameters.Add("J_COSTCENTRID", OracleDbType.Int32).Value = objDetailSub.CostCenterId;
                                              cmdAddInsertDetailS.Parameters.Add("J_PURID", OracleDbType.Int32).Value = DBNull.Value;
                                              cmdAddInsertDetailS.Parameters.Add("J_SALEID", OracleDbType.Int32).Value = DBNull.Value;
                                          }
                                          else if (objDetailSub.PurSaleRefNum == "Deb")
                                          {
                                              cmdAddInsertDetailS.Parameters.Add("J_COSTCENTRID", OracleDbType.Int32).Value = DBNull.Value;

                                              cmdAddInsertDetailS.Parameters.Add("J_PURID", OracleDbType.Int32).Value = objDetailSub.CostCenterId;
                                              cmdAddInsertDetailS.Parameters.Add("J_SALEID", OracleDbType.Int32).Value = DBNull.Value;
                                          }
                                          else
                                          {
                                              cmdAddInsertDetailS.Parameters.Add("J_COSTCENTRID", OracleDbType.Int32).Value = DBNull.Value;
                                              cmdAddInsertDetailS.Parameters.Add("J_PURID", OracleDbType.Int32).Value = DBNull.Value;
                                              cmdAddInsertDetailS.Parameters.Add("J_SALEID", OracleDbType.Int32).Value = objDetailSub.CostCenterId;
                                          }

                                          if (objDetailSub.CostGrp1Id != 0)
                                          {
                                              cmdAddInsertDetailS.Parameters.Add("R_COST_GRP_ID_ONE", OracleDbType.Int32).Value = objDetailSub.CostGrp1Id;
                                          }
                                          else
                                          {
                                              cmdAddInsertDetailS.Parameters.Add("R_COST_GRP_ID_ONE", OracleDbType.Int32).Value = null;

                                          }
                                          if (objDetailSub.CostGrp2Id != 0)
                                          {
                                              cmdAddInsertDetailS.Parameters.Add("R_COST_GRP_ID_TWO", OracleDbType.Int32).Value = objDetailSub.CostGrp2Id;
                                          }
                                          else
                                          {
                                              cmdAddInsertDetailS.Parameters.Add("R_COST_GRP_ID_TWO", OracleDbType.Int32).Value = null;
                                          }
                                      }
                                      else
                                      {
                                          cmdAddInsertDetailS.Parameters.Add("J_COSTCENTRID", OracleDbType.Int32).Value = DBNull.Value;
                                          cmdAddInsertDetailS.Parameters.Add("J_PURID", OracleDbType.Int32).Value = DBNull.Value;
                                          cmdAddInsertDetailS.Parameters.Add("J_SALEID", OracleDbType.Int32).Value = DBNull.Value;
                                          cmdAddInsertDetailS.Parameters.Add("R_COST_GRP_ID_ONE", OracleDbType.Int32).Value = null;
                                          cmdAddInsertDetailS.Parameters.Add("R_COST_GRP_ID_TWO", OracleDbType.Int32).Value = null;
                                      }

                                      if (objDetailSub.Expense_Id != 0)
                                      {
                                          cmdAddInsertDetailS.Parameters.Add("J_EXPENSE_ID", OracleDbType.Int32).Value = objDetailSub.Expense_Id;//040
                                          cmdAddInsertDetailS.Parameters.Add("J_EXPENSE_AMT", OracleDbType.Decimal).Value = objDetailSub.Expense_Amount;//040
                                      }
                                      else
                                      {
                                          cmdAddInsertDetailS.Parameters.Add("J_EXPENSE_ID", OracleDbType.Int32).Value = null;//040
                                          cmdAddInsertDetailS.Parameters.Add("J_EXPENSE_AMT", OracleDbType.Decimal).Value = null;//040
                                      }

                                      cmdAddInsertDetailS.ExecuteNonQuery();
                                  }
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

      public void ConfirmJournalDtls(clsEntityJournal objEntityShortList, List<clsEntityJournalLedgerDtl> objEntityJrnlLedgrList, List<clsEntityJournalCostCntrDtl> objEntityJrnlCostcentrList)
      {
          clsDataLayer objDatatLayer = new clsDataLayer();
          string strQueryLeaveTyp = "FMS_JOURNAL.SP_UPD_JOURNL_MASTER";
          OracleTransaction tran;
          //insert to main register table
          using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
          {
              con.Open();
              tran = con.BeginTransaction();

              try
              {
                  using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp, con))
                  {
                      cmdAddService.Transaction = tran;

                      int SubRef = 0, AccountClsChk = 0;
                      if (objEntityShortList.ViewStatus == 1)
                      {
                          clsEntityCommon objEntCommon = new clsEntityCommon();
                          objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.JOURNAL);
                          objEntCommon.CorporateID = objEntityShortList.Corp_Id;
                          //string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                          //objEntityShortList.JournalId = Convert.ToInt32(strNextNum);
                          //CHECKING FOR CORP GLOBAL SUB REF STATUS
                          int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intCorpId = 0; string strRefAccountCls = "0";
                          intCorpId = objEntityShortList.Corp_Id;
                          intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Journal);
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


                          // string year = DateTime.Today.Year.ToString();
                          // objEntityPayment.RefNum = "REF#" + year + strNextNum;
                          intCorpId = objEntityShortList.Corp_Id;
                          int intOrgId = objEntityShortList.Org_Id;

                          objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Journal);
                          DataTable dtFormate = readRefFormate(objEntCommon);

                          clsDataLayerDateAndTime objDataLayerDateTime = new clsDataLayerDateAndTime();
                          string CurrentDate = objDataLayerDateTime.DateAndTime().ToString("dd-MM-yyyy");
                          clsCommonLibrary objCommon = new clsCommonLibrary();
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

                              objEntityAudit.FromDate = objEntityShortList.JournalDate;
                              objEntityAudit.Organisation_id = intOrgId;
                              objEntityAudit.Corporate_id = intCorpId;
                              objEntityAccnt.FromDate = objEntityShortList.JournalDate;
                              clsEntityJournal objEntityLayerStock1 = new clsEntityJournal();
                              // clsdAJournal objBusinessLayerStock1 = new clsBusinessJournal();
                              objEntityLayerStock1.FromDate = objEntityShortList.JournalDate;
                              objEntityAccnt.Corporate_id = intCorpId;
                              objEntityLayerStock1.Corp_Id = intCorpId;
                              objEntityAccnt.Organisation_id = intOrgId;
                              objEntityLayerStock1.Org_Id = intOrgId;

                              DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
                              DataTable dtAuditCls = objEmpAuditCls.CheckAuditClosingDate(objEntityAudit);
                              if (dtAccntCls.Rows.Count > 0 || dtAuditCls.Rows.Count > 0)
                              {

                                  DataTable dtRefFormat1 = ReadRefNumberByDate(objEntityLayerStock1);
                                  if (dtRefFormat1.Rows.Count > 0)
                                  {
                                      string strRef = "";

                                      if (dtRefFormat1.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString() != "")
                                      {


                                          if (Convert.ToInt32(dtRefFormat1.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString()) != 1)
                                          {
                                              strRef = dtRefFormat1.Rows[0]["JURNL_REF"].ToString();
                                              strRef = strRef.TrimEnd('/');
                                              strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                          }
                                          else
                                          {
                                              strRef = dtRefFormat1.Rows[0]["JURNL_REF"].ToString();
                                          }
                                      }
                                      else
                                      {
                                          strRef = dtRefFormat1.Rows[0]["JURNL_REF"].ToString();
                                      }

                                      objEntityLayerStock1.RefNum = strRef;
                                      DataTable dtRefFormat = ReadRefNumberByDateLast(objEntityLayerStock1);

                                      if (dtRefFormat.Rows.Count > 0)
                                      {
                                          AccountClsChk = 1;
                                          SubRef = 1;
                                          if (objEntityShortList.JournalId != Convert.ToInt32(dtRefFormat.Rows[0]["JURNL_ID"].ToString()))
                                          {
                                              Ref = dtRefFormat.Rows[0]["JURNL_REF"].ToString();
                                              if (dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString() != null)
                                              {
                                                  SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString());
                                                  objEntityShortList.RefSeqNo = Convert.ToInt32(dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString());
                                              }
                                              if (SubRef != 1)
                                              {
                                                  Ref = Ref.TrimEnd('/');
                                                  Ref = Ref.Remove(Ref.LastIndexOf('/') + 1);
                                                  Ref = Ref + "" + SubRef;
                                              }
                                              else
                                              {
                                                  Ref = Ref + "/" + SubRef;
                                              }

                                              objEntityShortList.RefNum = Ref;
                                              SubRef++;

                                          }
                                      }
                                  }
                              }

                          }
                      }


                      cmdAddService.CommandType = CommandType.StoredProcedure;
                      cmdAddService.CommandText = strQueryLeaveTyp;
                      cmdAddService.CommandType = CommandType.StoredProcedure;
                      cmdAddService.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityShortList.JournalId;
                      cmdAddService.Parameters.Add("J_DATE", OracleDbType.Date).Value = objEntityShortList.JournalDate;
                      cmdAddService.Parameters.Add("J_CURRID", OracleDbType.Int32).Value = objEntityShortList.CurrencyId;
                      cmdAddService.Parameters.Add("J_DESC", OracleDbType.Varchar2).Value = objEntityShortList.Description;
                      cmdAddService.Parameters.Add("J_AMNT", OracleDbType.Decimal).Value = objEntityShortList.JournalTotAmnt;
                      cmdAddService.Parameters.Add("J_USRID", OracleDbType.Int32).Value = objEntityShortList.User_Id;
                      cmdAddService.Parameters.Add("J_STS", OracleDbType.Int32).Value = objEntityShortList.ConfirmSts;
                      if (objEntityShortList.ExchangeRate != 0)
                          cmdAddService.Parameters.Add("J_EXC", OracleDbType.Decimal).Value = objEntityShortList.ExchangeRate;
                      else
                          cmdAddService.Parameters.Add("J_EXC", OracleDbType.Decimal).Value = DBNull.Value;

                      if (SubRef != 0)
                          cmdAddService.Parameters.Add("J_SUBREFID", OracleDbType.Int32).Value = SubRef;
                      else
                          cmdAddService.Parameters.Add("J_SUBREFID", OracleDbType.Int32).Value = null;

                      cmdAddService.Parameters.Add("J_REF", OracleDbType.Varchar2).Value = objEntityShortList.RefNum;
                      cmdAddService.Parameters.Add("J_REFSTS", OracleDbType.Int32).Value = objEntityShortList.ViewStatus;
                      cmdAddService.Parameters.Add("J_REFNEXTSEQ", OracleDbType.Int32).Value = objEntityShortList.RefSeqNo;
                      cmdAddService.ExecuteNonQuery();
                  }

                  int Count = 0;
                  foreach (clsEntityJournalLedgerDtl objDetail in objEntityJrnlLedgrList)
                  {
                      string strQueryInsertDetails = "FMS_JOURNAL.SP_INS_LEDGR_DTL_CNF";
                      using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                      {
                          cmdAddInsertDetail.Transaction = tran;
                          cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                          cmdAddInsertDetail.Parameters.Add("J_JRNLID", OracleDbType.Int32).Value = objEntityShortList.JournalId;
                          cmdAddInsertDetail.Parameters.Add("J_LEDGRID", OracleDbType.Int32).Value = objDetail.LedgerId;
                          cmdAddInsertDetail.Parameters.Add("J_AMNT", OracleDbType.Decimal).Value = objDetail.LedgerTotAmnt;
                          cmdAddInsertDetail.Parameters.Add("J_STS", OracleDbType.Int32).Value = objDetail.TabMode;
                          cmdAddInsertDetail.Parameters.Add("J_EXCHANGE_AMNT", OracleDbType.Decimal).Value = objDetail.ExchangeRate;
                          cmdAddInsertDetail.Parameters.Add("J_FINCIALID", OracleDbType.Int32).Value = objEntityShortList.FinancialYrId;
                          cmdAddInsertDetail.Parameters.Add("J_REMARKS", OracleDbType.Varchar2).Value = objDetail.Remarks;
                          cmdAddInsertDetail.Parameters.Add("J_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                          cmdAddInsertDetail.Parameters.Add("V_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                          cmdAddInsertDetail.ExecuteNonQuery();
                          string strReturn = cmdAddInsertDetail.Parameters["J_ID"].Value.ToString();
                          objDetail.JournlLedgerId = Convert.ToInt32(strReturn);

                          string strReturnVcrId = cmdAddInsertDetail.Parameters["V_ID"].Value.ToString();

                          //-------------------------Debit-----------------------------------
                          if (objDetail.TabMode == 0)
                          {
                              //One credit field
                              if (objEntityShortList.CreditCount == 1)
                              {
                                  foreach (clsEntityJournalLedgerDtl objDetailSub1 in objEntityJrnlLedgrList)
                                  {
                                      //get Credit field
                                      if (objDetailSub1.TabMode == 1)
                                      {
                                          string strQuerySubDetailsCost = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                                          using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                                          {
                                              cmdAddSubDetail.Transaction = tran;
                                              cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                              cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetailSub1.LedgerId;
                                              cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturnVcrId);
                                              cmdAddSubDetail.ExecuteNonQuery();

                                          }
                                      }
                                  }
                              }
                              else //multiple credit field
                              {
                                  //One debit field
                                  if (objEntityShortList.DebitCount == 1)
                                  {
                                      foreach (clsEntityJournalLedgerDtl objDetailSub1 in objEntityJrnlLedgrList)
                                      {
                                          if (objDetailSub1.LdgrCount != Count)
                                          {
                                              string strQuerySubDetailsCost = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                                              using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                                              {
                                                  cmdAddSubDetail.Transaction = tran;
                                                  cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                  cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetailSub1.LedgerId;
                                                  cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturnVcrId);
                                                  cmdAddSubDetail.ExecuteNonQuery();
                                              }
                                          }
                                      }
                                  }
                                  else //multiple debit field
                                  {
                                      foreach (clsEntityJournalLedgerDtl objDetailSub1 in objEntityJrnlLedgrList)
                                      {
                                          if (objDetailSub1.LdgrCount == Count)
                                          {
                                              string strQuerySubDetailsCost = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                                              using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                                              {
                                                  cmdAddSubDetail.Transaction = tran;
                                                  cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                  cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetailSub1.LedgerId;
                                                  cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturnVcrId);
                                                  cmdAddSubDetail.ExecuteNonQuery();
                                              }
                                          }
                                      }
                                  }

                              }
                          }
                          //----------------------------Credit------------------------------
                          else if (objDetail.TabMode == 1)
                          {
                              //One debit field
                              if (objEntityShortList.DebitCount == 1)
                              {
                                  foreach (clsEntityJournalLedgerDtl objDetailSub1 in objEntityJrnlLedgrList)
                                  {
                                      //Get Debit field
                                      if (objDetailSub1.TabMode == 0)
                                      {
                                          string strQuerySubDetailsCost = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                                          using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                                          {
                                              cmdAddSubDetail.Transaction = tran;
                                              cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                              cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetailSub1.LedgerId;
                                              cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturnVcrId);
                                              cmdAddSubDetail.ExecuteNonQuery();

                                          }
                                      }
                                  }
                              }
                              else //multiple debit field
                              {
                                  //One credit field
                                  if (objEntityShortList.CreditCount == 1)
                                  {
                                      foreach (clsEntityJournalLedgerDtl objDetailSub1 in objEntityJrnlLedgrList)
                                      {
                                          if (objDetailSub1.LdgrCount != Count)
                                          {
                                              string strQuerySubDetailsCost = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                                              using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                                              {
                                                  cmdAddSubDetail.Transaction = tran;
                                                  cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                  cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetailSub1.LedgerId;
                                                  cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturnVcrId);
                                                  cmdAddSubDetail.ExecuteNonQuery();
                                              }
                                          }
                                      }
                                  }
                                  else //multiple credit field
                                  {
                                      foreach (clsEntityJournalLedgerDtl objDetailSub1 in objEntityJrnlLedgrList)
                                      {
                                          if (objDetailSub1.LdgrCount == Count)
                                          {
                                              string strQuerySubDetailsCost = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                                              using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                                              {
                                                  cmdAddSubDetail.Transaction = tran;
                                                  cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                  cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetailSub1.LedgerId;
                                                  cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturnVcrId);
                                                  cmdAddSubDetail.ExecuteNonQuery();
                                              }
                                          }
                                      }
                                  }
                              }
                          }
                          foreach (clsEntityJournalCostCntrDtl objDetailSub in objEntityJrnlCostcentrList)
                          {

                              if (objDetail.TabMode == objDetailSub.TabMode && objDetail.MainTabId == objDetailSub.MainTabId)
                              {
                                  string strQueryInsertDetailsub = "FMS_JOURNAL.SP_INS_COSTCNTR_DTL_CNF";
                                  using (OracleCommand cmdAddInsertDetailS = new OracleCommand(strQueryInsertDetailsub, con))
                                  {
                                      cmdAddInsertDetailS.Transaction = tran;
                                      cmdAddInsertDetailS.CommandType = CommandType.StoredProcedure;
                                      cmdAddInsertDetailS.Parameters.Add("J_JRNLID", OracleDbType.Int32).Value = objEntityShortList.JournalId;
                                      cmdAddInsertDetailS.Parameters.Add("J_JRNLLEDGRID", OracleDbType.Int32).Value = objDetail.JournlLedgerId;
                                      cmdAddInsertDetailS.Parameters.Add("J_AMNT", OracleDbType.Decimal).Value = objDetailSub.CostCntrAmnt;
                                      cmdAddInsertDetailS.Parameters.Add("J_STS", OracleDbType.Int32).Value = objDetail.TabMode;
                                      cmdAddInsertDetailS.Parameters.Add("J_EXCHANGE_AMNT", OracleDbType.Decimal).Value = objDetailSub.ExchangeRate;

                                      if (objDetailSub.CostCenterId != 0)
                                      {
                                          if (objDetailSub.PurSaleRefNum == "")
                                          {
                                              cmdAddInsertDetailS.Parameters.Add("J_COSTCENTRID", OracleDbType.Int32).Value = objDetailSub.CostCenterId;
                                              cmdAddInsertDetailS.Parameters.Add("J_PURID", OracleDbType.Int32).Value = DBNull.Value;
                                              cmdAddInsertDetailS.Parameters.Add("J_SALEID", OracleDbType.Int32).Value = DBNull.Value;
                                          }
                                          else if (objDetailSub.PurSaleRefNum == "Deb")
                                          {
                                              cmdAddInsertDetailS.Parameters.Add("J_COSTCENTRID", OracleDbType.Int32).Value = DBNull.Value;
                                              cmdAddInsertDetailS.Parameters.Add("J_PURID", OracleDbType.Int32).Value = objDetailSub.CostCenterId;
                                              cmdAddInsertDetailS.Parameters.Add("J_SALEID", OracleDbType.Int32).Value = DBNull.Value;
                                          }
                                          else
                                          {
                                              cmdAddInsertDetailS.Parameters.Add("J_COSTCENTRID", OracleDbType.Int32).Value = DBNull.Value;
                                              cmdAddInsertDetailS.Parameters.Add("J_PURID", OracleDbType.Int32).Value = DBNull.Value;
                                              cmdAddInsertDetailS.Parameters.Add("J_SALEID", OracleDbType.Int32).Value = objDetailSub.CostCenterId;
                                          }
                                          if (objDetailSub.CostGrp1Id != 0)
                                          {
                                              cmdAddInsertDetailS.Parameters.Add("R_COST_GRP_ID_ONE", OracleDbType.Int32).Value = objDetailSub.CostGrp1Id;
                                          }
                                          else
                                          {
                                              cmdAddInsertDetailS.Parameters.Add("R_COST_GRP_ID_ONE", OracleDbType.Int32).Value = null;
                                          }
                                          if (objDetailSub.CostGrp2Id != 0)
                                          {
                                              cmdAddInsertDetailS.Parameters.Add("R_COST_GRP_ID_TWO", OracleDbType.Int32).Value = objDetailSub.CostGrp2Id;
                                          }
                                          else
                                          {
                                              cmdAddInsertDetailS.Parameters.Add("R_COST_GRP_ID_TWO", OracleDbType.Int32).Value = null;
                                          }
                                      }
                                      else
                                      {
                                          cmdAddInsertDetailS.Parameters.Add("J_COSTCENTRID", OracleDbType.Int32).Value = DBNull.Value;
                                          cmdAddInsertDetailS.Parameters.Add("J_PURID", OracleDbType.Int32).Value = DBNull.Value;
                                          cmdAddInsertDetailS.Parameters.Add("J_SALEID", OracleDbType.Int32).Value = DBNull.Value;
                                          cmdAddInsertDetailS.Parameters.Add("R_COST_GRP_ID_ONE", OracleDbType.Int32).Value = null;
                                          cmdAddInsertDetailS.Parameters.Add("R_COST_GRP_ID_TWO", OracleDbType.Int32).Value = null;
                                      }


                                      if (objDetailSub.Expense_Id != 0)
                                      {
                                          cmdAddInsertDetailS.Parameters.Add("J_EXPENSE_ID", OracleDbType.Int32).Value = objDetailSub.Expense_Id;//040
                                          cmdAddInsertDetailS.Parameters.Add("J_EXPENSE_AMT", OracleDbType.Decimal).Value = objDetailSub.Expense_Amount;//040
                                      }
                                      else
                                      {
                                          cmdAddInsertDetailS.Parameters.Add("J_EXPENSE_ID", OracleDbType.Int32).Value = null;//040
                                          cmdAddInsertDetailS.Parameters.Add("J_EXPENSE_AMT", OracleDbType.Decimal).Value = null;//040
                                      }

                                      cmdAddInsertDetailS.ExecuteNonQuery();
                                  }


                                  if (objDetailSub.PurSaleRefNum == "")
                                  {

                                      string strQueryInsertVoucher = "FMS_COMMON.SP_INS_CSTCNTR_VOUCHER_ACCOUNT";
                                      using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                                      {
                                          cmdAddSubDetail.Transaction = tran;
                                          cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                          cmdAddSubDetail.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityShortList.JournalId;
                                          cmdAddSubDetail.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = objEntityShortList.RefNum;
                                          cmdAddSubDetail.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityShortList.JournalDate;
                                          cmdAddSubDetail.Parameters.Add("P_LD_ID", OracleDbType.Int32).Value = objDetail.LedgerId;
                                          cmdAddSubDetail.Parameters.Add("P_COST_CNTR_ID", OracleDbType.Int32).Value = objDetailSub.CostCenterId;
                                          if (objDetailSub.CostGrp1Id != 0)
                                          {
                                              cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_ONE", OracleDbType.Int32).Value = objDetailSub.CostGrp1Id;
                                          }
                                          else
                                          {
                                              cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_ONE", OracleDbType.Int32).Value = null;

                                          }
                                          if (objDetailSub.CostGrp2Id != 0)
                                          {
                                              cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_TWO", OracleDbType.Int32).Value = objDetailSub.CostGrp2Id;
                                          }
                                          else
                                          {
                                              cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_TWO", OracleDbType.Int32).Value = null;

                                          }

                                          cmdAddSubDetail.Parameters.Add("P_LDGR_AMT", OracleDbType.Decimal).Value = objDetailSub.CostCntrAmnt;
                                          cmdAddSubDetail.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityShortList.Org_Id;
                                          cmdAddSubDetail.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityShortList.Corp_Id;
                                          cmdAddSubDetail.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = objEntityShortList.FinancialYrId;

                                          cmdAddSubDetail.Parameters.Add("P_VOCHR_STS", OracleDbType.Int32).Value = objDetail.TabMode;
                                          cmdAddSubDetail.Parameters.Add("P_CRNC_MST_ID", OracleDbType.Int32).Value = objEntityShortList.CurrencyId;
                                          cmdAddSubDetail.Parameters.Add("P_VOCHR_TYPE", OracleDbType.Int32).Value = 2;
                                          cmdAddSubDetail.Parameters.Add("P_VOCHR_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturnVcrId);

                                          cmdAddSubDetail.ExecuteNonQuery();

                                      }
                                  }
                                  else
                                  {
                                      if (objDetailSub.CostCenterId != 0 && objDetailSub.CostCntrAmnt != 0)
                                      {
                                          string strQueryInsertVoucher = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";
                                          using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                                          {
                                              cmdAddSubDetail.Transaction = tran;
                                              cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                              cmdAddSubDetail.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturnVcrId);
                                              cmdAddSubDetail.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = objDetail.LedgerId;

                                              cmdAddSubDetail.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = objDetailSub.CostCntrAmnt;
                                              if (objDetailSub.PurSaleRefNum == "Deb")
                                              {
                                                  cmdAddSubDetail.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 1;//Purchase settlmnt
                                              }
                                              else
                                              {
                                                  cmdAddSubDetail.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 0;//Sale settlmnt
                                              }
                                              cmdAddSubDetail.Parameters.Add("C_USRID", OracleDbType.Int32).Value = objEntityShortList.User_Id;
                                              cmdAddSubDetail.Parameters.Add("C_SALID", OracleDbType.Int32).Value = objDetailSub.CostCenterId;
                                              cmdAddSubDetail.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = objEntityShortList.JournalId;
                                              cmdAddSubDetail.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = objDetailSub.SettlmntAmmnt;
                                              cmdAddSubDetail.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = objDetail.JournlLedgerId;

                                              cmdAddSubDetail.ExecuteNonQuery();


                                              cmdAddSubDetail.Dispose();
                                          }
                                      }

                                      if (objDetailSub.Expense_Id != 0 && objDetailSub.Expense_Amount != 0)//040
                                      {
                                          string strQueryInsertVoucher = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";
                                          using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                                          {
                                              cmdAddSubDetail.Transaction = tran;
                                              cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                              cmdAddSubDetail.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturnVcrId);
                                              cmdAddSubDetail.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = objDetail.LedgerId;
                                              cmdAddSubDetail.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = objDetailSub.Expense_Amount;
                                              cmdAddSubDetail.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 5;
                                              cmdAddSubDetail.Parameters.Add("C_USRID", OracleDbType.Int32).Value = objEntityShortList.User_Id;
                                              cmdAddSubDetail.Parameters.Add("C_SALID", OracleDbType.Int32).Value = objDetailSub.Expense_Id;
                                              cmdAddSubDetail.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = objEntityShortList.JournalId;
                                              cmdAddSubDetail.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = objDetailSub.BalAmount;
                                              cmdAddSubDetail.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = objDetail.JournlLedgerId;
                                              cmdAddSubDetail.ExecuteNonQuery();
                                          }
                                      }
                                  }


                              }


                          }

                      }
                      Count++;
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

      public void ReopenJournalDtls(clsEntityJournal objEntityShortList, List<clsEntityJournalLedgerDtl> objEntityJrnlLedgrList, List<clsEntityJournalCostCntrDtl> objEntityJrnlCostcentrList)
      {
          clsDataLayer objDatatLayer = new clsDataLayer();
          string strQueryLeaveTyp = "FMS_JOURNAL.SP_REOPEN_JOURNAL";
          OracleTransaction tran;
          //insert to main register table
          using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
          {
              con.Open();
              tran = con.BeginTransaction();

              try
              {
                  using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp, con))
                  {
                      cmdAddService.Transaction = tran;
                      cmdAddService.CommandType = CommandType.StoredProcedure;
                      cmdAddService.CommandText = strQueryLeaveTyp;
                      cmdAddService.CommandType = CommandType.StoredProcedure;
                      cmdAddService.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityShortList.JournalId;
                      cmdAddService.Parameters.Add("J_USER_ID", OracleDbType.Int32).Value = objEntityShortList.User_Id;
                      cmdAddService.ExecuteNonQuery();
                  }
                  string strQueryccVoucherDel = "FMS_COMMON.SP_DEL_CC_VOUCHER_ACNT_REOPEN";
                  using (OracleCommand cmdPerfmncTmplt = new OracleCommand(strQueryccVoucherDel, con))
                  {
                      //cmdPerfmncTmplt.CommandText = strQueryVoucherDel;
                      cmdPerfmncTmplt.Transaction = tran;
                      cmdPerfmncTmplt.CommandType = CommandType.StoredProcedure;
                      cmdPerfmncTmplt.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityShortList.JournalId;
                      cmdPerfmncTmplt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityShortList.Org_Id;
                      cmdPerfmncTmplt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityShortList.Corp_Id;
                      /// clsDataLayer.ExecuteNonQuery(cmdPerfmncTmplt);
                      cmdPerfmncTmplt.ExecuteNonQuery();
                      /// 
                  }

                  foreach (clsEntityJournalLedgerDtl objDetail in objEntityJrnlLedgrList)
                  {
                      string strQueryInsertDetails = "FMS_JOURNAL.SP_UPD_LEDGR_DTL_REOP";
                      using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                      {
                          cmdAddInsertDetail.Transaction = tran;
                          cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                          cmdAddInsertDetail.Parameters.Add("J_JRNLID", OracleDbType.Int32).Value = objEntityShortList.JournalId;
                          cmdAddInsertDetail.Parameters.Add("J_LEDGRID", OracleDbType.Int32).Value = objDetail.LedgerId;
                          cmdAddInsertDetail.Parameters.Add("J_AMNT", OracleDbType.Decimal).Value = objDetail.LedgerTotAmnt;
                          cmdAddInsertDetail.Parameters.Add("J_STS", OracleDbType.Int32).Value = objDetail.TabMode;
                        
                          cmdAddInsertDetail.Parameters.Add("J_EXCHANGE_AMNT", OracleDbType.Decimal).Value = objDetail.ExchangeRate;
                          cmdAddInsertDetail.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityShortList.Org_Id;
                          cmdAddInsertDetail.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityShortList.Corp_Id;
                          cmdAddInsertDetail.ExecuteNonQuery();
                       
                          foreach (clsEntityJournalCostCntrDtl objDetailSub in objEntityJrnlCostcentrList)
                          {

                              if (objDetail.TabMode == objDetailSub.TabMode && objDetail.MainTabId == objDetailSub.MainTabId)
                              {
                                  string strQueryInsertDetailsub = "FMS_JOURNAL.SP_UPD_COSTCNTR_DTL_REOP";
                                  using (OracleCommand cmdAddInsertDetailS = new OracleCommand(strQueryInsertDetailsub, con))
                                  {
                                      cmdAddInsertDetailS.Transaction = tran;
                                      cmdAddInsertDetailS.CommandType = CommandType.StoredProcedure;
                                      cmdAddInsertDetailS.Parameters.Add("J_JRNLID", OracleDbType.Int32).Value = objEntityShortList.JournalId;
                                      cmdAddInsertDetailS.Parameters.Add("J_AMNT", OracleDbType.Decimal).Value = objDetailSub.CostCntrAmnt;
                                      cmdAddInsertDetailS.Parameters.Add("J_STS", OracleDbType.Int32).Value = objDetail.TabMode;
                                      cmdAddInsertDetailS.Parameters.Add("J_EXCHANGE_AMNT", OracleDbType.Decimal).Value = objDetailSub.ExchangeRate;
                                      if (objDetailSub.PurSaleRefNum == "")
                                      {
                                          cmdAddInsertDetailS.Parameters.Add("J_COSTCENTRID", OracleDbType.Int32).Value = objDetailSub.CostCenterId;
                                          cmdAddInsertDetailS.Parameters.Add("J_PURID", OracleDbType.Int32).Value = DBNull.Value;
                                          cmdAddInsertDetailS.Parameters.Add("J_SALEID", OracleDbType.Int32).Value = DBNull.Value;
                                      }
                                      else if (objDetailSub.PurSaleRefNum == "Deb")
                                      {
                                          cmdAddInsertDetailS.Parameters.Add("J_COSTCENTRID", OracleDbType.Int32).Value = DBNull.Value;
                                          cmdAddInsertDetailS.Parameters.Add("J_PURID", OracleDbType.Int32).Value = objDetailSub.CostCenterId;
                                          cmdAddInsertDetailS.Parameters.Add("J_SALEID", OracleDbType.Int32).Value = DBNull.Value;
                                      }
                                      else
                                      {
                                          cmdAddInsertDetailS.Parameters.Add("J_COSTCENTRID", OracleDbType.Int32).Value = DBNull.Value;

                                          cmdAddInsertDetailS.Parameters.Add("J_PURID", OracleDbType.Int32).Value = DBNull.Value;
                                          cmdAddInsertDetailS.Parameters.Add("J_SALEID", OracleDbType.Int32).Value = objDetailSub.CostCenterId;

                                      }

                                      if (objDetailSub.Expense_Id != 0)
                                      {
                                          cmdAddInsertDetailS.Parameters.Add("J_EXPENSE_ID", OracleDbType.Int32).Value = objDetailSub.Expense_Id;//040
                                          cmdAddInsertDetailS.Parameters.Add("J_EXPENSE_AMT", OracleDbType.Decimal).Value = objDetailSub.Expense_Amount;//040
                                      }
                                      else
                                      {
                                          cmdAddInsertDetailS.Parameters.Add("J_EXPENSE_ID", OracleDbType.Int32).Value = null;//040
                                          cmdAddInsertDetailS.Parameters.Add("J_EXPENSE_AMT", OracleDbType.Decimal).Value = null;//040
                                      }

                                      cmdAddInsertDetailS.ExecuteNonQuery();
                                  }
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

      public DataTable readRefFormate(clsEntityCommon ObjEntitySales)
      {
          string strQueryReadCustomerLdger = "FMS_JOURNAL.SP_RD_REF_FORMAT";
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
      public DataTable ReadRefNumberByDate(clsEntityJournal ObjEntitySales)
      {
          string strQueryReadCustomerLdger = "FMS_JOURNAL.SP_RD_REF_BYDATE";
          OracleCommand cmdReadCustomerLdger = new OracleCommand();
          cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
          cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
          cmdReadCustomerLdger.Parameters.Add("S_DATE", OracleDbType.Date).Value = ObjEntitySales.FromDate;
          cmdReadCustomerLdger.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corp_Id;
          cmdReadCustomerLdger.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Org_Id;
          cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtCustomerLdger = new DataTable();
          dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
          return dtCustomerLdger;
      }
      public DataTable ReadRefNumberByDateLast(clsEntityJournal ObjEntitySales)
      {
          string strQueryReadCustomerLdger = "FMS_JOURNAL.SP_RD_REF_BYDATE_LAST";
          OracleCommand cmdReadCustomerLdger = new OracleCommand();
          cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
          cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
          cmdReadCustomerLdger.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corp_Id;
          cmdReadCustomerLdger.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Org_Id;
          cmdReadCustomerLdger.Parameters.Add("S_REF", OracleDbType.Varchar2).Value = ObjEntitySales.RefNum;
          cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtCustomerLdger = new DataTable();
          dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
          return dtCustomerLdger;
      }


      public DataTable ReadCorpDtls(clsEntityJournal ObjEntitySales)
      {
          string strQueryReadTcs = "FMS_JOURNAL.SP_READ_CORP_DTLS";
          OracleCommand cmdReadTcs = new OracleCommand();
          cmdReadTcs.CommandText = strQueryReadTcs;
          cmdReadTcs.CommandType = CommandType.StoredProcedure;
          cmdReadTcs.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Org_Id;
          cmdReadTcs.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corp_Id;
          cmdReadTcs.Parameters.Add("S_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtLeav = new DataTable();
          dtLeav = clsDataLayer.ExecuteReader(cmdReadTcs);
          return dtLeav;
      }



      public void ConfirmJournalDtlsList(clsEntityJournal objEntityShortList, List<clsEntityJournalLedgerDtl> objEntityJrnlLedgrList, List<clsEntityJournalCostCntrDtl> objEntityJrnlCostcentrList)
      {
          clsDataLayer objDatatLayer = new clsDataLayer();
          string strQueryLeaveTyp = "FMS_JOURNAL.SP_UPD_JOURNL_MASTER_LIST";
          OracleTransaction tran;
          //insert to main register table
          using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
          {
              con.Open();
              tran = con.BeginTransaction();

              try
              {
                  using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp, con))
                  {
                      cmdAddService.Transaction = tran;

                      int SubRef = 0, AccountClsChk = 0;
                     
                          clsEntityCommon objEntCommon = new clsEntityCommon();
                          objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.JOURNAL);
                          objEntCommon.CorporateID = objEntityShortList.Corp_Id;
                          //string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                          //objEntityShortList.JournalId = Convert.ToInt32(strNextNum);
                          //CHECKING FOR CORP GLOBAL SUB REF STATUS
                          int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intCorpId = 0; string strRefAccountCls = "0";
                          intCorpId = objEntityShortList.Corp_Id;
                          intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Journal);
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


                          // string year = DateTime.Today.Year.ToString();
                          // objEntityPayment.RefNum = "REF#" + year + strNextNum;
                          intCorpId = objEntityShortList.Corp_Id;
                          int intOrgId = objEntityShortList.Org_Id;

                          objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Journal);
                          DataTable dtFormate = readRefFormate(objEntCommon);

                          clsDataLayerDateAndTime objDataLayerDateTime = new clsDataLayerDateAndTime();
                          string CurrentDate = objDataLayerDateTime.DateAndTime().ToString("dd-MM-yyyy");
                          clsCommonLibrary objCommon = new clsCommonLibrary();
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

                              objEntityAudit.FromDate = objEntityShortList.JournalDate;
                              objEntityAudit.Organisation_id = intOrgId;
                              objEntityAudit.Corporate_id = intCorpId;


                              objEntityAccnt.FromDate = objEntityShortList.JournalDate;
                              clsEntityJournal objEntityLayerStock1 = new clsEntityJournal();
                              // clsdAJournal objBusinessLayerStock1 = new clsBusinessJournal();
                              objEntityLayerStock1.FromDate = objEntityShortList.JournalDate;
                              objEntityAccnt.Corporate_id = intCorpId;
                              objEntityLayerStock1.Corp_Id = intCorpId;
                              objEntityAccnt.Organisation_id = intOrgId;
                              objEntityLayerStock1.Org_Id = intOrgId;


                              DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);



                              DataTable dtAuditCls = objEmpAuditCls.CheckAuditClosingDate(objEntityAudit);
                              if (dtAccntCls.Rows.Count > 0 || dtAuditCls.Rows.Count > 0)
                              {

                                  DataTable dtRefFormat1 = ReadRefNumberByDate(objEntityLayerStock1);
                                  if (dtRefFormat1.Rows.Count > 0)
                                  {
                                      string strRef = "";
                                      if (dtRefFormat1.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString() != "")
                                      {
                                          if (Convert.ToInt32(dtRefFormat1.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString()) != 1)
                                          {
                                              strRef = dtRefFormat1.Rows[0]["JURNL_REF"].ToString();
                                              strRef = strRef.TrimEnd('/');
                                              strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                          }
                                          else
                                          {
                                              strRef = dtRefFormat1.Rows[0]["JURNL_REF"].ToString();
                                          }
                                      }
                                      else
                                      {
                                          strRef = dtRefFormat1.Rows[0]["JURNL_REF"].ToString();
                                      }
                                      objEntityLayerStock1.RefNum = strRef;
                                      DataTable dtRefFormat = ReadRefNumberByDateLast(objEntityLayerStock1);

                                      if (dtRefFormat.Rows.Count > 0)
                                      {
                                          AccountClsChk = 1;
                                          SubRef = 1;
                                          objEntityShortList.ViewStatus = 1;
                                          if (objEntityShortList.JournalId != Convert.ToInt32(dtRefFormat.Rows[0]["JURNL_ID"].ToString()))
                                          {
                                              Ref = dtRefFormat.Rows[0]["JURNL_REF"].ToString();
                                              if (dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString() != null)
                                              {
                                                  SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString());
                                                  objEntityShortList.RefSeqNo = Convert.ToInt32(dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString());
                                              }
                                              if (SubRef != 1)
                                              {
                                                  Ref = Ref.TrimEnd('/');
                                                  Ref = Ref.Remove(Ref.LastIndexOf('/') + 1);
                                                  Ref = Ref + "" + SubRef;
                                              }
                                              else
                                              {
                                                  Ref = Ref + "/" + SubRef;
                                              }

                                              objEntityShortList.RefNum = Ref;
                                              SubRef++;

                                          }
                                      }
                                  }
                              }

                          }
                     


                      cmdAddService.CommandType = CommandType.StoredProcedure;
                      cmdAddService.CommandText = strQueryLeaveTyp;
                      cmdAddService.CommandType = CommandType.StoredProcedure;
                      cmdAddService.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityShortList.JournalId;
                      
                      cmdAddService.Parameters.Add("J_USRID", OracleDbType.Int32).Value = objEntityShortList.User_Id;
                  
                      if (SubRef != 0)
                          cmdAddService.Parameters.Add("J_SUBREFID", OracleDbType.Int32).Value = SubRef;
                      else
                          cmdAddService.Parameters.Add("J_SUBREFID", OracleDbType.Int32).Value = null;

                      cmdAddService.Parameters.Add("J_REF", OracleDbType.Varchar2).Value = objEntityShortList.RefNum;
                      cmdAddService.Parameters.Add("J_ORGID", OracleDbType.Varchar2).Value = objEntityShortList.Org_Id;
                      cmdAddService.Parameters.Add("J_CORPID", OracleDbType.Varchar2).Value = objEntityShortList.Corp_Id;
                      cmdAddService.Parameters.Add("J_REFNEXTSEQ", OracleDbType.Int32).Value = objEntityShortList.RefSeqNo;
                    
                      cmdAddService.ExecuteNonQuery();
                  }

                  int Count = 0;
                  foreach (clsEntityJournalLedgerDtl objDetail in objEntityJrnlLedgrList)
                  {
                       string strQueryInsertDetails = "FMS_JOURNAL.SP_UPD_LEDGR_DTL_CNF";
                       using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                       {
                           cmdAddInsertDetail.Transaction = tran;
                           cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                           cmdAddInsertDetail.Parameters.Add("J_JRNLID", OracleDbType.Int32).Value = objEntityShortList.JournalId;
                           cmdAddInsertDetail.Parameters.Add("J_LEDGRID", OracleDbType.Int32).Value = objDetail.LedgerId;
                        
                           cmdAddInsertDetail.Parameters.Add("J_STS", OracleDbType.Int32).Value = objDetail.TabMode;

                           cmdAddInsertDetail.Parameters.Add("J_EXCHANGE_AMNT", OracleDbType.Decimal).Value = objDetail.ExchangeRate;
                           cmdAddInsertDetail.Parameters.Add("J_FINCIALID", OracleDbType.Int32).Value = objEntityShortList.FinancialYrId;
                           cmdAddInsertDetail.Parameters.Add("J_REMARKS", OracleDbType.Varchar2).Value = objDetail.Remarks;

                           cmdAddInsertDetail.Parameters.Add("V_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                           cmdAddInsertDetail.ExecuteNonQuery();
                       
                           string strReturnVcrId = cmdAddInsertDetail.Parameters["V_ID"].Value.ToString();

                           //-------------------------Debit-----------------------------------
                           if (objDetail.TabMode == 0)
                           {
                               //One credit field
                               if (objEntityShortList.CreditCount == 1)
                               {
                                   foreach (clsEntityJournalLedgerDtl objDetailSub1 in objEntityJrnlLedgrList)
                                   {
                                       //get Credit field
                                       if (objDetailSub1.TabMode == 1)
                                       {
                                           string strQuerySubDetailsCost = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                                           using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                                           {
                                               cmdAddSubDetail.Transaction = tran;
                                               cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                               cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetailSub1.LedgerId;
                                               cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturnVcrId);
                                               cmdAddSubDetail.ExecuteNonQuery();

                                           }
                                       }
                                   }
                               }
                               else //multiple credit field
                               {
                                   //One debit field
                                   if (objEntityShortList.DebitCount == 1)
                                   {
                                       foreach (clsEntityJournalLedgerDtl objDetailSub1 in objEntityJrnlLedgrList)
                                       {
                                           if (objDetailSub1.LdgrCount != Count)
                                           {
                                               string strQuerySubDetailsCost = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                                               using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                                               {
                                                   cmdAddSubDetail.Transaction = tran;
                                                   cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                   cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetailSub1.LedgerId;
                                                   cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturnVcrId);
                                                   cmdAddSubDetail.ExecuteNonQuery();
                                               }
                                           }
                                       }
                                   }
                                   else //multiple debit field
                                   {
                                       foreach (clsEntityJournalLedgerDtl objDetailSub1 in objEntityJrnlLedgrList)
                                       {
                                           if (objDetailSub1.LdgrCount == Count)
                                           {
                                               string strQuerySubDetailsCost = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                                               using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                                               {
                                                   cmdAddSubDetail.Transaction = tran;
                                                   cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                   cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetailSub1.LedgerId;
                                                   cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturnVcrId);
                                                   cmdAddSubDetail.ExecuteNonQuery();
                                               }
                                           }
                                       }
                                   }

                               }
                           }
                           //----------------------------Credit------------------------------
                           else if (objDetail.TabMode == 1)
                           {
                               //One debit field
                               if (objEntityShortList.DebitCount == 1)
                               {
                                   foreach (clsEntityJournalLedgerDtl objDetailSub1 in objEntityJrnlLedgrList)
                                   {
                                       //Get Debit field
                                       if (objDetailSub1.TabMode == 0)
                                       {
                                           string strQuerySubDetailsCost = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                                           using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                                           {
                                               cmdAddSubDetail.Transaction = tran;
                                               cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                               cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetailSub1.LedgerId;
                                               cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturnVcrId);
                                               cmdAddSubDetail.ExecuteNonQuery();

                                           }
                                       }
                                   }
                               }
                               else //multiple debit field
                               {
                                   //One credit field
                                   if (objEntityShortList.CreditCount == 1)
                                   {
                                       foreach (clsEntityJournalLedgerDtl objDetailSub1 in objEntityJrnlLedgrList)
                                       {
                                           if (objDetailSub1.LdgrCount != Count)
                                           {
                                               string strQuerySubDetailsCost = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                                               using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                                               {
                                                   cmdAddSubDetail.Transaction = tran;
                                                   cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                   cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetailSub1.LedgerId;
                                                   cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturnVcrId);
                                                   cmdAddSubDetail.ExecuteNonQuery();
                                               }
                                           }
                                       }
                                   }
                                   else //multiple credit field
                                   {
                                       foreach (clsEntityJournalLedgerDtl objDetailSub1 in objEntityJrnlLedgrList)
                                       {
                                           if (objDetailSub1.LdgrCount == Count)
                                           {
                                               string strQuerySubDetailsCost = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                                               using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                                               {
                                                   cmdAddSubDetail.Transaction = tran;
                                                   cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                   cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetailSub1.LedgerId;
                                                   cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturnVcrId);
                                                   cmdAddSubDetail.ExecuteNonQuery();
                                               }
                                           }
                                       }
                                   }
                               }
                           }

                           foreach (clsEntityJournalCostCntrDtl objDetailSub in objEntityJrnlCostcentrList)
                           {

                               if (objDetail.TabMode == objDetailSub.TabMode && objDetail.MainTabId == objDetailSub.MainTabId)
                               {

                                   string strQueryInsertDetailsub = "FMS_JOURNAL.SP_UPD_COSTCNTR_DTL_CNF";
                                   using (OracleCommand cmdAddInsertDetailS = new OracleCommand(strQueryInsertDetailsub, con))
                                   {
                                       cmdAddInsertDetailS.Transaction = tran;
                                       cmdAddInsertDetailS.CommandType = CommandType.StoredProcedure;
                                       cmdAddInsertDetailS.Parameters.Add("J_JRNLID", OracleDbType.Int32).Value = objEntityShortList.JournalId;
                                      
                                       cmdAddInsertDetailS.Parameters.Add("J_AMNT", OracleDbType.Decimal).Value = objDetailSub.CostCntrAmnt;
                                       cmdAddInsertDetailS.Parameters.Add("J_STS", OracleDbType.Int32).Value = objDetail.TabMode;
                                       cmdAddInsertDetailS.Parameters.Add("J_EXCHANGE_AMNT", OracleDbType.Decimal).Value = objDetailSub.ExchangeRate;
                                       if (objDetailSub.PurSaleRefNum == "")
                                       {
                                           cmdAddInsertDetailS.Parameters.Add("J_COSTCENTRID", OracleDbType.Int32).Value = objDetailSub.CostCenterId;
                                           cmdAddInsertDetailS.Parameters.Add("J_PURID", OracleDbType.Int32).Value = DBNull.Value;
                                           cmdAddInsertDetailS.Parameters.Add("J_SALEID", OracleDbType.Int32).Value = DBNull.Value;
                                       }
                                       else if (objDetailSub.PurSaleRefNum == "Deb")
                                       {
                                           cmdAddInsertDetailS.Parameters.Add("J_COSTCENTRID", OracleDbType.Int32).Value = DBNull.Value;
                                           cmdAddInsertDetailS.Parameters.Add("J_PURID", OracleDbType.Int32).Value = objDetailSub.CostCenterId;
                                           cmdAddInsertDetailS.Parameters.Add("J_SALEID", OracleDbType.Int32).Value = DBNull.Value;

                                       }
                                       else
                                       {
                                           cmdAddInsertDetailS.Parameters.Add("J_COSTCENTRID", OracleDbType.Int32).Value = DBNull.Value;
                                           cmdAddInsertDetailS.Parameters.Add("J_PURID", OracleDbType.Int32).Value = DBNull.Value;
                                           cmdAddInsertDetailS.Parameters.Add("J_SALEID", OracleDbType.Int32).Value = objDetailSub.CostCenterId;
                                       }

                                       if (objDetailSub.Expense_Id != 0)
                                       {
                                           cmdAddInsertDetailS.Parameters.Add("J_EXPENSE_ID", OracleDbType.Int32).Value = objDetailSub.Expense_Id;//040
                                           cmdAddInsertDetailS.Parameters.Add("J_EXPENSE_AMT", OracleDbType.Decimal).Value = objDetailSub.Expense_Amount;//040
                                       }
                                       else
                                       {
                                           cmdAddInsertDetailS.Parameters.Add("J_EXPENSE_ID", OracleDbType.Int32).Value = null;//040
                                           cmdAddInsertDetailS.Parameters.Add("J_EXPENSE_AMT", OracleDbType.Decimal).Value = null;//040
                                       }

                                    
                                       cmdAddInsertDetailS.ExecuteNonQuery();
                                   }




                                   if (objDetailSub.PurSaleRefNum == "")
                                   {

                                       string strQueryInsertVoucher = "FMS_COMMON.SP_INS_CSTCNTR_VOUCHER_ACCOUNT";
                                       using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                                       {
                                           cmdAddSubDetail.Transaction = tran;
                                           cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                           cmdAddSubDetail.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityShortList.JournalId;
                                           cmdAddSubDetail.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = objEntityShortList.RefNum;
                                           cmdAddSubDetail.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityShortList.JournalDate;
                                           cmdAddSubDetail.Parameters.Add("P_LD_ID", OracleDbType.Int32).Value = objDetail.LedgerId;
                                           cmdAddSubDetail.Parameters.Add("P_COST_CNTR_ID", OracleDbType.Int32).Value = objDetailSub.CostCenterId;
                                           if (objDetailSub.CostGrp1Id != 0)
                                           {
                                               cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_ONE", OracleDbType.Int32).Value = objDetailSub.CostGrp1Id;
                                           }
                                           else
                                           {
                                               cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_ONE", OracleDbType.Int32).Value = null;

                                           }
                                           if (objDetailSub.CostGrp2Id != 0)
                                           {
                                               cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_TWO", OracleDbType.Int32).Value = objDetailSub.CostGrp2Id;
                                           }
                                           else
                                           {
                                               cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_TWO", OracleDbType.Int32).Value = null;

                                           }

                                           cmdAddSubDetail.Parameters.Add("P_LDGR_AMT", OracleDbType.Decimal).Value = objDetailSub.CostCntrAmnt;
                                           cmdAddSubDetail.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityShortList.Org_Id;
                                           cmdAddSubDetail.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityShortList.Corp_Id;
                                           cmdAddSubDetail.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = objEntityShortList.FinancialYrId;

                                           cmdAddSubDetail.Parameters.Add("P_VOCHR_STS", OracleDbType.Int32).Value = objDetail.TabMode;
                                           cmdAddSubDetail.Parameters.Add("P_CRNC_MST_ID", OracleDbType.Int32).Value = objEntityShortList.CurrencyId;
                                           cmdAddSubDetail.Parameters.Add("P_VOCHR_TYPE", OracleDbType.Int32).Value = 2;
                                           cmdAddSubDetail.Parameters.Add("P_VOCHR_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturnVcrId);

                                           cmdAddSubDetail.ExecuteNonQuery();

                                       }
                                   }
                                   else
                                   {
                                       if (objDetailSub.CostCenterId != 0 && objDetailSub.CostCntrAmnt != 0)
                                       {
                                           string strQueryInsertVoucher = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";
                                           using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                                           {
                                               cmdAddSubDetail.Transaction = tran;
                                               cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                               cmdAddSubDetail.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturnVcrId);
                                               cmdAddSubDetail.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = objDetail.LedgerId;

                                               cmdAddSubDetail.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = objDetailSub.CostCntrAmnt;
                                               if (objDetailSub.PurSaleRefNum == "Deb")
                                               {
                                                   cmdAddSubDetail.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 1;//Purchase settlmnt
                                               }
                                               else
                                               {
                                                   cmdAddSubDetail.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 0;//Sale settlmnt
                                               }
                                               cmdAddSubDetail.Parameters.Add("C_USRID", OracleDbType.Int32).Value = objEntityShortList.User_Id;
                                               cmdAddSubDetail.Parameters.Add("C_SALID", OracleDbType.Int32).Value = objDetailSub.CostCenterId;
                                               cmdAddSubDetail.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = objEntityShortList.JournalId;
                                               cmdAddSubDetail.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = objDetailSub.SettlmntAmmnt;
                                               cmdAddSubDetail.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = objDetail.JournlLedgerId;

                                               cmdAddSubDetail.ExecuteNonQuery();


                                               cmdAddSubDetail.Dispose();
                                           }
                                       }

                                       if (objDetailSub.Expense_Id != 0 && objDetailSub.Expense_Amount != 0)//040
                                       {
                                           string strQueryInsertVoucher = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";
                                           using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                                           {
                                               cmdAddSubDetail.Transaction = tran;
                                               cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                               cmdAddSubDetail.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = Convert.ToInt32(strReturnVcrId);
                                               cmdAddSubDetail.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = objDetail.LedgerId;
                                               cmdAddSubDetail.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = objDetailSub.Expense_Amount;
                                               cmdAddSubDetail.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 5;
                                               cmdAddSubDetail.Parameters.Add("C_USRID", OracleDbType.Int32).Value = objEntityShortList.User_Id;
                                               cmdAddSubDetail.Parameters.Add("C_SALID", OracleDbType.Int32).Value = objDetailSub.Expense_Id;
                                               cmdAddSubDetail.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = objEntityShortList.JournalId;
                                               cmdAddSubDetail.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = objDetailSub.BalAmount;
                                               cmdAddSubDetail.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = objDetail.JournlLedgerId;
                                               cmdAddSubDetail.ExecuteNonQuery();
                                           }
                                       }
                                   }

                               }


                           }

                       }
                       Count++;
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

      public void DeleteSalePurchaseLedgers(List<clsEntityJournalCostCntrDtl> ObjEntityJrnlCstCntrDEL)
      {
          foreach (clsEntityJournalCostCntrDtl objEntity in ObjEntityJrnlCstCntrDEL)
          {
              string strCommandText = "FMS_JOURNAL.SP_DELETE_ADDEDSALEPURCHS";
              OracleCommand cmdReadRcpt = new OracleCommand();
              cmdReadRcpt.CommandText = strCommandText;
              cmdReadRcpt.CommandType = CommandType.StoredProcedure;
              cmdReadRcpt.Parameters.Add("J_CST_ID", OracleDbType.Int32).Value = objEntity.JournalCostCntrId;
              clsDataLayer.ExecuteNonQuery(cmdReadRcpt);
          }
      }

      //START EVM 040
      public DataTable ReadSalesExpense(clsEntityJournal objEntityEmpSlry)
      {
          string strQueryReadEmpSlry = "FMS_JOURNAL.SP_READ_SALES_EXPENSE";
          OracleCommand cmdReadPayGrd = new OracleCommand();
          cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
          cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
          cmdReadPayGrd.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
          cmdReadPayGrd.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
          cmdReadPayGrd.Parameters.Add("J_LEDGRID", OracleDbType.Int32).Value = objEntityEmpSlry.JournlLedgerId;
          cmdReadPayGrd.Parameters.Add("J_STS", OracleDbType.Int32).Value = objEntityEmpSlry.ConfirmSts;
          cmdReadPayGrd.Parameters.Add("J_VIEWSTS", OracleDbType.Int32).Value = objEntityEmpSlry.ViewStatus;
          cmdReadPayGrd.Parameters.Add("J_JRNLID", OracleDbType.Int32).Value = objEntityEmpSlry.JournalId;
          cmdReadPayGrd.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
          DataTable dtEmpSlry = new DataTable();
          dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
          return dtEmpSlry;
      }
        //END 040



    }
}
