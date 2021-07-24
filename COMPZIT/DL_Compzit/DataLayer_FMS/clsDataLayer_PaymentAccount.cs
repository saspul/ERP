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
    public class clsDataLayer_PaymentAccount
    {
        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();

        public DataTable ReadCurrency(clsEntityPaymentAccount objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_CURRENCY";
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

        public DataTable ReadDefualtCurrency(clsEntityPaymentAccount objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READDEFLT_CURRENCY";
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

        public DataTable ReadAccountLedger(clsEntityPaymentAccount objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_ACCNT_LEDGER_READ";
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

        public DataTable ReadLeadgerReceipt(clsEntityPaymentAccount objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_RECEIPT_LEDGER";
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
        public DataTable ReadCostCenter(clsEntityPaymentAccount objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_COSTCENTER";
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
        public DataTable ReadSalesbyId(clsEntityPaymentAccount objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_PURCHASE_BY_LEDID";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_LEDGERID", OracleDbType.Int32).Value = objEntity.LedgerId;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_PAYID", OracleDbType.Int32).Value = objEntity.PaymentId;
            cmdReadRcpt.Parameters.Add("R_PAYLDGRID", OracleDbType.Int32).Value = objEntity.Payment_Ledgr_Id;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }

        public DataTable ReadOepningBalById(clsEntityPaymentAccount objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_OB_BY_LEDID";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadRcpt.Parameters.Add("R_LEDGERID", OracleDbType.Int32).Value = objEntity.LedgerId;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_PAYID", OracleDbType.Int32).Value = objEntity.PaymentId;
            cmdReadRcpt.Parameters.Add("R_PAYLDGRID", OracleDbType.Int32).Value = objEntity.Payment_Ledgr_Id;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }

        public DataTable AccntBalancebyId(clsEntityPaymentAccount objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_ACCNTBALANCE_BYID";
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
        public void InsertPaymentMaster(clsEntityPaymentAccount objEntityPayment, List<clsEntityPaymentAccount> objEntityPerfomList, List<clsEntityPaymentAccount> objEntityPerfomListGrps)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "FMS_PAYMENT_ACCOUNT.SP_INS_PAYMENT_MSTR";
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
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.FMS_PAYMENT);
                        objEntCommon.CorporateID = objEntityPayment.Corporate_id;
                        string strNextId1 = objDatatLayer.ReadNextNumber(objEntCommon);
                        string strNextId = objDatatLayer.ReadNextNumberSequanceForUI(objEntCommon);
                        objEntityPayment.PaymentId = Convert.ToInt32(strNextId1);
                        int intCorpId = objEntityPayment.Corporate_id;
                        int intOrgId = objEntityPayment.Organisation_id;
                        DataTable dtFormate = readRefFormate(objEntCommon);
                        int intUsrRolMstrId = 0;
                        string strRefAccountCls = "0";
                        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.PAYMENT_ACCOUNT);
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
                        clsCommonLibrary objCommon = new clsCommonLibrary();
                        DateTime dtCurrentDate = objCommon.textToDateTime(CurrentDate);
                        int DtYear = dtCurrentDate.Year;
                        int DtMonth = dtCurrentDate.Month;
                        string refFormatByDiv = "";
                        string dtyy = dtCurrentDate.ToString("yy");

                        clsDataLayer objBusinessLayer = new clsDataLayer();
                        clsEntityCommon objEntityCommon = new clsEntityCommon();

                        objEntityCommon.Organisation_Id = objEntityPayment.Organisation_id;
                        objEntityCommon.CorporateID = objEntityPayment.Corporate_id;
                        objEntityCommon.FinancialYrId = objEntityPayment.FinancialYrId;

                        DataTable dtCurrentFiscalYr = objBusinessLayer.ReadFinancialYearById(objEntityCommon);
                        DateTime dtFinStartDate = new DateTime();
                        DateTime dtFinEndDate = new DateTime();
                        if (dtCurrentFiscalYr.Rows.Count > 0)
                        {
                            dtFinStartDate = objCommon.textToDateTime(dtCurrentFiscalYr.Rows[0]["FINCYR_START_DT"].ToString());
                            dtFinEndDate = objCommon.textToDateTime(dtCurrentFiscalYr.Rows[0]["FINCYR_END_DT"].ToString());
                        }

                        string strRealFormat = "";
                        if (dtFormate.Rows.Count > 0)
                        {
                            if (dtFormate.Rows[0]["REF_FORMATE"].ToString() != "")
                            {
                                refFormatByDiv = dtFormate.Rows[0]["REF_FORMATE"].ToString();
                                string strReferenceFormat = "";
                                strReferenceFormat = refFormatByDiv;

                              
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
                                        strRealFormat = strRealFormat.Replace("#USR#", objEntityPayment.User_Id.ToString());
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
                                objEntityPayment.RefNum = strRealFormat;
                        }
                        else
                        {

                            objEntityPayment.RefNum = strNextId;
                        }
                        objEntityPayment.SequenceRef = Convert.ToInt32(strNextId);
                        //CHECKING SUB REF NUMBER
                        string Ref = ""; int SubRef = 1;
                        if (strRefAccountCls == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                        {
                            clsDataLayer_Account_Close objEmpAccntCls = new clsDataLayer_Account_Close();
                            
                            clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();

                            clsDataLayer_Audit_Closing objBusinessAudit = new clsDataLayer_Audit_Closing();
                            clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
                            objEntityAudit.FromDate = objEntityPayment.FromDate;
                            objEntityAudit.Corporate_id = intCorpId;
                            objEntityAudit.Organisation_id = intOrgId;
                            objEntityAccnt.FromDate = objEntityPayment.FromDate;

                            objEntityPayment.FromDate = objEntityPayment.FromDate;
                            objEntityAccnt.Corporate_id = intCorpId;
                            objEntityPayment.Corporate_id = intCorpId;
                            objEntityAccnt.Organisation_id = intOrgId;
                            objEntityPayment.Organisation_id = intOrgId;
                            DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
                            clsEntityPaymentAccount objEntityLayerPymnt = new clsEntityPaymentAccount();

                            objEntityLayerPymnt.Corporate_id = intCorpId;
                            objEntityLayerPymnt.Organisation_id = intOrgId;

                            DataTable dtAuditCls = objBusinessAudit.CheckAuditClosingDate(objEntityAudit);
                            if (dtAccntCls.Rows.Count > 0 || dtAuditCls.Rows.Count > 0)
                            {
                                DataTable dtRefFormat1 = ReadRefNumberByDate(objEntityPayment);
                                if (dtRefFormat1.Rows.Count > 0)
                                {
                                    string strRef = "";
                                    if (dtRefFormat1.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString() != "")
                                    {
                                        if (Convert.ToInt32(dtRefFormat1.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString()) != 1)
                                        {
                                            strRef = dtRefFormat1.Rows[0]["PAYMNT_REF"].ToString();
                                            strRef = strRef.TrimEnd('/');
                                            strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                        }
                                        else
                                        {
                                            strRef = dtRefFormat1.Rows[0]["PAYMNT_REF"].ToString(); 
                                        }
                                    }
                                    else
                                    {
                                        strRef = dtRefFormat1.Rows[0]["PAYMNT_REF"].ToString(); 
                                    }

                                    objEntityLayerPymnt.RefNum = strRef;
                                    DataTable dtRefFormat = ReadRefNumberByDateLast(objEntityLayerPymnt);
                                    if (dtRefFormat.Rows.Count > 0)
                                    {
                                        Ref = dtRefFormat.Rows[0]["PAYMNT_REF"].ToString();
                                        if (dtRefFormat.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString() != null)
                                        {
                                            SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString());
                                            objEntityPayment.SequenceRef = Convert.ToInt32(dtRefFormat.Rows[0]["PAYMNT_REF_SEQNUM"].ToString());
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
                                        objEntityPayment.RefNum = Ref;
                                        SubRef++;
                                    }

                                }
                            }
                        }
                        cmdAddService.CommandText = strQueryLeaveTyp;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                        cmdAddService.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = objEntityPayment.RefNum;
                        cmdAddService.Parameters.Add("P_ACCID", OracleDbType.Int32).Value = objEntityPayment.AccntNameId;
                        cmdAddService.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPayment.FromDate;
                        cmdAddService.Parameters.Add("P_CURNCY", OracleDbType.Int32).Value = objEntityPayment.CurrcyId;
                        cmdAddService.Parameters.Add("P_TOTALAMT", OracleDbType.Decimal).Value = objEntityPayment.TotalAmnt;
                        cmdAddService.Parameters.Add("P_DESRTN", OracleDbType.Varchar2).Value = objEntityPayment.Description;
                        cmdAddService.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayment.Organisation_id;
                        cmdAddService.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayment.Corporate_id;
                        cmdAddService.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityPayment.User_Id;
                        if (objEntityPayment.ExchangeRate != 0)
                        {
                            cmdAddService.Parameters.Add("P_EXCHNG", OracleDbType.Decimal).Value = objEntityPayment.ExchangeRate;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("P_EXCHNG", OracleDbType.Decimal).Value = null;
                        }
                        cmdAddService.Parameters.Add("P_PAY_MODE", OracleDbType.Int32).Value = objEntityPayment.PayemntMode;

                        if (objEntityPayment.PayemntMode == 1)
                        {
                            cmdAddService.Parameters.Add("P_CHQ_BK", OracleDbType.Int32).Value = objEntityPayment.ChequeBookId;
                            cmdAddService.Parameters.Add("P_CHQ_NUM", OracleDbType.Int32).Value = objEntityPayment.ChequeBookNumber;
                            cmdAddService.Parameters.Add("P_CHQ_ISSUE", OracleDbType.Int32).Value = objEntityPayment.ChequeIssue;
                            if (objEntityPayment.ChequeIssue == 1)
                            {
                                cmdAddService.Parameters.Add("P_CHQ_ISU_DATE", OracleDbType.Date).Value = objEntityPayment.ChequeIssueDate;
                            }
                            else
                            {
                                cmdAddService.Parameters.Add("P_CHQ_ISU_DATE", OracleDbType.Date).Value = null;
                            }
                            cmdAddService.Parameters.Add("P_PAYEE", OracleDbType.Varchar2).Value = objEntityPayment.Payee;

                            
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("P_CHQ_BK", OracleDbType.Int32).Value = null;
                            cmdAddService.Parameters.Add("P_CHQ_NUM", OracleDbType.Int32).Value = null;
                            cmdAddService.Parameters.Add("P_CHQ_ISSUE", OracleDbType.Int32).Value = null;
                            cmdAddService.Parameters.Add("P_CHQ_ISU_DATE", OracleDbType.Date).Value = null;
                            cmdAddService.Parameters.Add("P_PAYEE", OracleDbType.Varchar2).Value = null;

                        }


                        if (objEntityPayment.PayemntMode == 2)
                        {
                            cmdAddService.Parameters.Add("P_DD", OracleDbType.Varchar2).Value = objEntityPayment.DD_Number;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("P_DD", OracleDbType.Varchar2).Value = null;

                        }
                        if (objEntityPayment.PayemntMode == 3)
                        {
                            cmdAddService.Parameters.Add("P_BK_MODE", OracleDbType.Int32).Value = objEntityPayment.BankTransfer_Mode;
                            cmdAddService.Parameters.Add("P_BK_NAME", OracleDbType.Varchar2).Value = objEntityPayment.Bank_BankTransfer;
                            cmdAddService.Parameters.Add("P_BK_IBAN", OracleDbType.Varchar2).Value = objEntityPayment.IBAN_BankTransfer;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("P_BK_MODE", OracleDbType.Int32).Value = null;
                            cmdAddService.Parameters.Add("P_BK_NAME", OracleDbType.Varchar2).Value = null;
                            cmdAddService.Parameters.Add("P_BK_IBAN", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityPayment.PayemntMode == 1 || objEntityPayment.PayemntMode == 2 || objEntityPayment.PayemntMode == 3)
                        {
                            cmdAddService.Parameters.Add("P_PAY_DATE", OracleDbType.Date).Value = objEntityPayment.ToDate;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("P_PAY_DATE", OracleDbType.Date).Value = null;
                        }


                        cmdAddService.Parameters.Add("P_SUBREFID", OracleDbType.Int32).Value = SubRef;
                        cmdAddService.Parameters.Add("P_SEQNUM", OracleDbType.Int32).Value = objEntityPayment.SequenceRef;


                        if (objEntityPayment.RecurPeriodId != 0)
                        {
                            cmdAddService.Parameters.Add("P_REC_PERIOD", OracleDbType.Int32).Value = objEntityPayment.RecurPeriodId;
                            cmdAddService.Parameters.Add("P_REC_REMIND_DAYS", OracleDbType.Int32).Value = objEntityPayment.RecurRemindDays;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("P_REC_PERIOD", OracleDbType.Int32).Value = DBNull.Value;
                            cmdAddService.Parameters.Add("P_REC_REMIND_DAYS", OracleDbType.Int32).Value = DBNull.Value;
                        }
                        cmdAddService.Parameters.Add("P_REC_SUBID", OracleDbType.Int32).Value = objEntityPayment.RecurSubId;
                        cmdAddService.Parameters.Add("POST_CHK_STS", OracleDbType.Int32).Value = objEntityPayment.PostdatedStatus;
                        if (objEntityPayment.PostdateChqId != 0)
                        {
                            cmdAddService.Parameters.Add("POST_CHQ_ID", OracleDbType.Int32).Value = objEntityPayment.PostdateChqId;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("POST_CHQ_ID", OracleDbType.Int32).Value = DBNull.Value;
                        }
                        if (objEntityPayment.PostdateChqId != 0)
                        {
                            cmdAddService.Parameters.Add("POST_CHQ_DTL_ID", OracleDbType.Int32).Value = objEntityPayment.PostdateChqDtlId;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("POST_CHQ_DTL_ID", OracleDbType.Int32).Value = DBNull.Value;
                        }
                        cmdAddService.ExecuteNonQuery();
                    }
                    foreach (clsEntityPaymentAccount objSubDetail in objEntityPerfomListGrps)
                    {
                        if (objSubDetail.LedgerId != 0)
                        {
                            string strQuerySubDetails = "FMS_PAYMENT_ACCOUNT.SP_INS_PAYMENT_LEDGER";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetails, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                clsEntityCommon objEntCommon = new clsEntityCommon();
                                objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PAYMENT_LEDGER);
                                objEntCommon.CorporateID = objEntityPayment.Corporate_id;
                                string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                                objSubDetail.Payment_Ledgr_Id = Convert.ToInt32(strNextNum);
                                cmdAddSubDetail.Parameters.Add("P_PLID", OracleDbType.Int32).Value = objSubDetail.Payment_Ledgr_Id;
                                cmdAddSubDetail.Parameters.Add("P_LLID", OracleDbType.Int32).Value = objSubDetail.LedgerId;
                                cmdAddSubDetail.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                cmdAddSubDetail.Parameters.Add("P_PAMT", OracleDbType.Decimal).Value = objSubDetail.LedgerAmnt;
                                cmdAddSubDetail.Parameters.Add("P_REMRK", OracleDbType.Varchar2).Value = objSubDetail.Remarks;
                                cmdAddSubDetail.ExecuteNonQuery();
                            }

                            foreach (clsEntityPaymentAccount objSubDetailCost in objEntityPerfomList)
                            {
                                if (objSubDetail.LedgerId == objSubDetailCost.LedgerId && objSubDetail.LedgerRow == objSubDetailCost.LedgerRow)
                                {
                                    string strQuerySubDetailsCost = "FMS_PAYMENT_ACCOUNT.SP_INS_PAYMENT_COSTCENTER";
                                    using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                                    {
                                        cmdAddSubDetail.Transaction = tran;
                                        cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                        if (objSubDetailCost.CostCtrId != 0)
                                        {
                                            cmdAddSubDetail.Parameters.Add("P_CST_CNTRID", OracleDbType.Int32).Value = objSubDetailCost.CostCtrId;
                                        }
                                        else
                                        {
                                            cmdAddSubDetail.Parameters.Add("P_CST_CNTRID", OracleDbType.Int32).Value = null;
                                        }
                                        cmdAddSubDetail.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                        cmdAddSubDetail.Parameters.Add("P_CST_CNTR_AMT", OracleDbType.Decimal).Value = objSubDetailCost.CstCntrAmnt;
                                               
                                        cmdAddSubDetail.Parameters.Add("P_PLID", OracleDbType.Int32).Value = objSubDetail.Payment_Ledgr_Id;
                                        if (objSubDetailCost.PurchaseId != 0)
                                        {
                                            cmdAddSubDetail.Parameters.Add("P_PURCH_ID", OracleDbType.Int32).Value = objSubDetailCost.PurchaseId;
                                        }
                                        else
                                        {
                                            cmdAddSubDetail.Parameters.Add("P_PURCH_ID", OracleDbType.Int32).Value = null;
                                        }

                                        cmdAddSubDetail.Parameters.Add("P_PSTS", OracleDbType.Int32).Value = objSubDetailCost.Status;
                                        if (objSubDetailCost.CostGrp1Id != 0)
                                        {
                                            cmdAddSubDetail.Parameters.Add("R_COST_GRP_ID_ONE", OracleDbType.Int32).Value = objSubDetailCost.CostGrp1Id;
                                        }
                                        else
                                        {
                                            cmdAddSubDetail.Parameters.Add("R_COST_GRP_ID_ONE", OracleDbType.Int32).Value = null;

                                        }
                                        if (objSubDetailCost.CostGrp2Id != 0)
                                        {
                                            cmdAddSubDetail.Parameters.Add("R_COST_GRP_ID_TWO", OracleDbType.Int32).Value = objSubDetailCost.CostGrp2Id;
                                        }
                                        else
                                        {
                                            cmdAddSubDetail.Parameters.Add("R_COST_GRP_ID_TWO", OracleDbType.Int32).Value = null;

                                        }
                                        if (objSubDetailCost.DebitNoteStatus != 0)
                                        {
                                            cmdAddSubDetail.Parameters.Add("R_DNT_STS", OracleDbType.Int32).Value = objSubDetailCost.DebitNoteStatus;
                                            if (objSubDetailCost.DebitNoteId != 0)
                                                cmdAddSubDetail.Parameters.Add("R_DNT_ID", OracleDbType.Int32).Value = objSubDetailCost.DebitNoteId;
                                            else
                                                cmdAddSubDetail.Parameters.Add("R_DNT_ID", OracleDbType.Int32).Value = null;
                                            if (objSubDetailCost.DebitNoteAmount != 0)
                                                cmdAddSubDetail.Parameters.Add("R_DNT_AMT", OracleDbType.Decimal).Value = objSubDetailCost.DebitNoteAmount;
                                            else
                                                cmdAddSubDetail.Parameters.Add("R_DNT_AMT", OracleDbType.Decimal).Value = null;
                                        }
                                        else
                                        {
                                            cmdAddSubDetail.Parameters.Add("R_DNT_STS", OracleDbType.Int32).Value = objSubDetailCost.DebitNoteStatus;
                                            cmdAddSubDetail.Parameters.Add("R_DNT_ID", OracleDbType.Int32).Value = null;
                                            cmdAddSubDetail.Parameters.Add("R_DNT_AMT", OracleDbType.Decimal).Value = null;
                                        }

                                        cmdAddSubDetail.Parameters.Add("P_OBPAID_AMT", OracleDbType.Decimal).Value = objSubDetailCost.PaidAmt;
                                        cmdAddSubDetail.Parameters.Add("P_OBBAL_AMT", OracleDbType.Decimal).Value = objSubDetailCost.BalnceAmt;

                                        //0043
                                        cmdAddSubDetail.Parameters.Add("P_EXPENSE_AMT", OracleDbType.Decimal).Value = objSubDetailCost.ExpnsAmnt;
                                        if (objSubDetailCost.ExpenceId != 0)
                                        {
                                            cmdAddSubDetail.Parameters.Add("P_EXPNSID", OracleDbType.Int32).Value = objSubDetailCost.ExpenceId;
                                        }
                                        else
                                        {
                                            cmdAddSubDetail.Parameters.Add("P_EXPNSID", OracleDbType.Int32).Value = null;
                                        }
                                        //end

                                        cmdAddSubDetail.ExecuteNonQuery();
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
        public DataTable Payment_List(clsEntityPaymentAccount objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_PAYMENT_LIST";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadRcpt.Parameters.Add("PR_ACC", OracleDbType.Int32).Value = objEntity.AccntNameId;
            cmdReadRcpt.Parameters.Add("PR_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("PR_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("PR_CANCEL", OracleDbType.Int32).Value = objEntity.cnclStatus;
            cmdReadRcpt.Parameters.Add("PR_LDR", OracleDbType.Int32).Value = objEntity.LedgerId;
            if (objEntity.FromDate != DateTime.MinValue)
            {
                cmdReadRcpt.Parameters.Add("FROMDT", OracleDbType.Date).Value = objEntity.FromDate;
            }
            else
            {
                cmdReadRcpt.Parameters.Add("FROMDT", OracleDbType.Date).Value = null;
            }
            if (objEntity.ToDate != DateTime.MinValue)
            {
                cmdReadRcpt.Parameters.Add("TODT", OracleDbType.Date).Value = objEntity.ToDate;
            }
            else
            {
                cmdReadRcpt.Parameters.Add("TODT", OracleDbType.Date).Value = null;
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
            cmdReadRcpt.Parameters.Add("PR_PUR_STS", OracleDbType.Int32).Value = objEntity.ConfirmStatus;
            cmdReadRcpt.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public void CancelPaymentAccount(clsEntityPaymentAccount objEntity)
        {
            string strQuerylWelfare = "FMS_PAYMENT_ACCOUNT.SP_DEL_PAYMENT";
            using (OracleCommand cmdlWelfare = new OracleCommand())
            {
                cmdlWelfare.CommandText = strQuerylWelfare;
                cmdlWelfare.CommandType = CommandType.StoredProcedure;
                cmdlWelfare.Parameters.Add("PRDCT", OracleDbType.Int32).Value = objEntity.PaymentId;
                cmdlWelfare.Parameters.Add("USRID", OracleDbType.Int32).Value = objEntity.User_Id;
                cmdlWelfare.Parameters.Add("CNSL_RSN", OracleDbType.Varchar2).Value = objEntity.CancelReason;
                clsDataLayer.ExecuteNonQuery(cmdlWelfare);
            }
        }
        public DataTable Read_PayemntByID(clsEntityPaymentAccount objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_PAYMENT_BYID";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadRcpt.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntity.PaymentId;
            cmdReadRcpt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable Read_PayemntLedgerByID(clsEntityPaymentAccount objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_PAYMENT_LDGR_BYID";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadRcpt.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntity.PaymentId;
            cmdReadRcpt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable Read_PayemntLedgerByIDForPrint(clsEntityPaymentAccount objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_LDGR_DTLS_BYID_PRNT";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadRcpt.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntity.PaymentId;
            cmdReadRcpt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable Read_PayemntCostByID(clsEntityPaymentAccount objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_PAYMENT_COST_BYID";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadRcpt.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntity.PaymentId;
            cmdReadRcpt.Parameters.Add("P_LID", OracleDbType.Int32).Value = objEntity.Payment_Ledgr_Id;
            cmdReadRcpt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public void UpdatePaymentLedgerCostCenter(clsEntityPaymentAccount objEntityPayment, List<clsEntityPaymentAccount> objEntityLedgerIns, List<clsEntityPaymentAccount> objEntityLedgerUpd, List<clsEntityPaymentAccount> objEntityLedgerDel, List<clsEntityPaymentAccount> objEntityCostCenterIns, List<clsEntityPaymentAccount> objEntityCostCenterUpd, List<clsEntityPaymentAccount> objEntityCostCenterDel)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "FMS_PAYMENT_ACCOUNT.SP_UPD_PAYMENT_MSTR";
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
                        string Ref = ""; int SubRef = 1;
                        if (objEntityPayment.FromDate != objEntityPayment.UpdPaymentDate)
                        {
                            clsEntityCommon objEntCommon = new clsEntityCommon();
                            objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.FMS_PAYMENT);
                            objEntCommon.CorporateID = objEntityPayment.Corporate_id;
                            // string strNextId = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                            int intCorpId = objEntityPayment.Corporate_id;
                            int intOrgId = objEntityPayment.Organisation_id;
                            DataTable dtFormate = readRefFormate(objEntCommon);
                            int intUsrRolMstrId = 0;
                            string strRefAccountCls = "0";
                            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.PAYMENT_ACCOUNT);
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
                            clsCommonLibrary objCommon = new clsCommonLibrary();
                            DateTime dtCurrentDate = objCommon.textToDateTime(CurrentDate);
                            int DtYear = dtCurrentDate.Year;
                            int DtMonth = dtCurrentDate.Month;
                            string refFormatByDiv = "";
                            string strRealFormat = "";

                            //CHECKING SUB REF NUMBER
                            if (strRefAccountCls == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                            {
                                clsDataLayer_Account_Close objEmpAccntCls = new clsDataLayer_Account_Close();
                                clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();

                                clsDataLayer_Audit_Closing objBusinessAudit = new clsDataLayer_Audit_Closing();
                                clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
                                objEntityAudit.FromDate = objEntityPayment.FromDate;
                                objEntityAudit.Corporate_id = intCorpId;
                                objEntityAudit.Organisation_id = intOrgId;
                                objEntityAccnt.FromDate = objEntityPayment.FromDate;
                                objEntityPayment.FromDate = objEntityPayment.FromDate;
                                objEntityAccnt.Corporate_id = intCorpId;
                                objEntityPayment.Corporate_id = intCorpId;
                                objEntityAccnt.Organisation_id = intOrgId;
                                objEntityPayment.Organisation_id = intOrgId;
                                DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
                                clsEntityPaymentAccount objEntityLayerStock1 = new clsEntityPaymentAccount();
                                objEntityLayerStock1.Corporate_id = intCorpId;
                                objEntityLayerStock1.Organisation_id = intOrgId;
                                DataTable dtAuditCls = objBusinessAudit.CheckAuditClosingDate(objEntityAudit);
                                if (dtAccntCls.Rows.Count > 0 || dtAuditCls.Rows.Count > 0)
                                {
                                    DataTable dtRefFormat1 = ReadRefNumberByDate(objEntityPayment);
                                    if (dtRefFormat1.Rows.Count > 0)
                                    {
                                        string strRef = "";
                                        if (dtRefFormat1.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString() != "")
                                        {
                                            if (Convert.ToInt32(dtRefFormat1.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString()) != 1)
                                            {
                                                strRef = dtRefFormat1.Rows[0]["PAYMNT_REF"].ToString();
                                                strRef = strRef.TrimEnd('/');
                                                strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                            }
                                            else
                                            {
                                                strRef = dtRefFormat1.Rows[0]["PAYMNT_REF"].ToString(); ;
                                            }
                                        }
                                        else
                                        {
                                            strRef = dtRefFormat1.Rows[0]["PAYMNT_REF"].ToString();

                                        }

                                        objEntityLayerStock1.RefNum = strRef;
                                        DataTable dtRefFormat = ReadRefNumberByDateLast(objEntityLayerStock1);
                                        if (dtRefFormat.Rows.Count > 0)
                                        {
                                            if (objEntityPayment.PaymentId != Convert.ToInt32(dtRefFormat.Rows[0]["PAYMNT_ID"].ToString()))
                                            {
                                                Ref = dtRefFormat.Rows[0]["PAYMNT_REF"].ToString();
                                                if (dtRefFormat.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString() != null)
                                                {
                                                    SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString());
                                                    objEntityPayment.SequenceRef = Convert.ToInt32(dtRefFormat.Rows[0]["PAYMNT_REF_SEQNUM"].ToString());
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
                                                objEntityPayment.RefNum = Ref;
                                                SubRef++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        cmdAddService.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                        cmdAddService.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = objEntityPayment.RefNum;
                        cmdAddService.Parameters.Add("P_ACCID", OracleDbType.Int32).Value = objEntityPayment.AccntNameId;
                        cmdAddService.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPayment.FromDate;
                        cmdAddService.Parameters.Add("P_CURNCY", OracleDbType.Int32).Value = objEntityPayment.CurrcyId;
                        cmdAddService.Parameters.Add("P_TOTALAMT", OracleDbType.Decimal).Value = objEntityPayment.TotalAmnt;
                        cmdAddService.Parameters.Add("P_DESRTN", OracleDbType.Varchar2).Value = objEntityPayment.Description;
                        cmdAddService.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityPayment.User_Id;
                        cmdAddService.Parameters.Add("P_STS", OracleDbType.Int32).Value = objEntityPayment.ConfirmStatus;
                        if (objEntityPayment.ExchangeRate != 0)
                        {
                            cmdAddService.Parameters.Add("P_EXCHNG", OracleDbType.Decimal).Value = objEntityPayment.ExchangeRate;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("P_EXCHNG", OracleDbType.Decimal).Value = null;
                        }
                        cmdAddService.Parameters.Add("P_PAY_MODE", OracleDbType.Int32).Value = objEntityPayment.PayemntMode;

                        if (objEntityPayment.PayemntMode == 1)
                        {
                            cmdAddService.Parameters.Add("P_CHQ_BK", OracleDbType.Int32).Value = objEntityPayment.ChequeBookId;
                            cmdAddService.Parameters.Add("P_CHQ_NUM", OracleDbType.Int32).Value = objEntityPayment.ChequeBookNumber;
                            cmdAddService.Parameters.Add("P_CHQ_ISSUE", OracleDbType.Int32).Value = objEntityPayment.ChequeIssue;
                            if (objEntityPayment.ChequeIssue == 1)
                            {
                                cmdAddService.Parameters.Add("P_CHQ_ISU_DATE", OracleDbType.Date).Value = objEntityPayment.ChequeIssueDate;
                            }
                            else
                            {
                                cmdAddService.Parameters.Add("P_CHQ_ISU_DATE", OracleDbType.Date).Value = null;
                            }
                            cmdAddService.Parameters.Add("P_PAYEE", OracleDbType.Varchar2).Value = objEntityPayment.Payee;

                        }
                        else
                        {
                            cmdAddService.Parameters.Add("P_CHQ_BK", OracleDbType.Int32).Value = null;
                            cmdAddService.Parameters.Add("P_CHQ_NUM", OracleDbType.Int32).Value = null;
                            cmdAddService.Parameters.Add("P_CHQ_ISSUE", OracleDbType.Int32).Value = null;
                            cmdAddService.Parameters.Add("P_CHQ_ISU_DATE", OracleDbType.Date).Value = null;
                            cmdAddService.Parameters.Add("P_PAYEE", OracleDbType.Varchar2).Value = null;

                        }


                        if (objEntityPayment.PayemntMode == 2)
                        {
                            cmdAddService.Parameters.Add("P_DD", OracleDbType.Varchar2).Value = objEntityPayment.DD_Number;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("P_DD", OracleDbType.Varchar2).Value = null;

                        }
                        if (objEntityPayment.PayemntMode == 3)
                        {
                            cmdAddService.Parameters.Add("P_BK_MODE", OracleDbType.Int32).Value = objEntityPayment.BankTransfer_Mode;
                            cmdAddService.Parameters.Add("P_BK_NAME", OracleDbType.Varchar2).Value = objEntityPayment.Bank_BankTransfer;
                            cmdAddService.Parameters.Add("P_BK_IBAN", OracleDbType.Varchar2).Value = objEntityPayment.IBAN_BankTransfer;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("P_BK_MODE", OracleDbType.Int32).Value = null;
                            cmdAddService.Parameters.Add("P_BK_NAME", OracleDbType.Varchar2).Value = null;
                            cmdAddService.Parameters.Add("P_BK_IBAN", OracleDbType.Varchar2).Value = null;
                        }
                        if (objEntityPayment.PayemntMode == 1 || objEntityPayment.PayemntMode == 2 || objEntityPayment.PayemntMode == 3)
                        {
                            cmdAddService.Parameters.Add("P_PAY_DATE", OracleDbType.Date).Value = objEntityPayment.ToDate;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("P_PAY_DATE", OracleDbType.Date).Value = null;
                        }
                        cmdAddService.Parameters.Add("J_SUBREFID", OracleDbType.Int32).Value = SubRef;
                        cmdAddService.Parameters.Add("P_SEQNUM", OracleDbType.Int32).Value = objEntityPayment.SequenceRef;


                        if (objEntityPayment.RecurPeriodId != 0)
                        {
                            cmdAddService.Parameters.Add("P_REC_PERIOD", OracleDbType.Int32).Value = objEntityPayment.RecurPeriodId;
                            cmdAddService.Parameters.Add("P_REC_REMIND_DAYS", OracleDbType.Int32).Value = objEntityPayment.RecurRemindDays;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("P_REC_PERIOD", OracleDbType.Int32).Value = DBNull.Value;
                            cmdAddService.Parameters.Add("P_REC_REMIND_DAYS", OracleDbType.Int32).Value = DBNull.Value;
                        }
                        cmdAddService.ExecuteNonQuery();
                    }

                    //on confirm
                    if (objEntityPayment.ConfirmStatus == 1)
                    {
                        //update accnt book ledger balance
                        string strQueryUpdateLedger = "FMS_PAYMENT_ACCOUNT.SP_UPDATE_LEDGER_MASTR";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryUpdateLedger, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objEntityPayment.AccntNameId;
                            cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = objEntityPayment.TotalAmnt;
                            cmdAddSubDetail.ExecuteNonQuery();
                        }

                        //insert Account book details to vocher account
                        string strQueryInsertVoucher = "FMS_PAYMENT_ACCOUNT.SP_INS_VOUCHER_ACCOUNT";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                            cmdAddSubDetail.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = objEntityPayment.RefNum;
                            cmdAddSubDetail.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPayment.FromDate;
                            cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objEntityPayment.AccntNameId;
                            cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = objEntityPayment.TotalAmnt;
                            cmdAddSubDetail.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayment.Organisation_id;
                            cmdAddSubDetail.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayment.Corporate_id;
                            cmdAddSubDetail.Parameters.Add("P_VOCHR", OracleDbType.Int32).Value = 1;
                            cmdAddSubDetail.Parameters.Add("P_DESC", OracleDbType.Varchar2).Value = objEntityPayment.Description;
                            cmdAddSubDetail.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = objEntityPayment.FinancialYrId;
                            cmdAddSubDetail.Parameters.Add("P_BANKSTS", OracleDbType.Int32).Value = 1;
                            cmdAddSubDetail.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 1;
                            cmdAddSubDetail.Parameters.Add("P_VOUCHR_CAT", OracleDbType.Int32).Value = 0;
                            cmdAddSubDetail.Parameters.Add("L_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                            cmdAddSubDetail.ExecuteNonQuery();
                            string strReturn = cmdAddSubDetail.Parameters["L_ID"].Value.ToString();
                            cmdAddSubDetail.Dispose();
                            objEntityPayment.AccountVocherID = Convert.ToInt32(strReturn);
                        }
                    }

                    string strQueryDeleteCostCentr = "FMS_PAYMENT_ACCOUNT.SP_DELETE_LEDGER_MASTR";
                    using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryDeleteCostCentr, con))
                    {
                        cmdAddSubDetail.Transaction = tran;
                        cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                        cmdAddSubDetail.Parameters.Add("P_PLID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                        cmdAddSubDetail.ExecuteNonQuery();
                    }

                    //paymnt ledgers INSERT
                    foreach (clsEntityPaymentAccount objSubDetail in objEntityLedgerIns)
                    {
                        if (objSubDetail.LedgerId != 0)
                        {
                            string strQuerySubDetails = "FMS_PAYMENT_ACCOUNT.SP_INS_PAYMENT_LEDGER";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetails, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                clsEntityCommon objEntCommon = new clsEntityCommon();
                                objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PAYMENT_LEDGER);
                                objEntCommon.CorporateID = objEntityPayment.Corporate_id;
                                string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                                objSubDetail.Payment_Ledgr_Id = Convert.ToInt32(strNextNum);
                                cmdAddSubDetail.Parameters.Add("P_PLID", OracleDbType.Int32).Value = objSubDetail.Payment_Ledgr_Id;
                                cmdAddSubDetail.Parameters.Add("P_LLID", OracleDbType.Int32).Value = objSubDetail.LedgerId;
                                cmdAddSubDetail.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                cmdAddSubDetail.Parameters.Add("P_PAMT", OracleDbType.Decimal).Value = objSubDetail.LedgerAmnt;
                                cmdAddSubDetail.Parameters.Add("P_REMRK", OracleDbType.Varchar2).Value = objSubDetail.Remarks;
                                cmdAddSubDetail.ExecuteNonQuery();
                            }

                            //on confirm
                            if (objEntityPayment.ConfirmStatus == 1)
                            {
                                //update ledger balance
                                string strQueryUpdateLedger = "FMS_PAYMENT_ACCOUNT.SP_UPD_LDGR_ACNT_REOPEN";
                                using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryUpdateLedger, con))
                                {
                                    cmdAddSubDetail.Transaction = tran;
                                    cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                    cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objSubDetail.LedgerId;
                                    cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = objSubDetail.LedgerAmnt;
                                    cmdAddSubDetail.ExecuteNonQuery();
                                }

                                //Insert Ledger details to Vocher Account
                                string strQueryInsertVoucher = "FMS_PAYMENT_ACCOUNT.SP_INS_VOUCHER_ACCOUNT";
                                using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucher, con))
                                {
                                    cmdAddVoucher.Transaction = tran;
                                    cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                    cmdAddVoucher.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                    cmdAddVoucher.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = objEntityPayment.RefNum;
                                    cmdAddVoucher.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPayment.FromDate;
                                    cmdAddVoucher.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objSubDetail.LedgerId;
                                    if (objSubDetail.LedgerAmnt != 0)
                                    {
                                        cmdAddVoucher.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = objSubDetail.LedgerAmnt;
                                    }
                                    else if (objSubDetail.PaidAmt != 0)
                                    {
                                        cmdAddVoucher.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = objSubDetail.PaidAmt;
                                    }
                                    cmdAddVoucher.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayment.Organisation_id;
                                    cmdAddVoucher.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayment.Corporate_id;

                                    cmdAddVoucher.Parameters.Add("P_VOCHR", OracleDbType.Int32).Value = 0;
                                    cmdAddVoucher.Parameters.Add("P_DESC", OracleDbType.Varchar2).Value = objSubDetail.Remarks;
                                    cmdAddVoucher.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = objEntityPayment.FinancialYrId;
                                    cmdAddVoucher.Parameters.Add("P_BANKSTS", OracleDbType.Int32).Value = 0;
                                    cmdAddVoucher.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 0;
                                    cmdAddVoucher.Parameters.Add("P_VOUCHR_CAT", OracleDbType.Int32).Value = 0;
                                    cmdAddVoucher.Parameters.Add("L_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                    cmdAddVoucher.ExecuteNonQuery();
                                    string strReturn = cmdAddVoucher.Parameters["L_ID"].Value.ToString();
                                    cmdAddVoucher.Dispose();
                                    objEntityPayment.VoucherID = Convert.ToInt32(strReturn);
                                }

                                //voucher details table
                                string strQueryInsertVoucherDtls = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS"; //Ledger to Account
                                using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherDtls, con))
                                {
                                    cmdAddVoucher.Transaction = tran;
                                    cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                    cmdAddVoucher.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objEntityPayment.AccntNameId;
                                    cmdAddVoucher.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = objEntityPayment.VoucherID;
                                    cmdAddVoucher.ExecuteNonQuery();

                                }
                                string strQueryInsertVoucherAccDtls = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";  //Account to Ledger
                                using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherAccDtls, con))
                                {
                                    cmdAddVoucher.Transaction = tran;
                                    cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                    cmdAddVoucher.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objSubDetail.LedgerId;
                                    cmdAddVoucher.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = objEntityPayment.AccountVocherID;
                                    cmdAddVoucher.ExecuteNonQuery();
                                }

                                //opening balance settlemnt
                                if (objEntityPayment.VoucherCategory == 1)
                                {
                                    if (objSubDetail.PaidAmt > 0)
                                    {
                                        //updating opening balance row in voucher table
                                        string strQueryInsertVoucher1 = "FMS_PAYMENT_ACCOUNT.SP_UPDATE_VOUCHER_ACCOUNT";
                                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher1, con))
                                        {
                                            cmdAddSubDetail.Transaction = tran;
                                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                            cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objSubDetail.LedgerId;
                                            cmdAddSubDetail.Parameters.Add("P_VOUCHR_CAT", OracleDbType.Int32).Value = objEntityPayment.VoucherCategory;
                                            cmdAddSubDetail.Parameters.Add("R_OBPAID_AMT", OracleDbType.Decimal).Value = objSubDetail.BalnceAmt;//balancamt
                                            cmdAddSubDetail.Parameters.Add("L_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                            cmdAddSubDetail.ExecuteNonQuery();
                                        }
                                        //inserting opening balance settlement to voucher settlement table
                                        string strQueryInsertVoucherSettleDtls = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";  //Add settle amount details
                                        using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherSettleDtls, con))
                                        {
                                            cmdAddVoucher.Transaction = tran;
                                            cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                            cmdAddVoucher.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = objEntityPayment.VoucherID;
                                            cmdAddVoucher.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = objSubDetail.LedgerId;
                                            cmdAddVoucher.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = objSubDetail.PaidAmt;//paid amt
                                            cmdAddVoucher.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 4;
                                            cmdAddVoucher.Parameters.Add("C_USRID", OracleDbType.Int32).Value = objEntityPayment.User_Id;
                                            cmdAddVoucher.Parameters.Add("C_SALID", OracleDbType.Int32).Value = objSubDetail.LedgerId;
                                            cmdAddVoucher.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                            cmdAddVoucher.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = objSubDetail.BalnceAmt;
                                            cmdAddVoucher.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = objSubDetail.Payment_Ledgr_Id;
                                            cmdAddVoucher.ExecuteNonQuery();
                                        }
                                    }
                                }

                            }

                            //cost centre details
                            foreach (clsEntityPaymentAccount objSubDetailCost in objEntityCostCenterIns)
                            {
                                if (objSubDetail.LedgerId == objSubDetailCost.LedgerId && objSubDetail.LedgerRow == objSubDetailCost.LedgerRow)
                                {
                                    string strQuerySubDetailsCost = "FMS_PAYMENT_ACCOUNT.SP_INS_PAYMENT_COSTCENTER";
                                    using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                                    {
                                        cmdAddSubDetail.Transaction = tran;
                                        cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                        if (objSubDetailCost.CostCtrId != 0)
                                        {
                                            cmdAddSubDetail.Parameters.Add("P_CST_CNTRID", OracleDbType.Int32).Value = objSubDetailCost.CostCtrId;
                                        }
                                        else
                                        {
                                            cmdAddSubDetail.Parameters.Add("P_CST_CNTRID", OracleDbType.Int32).Value = null;
                                        }
                                        cmdAddSubDetail.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;

                                        cmdAddSubDetail.Parameters.Add("P_CST_CNTR_AMT", OracleDbType.Decimal).Value = objSubDetailCost.CstCntrAmnt;
                                        cmdAddSubDetail.Parameters.Add("P_PLID", OracleDbType.Int32).Value = objSubDetail.Payment_Ledgr_Id;
                                        if (objSubDetailCost.PurchaseId != 0)
                                        {
                                            cmdAddSubDetail.Parameters.Add("P_PURCH_ID", OracleDbType.Int32).Value = objSubDetailCost.PurchaseId;
                                        }
                                        else
                                        {
                                            cmdAddSubDetail.Parameters.Add("P_PURCH_ID", OracleDbType.Int32).Value = null;
                                        }
                                        cmdAddSubDetail.Parameters.Add("P_PSTS", OracleDbType.Int32).Value = objSubDetailCost.Status;
                                        if (objSubDetailCost.CostGrp1Id != 0)
                                        {
                                            cmdAddSubDetail.Parameters.Add("R_COST_GRP_ID_ONE", OracleDbType.Int32).Value = objSubDetailCost.CostGrp1Id;
                                        }
                                        else
                                        {
                                            cmdAddSubDetail.Parameters.Add("R_COST_GRP_ID_ONE", OracleDbType.Int32).Value = null;

                                        }
                                        if (objSubDetailCost.CostGrp2Id != 0)
                                        {
                                            cmdAddSubDetail.Parameters.Add("R_COST_GRP_ID_TWO", OracleDbType.Int32).Value = objSubDetailCost.CostGrp2Id;
                                        }
                                        else
                                        {
                                            cmdAddSubDetail.Parameters.Add("R_COST_GRP_ID_TWO", OracleDbType.Int32).Value = null;

                                        }
                                        if (objSubDetailCost.DebitNoteStatus != 0)
                                        {
                                            cmdAddSubDetail.Parameters.Add("R_DNT_STS", OracleDbType.Int32).Value = objSubDetailCost.DebitNoteStatus;
                                            if (objSubDetailCost.DebitNoteId != 0)
                                                cmdAddSubDetail.Parameters.Add("R_DNT_ID", OracleDbType.Int32).Value = objSubDetailCost.DebitNoteId;
                                            else
                                                cmdAddSubDetail.Parameters.Add("R_DNT_ID", OracleDbType.Int32).Value = null;
                                            if (objSubDetailCost.DebitNoteAmount != 0)
                                                cmdAddSubDetail.Parameters.Add("R_DNT_AMT", OracleDbType.Decimal).Value = objSubDetailCost.DebitNoteAmount;
                                            else
                                                cmdAddSubDetail.Parameters.Add("R_DNT_AMT", OracleDbType.Decimal).Value = null;
                                        }
                                        else
                                        {
                                            cmdAddSubDetail.Parameters.Add("R_DNT_STS", OracleDbType.Int32).Value = objSubDetailCost.DebitNoteStatus;
                                            cmdAddSubDetail.Parameters.Add("R_DNT_ID", OracleDbType.Int32).Value = null;
                                            cmdAddSubDetail.Parameters.Add("R_DNT_AMT", OracleDbType.Decimal).Value = null;
                                        }
                                        cmdAddSubDetail.Parameters.Add("P_OBPAID_AMT", OracleDbType.Decimal).Value = objSubDetailCost.PaidAmt;
                                        cmdAddSubDetail.Parameters.Add("P_OBBAL_AMT", OracleDbType.Decimal).Value = objSubDetailCost.BalnceAmt;

                                        //0043
                                        cmdAddSubDetail.Parameters.Add("P_EXPENSE_AMT", OracleDbType.Decimal).Value = objSubDetailCost.ExpnsAmnt;
                                        if (objSubDetailCost.ExpenceId != 0)
                                        {
                                            cmdAddSubDetail.Parameters.Add("P_EXPNSID", OracleDbType.Int32).Value = objSubDetailCost.ExpenceId;
                                        }
                                        else
                                        {
                                            cmdAddSubDetail.Parameters.Add("P_EXPNSID", OracleDbType.Int32).Value = null;
                                        }
                                        //end            
                                        
                                        cmdAddSubDetail.ExecuteNonQuery();
                                    }

                                    //on confirm
                                    if (objEntityPayment.ConfirmStatus == 1)
                                    {
                                        //update purchase balance
                                        string strQuerySubSalesUpdate = "FMS_PAYMENT_ACCOUNT.SP_UPDATE_PURCHS_OR_COSTCNTR";
                                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubSalesUpdate, con))
                                        {
                                            cmdAddSubDetail.Transaction = tran;
                                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                            if (objSubDetailCost.CostCtrId != 0)
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_CST_CNTRID", OracleDbType.Int32).Value = objSubDetailCost.CostCtrId;
                                            }
                                            else
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_CST_CNTRID", OracleDbType.Int32).Value = null;
                                            }
                                            if (objSubDetailCost.PurchaseId != 0)
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_PURCH_ID", OracleDbType.Int32).Value = objSubDetailCost.PurchaseId;
                                            }
                                            else
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_PURCH_ID", OracleDbType.Int32).Value = null;
                                            }
                                            if (objSubDetailCost.CstCntrAmnt != 0)
                                                cmdAddSubDetail.Parameters.Add("R_COSTCNTR_AMT", OracleDbType.Decimal).Value = objSubDetailCost.CstCntrAmnt;
                                            else
                                                cmdAddSubDetail.Parameters.Add("R_COSTCNTR_AMT", OracleDbType.Decimal).Value = null;
                                            if (objSubDetailCost.DebitNoteId != 0)
                                            {
                                                cmdAddSubDetail.Parameters.Add("R_DNT_ID", OracleDbType.Int32).Value = objSubDetailCost.DebitNoteId;
                                                cmdAddSubDetail.Parameters.Add("R_DNT_AMT", OracleDbType.Decimal).Value = objSubDetailCost.DebitNoteAmount;
                                                cmdAddSubDetail.Parameters.Add("P_LID", OracleDbType.Int32).Value = objSubDetail.LedgerId;
                                            }
                                            else
                                            {
                                                cmdAddSubDetail.Parameters.Add("R_DNT_ID", OracleDbType.Int32).Value = 0;
                                                cmdAddSubDetail.Parameters.Add("R_DNT_AMT", OracleDbType.Decimal).Value = null;
                                                cmdAddSubDetail.Parameters.Add("P_LID", OracleDbType.Int32).Value = null;
                                            }

                                            //0043
                                            cmdAddSubDetail.Parameters.Add("P_EXPENSE_AMT", OracleDbType.Decimal).Value = objSubDetailCost.ExpnsAmnt;
                                            if (objSubDetailCost.ExpenceId != 0)
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_EXPNSID", OracleDbType.Int32).Value = objSubDetailCost.ExpenceId;
                                            }
                                            else
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_EXPNSID", OracleDbType.Int32).Value = null;
                                            }
                                            //end

                                            cmdAddSubDetail.ExecuteNonQuery();
                                        }

                                        //insert into cost centre voucher table
                                        string strQueryInsertVoucher = "FMS_COMMON.SP_INS_CSTCNTR_VOUCHER_ACCOUNT";
                                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                                        {
                                            if (objSubDetailCost.CostCtrId != 0)
                                            {
                                                cmdAddSubDetail.Transaction = tran;
                                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                cmdAddSubDetail.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                                cmdAddSubDetail.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = objEntityPayment.RefNum;
                                                cmdAddSubDetail.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPayment.FromDate;
                                                cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objSubDetail.LedgerId;
                                                cmdAddSubDetail.Parameters.Add("P_COST_CNTR_ID", OracleDbType.Int32).Value = objSubDetailCost.CostCtrId;
                                                if (objSubDetailCost.CostGrp1Id != 0)
                                                    cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_ONE", OracleDbType.Int32).Value = objSubDetailCost.CostGrp1Id;
                                                else
                                                    cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_ONE", OracleDbType.Int32).Value = null;
                                                if (objSubDetailCost.CostGrp2Id != 0)
                                                    cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_TWO", OracleDbType.Int32).Value = objSubDetailCost.CostGrp2Id;
                                                else
                                                    cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_TWO", OracleDbType.Int32).Value = null;
                                                cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = objSubDetailCost.CstCntrAmnt;
                                                cmdAddSubDetail.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayment.Organisation_id;
                                                cmdAddSubDetail.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayment.Corporate_id;
                                                cmdAddSubDetail.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = objEntityPayment.FinancialYrId;
                                                cmdAddSubDetail.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 0;
                                                cmdAddSubDetail.Parameters.Add("P_CRNC_MST_ID", OracleDbType.Int32).Value = objEntityPayment.CurrcyId;
                                                cmdAddSubDetail.Parameters.Add("P_VOCHR_TYPE", OracleDbType.Int32).Value = 1;
                                                cmdAddSubDetail.Parameters.Add("P_VOCHR_ID", OracleDbType.Int32).Value = objEntityPayment.VoucherID;

                                                cmdAddSubDetail.ExecuteNonQuery();
                                            }
                                        }

                                        //insert into voucher settlemnt purchase
                                        if (objSubDetailCost.PurchaseId != 0 && objSubDetailCost.CstCntrAmnt != 0 && objSubDetailCost.DebitNoteId == 0)
                                        {
                                            string strQueryInsertVoucherSettleDtls = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";  //Add settle amount details
                                            using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherSettleDtls, con))
                                            {
                                                cmdAddVoucher.Transaction = tran;
                                                cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                                cmdAddVoucher.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = objEntityPayment.VoucherID;
                                                cmdAddVoucher.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = objSubDetail.LedgerId;
                                                cmdAddVoucher.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = objSubDetailCost.CstCntrAmnt;
                                                cmdAddVoucher.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 1;
                                                cmdAddVoucher.Parameters.Add("C_USRID", OracleDbType.Int32).Value = objEntityPayment.User_Id;
                                                cmdAddVoucher.Parameters.Add("C_SALID", OracleDbType.Int32).Value = objSubDetailCost.PurchaseId;
                                                cmdAddVoucher.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                                cmdAddVoucher.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = objSubDetailCost.PurchaseActAmount;
                                                cmdAddVoucher.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = objSubDetail.Payment_Ledgr_Id;
                                                cmdAddVoucher.ExecuteNonQuery();
                                            }
                                        }

                                        if (objSubDetailCost.DebitNoteId != 0 && objSubDetailCost.DebitNoteAmount != 0)
                                        {
                                            //insert into voucher settlemnt credit note
                                            string strQueryInsertVoucherSettleDtls = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";  //Add settle amount details
                                            using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherSettleDtls, con))
                                            {
                                                cmdAddVoucher.Transaction = tran;
                                                cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                                cmdAddVoucher.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = objEntityPayment.VoucherID;
                                                cmdAddVoucher.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = objSubDetail.LedgerId;
                                                cmdAddVoucher.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = objSubDetailCost.DebitNoteAmount;
                                                cmdAddVoucher.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 2;
                                                cmdAddVoucher.Parameters.Add("C_USRID", OracleDbType.Int32).Value = objEntityPayment.User_Id;
                                                cmdAddVoucher.Parameters.Add("C_SALID", OracleDbType.Int32).Value = objSubDetailCost.PurchaseId;
                                                cmdAddVoucher.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                                cmdAddVoucher.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = objSubDetailCost.DebitNoteRemainingAmount;
                                                cmdAddVoucher.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = objSubDetail.Payment_Ledgr_Id;
                                                cmdAddVoucher.ExecuteNonQuery();
                                            }
                                        }

                                        if (objSubDetailCost.ExpenceId != 0 && objSubDetailCost.ExpnsAmnt != 0)
                                        {
                                            //insert into voucher settlemnt expense
                                            string strQueryInsertVoucherSettleDtls = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";  //Add settle amount details
                                            using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherSettleDtls, con))
                                            {
                                                cmdAddVoucher.Transaction = tran;
                                                cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                                cmdAddVoucher.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = objEntityPayment.VoucherID;
                                                cmdAddVoucher.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = objSubDetail.LedgerId;
                                                cmdAddVoucher.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = objSubDetailCost.ExpnsAmnt;
                                                cmdAddVoucher.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 5;
                                                cmdAddVoucher.Parameters.Add("C_USRID", OracleDbType.Int32).Value = objEntityPayment.User_Id;
                                                cmdAddVoucher.Parameters.Add("C_SALID", OracleDbType.Int32).Value = objSubDetailCost.ExpenceId;
                                                cmdAddVoucher.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                                cmdAddVoucher.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = objSubDetailCost.TotalExpnsAmnt;
                                                cmdAddVoucher.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = objSubDetail.Payment_Ledgr_Id;
                                                cmdAddVoucher.ExecuteNonQuery();
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }

                    //paymnt ledgers UPDATE
                    foreach (clsEntityPaymentAccount ObjEntityLdgrupdate in objEntityLedgerUpd)
                    {
                        if (ObjEntityLdgrupdate.LedgerId != 0)
                        {
                            string strQueryledger = "FMS_PAYMENT_ACCOUNT.SP_UPDATE_PAYMENT_LEDGER";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryledger, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddSubDetail.Parameters.Add("R_PYMNT_ID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                cmdAddSubDetail.Parameters.Add("R_PYMNT_LD_ID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.Payment_Ledgr_Id;
                                cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.LedgerId;
                                cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = ObjEntityLdgrupdate.LedgerAmnt;
                                cmdAddSubDetail.Parameters.Add("P_REMRK", OracleDbType.Varchar2).Value = ObjEntityLdgrupdate.Remarks;
                                cmdAddSubDetail.ExecuteNonQuery();
                            }

                            //on confirm
                            if (objEntityPayment.ConfirmStatus == 1)
                            {
                                //update ledger balance
                                string strQueryUpdateLedger = "FMS_PAYMENT_ACCOUNT.SP_UPD_LDGR_ACNT_REOPEN";
                                using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryUpdateLedger, con))
                                {
                                    cmdAddSubDetail.Transaction = tran;
                                    cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                    cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.LedgerId;
                                    cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = ObjEntityLdgrupdate.LedgerAmnt;
                                    cmdAddSubDetail.ExecuteNonQuery();
                                }

                                //Insert Ledger details to Vocher Account
                                string strQueryInsertVoucher = "FMS_PAYMENT_ACCOUNT.SP_INS_VOUCHER_ACCOUNT";
                                using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucher, con))
                                {
                                    cmdAddVoucher.Transaction = tran;
                                    cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                    cmdAddVoucher.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                    cmdAddVoucher.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = objEntityPayment.RefNum;
                                    cmdAddVoucher.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPayment.FromDate;
                                    cmdAddVoucher.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.LedgerId;
                                    cmdAddVoucher.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = ObjEntityLdgrupdate.LedgerAmnt;
                                    cmdAddVoucher.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayment.Organisation_id;
                                    cmdAddVoucher.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayment.Corporate_id;
                                    cmdAddVoucher.Parameters.Add("P_VOCHR", OracleDbType.Int32).Value = 0;
                                    cmdAddVoucher.Parameters.Add("P_DESC", OracleDbType.Varchar2).Value = ObjEntityLdgrupdate.Remarks;
                                    cmdAddVoucher.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = objEntityPayment.FinancialYrId;
                                    cmdAddVoucher.Parameters.Add("P_BANKSTS", OracleDbType.Int32).Value = 0;
                                    cmdAddVoucher.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 0;
                                    cmdAddVoucher.Parameters.Add("P_VOUCHR_CAT", OracleDbType.Int32).Value = 0;
                                    cmdAddVoucher.Parameters.Add("L_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                    cmdAddVoucher.ExecuteNonQuery();
                                    string strReturn = cmdAddVoucher.Parameters["L_ID"].Value.ToString();
                                    cmdAddVoucher.Dispose();
                                    objEntityPayment.VoucherID = Convert.ToInt32(strReturn);
                                }

                                //voucher details table
                                string strQueryInsertVoucherDtls = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS"; //Ledger to Account
                                using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherDtls, con))
                                {
                                    cmdAddVoucher.Transaction = tran;
                                    cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                    cmdAddVoucher.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objEntityPayment.AccntNameId;
                                    cmdAddVoucher.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = objEntityPayment.VoucherID;
                                    cmdAddVoucher.ExecuteNonQuery();
                                }
                                string strQueryInsertVoucherAccDtls = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";  //Account to Ledger
                                using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherAccDtls, con))
                                {
                                    cmdAddVoucher.Transaction = tran;
                                    cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                    cmdAddVoucher.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.LedgerId;
                                    cmdAddVoucher.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = objEntityPayment.AccountVocherID;
                                    cmdAddVoucher.ExecuteNonQuery();
                                }

                                //opening balance settlemnt
                                if (objEntityPayment.VoucherCategory == 1)
                                {
                                    if (ObjEntityLdgrupdate.PaidAmt > 0)
                                    {
                                        //updating opening balance row in voucher table
                                        string strQueryInsertVoucher1 = "FMS_PAYMENT_ACCOUNT.SP_UPDATE_VOUCHER_ACCOUNT";
                                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher1, con))
                                        {
                                            cmdAddSubDetail.Transaction = tran;
                                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                            cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.LedgerId;
                                            cmdAddSubDetail.Parameters.Add("P_VOUCHR_CAT", OracleDbType.Int32).Value = objEntityPayment.VoucherCategory;
                                            cmdAddSubDetail.Parameters.Add("R_OBPAID_AMT", OracleDbType.Decimal).Value = ObjEntityLdgrupdate.BalnceAmt;//balancamt
                                            cmdAddSubDetail.Parameters.Add("L_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                            cmdAddSubDetail.ExecuteNonQuery();
                                        }
                                        //inserting opening balance settlement to voucher settlement table
                                        string strQueryInsertVoucherSettleDtls = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";  //Add settle amount details
                                        using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherSettleDtls, con))
                                        {
                                            cmdAddVoucher.Transaction = tran;
                                            cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                            cmdAddVoucher.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = objEntityPayment.VoucherID;
                                            cmdAddVoucher.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.LedgerId;
                                            cmdAddVoucher.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = ObjEntityLdgrupdate.PaidAmt;//paid amt
                                            cmdAddVoucher.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 4;
                                            cmdAddVoucher.Parameters.Add("C_USRID", OracleDbType.Int32).Value = objEntityPayment.User_Id;
                                            cmdAddVoucher.Parameters.Add("C_SALID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.LedgerId;
                                            cmdAddVoucher.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                            cmdAddVoucher.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = ObjEntityLdgrupdate.BalnceAmt;
                                            cmdAddVoucher.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.Payment_Ledgr_Id;
                                            cmdAddVoucher.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }

                            //cost centre details
                            foreach (clsEntityPaymentAccount objSubDetailCost in objEntityCostCenterIns)
                            {
                                if (ObjEntityLdgrupdate.LedgerId == objSubDetailCost.LedgerId && ObjEntityLdgrupdate.LedgerRow == objSubDetailCost.LedgerRow)
                                {
                                    string strQuerySubDetailsCost = "FMS_PAYMENT_ACCOUNT.SP_INS_PAYMENT_COSTCENTER";
                                    using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                                    {
                                        cmdAddSubDetail.Transaction = tran;
                                        cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                        if (objSubDetailCost.CostCtrId != 0)
                                        {
                                            cmdAddSubDetail.Parameters.Add("P_CST_CNTRID", OracleDbType.Int32).Value = objSubDetailCost.CostCtrId;
                                        }
                                        else
                                        {
                                            cmdAddSubDetail.Parameters.Add("P_CST_CNTRID", OracleDbType.Int32).Value = null;
                                        }
                                        cmdAddSubDetail.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                        cmdAddSubDetail.Parameters.Add("P_CST_CNTR_AMT", OracleDbType.Decimal).Value = objSubDetailCost.CstCntrAmnt;
                                        cmdAddSubDetail.Parameters.Add("P_PLID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.Payment_Ledgr_Id;
                                        if (objSubDetailCost.PurchaseId != 0)
                                        {
                                            cmdAddSubDetail.Parameters.Add("P_PURCH_ID", OracleDbType.Int32).Value = objSubDetailCost.PurchaseId;
                                        }
                                        else
                                        {
                                            cmdAddSubDetail.Parameters.Add("P_PURCH_ID", OracleDbType.Int32).Value = null;
                                        }
                                        cmdAddSubDetail.Parameters.Add("P_PSTS", OracleDbType.Int32).Value = objSubDetailCost.Status;
                                        if (objSubDetailCost.CostGrp1Id != 0)
                                        {
                                            cmdAddSubDetail.Parameters.Add("R_COST_GRP_ID_ONE", OracleDbType.Int32).Value = objSubDetailCost.CostGrp1Id;
                                        }
                                        else
                                        {
                                            cmdAddSubDetail.Parameters.Add("R_COST_GRP_ID_ONE", OracleDbType.Int32).Value = null;
                                        }
                                        if (objSubDetailCost.CostGrp2Id != 0)
                                        {
                                            cmdAddSubDetail.Parameters.Add("R_COST_GRP_ID_TWO", OracleDbType.Int32).Value = objSubDetailCost.CostGrp2Id;
                                        }
                                        else
                                        {
                                            cmdAddSubDetail.Parameters.Add("R_COST_GRP_ID_TWO", OracleDbType.Int32).Value = null;
                                        }
                                        if (objSubDetailCost.DebitNoteStatus != 0)
                                        {
                                            cmdAddSubDetail.Parameters.Add("R_DNT_STS", OracleDbType.Int32).Value = objSubDetailCost.DebitNoteStatus;
                                            if (objSubDetailCost.DebitNoteId != 0)
                                                cmdAddSubDetail.Parameters.Add("R_DNT_ID", OracleDbType.Int32).Value = objSubDetailCost.DebitNoteId;
                                            else
                                                cmdAddSubDetail.Parameters.Add("R_DNT_ID", OracleDbType.Int32).Value = null;
                                            if (objSubDetailCost.DebitNoteAmount != 0)
                                                cmdAddSubDetail.Parameters.Add("R_DNT_AMT", OracleDbType.Decimal).Value = objSubDetailCost.DebitNoteAmount;
                                            else
                                                cmdAddSubDetail.Parameters.Add("R_DNT_AMT", OracleDbType.Decimal).Value = null;
                                        }
                                        else
                                        {
                                            cmdAddSubDetail.Parameters.Add("R_DNT_STS", OracleDbType.Int32).Value = objSubDetailCost.DebitNoteStatus;
                                            cmdAddSubDetail.Parameters.Add("R_DNT_ID", OracleDbType.Int32).Value = null;
                                            cmdAddSubDetail.Parameters.Add("R_DNT_AMT", OracleDbType.Decimal).Value = null;
                                        }
                                        cmdAddSubDetail.Parameters.Add("P_OBPAID_AMT", OracleDbType.Decimal).Value = objSubDetailCost.PaidAmt;
                                        cmdAddSubDetail.Parameters.Add("P_OBBAL_AMT", OracleDbType.Decimal).Value = objSubDetailCost.BalnceAmt;

                                        //0043
                                        cmdAddSubDetail.Parameters.Add("P_EXPENSE_AMT", OracleDbType.Decimal).Value = objSubDetailCost.ExpnsAmnt;
                                        if (objSubDetailCost.ExpenceId != 0)
                                        {
                                            cmdAddSubDetail.Parameters.Add("P_EXPNSID", OracleDbType.Int32).Value = objSubDetailCost.ExpenceId;
                                        }
                                        else
                                        {
                                            cmdAddSubDetail.Parameters.Add("P_EXPNSID", OracleDbType.Int32).Value = null;
                                        }
                                        //end

                                        cmdAddSubDetail.ExecuteNonQuery();
                                    }

                                    //on confirm
                                    if (objEntityPayment.ConfirmStatus == 1)
                                    {
                                        //insert into voucher settlemnt purchase
                                        if (objSubDetailCost.PurchaseId != 0 && objSubDetailCost.CstCntrAmnt != 0 && objSubDetailCost.DebitNoteId == 0)
                                        {
                                            string strQueryInsertVoucherSettleDtls = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";  //Add settle amount details
                                            using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherSettleDtls, con))
                                            {
                                                cmdAddVoucher.Transaction = tran;
                                                cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                                cmdAddVoucher.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = objEntityPayment.AccountVocherID;
                                                cmdAddVoucher.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.LedgerId;
                                                cmdAddVoucher.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = objSubDetailCost.CstCntrAmnt;
                                                cmdAddVoucher.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 1;
                                                cmdAddVoucher.Parameters.Add("C_USRID", OracleDbType.Int32).Value = objEntityPayment.User_Id;
                                                cmdAddVoucher.Parameters.Add("C_SALID", OracleDbType.Int32).Value = objSubDetailCost.PurchaseId;
                                                cmdAddVoucher.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                                cmdAddVoucher.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = objSubDetailCost.PurchaseActAmount;
                                                cmdAddVoucher.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.Payment_Ledgr_Id;
                                                cmdAddVoucher.ExecuteNonQuery();
                                            }
                                        }

                                        //insert into voucher settlemnt credit note
                                        if (objSubDetailCost.DebitNoteAmount != 0 && objSubDetailCost.DebitNoteId != 0)
                                        {
                                            string strQueryInsertVoucherSettleDtls = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";  //Add settle amount details
                                            using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherSettleDtls, con))
                                            {
                                                cmdAddVoucher.Transaction = tran;
                                                cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                                cmdAddVoucher.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = objEntityPayment.VoucherID;
                                                cmdAddVoucher.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.LedgerId;
                                                cmdAddVoucher.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = objSubDetailCost.DebitNoteAmount;
                                                cmdAddVoucher.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 2;
                                                cmdAddVoucher.Parameters.Add("C_USRID", OracleDbType.Int32).Value = objEntityPayment.User_Id;
                                                cmdAddVoucher.Parameters.Add("C_SALID", OracleDbType.Int32).Value = objSubDetailCost.PurchaseId;
                                                cmdAddVoucher.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                                cmdAddVoucher.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = objSubDetailCost.DebitNoteRemainingAmount;
                                                cmdAddVoucher.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.Payment_Ledgr_Id;
                                                cmdAddVoucher.ExecuteNonQuery();
                                            }
                                        }

                                        if (objSubDetailCost.ExpenceId != 0 && objSubDetailCost.ExpnsAmnt != 0)
                                        {
                                            //insert into voucher settlemnt expense
                                            string strQueryInsertVoucherSettleDtls = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";  //Add settle amount details
                                            using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherSettleDtls, con))
                                            {
                                                cmdAddVoucher.Transaction = tran;
                                                cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                                cmdAddVoucher.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = objEntityPayment.VoucherID;
                                                cmdAddVoucher.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.LedgerId;
                                                cmdAddVoucher.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = objSubDetailCost.ExpnsAmnt;
                                                cmdAddVoucher.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 5;
                                                cmdAddVoucher.Parameters.Add("C_USRID", OracleDbType.Int32).Value = objEntityPayment.User_Id;
                                                cmdAddVoucher.Parameters.Add("C_SALID", OracleDbType.Int32).Value = objSubDetailCost.ExpenceId;
                                                cmdAddVoucher.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                                cmdAddVoucher.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = objSubDetailCost.TotalExpnsAmnt;
                                                cmdAddVoucher.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.Payment_Ledgr_Id;
                                                cmdAddVoucher.ExecuteNonQuery();
                                            }
                                        }

                                        //insert into cost centre voucher table
                                        string strQueryInsertVoucher = "FMS_COMMON.SP_INS_CSTCNTR_VOUCHER_ACCOUNT";
                                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                                        {
                                            if (objEntityPayment.ConfirmStatus == 1)
                                            {
                                                if (objSubDetailCost.CostCtrId != 0)
                                                {
                                                    cmdAddSubDetail.Transaction = tran;
                                                    cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                    cmdAddSubDetail.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                                    cmdAddSubDetail.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = objEntityPayment.RefNum;
                                                    cmdAddSubDetail.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPayment.FromDate;
                                                    cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.LedgerId;
                                                    cmdAddSubDetail.Parameters.Add("P_COST_CNTR_ID", OracleDbType.Int32).Value = objSubDetailCost.CostCtrId;
                                                    if (objSubDetailCost.CostGrp1Id != 0)
                                                        cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_ONE", OracleDbType.Int32).Value = objSubDetailCost.CostGrp1Id;
                                                    else
                                                        cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_ONE", OracleDbType.Int32).Value = null;
                                                    if (objSubDetailCost.CostGrp2Id != 0)
                                                        cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_TWO", OracleDbType.Int32).Value = objSubDetailCost.CostGrp2Id;
                                                    else
                                                        cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_TWO", OracleDbType.Int32).Value = null;
                                                    cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = objSubDetailCost.CstCntrAmnt;
                                                    cmdAddSubDetail.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayment.Organisation_id;
                                                    cmdAddSubDetail.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayment.Corporate_id;
                                                    cmdAddSubDetail.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = objEntityPayment.FinancialYrId;
                                                    cmdAddSubDetail.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 0;
                                                    cmdAddSubDetail.Parameters.Add("P_CRNC_MST_ID", OracleDbType.Int32).Value = objEntityPayment.CurrcyId;
                                                    cmdAddSubDetail.Parameters.Add("P_VOCHR_TYPE", OracleDbType.Int32).Value = 1;
                                                    cmdAddSubDetail.Parameters.Add("P_VOCHR_ID", OracleDbType.Int32).Value = objEntityPayment.VoucherID;

                                                    cmdAddSubDetail.ExecuteNonQuery();
                                                }
                                            }
                                        }
                                        //update purchase balance
                                        string strQuerySubSalesUpdate = "FMS_PAYMENT_ACCOUNT.SP_UPDATE_PURCHS_OR_COSTCNTR";
                                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubSalesUpdate, con))
                                        {
                                            cmdAddSubDetail.Transaction = tran;
                                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                            if (objSubDetailCost.CostCtrId != 0)
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_CST_CNTRID", OracleDbType.Int32).Value = objSubDetailCost.CostCtrId;
                                            }
                                            else
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_CST_CNTRID", OracleDbType.Int32).Value = null;
                                            }
                                            if (objSubDetailCost.PurchaseId != 0)
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_PURCH_ID", OracleDbType.Int32).Value = objSubDetailCost.PurchaseId;
                                            }
                                            else
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_PURCH_ID", OracleDbType.Int32).Value = null;
                                            }
                                            if (objSubDetailCost.CstCntrAmnt != 0)
                                                cmdAddSubDetail.Parameters.Add("R_COSTCNTR_AMT", OracleDbType.Decimal).Value = objSubDetailCost.CstCntrAmnt;
                                            else
                                                cmdAddSubDetail.Parameters.Add("R_COSTCNTR_AMT", OracleDbType.Decimal).Value = null;
                                            if (objSubDetailCost.DebitNoteId != 0)
                                            {
                                                cmdAddSubDetail.Parameters.Add("R_DNT_ID", OracleDbType.Int32).Value = objSubDetailCost.DebitNoteId;
                                                cmdAddSubDetail.Parameters.Add("R_DNT_AMT", OracleDbType.Decimal).Value = objSubDetailCost.DebitNoteAmount;
                                                cmdAddSubDetail.Parameters.Add("P_LID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.LedgerId;
                                            }
                                            else
                                            {
                                                cmdAddSubDetail.Parameters.Add("R_DNT_ID", OracleDbType.Int32).Value = 0;
                                                cmdAddSubDetail.Parameters.Add("R_DNT_AMT", OracleDbType.Decimal).Value = null;
                                                cmdAddSubDetail.Parameters.Add("P_LID", OracleDbType.Int32).Value = null;
                                            }
                                            //0043
                                            cmdAddSubDetail.Parameters.Add("P_EXPENSE_AMT", OracleDbType.Decimal).Value = objSubDetailCost.ExpnsAmnt;
                                            if (objSubDetailCost.ExpenceId != 0)
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_EXPNSID", OracleDbType.Int32).Value = objSubDetailCost.ExpenceId;
                                            }
                                            else
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_EXPNSID", OracleDbType.Int32).Value = null;
                                            }
                                            //end
                                            cmdAddSubDetail.ExecuteNonQuery();
                                        }
                                    }

                                }

                            }
                        }
                    }
                    //Deleting payment ledgers
                    foreach (clsEntityPaymentAccount objSubLdgr in objEntityLedgerDel)
                    {
                        string strQueryChangeStatus = "FMS_PAYMENT_ACCOUNT.DETETE_PAYMENT_LEDGER";
                        using (OracleCommand cmdChangeStatus = new OracleCommand(strQueryChangeStatus, con))
                        {
                            cmdChangeStatus.CommandText = strQueryChangeStatus;
                            cmdChangeStatus.CommandType = CommandType.StoredProcedure;
                            cmdChangeStatus.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                            cmdChangeStatus.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objSubLdgr.Payment_Ledgr_Id;
                            cmdChangeStatus.Parameters.Add("USRID", OracleDbType.Int32).Value = objEntityPayment.User_Id;
                            cmdChangeStatus.ExecuteNonQuery();
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

        public DataTable ChkPaymentMasterIsCancel(clsEntityPaymentAccount objEntityPayment)
        {
            string strQueryReadCustomerLdger = "FMS_PAYMENT_ACCOUNT.SP_CHK_PAYMENT_CANCEL";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("PR_PUR", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
            cmdReadCustomerLdger.Parameters.Add("PR_ORGID", OracleDbType.Int32).Value = objEntityPayment.Organisation_id;
            cmdReadCustomerLdger.Parameters.Add("PR_CORPID", OracleDbType.Int32).Value = objEntityPayment.Corporate_id;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public DataTable ChkPaymentMasterIsCnfrm(clsEntityPaymentAccount objEntityPayment)
        {
            string strQueryReadCustomerLdger = "FMS_PAYMENT_ACCOUNT.SP_CHK_PAYMENT_CNFRM";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("PR_PUR", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
            cmdReadCustomerLdger.Parameters.Add("PR_ORGID", OracleDbType.Int32).Value = objEntityPayment.Organisation_id;
            cmdReadCustomerLdger.Parameters.Add("PR_CORPID", OracleDbType.Int32).Value = objEntityPayment.Corporate_id;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public DataTable ReadChequeBooks(clsEntityPaymentAccount objEntityPayment)
        {
            string strQueryReadCustomerLdger = "FMS_PAYMENT_ACCOUNT.SP_READ_CHEQUEBOOK";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPayment.ChequeBookId;
            cmdReadCustomerLdger.Parameters.Add("LEDGER_ID", OracleDbType.Int32).Value = objEntityPayment.LedgerId;
            cmdReadCustomerLdger.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public DataTable ReadChequeBook_CancelIds(clsEntityPaymentAccount objEntityPayment)
        {
            string strQueryReadCustomerLdger = "FMS_PAYMENT_ACCOUNT.SP_READ_CHEQUEBOOK_CANCELIDS";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("P_CHKBOK_ID", OracleDbType.Int32).Value = objEntityPayment.ChequeBookId;
            cmdReadCustomerLdger.Parameters.Add("B_BANKID", OracleDbType.Int32).Value = objEntityPayment.AccntNameId;
            cmdReadCustomerLdger.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public DataTable ReadChequeBook_UsedIds(clsEntityPaymentAccount objEntityPayment)
        {
            string strQueryReadCustomerLdger = "FMS_PAYMENT_ACCOUNT.SP_READ_CHEQUEBOOK_USED_IDS";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("P_CHKBOK_ID", OracleDbType.Int32).Value = objEntityPayment.ChequeBookId;
            cmdReadCustomerLdger.Parameters.Add("P_CHKBOK_NO", OracleDbType.Int32).Value = objEntityPayment.ChequeBookNumber;
            cmdReadCustomerLdger.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
            cmdReadCustomerLdger.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public DataTable ReadAccountClosingDate(clsEntityPaymentAccount objEntityPayment)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_ACCOUNT_CLOSE_DATE";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityPayment.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORP_ID", OracleDbType.Int32).Value = objEntityPayment.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public void PayemntReOpenById(clsEntityPaymentAccount objEntityPayment, List<clsEntityPaymentAccount> objEntityLedger, List<clsEntityPaymentAccount> objEntityLedgerCostCenter)
        {
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    string strQueryUpdateLedgerAccount = "FMS_PAYMENT_ACCOUNT.SP_UPD_LDGR_ACNT_REOPEN";
                    using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryUpdateLedgerAccount, con))
                    {
                        cmdAddSubDetail.Transaction = tran;
                        cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                        cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objEntityPayment.LedgerId;
                        cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = objEntityPayment.LedgerAmnt;
                        cmdAddSubDetail.ExecuteNonQuery();
                    }
                    foreach (clsEntityPaymentAccount objSubLdgr in objEntityLedger)
                    {
                        string strQueryUpdateLedger = "FMS_PAYMENT_ACCOUNT.SP_UPDATE_LEDGER_MASTR";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryUpdateLedger, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objSubLdgr.LedgerId;
                            cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = objSubLdgr.LedgerAmnt;
                            cmdAddSubDetail.ExecuteNonQuery();
                        }
                        if (objSubLdgr.VoucherCategory == 1)
                        {
                            //EVM-0027 AUG 8
                            string strQueryUpdateVoucherTable = "FMS_PAYMENT_ACCOUNT.SP_UPDATE_VOUCHER_ACCOUNT";
                            using (OracleCommand CmdUpdateVT = new OracleCommand(strQueryUpdateVoucherTable, con))
                            {
                                CmdUpdateVT.Transaction = tran;
                                CmdUpdateVT.CommandType = CommandType.StoredProcedure;
                                CmdUpdateVT.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objSubLdgr.LedgerId;
                                CmdUpdateVT.Parameters.Add("P_VOUCHR_CAT", OracleDbType.Int32).Value = objSubLdgr.VoucherCategory;
                                CmdUpdateVT.Parameters.Add("R_OBPAID_AMT", OracleDbType.Decimal).Value = objSubLdgr.BalnceAmt;//balancamt
                                CmdUpdateVT.Parameters.Add("L_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                CmdUpdateVT.ExecuteNonQuery();
                            }
                            //END
                        }
                    }

                    foreach (clsEntityPaymentAccount objSubDetailCost in objEntityLedgerCostCenter)
                    {
                        
                            string strQueryUpdateLedger = "FMS_PAYMENT_ACCOUNT.SP_REOPEN_PURCHS_OR_COSTCNTR";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryUpdateLedger, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                if (objSubDetailCost.CostCtrId != 0)
                                {
                                    cmdAddSubDetail.Parameters.Add("P_CST_CNTRID", OracleDbType.Int32).Value = objSubDetailCost.CostCtrId;
                                }
                                else
                                {
                                    cmdAddSubDetail.Parameters.Add("P_CST_CNTRID", OracleDbType.Int32).Value = null;
                                }
                                if (objSubDetailCost.PurchaseId != 0)
                                {
                                    cmdAddSubDetail.Parameters.Add("P_PURCH_ID", OracleDbType.Int32).Value = objSubDetailCost.PurchaseId;
                                }
                                else
                                {
                                    cmdAddSubDetail.Parameters.Add("P_PURCH_ID", OracleDbType.Int32).Value = null;
                                }


                                if (objSubDetailCost.CstCntrAmnt != 0)
                                    cmdAddSubDetail.Parameters.Add("R_COSTCNTR_AMT", OracleDbType.Decimal).Value = objSubDetailCost.CstCntrAmnt;
                                else
                                    cmdAddSubDetail.Parameters.Add("R_COSTCNTR_AMT", OracleDbType.Decimal).Value = null;
                                if (objSubDetailCost.DebitNoteId != 0)
                                {
                                    cmdAddSubDetail.Parameters.Add("R_DNT_ID", OracleDbType.Int32).Value = objSubDetailCost.DebitNoteId;
                                    cmdAddSubDetail.Parameters.Add("R_DNT_AMT", OracleDbType.Decimal).Value = objSubDetailCost.DebitNoteAmount;
                                    cmdAddSubDetail.Parameters.Add("P_LID", OracleDbType.Int32).Value = objSubDetailCost.LedgerId;


                                }
                                else
                                {
                                    cmdAddSubDetail.Parameters.Add("R_DNT_ID", OracleDbType.Int32).Value = 0;
                                    cmdAddSubDetail.Parameters.Add("R_DNT_AMT", OracleDbType.Decimal).Value = null;
                                    cmdAddSubDetail.Parameters.Add("P_LID", OracleDbType.Int32).Value = null;
                                }
                                //0043
                                cmdAddSubDetail.Parameters.Add("P_EXPENSE_AMT", OracleDbType.Decimal).Value = objSubDetailCost.ExpnsAmnt;
                                if (objSubDetailCost.ExpenceId != 0)
                                {
                                    cmdAddSubDetail.Parameters.Add("P_EXPNSID", OracleDbType.Int32).Value = objSubDetailCost.ExpenceId;
                                }
                                else
                                {
                                    cmdAddSubDetail.Parameters.Add("P_EXPNSID", OracleDbType.Int32).Value = null;
                                }
                                //end

                                cmdAddSubDetail.ExecuteNonQuery();
                            }
                            if (objSubDetailCost.DebitNoteAmount != 0 && objSubDetailCost.DebitNoteId != 0)
                            {
                                //string strQueryUpdateLedger1 = "FMS_PAYMENT_ACCOUNT.SP_UPD_LDGR_ACNT_REOPEN";
                                //using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryUpdateLedger1, con))
                                //{
                                //    cmdAddSubDetail.Transaction = tran;
                                //    cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                //    cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objSubDetailCost.LedgerId;
                                //    cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = objSubDetailCost.DebitNoteAmount;
                                //    cmdAddSubDetail.ExecuteNonQuery();
                                //}
                            }
                    }
                    string strQueryVoucherDel = " FMS_PAYMENT_ACCOUNT.SP_DEL_VOUCHER_ACCOUNT_REOPEN";
                    using (OracleCommand cmdPerfmncTmplt = new OracleCommand())
                    {
                        cmdPerfmncTmplt.CommandText = strQueryVoucherDel;
                        cmdPerfmncTmplt.CommandType = CommandType.StoredProcedure;
                        cmdPerfmncTmplt.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                        cmdPerfmncTmplt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayment.Organisation_id;
                        cmdPerfmncTmplt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayment.Corporate_id;
                        clsDataLayer.ExecuteNonQuery(cmdPerfmncTmplt);
                    }
                    string strQueryMemoRsnCncl = " FMS_PAYMENT_ACCOUNT.SP_PAYMENT_REOPEN";
                    using (OracleCommand cmdPerfmncTmplt = new OracleCommand())
                    {
                        cmdPerfmncTmplt.CommandText = strQueryMemoRsnCncl;
                        cmdPerfmncTmplt.CommandType = CommandType.StoredProcedure;
                        cmdPerfmncTmplt.Parameters.Add("R_PID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                        cmdPerfmncTmplt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityPayment.Organisation_id;
                        cmdPerfmncTmplt.Parameters.Add("R_CORP_ID", OracleDbType.Int32).Value = objEntityPayment.Corporate_id;
                        cmdPerfmncTmplt.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objEntityPayment.AccntNameId;
                        cmdPerfmncTmplt.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = objEntityPayment.TotalAmnt;
                        cmdPerfmncTmplt.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityPayment.User_Id;

                        clsDataLayer.ExecuteNonQuery(cmdPerfmncTmplt);
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
        public void CheckIssue_PaymentAccount(clsEntityPaymentAccount objEntity)
        {
            string strQuerylWelfare = "FMS_PAYMENT_ACCOUNT.SP_CHECK_ISSUE";
            using (OracleCommand cmdlWelfare = new OracleCommand())
            {
                cmdlWelfare.CommandText = strQuerylWelfare;
                cmdlWelfare.CommandType = CommandType.StoredProcedure;
                cmdlWelfare.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntity.PaymentId;
                cmdlWelfare.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntity.ChequeIssueDate;
                clsDataLayer.ExecuteNonQuery(cmdlWelfare);
            }
        }
        public DataTable readRefFormate(clsEntityCommon ObjEntitySales)
        {
            string strQueryReadCustomerLdger = "FMS_PAYMENT_ACCOUNT.SP_RD_REF_FORMAT";
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

        public DataTable ReadRefNumberByDate(clsEntityPaymentAccount ObjEntitySales)
        {
            string strQueryReadCustomerLdger = "FMS_PAYMENT_ACCOUNT.SP_RD_REF_BYDATE";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("S_DATE", OracleDbType.Date).Value = ObjEntitySales.FromDate;
            cmdReadCustomerLdger.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntitySales.Corporate_id;
            cmdReadCustomerLdger.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntitySales.Organisation_id;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public DataTable ReadRefNumberByDateLast(clsEntityPaymentAccount ObjEntitySales)
        {
            string strQueryReadCustomerLdger = "FMS_PAYMENT_ACCOUNT.SP_RD_REF_BYDATE_LAST";
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
        public DataTable ReadCorpDtls(clsEntityPaymentAccount ObjEntitySales)
        {
            string strQueryReadTcs = "FMS_PAYMENT_ACCOUNT.SP_READ_CORP_DTLS";
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
        public DataTable CheckPaymentCnclSts(clsEntityPaymentAccount objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_PAYMENT_ACCOUNT.SP_CHECK_CNCL_STS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityEmpSlry.PaymentId;
            cmdReadPayGrd.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }

        public DataTable ReadCostGroup1(clsEntityPaymentAccount objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_COSTGRP1";
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
        public DataTable ReadCostGroup2(clsEntityPaymentAccount objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_COSTGRP2";
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

        public DataTable ReadChequeTemId(clsEntityPaymentAccount objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_CHEQUE_TEMID";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_CHQBOOK_ID", OracleDbType.Int32).Value = objEntity.ChequeBookId;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable ReadPurchaseBalance(clsEntityPaymentAccount objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_PURCHASE_BALANCE";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("F_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("F_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("F_LDGRID", OracleDbType.Int32).Value = objEntity.PurchaseId;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public void ConfirmPaymentFromList(clsEntityPaymentAccount objEntityPayment, List<clsEntityPaymentAccount> objEntityLedgerIns, List<clsEntityPaymentAccount> objEntityLedgerUpd, List<clsEntityPaymentAccount> objEntityLedgerDel, List<clsEntityPaymentAccount> objEntityCostCenterIns, List<clsEntityPaymentAccount> objEntityCostCenterUpd, List<clsEntityPaymentAccount> objEntityCostCenterDel)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "FMS_PAYMENT_ACCOUNT.SP_CNFRM_PAYMENT_MSTR";
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
                        string Ref = ""; int SubRef = 1;
                        if (objEntityPayment.FromDate != objEntityPayment.UpdPaymentDate)
                        {
                            clsEntityCommon objEntCommon = new clsEntityCommon();
                            objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.FMS_PAYMENT);
                            objEntCommon.CorporateID = objEntityPayment.Corporate_id;
                            // string strNextId = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                            int intCorpId = objEntityPayment.Corporate_id;
                            int intOrgId = objEntityPayment.Organisation_id;
                            DataTable dtFormate = readRefFormate(objEntCommon);
                            int intUsrRolMstrId = 0;
                            string strRefAccountCls = "0";
                            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.PAYMENT_ACCOUNT);
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
                            clsCommonLibrary objCommon = new clsCommonLibrary();
                            DateTime dtCurrentDate = objCommon.textToDateTime(CurrentDate);
                            int DtYear = dtCurrentDate.Year;
                            int DtMonth = dtCurrentDate.Month;
                            string refFormatByDiv = "";
                            string strRealFormat = "";

                            //CHECKING SUB REF NUMBER
                            if (strRefAccountCls == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                            {
                                clsDataLayer_Account_Close objEmpAccntCls = new clsDataLayer_Account_Close();
                                clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
                                clsDataLayer_Audit_Closing objBusinessAudit = new clsDataLayer_Audit_Closing();
                                clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
                                objEntityAudit.FromDate = objEntityPayment.FromDate;
                                objEntityAudit.Corporate_id = intCorpId;
                                objEntityAudit.Organisation_id = intOrgId;
                                objEntityAccnt.FromDate = objEntityPayment.FromDate;
                                objEntityAccnt.FromDate = objEntityPayment.FromDate;
                                objEntityPayment.FromDate = objEntityPayment.FromDate;
                                objEntityAccnt.Corporate_id = intCorpId;
                                objEntityPayment.Corporate_id = intCorpId;
                                objEntityAccnt.Organisation_id = intOrgId;
                                objEntityPayment.Organisation_id = intOrgId;
                                DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
                                clsEntityPaymentAccount objEntityLayerStock1 = new clsEntityPaymentAccount();
                                DataTable dtAuditCls = objBusinessAudit.CheckAuditClosingDate(objEntityAudit);
                                if (dtAccntCls.Rows.Count > 0 || dtAuditCls.Rows.Count > 0)
                                {
                                    DataTable dtRefFormat1 = ReadRefNumberByDate(objEntityPayment);
                                    if (dtRefFormat1.Rows.Count > 0)
                                    {
                                        string strRef = "";
                                        if (dtRefFormat1.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString() != "")
                                        {
                                            if (Convert.ToInt32(dtRefFormat1.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString()) != 1)
                                            {
                                                strRef = dtRefFormat1.Rows[0]["PAYMNT_REF"].ToString();
                                                strRef = strRef.TrimEnd('/');
                                                strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                            }
                                            else
                                            {
                                                strRef = dtRefFormat1.Rows[0]["PAYMNT_REF"].ToString(); ;
                                            }
                                        }
                                        else
                                        {
                                            strRef = dtRefFormat1.Rows[0]["PAYMNT_REF"].ToString();

                                        }

                                        objEntityLayerStock1.RefNum = strRef;
                                        objEntityLayerStock1.Corporate_id = intCorpId;
                                        objEntityLayerStock1.Organisation_id = intOrgId;
                                        DataTable dtRefFormat = ReadRefNumberByDateLast(objEntityLayerStock1);
                                        if (dtRefFormat.Rows.Count > 0)
                                        {
                                            if (objEntityPayment.PaymentId != Convert.ToInt32(dtRefFormat.Rows[0]["PAYMNT_ID"].ToString()))
                                            {
                                                Ref = dtRefFormat.Rows[0]["PAYMNT_REF"].ToString();
                                                if (dtRefFormat.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString() != null)
                                                {
                                                    SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString());
                                                    objEntityPayment.SequenceRef = Convert.ToInt32(dtRefFormat.Rows[0]["PAYMNT_REF_SEQNUM"].ToString());
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
                                                objEntityPayment.RefNum = Ref;
                                                SubRef++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        cmdAddService.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                        cmdAddService.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = objEntityPayment.RefNum;
                        cmdAddService.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityPayment.User_Id;
                        cmdAddService.Parameters.Add("P_STS", OracleDbType.Int32).Value = objEntityPayment.ConfirmStatus;
                        cmdAddService.Parameters.Add("J_SUBREFID", OracleDbType.Int32).Value = SubRef;
                        cmdAddService.Parameters.Add("P_SEQNUM", OracleDbType.Int32).Value = objEntityPayment.SequenceRef;

                        cmdAddService.ExecuteNonQuery();
                    }

                    //on confirm
                    if (objEntityPayment.ConfirmStatus == 1)
                    {
                        //update ledger balance
                        string strQueryUpdateLedger = "FMS_PAYMENT_ACCOUNT.SP_UPDATE_LEDGER_MASTR";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryUpdateLedger, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objEntityPayment.AccntNameId;
                            cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = objEntityPayment.TotalAmnt;
                            cmdAddSubDetail.ExecuteNonQuery();
                        }
                        //Insert account book details to voucher account table
                        string strQueryInsertVoucher = "FMS_PAYMENT_ACCOUNT.SP_INS_VOUCHER_ACCOUNT";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                            cmdAddSubDetail.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = objEntityPayment.RefNum;
                            cmdAddSubDetail.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPayment.FromDate;
                            cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objEntityPayment.AccntNameId;
                            cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = objEntityPayment.TotalAmnt;
                            cmdAddSubDetail.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayment.Organisation_id;
                            cmdAddSubDetail.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayment.Corporate_id;
                            cmdAddSubDetail.Parameters.Add("P_VOCHR", OracleDbType.Int32).Value = 1;
                            cmdAddSubDetail.Parameters.Add("P_DESC", OracleDbType.Varchar2).Value = objEntityPayment.Description;
                            cmdAddSubDetail.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = objEntityPayment.FinancialYrId;
                            cmdAddSubDetail.Parameters.Add("P_BANKSTS", OracleDbType.Int32).Value = 1;
                            cmdAddSubDetail.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 1;
                            cmdAddSubDetail.Parameters.Add("P_VOUCHR_CAT", OracleDbType.Int32).Value = 0;

                            cmdAddSubDetail.Parameters.Add("L_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                            cmdAddSubDetail.ExecuteNonQuery();
                            string strReturn = cmdAddSubDetail.Parameters["L_ID"].Value.ToString();
                            cmdAddSubDetail.Dispose();
                            objEntityPayment.AccountVocherID = Convert.ToInt32(strReturn);
                        }
                    }

                    //payment ledgers INSERT
                    foreach (clsEntityPaymentAccount objSubDetail in objEntityLedgerIns)
                    {
                        if (objSubDetail.LedgerId != 0)
                        {
                            //on confirm
                            if (objEntityPayment.ConfirmStatus == 1)
                            {
                                //update ledger balance
                                string strQueryUpdateLedger = "FMS_PAYMENT_ACCOUNT.SP_UPD_LDGR_ACNT_REOPEN";
                                using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryUpdateLedger, con))
                                {
                                    cmdAddSubDetail.Transaction = tran;
                                    cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                    cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objSubDetail.LedgerId;
                                    cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = objSubDetail.LedgerAmnt;
                                    cmdAddSubDetail.ExecuteNonQuery();
                                }
                                //Insert ledger details to voucher account table
                                string strQueryInsertVoucher = "FMS_PAYMENT_ACCOUNT.SP_INS_VOUCHER_ACCOUNT";
                                using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucher, con))
                                {
                                    cmdAddVoucher.Transaction = tran;
                                    cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                    cmdAddVoucher.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                    cmdAddVoucher.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = objEntityPayment.RefNum;
                                    cmdAddVoucher.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPayment.FromDate;
                                    cmdAddVoucher.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objSubDetail.LedgerId;
                                    cmdAddVoucher.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = objSubDetail.LedgerAmnt;
                                    cmdAddVoucher.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayment.Organisation_id;
                                    cmdAddVoucher.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayment.Corporate_id;

                                    cmdAddVoucher.Parameters.Add("P_VOCHR", OracleDbType.Int32).Value = 0;
                                    cmdAddVoucher.Parameters.Add("P_DESC", OracleDbType.Varchar2).Value = objSubDetail.Remarks;
                                    cmdAddVoucher.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = objEntityPayment.FinancialYrId;
                                    cmdAddVoucher.Parameters.Add("P_BANKSTS", OracleDbType.Int32).Value = 0;
                                    cmdAddVoucher.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 0;
                                    cmdAddVoucher.Parameters.Add("P_VOUCHR_CAT", OracleDbType.Int32).Value = 0;
                                    cmdAddVoucher.Parameters.Add("L_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;

                                    cmdAddVoucher.ExecuteNonQuery();
                                    string strReturn = cmdAddVoucher.Parameters["L_ID"].Value.ToString();
                                    cmdAddVoucher.Dispose();
                                    objEntityPayment.VoucherID = Convert.ToInt32(strReturn);
                                }
                                //Insert into voucher details table
                                string strQueryInsertVoucherDtls = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS"; //Ledger to Account
                                using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherDtls, con))
                                {
                                    cmdAddVoucher.Transaction = tran;
                                    cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                    cmdAddVoucher.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objEntityPayment.AccntNameId;
                                    cmdAddVoucher.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = objEntityPayment.VoucherID;
                                    cmdAddVoucher.ExecuteNonQuery();

                                }
                                string strQueryInsertVoucherAccDtls = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";  //Account to Ledger
                                using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherAccDtls, con))
                                {
                                    cmdAddVoucher.Transaction = tran;
                                    cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                    cmdAddVoucher.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objSubDetail.LedgerId;
                                    cmdAddVoucher.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = objEntityPayment.AccountVocherID;
                                    cmdAddVoucher.ExecuteNonQuery();

                                }

                                if (objSubDetail.PaidAmt > 0)
                                {
                                    string strQueryInsertVoucher1 = "FMS_PAYMENT_ACCOUNT.SP_UPDATE_VOUCHER_ACCOUNT";
                                    using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher1, con))
                                    {
                                        cmdAddSubDetail.Transaction = tran;
                                        cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                        cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objSubDetail.LedgerId;
                                        cmdAddSubDetail.Parameters.Add("P_VOUCHR_CAT", OracleDbType.Int32).Value = objEntityPayment.VoucherCategory;
                                        cmdAddSubDetail.Parameters.Add("R_OBPAID_AMT", OracleDbType.Decimal).Value = objSubDetail.BalnceAmt;//balancamt
                                        cmdAddSubDetail.Parameters.Add("L_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                        cmdAddSubDetail.ExecuteNonQuery();
                                    }

                                    string strQueryInsertVoucherSettleDtls = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";  //Add settle amount details
                                    using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherSettleDtls, con))
                                    {
                                        cmdAddVoucher.Transaction = tran;
                                        cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                        cmdAddVoucher.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = objEntityPayment.VoucherID;
                                        cmdAddVoucher.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = objSubDetail.LedgerId;
                                        cmdAddVoucher.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = objSubDetail.PaidAmt;//paid amt
                                        cmdAddVoucher.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 4;
                                        cmdAddVoucher.Parameters.Add("C_USRID", OracleDbType.Int32).Value = objEntityPayment.User_Id;
                                        cmdAddVoucher.Parameters.Add("C_SALID", OracleDbType.Int32).Value = objSubDetail.LedgerId;
                                        cmdAddVoucher.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                        cmdAddVoucher.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = objSubDetail.BalnceAmt;
                                        cmdAddVoucher.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = objSubDetail.Payment_Ledgr_Id;
                                        cmdAddVoucher.ExecuteNonQuery();
                                    }
                                }

                            }
                            //cost centre details
                            foreach (clsEntityPaymentAccount objSubDetailCost in objEntityCostCenterIns)
                            {
                                if (objSubDetail.LedgerId == objSubDetailCost.LedgerId && objSubDetail.Payment_Ledgr_Id == objSubDetailCost.Payment_Ledgr_Id)
                                {
                                    //on confirm
                                    if (objEntityPayment.ConfirmStatus == 1)
                                    {
                                        if (objSubDetailCost.PurchaseId != 0 && objSubDetailCost.CstCntrAmnt != 0 && objSubDetailCost.DebitNoteId == 0)
                                        {
                                            //Insert purchase settlement to voucher settlemnt table
                                            string strQueryInsertVoucherSettleDtls = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";  //Add settle amount details
                                            using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherSettleDtls, con))
                                            {
                                                cmdAddVoucher.Transaction = tran;
                                                cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                                cmdAddVoucher.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = objEntityPayment.AccountVocherID;
                                                cmdAddVoucher.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = objSubDetail.LedgerId;
                                                cmdAddVoucher.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = objSubDetailCost.CstCntrAmnt;
                                                cmdAddVoucher.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 1;
                                                cmdAddVoucher.Parameters.Add("C_USRID", OracleDbType.Int32).Value = objEntityPayment.User_Id;
                                                cmdAddVoucher.Parameters.Add("C_SALID", OracleDbType.Int32).Value = objSubDetailCost.PurchaseId;
                                                cmdAddVoucher.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                                cmdAddVoucher.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = objSubDetailCost.PurchaseActAmount;
                                                cmdAddVoucher.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = objSubDetail.Payment_Ledgr_Id;
                                                cmdAddVoucher.ExecuteNonQuery();
                                            }
                                        }
                                        if (objSubDetailCost.DebitNoteAmount != 0 && objSubDetailCost.DebitNoteId != 0)
                                        {
                                            //Insert credit note settlement to voucher settlemnt table
                                            string strQueryInsertVoucherSettleDtls = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";  //Add settle amount details
                                            using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherSettleDtls, con))
                                            {
                                                cmdAddVoucher.Transaction = tran;
                                                cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                                cmdAddVoucher.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = objEntityPayment.VoucherID;
                                                cmdAddVoucher.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = objSubDetail.LedgerId;
                                                cmdAddVoucher.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = objSubDetailCost.DebitNoteAmount;
                                                cmdAddVoucher.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 2;
                                                cmdAddVoucher.Parameters.Add("C_USRID", OracleDbType.Int32).Value = objEntityPayment.User_Id;
                                                cmdAddVoucher.Parameters.Add("C_SALID", OracleDbType.Int32).Value = objSubDetailCost.PurchaseId;
                                                cmdAddVoucher.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                                cmdAddVoucher.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = objSubDetailCost.DebitNoteRemainingAmount;
                                                cmdAddVoucher.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = objSubDetail.Payment_Ledgr_Id;
                                                cmdAddVoucher.ExecuteNonQuery();
                                            }
                                        }
                                        if (objSubDetailCost.ExpenceId != 0 && objSubDetailCost.ExpnsAmnt != 0)
                                        {
                                            //insert into voucher settlemnt expense
                                            string strQueryInsertVoucherSettleDtls = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";  //Add settle amount details
                                            using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherSettleDtls, con))
                                            {
                                                cmdAddVoucher.Transaction = tran;
                                                cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                                cmdAddVoucher.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = objEntityPayment.VoucherID;
                                                cmdAddVoucher.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = objSubDetail.LedgerId;
                                                cmdAddVoucher.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = objSubDetailCost.ExpnsAmnt;
                                                cmdAddVoucher.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 5;
                                                cmdAddVoucher.Parameters.Add("C_USRID", OracleDbType.Int32).Value = objEntityPayment.User_Id;
                                                cmdAddVoucher.Parameters.Add("C_SALID", OracleDbType.Int32).Value = objSubDetailCost.ExpenceId;
                                                cmdAddVoucher.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                                cmdAddVoucher.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = objSubDetailCost.TotalExpnsAmnt;
                                                cmdAddVoucher.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = objSubDetail.Payment_Ledgr_Id;
                                                cmdAddVoucher.ExecuteNonQuery();
                                            }
                                        }

                                        //update purchase balance
                                        string strQuerySubSalesUpdate = "FMS_PAYMENT_ACCOUNT.SP_UPDATE_PURCHS_OR_COSTCNTR";
                                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubSalesUpdate, con))
                                        {
                                            cmdAddSubDetail.Transaction = tran;
                                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                            if (objSubDetailCost.CostCtrId != 0)
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_CST_CNTRID", OracleDbType.Int32).Value = objSubDetailCost.CostCtrId;
                                            }
                                            else
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_CST_CNTRID", OracleDbType.Int32).Value = null;
                                            }
                                            if (objSubDetailCost.PurchaseId != 0)
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_PURCH_ID", OracleDbType.Int32).Value = objSubDetailCost.PurchaseId;
                                            }
                                            else
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_PURCH_ID", OracleDbType.Int32).Value = null;
                                            }
                                            if (objSubDetailCost.CstCntrAmnt != 0)
                                            {
                                                cmdAddSubDetail.Parameters.Add("R_COSTCNTR_AMT", OracleDbType.Decimal).Value = objSubDetailCost.CstCntrAmnt;
                                            }
                                            else
                                            {
                                                cmdAddSubDetail.Parameters.Add("R_COSTCNTR_AMT", OracleDbType.Decimal).Value = null;
                                            }
                                            if (objSubDetailCost.DebitNoteId != 0)
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_DNT_ID", OracleDbType.Int32).Value = objSubDetailCost.DebitNoteId;
                                            }
                                            else
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_DNT_ID", OracleDbType.Int32).Value = 0;
                                            }
                                            if (objSubDetailCost.DebitNoteAmount != 0)
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_DNT_AMT", OracleDbType.Decimal).Value = objSubDetailCost.DebitNoteAmount;
                                            }
                                            else
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_DNT_AMT", OracleDbType.Decimal).Value = null;
                                            }
                                            if (objSubDetail.LedgerId != 0)
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_LID", OracleDbType.Int32).Value = objSubDetail.LedgerId;
                                            }
                                            else
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_LID", OracleDbType.Int32).Value = null;
                                            }
                                            //0043
                                            cmdAddSubDetail.Parameters.Add("P_EXPENSE_AMT", OracleDbType.Decimal).Value = objSubDetailCost.ExpnsAmnt;
                                            if (objSubDetailCost.ExpenceId != 0)
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_EXPNSID", OracleDbType.Int32).Value = objSubDetailCost.ExpenceId;
                                            }
                                            else
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_EXPNSID", OracleDbType.Int32).Value = null;
                                            }
                                            //end
                                            cmdAddSubDetail.ExecuteNonQuery();
                                        }

                                        //insert into cost centre voucher table
                                        string strQueryInsertVoucher = "FMS_COMMON.SP_INS_CSTCNTR_VOUCHER_ACCOUNT";
                                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                                        {
                                            if (objSubDetailCost.CostCtrId != 0)
                                            {
                                                cmdAddSubDetail.Transaction = tran;
                                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                cmdAddSubDetail.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                                cmdAddSubDetail.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = objEntityPayment.RefNum;
                                                cmdAddSubDetail.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPayment.FromDate;
                                                cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objSubDetail.LedgerId;
                                                cmdAddSubDetail.Parameters.Add("P_COST_CNTR_ID", OracleDbType.Int32).Value = objSubDetailCost.CostCtrId;
                                                if (objSubDetailCost.CostGrp1Id != 0)
                                                    cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_ONE", OracleDbType.Int32).Value = objSubDetailCost.CostGrp1Id;
                                                else
                                                    cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_ONE", OracleDbType.Int32).Value = null;
                                                if (objSubDetailCost.CostGrp2Id != 0)
                                                    cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_TWO", OracleDbType.Int32).Value = objSubDetailCost.CostGrp2Id;
                                                else
                                                    cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_TWO", OracleDbType.Int32).Value = null;
                                                cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = objSubDetailCost.CstCntrAmnt;
                                                cmdAddSubDetail.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayment.Organisation_id;
                                                cmdAddSubDetail.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayment.Corporate_id;
                                                cmdAddSubDetail.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = objEntityPayment.FinancialYrId;
                                                cmdAddSubDetail.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 0;
                                                cmdAddSubDetail.Parameters.Add("P_CRNC_MST_ID", OracleDbType.Int32).Value = objEntityPayment.CurrcyId;
                                                cmdAddSubDetail.Parameters.Add("P_VOCHR_TYPE", OracleDbType.Int32).Value = 1;
                                                cmdAddSubDetail.Parameters.Add("P_VOCHR_ID", OracleDbType.Int32).Value = objEntityPayment.VoucherID;

                                                cmdAddSubDetail.ExecuteNonQuery();
                                            }
                                        }
                                    }

                                }
                            }
                        }
                    }

                    //payment ledgers UPDATE
                    foreach (clsEntityPaymentAccount ObjEntityLdgrupdate in objEntityLedgerUpd)
                    {
                        if (ObjEntityLdgrupdate.LedgerId != 0)
                        {
                            //on confirm
                            if (objEntityPayment.ConfirmStatus == 1)
                            {
                                //update ledger balance
                                string strQueryUpdateLedger = "FMS_PAYMENT_ACCOUNT.SP_UPD_LDGR_ACNT_REOPEN";
                                using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryUpdateLedger, con))
                                {
                                    cmdAddSubDetail.Transaction = tran;
                                    cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                    cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.LedgerId;
                                    cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = ObjEntityLdgrupdate.LedgerAmnt;
                                    cmdAddSubDetail.ExecuteNonQuery();
                                }
                                //Insert ledger details to voucher account table
                                string strQueryInsertVoucher = "FMS_PAYMENT_ACCOUNT.SP_INS_VOUCHER_ACCOUNT";
                                using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucher, con))
                                {
                                    cmdAddVoucher.Transaction = tran;
                                    cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                    cmdAddVoucher.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                    cmdAddVoucher.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = objEntityPayment.RefNum;
                                    cmdAddVoucher.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPayment.FromDate;
                                    cmdAddVoucher.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.LedgerId;
                                    cmdAddVoucher.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = ObjEntityLdgrupdate.LedgerAmnt;
                                    cmdAddVoucher.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayment.Organisation_id;
                                    cmdAddVoucher.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayment.Corporate_id;

                                    cmdAddVoucher.Parameters.Add("P_VOCHR", OracleDbType.Int32).Value = 0;
                                    cmdAddVoucher.Parameters.Add("P_DESC", OracleDbType.Varchar2).Value = ObjEntityLdgrupdate.Remarks;
                                    cmdAddVoucher.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = objEntityPayment.FinancialYrId;
                                    cmdAddVoucher.Parameters.Add("P_BANKSTS", OracleDbType.Int32).Value = 0;
                                    cmdAddVoucher.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 0;
                                    cmdAddVoucher.Parameters.Add("P_VOUCHR_CAT", OracleDbType.Int32).Value = 0;
                                    cmdAddVoucher.Parameters.Add("L_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                    cmdAddVoucher.ExecuteNonQuery();

                                    string strReturn = cmdAddVoucher.Parameters["L_ID"].Value.ToString();
                                    cmdAddVoucher.Dispose();
                                    objEntityPayment.VoucherID = Convert.ToInt32(strReturn);
                                }
                                //insert into voucher details table
                                string strQueryInsertVoucherDtls = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS"; //Ledger to Account
                                using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherDtls, con))
                                {
                                    cmdAddVoucher.Transaction = tran;
                                    cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                    cmdAddVoucher.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objEntityPayment.AccntNameId;
                                    cmdAddVoucher.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = objEntityPayment.VoucherID;
                                    cmdAddVoucher.ExecuteNonQuery();

                                }
                                string strQueryInsertVoucherAccDtls = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";  //Account to Ledger
                                using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherAccDtls, con))
                                {
                                    cmdAddVoucher.Transaction = tran;
                                    cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                    cmdAddVoucher.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.LedgerId;
                                    cmdAddVoucher.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = objEntityPayment.AccountVocherID;
                                    cmdAddVoucher.ExecuteNonQuery();
                                }

                                if (ObjEntityLdgrupdate.PaidAmt > 0)
                                {
                                    string strQueryInsertVoucher1 = "FMS_PAYMENT_ACCOUNT.SP_UPDATE_VOUCHER_ACCOUNT";
                                    using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher1, con))
                                    {
                                        cmdAddSubDetail.Transaction = tran;
                                        cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                        cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.LedgerId;
                                        cmdAddSubDetail.Parameters.Add("P_VOUCHR_CAT", OracleDbType.Int32).Value = objEntityPayment.VoucherCategory;
                                        cmdAddSubDetail.Parameters.Add("R_OBPAID_AMT", OracleDbType.Decimal).Value = ObjEntityLdgrupdate.BalnceAmt;//balancamt
                                        cmdAddSubDetail.Parameters.Add("L_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                        cmdAddSubDetail.ExecuteNonQuery();
                                    }

                                    string strQueryInsertVoucherSettleDtls = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";  //Add settle amount details
                                    using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherSettleDtls, con))
                                    {
                                        cmdAddVoucher.Transaction = tran;
                                        cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                        cmdAddVoucher.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = objEntityPayment.VoucherID;
                                        cmdAddVoucher.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.LedgerId;
                                        cmdAddVoucher.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = ObjEntityLdgrupdate.PaidAmt;//paid amt
                                        cmdAddVoucher.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 4;
                                        cmdAddVoucher.Parameters.Add("C_USRID", OracleDbType.Int32).Value = objEntityPayment.User_Id;
                                        cmdAddVoucher.Parameters.Add("C_SALID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.LedgerId;
                                        cmdAddVoucher.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                        cmdAddVoucher.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = ObjEntityLdgrupdate.BalnceAmt;
                                        cmdAddVoucher.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.Payment_Ledgr_Id;
                                        cmdAddVoucher.ExecuteNonQuery();
                                    }
                                }
                            }
                            //cost centre details
                            foreach (clsEntityPaymentAccount objSubDetailCost in objEntityCostCenterIns)
                            {
                                if (objEntityPayment.ConfirmStatus == 1)
                                {
                                    if (ObjEntityLdgrupdate.LedgerId == objSubDetailCost.LedgerId && ObjEntityLdgrupdate.Payment_Ledgr_Id == objSubDetailCost.Payment_Ledgr_Id)
                                    {
                                        //insert into cost centre vocuher table
                                        string strQueryInsertVoucher = "FMS_COMMON.SP_INS_CSTCNTR_VOUCHER_ACCOUNT";
                                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                                        {
                                            if (objSubDetailCost.CostCtrId != 0)
                                            {
                                                cmdAddSubDetail.Transaction = tran;
                                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                cmdAddSubDetail.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                                cmdAddSubDetail.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = objEntityPayment.RefNum;
                                                cmdAddSubDetail.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPayment.FromDate;
                                                cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.LedgerId;
                                                cmdAddSubDetail.Parameters.Add("P_COST_CNTR_ID", OracleDbType.Int32).Value = objSubDetailCost.CostCtrId;
                                                if (objSubDetailCost.CostGrp1Id != 0)
                                                    cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_ONE", OracleDbType.Int32).Value = objSubDetailCost.CostGrp1Id;
                                                else
                                                    cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_ONE", OracleDbType.Int32).Value = null;
                                                if (objSubDetailCost.CostGrp2Id != 0)
                                                    cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_TWO", OracleDbType.Int32).Value = objSubDetailCost.CostGrp2Id;
                                                else
                                                    cmdAddSubDetail.Parameters.Add("P_COST_GRP_ID_TWO", OracleDbType.Int32).Value = null;
                                                cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = objSubDetailCost.CstCntrAmnt;
                                                cmdAddSubDetail.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPayment.Organisation_id;
                                                cmdAddSubDetail.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPayment.Corporate_id;
                                                cmdAddSubDetail.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = objEntityPayment.FinancialYrId;
                                                cmdAddSubDetail.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 0;
                                                cmdAddSubDetail.Parameters.Add("P_CRNC_MST_ID", OracleDbType.Int32).Value = objEntityPayment.CurrcyId;
                                                cmdAddSubDetail.Parameters.Add("P_VOCHR_TYPE", OracleDbType.Int32).Value = 1;
                                                cmdAddSubDetail.Parameters.Add("P_VOCHR_ID", OracleDbType.Int32).Value = objEntityPayment.VoucherID;

                                                cmdAddSubDetail.ExecuteNonQuery();
                                            }
                                        }

                                        //update purchase balance
                                        string strQuerySubSalesUpdate = "FMS_PAYMENT_ACCOUNT.SP_UPDATE_PURCHS_OR_COSTCNTR";
                                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubSalesUpdate, con))
                                        {
                                            cmdAddSubDetail.Transaction = tran;
                                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                            if (objSubDetailCost.CostCtrId != 0)
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_CST_CNTRID", OracleDbType.Int32).Value = objSubDetailCost.CostCtrId;
                                            }
                                            else
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_CST_CNTRID", OracleDbType.Int32).Value = null;
                                            }
                                            if (objSubDetailCost.PurchaseId != 0)
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_PURCH_ID", OracleDbType.Int32).Value = objSubDetailCost.PurchaseId;
                                            }
                                            else
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_PURCH_ID", OracleDbType.Int32).Value = null;
                                            }
                                            if (objSubDetailCost.CstCntrAmnt != 0)
                                                cmdAddSubDetail.Parameters.Add("R_COSTCNTR_AMT", OracleDbType.Decimal).Value = objSubDetailCost.CstCntrAmnt;
                                            else
                                                cmdAddSubDetail.Parameters.Add("R_COSTCNTR_AMT", OracleDbType.Decimal).Value = null;
                                            if (objSubDetailCost.DebitNoteId != 0)
                                            {
                                                cmdAddSubDetail.Parameters.Add("R_DNT_ID", OracleDbType.Int32).Value = objSubDetailCost.DebitNoteId;
                                                cmdAddSubDetail.Parameters.Add("R_DNT_AMT", OracleDbType.Decimal).Value = objSubDetailCost.DebitNoteAmount;
                                                cmdAddSubDetail.Parameters.Add("P_LID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.LedgerId;
                                            }
                                            else
                                            {
                                                cmdAddSubDetail.Parameters.Add("R_DNT_ID", OracleDbType.Int32).Value = 0;
                                                cmdAddSubDetail.Parameters.Add("R_DNT_AMT", OracleDbType.Decimal).Value = null;
                                                cmdAddSubDetail.Parameters.Add("P_LID", OracleDbType.Int32).Value = null;
                                            }
                                            //0043
                                            cmdAddSubDetail.Parameters.Add("P_EXPENSE_AMT", OracleDbType.Decimal).Value = objSubDetailCost.ExpnsAmnt;
                                            if (objSubDetailCost.ExpenceId != 0)
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_EXPNSID", OracleDbType.Int32).Value = objSubDetailCost.ExpenceId;
                                            }
                                            else
                                            {
                                                cmdAddSubDetail.Parameters.Add("P_EXPNSID", OracleDbType.Int32).Value = null;
                                            }
                                            //end
                                            cmdAddSubDetail.ExecuteNonQuery();
                                        }

                                        if (objSubDetailCost.PurchaseId != 0 && objSubDetailCost.CstCntrAmnt != 0 && objSubDetailCost.DebitNoteId == 0)
                                        {
                                            //insert purchase settlement to voucher settlement table
                                            string strQueryInsertVoucherSettleDtls = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";  //Add settle amount details
                                            using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherSettleDtls, con))
                                            {
                                                cmdAddVoucher.Transaction = tran;
                                                cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                                cmdAddVoucher.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = objEntityPayment.VoucherID;
                                                cmdAddVoucher.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.LedgerId;
                                                cmdAddVoucher.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = objSubDetailCost.CstCntrAmnt;
                                                cmdAddVoucher.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 1;
                                                cmdAddVoucher.Parameters.Add("C_USRID", OracleDbType.Int32).Value = objEntityPayment.User_Id;
                                                cmdAddVoucher.Parameters.Add("C_SALID", OracleDbType.Int32).Value = objSubDetailCost.PurchaseId;
                                                cmdAddVoucher.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                                cmdAddVoucher.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = objSubDetailCost.PurchaseActAmount;
                                                cmdAddVoucher.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.Payment_Ledgr_Id;
                                                cmdAddVoucher.ExecuteNonQuery();
                                            }
                                        }
                                        if (objSubDetailCost.DebitNoteAmount != 0 && objSubDetailCost.DebitNoteId != 0)
                                        {
                                            //insert credit note settlement to voucher settlement table
                                            string strQueryInsertVoucherSettleDtls = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";  //Add settle amount details
                                            using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherSettleDtls, con))
                                            {
                                                cmdAddVoucher.Transaction = tran;
                                                cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                                cmdAddVoucher.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = objEntityPayment.VoucherID;
                                                cmdAddVoucher.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.LedgerId;
                                                cmdAddVoucher.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = objSubDetailCost.DebitNoteAmount;
                                                cmdAddVoucher.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 2;
                                                cmdAddVoucher.Parameters.Add("C_USRID", OracleDbType.Int32).Value = objEntityPayment.User_Id;
                                                cmdAddVoucher.Parameters.Add("C_SALID", OracleDbType.Int32).Value = objSubDetailCost.PurchaseId;
                                                cmdAddVoucher.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                                cmdAddVoucher.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = objSubDetailCost.DebitNoteRemainingAmount;
                                                cmdAddVoucher.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.Payment_Ledgr_Id;
                                                cmdAddVoucher.ExecuteNonQuery();
                                            }
                                        }

                                        if (objSubDetailCost.ExpenceId != 0 && objSubDetailCost.ExpnsAmnt != 0)
                                        {
                                            //insert into voucher settlemnt expense
                                            string strQueryInsertVoucherSettleDtls = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";  //Add settle amount details
                                            using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherSettleDtls, con))
                                            {
                                                cmdAddVoucher.Transaction = tran;
                                                cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                                cmdAddVoucher.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = objEntityPayment.VoucherID;
                                                cmdAddVoucher.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.LedgerId;
                                                cmdAddVoucher.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = objSubDetailCost.ExpnsAmnt;
                                                cmdAddVoucher.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 5;
                                                cmdAddVoucher.Parameters.Add("C_USRID", OracleDbType.Int32).Value = objEntityPayment.User_Id;
                                                cmdAddVoucher.Parameters.Add("C_SALID", OracleDbType.Int32).Value = objSubDetailCost.ExpenceId;
                                                cmdAddVoucher.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = objEntityPayment.PaymentId;
                                                cmdAddVoucher.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = objSubDetailCost.TotalExpnsAmnt;
                                                cmdAddVoucher.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.Payment_Ledgr_Id;
                                                cmdAddVoucher.ExecuteNonQuery();
                                            }
                                        }



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

        public DataTable ReadPurchaseDebitNoteDtls(clsEntityPaymentAccount objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_DEBITNOTE_SETTLE_DTLS";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("F_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("F_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("F_LDGRID", OracleDbType.Int32).Value = objEntity.LedgerId;
            cmdReadRcpt.Parameters.Add("F_PAYID", OracleDbType.Int32).Value = objEntity.PaymentId;
            cmdReadRcpt.Parameters.Add("R_PAYLDGRID", OracleDbType.Int32).Value = objEntity.Payment_Ledgr_Id;
            cmdReadRcpt.Parameters.Add("F_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable ReadPurchaseDebitNoteBalanceDtls(clsEntityPaymentAccount objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_DEBITNOTE_BALANCE";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("F_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("F_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("F_LDGRID", OracleDbType.Int32).Value = objEntity.LedgerId;
            cmdReadRcpt.Parameters.Add("F_DNTID", OracleDbType.Int32).Value = objEntity.DebitNoteId;
            cmdReadRcpt.Parameters.Add("F_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }

        public void DeletePurchaseLedgers(List<clsEntityPaymentAccount> ObjEntityPymntCstCntrDEL)
        {
            foreach (clsEntityPaymentAccount objEntity in ObjEntityPymntCstCntrDEL)
            {
                string strCommandText = "FMS_PAYMENT_ACCOUNT.SP_DELETE_ADDEDPURCHS";
                OracleCommand cmdReadRcpt = new OracleCommand();
                cmdReadRcpt.CommandText = strCommandText;
                cmdReadRcpt.CommandType = CommandType.StoredProcedure;
                cmdReadRcpt.Parameters.Add("J_CST_ID", OracleDbType.Int32).Value = objEntity.PaymentCostCntrId;
                clsDataLayer.ExecuteNonQuery(cmdReadRcpt);
            }
        }

        public DataTable ReadChqNoByChqbkId(clsEntityPaymentAccount objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_CHEQUEBOOK";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_CHBKID", OracleDbType.Int32).Value = objEntity.ChequeBookId;
            cmdReadRcpt.Parameters.Add("R_ID", OracleDbType.Int32).Value = objEntity.PaymentId;
            cmdReadRcpt.Parameters.Add("R_TYPE", OracleDbType.Int32).Value = 0;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }

        public DataTable ReadSettledAmnt(clsEntityPaymentAccount objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_CHEQUEBOOK";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_CHBKID", OracleDbType.Int32).Value = objEntity.ChequeBookId;
            cmdReadRcpt.Parameters.Add("R_ID", OracleDbType.Int32).Value = objEntity.PaymentId;
            cmdReadRcpt.Parameters.Add("R_TYPE", OracleDbType.Int32).Value = 0;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }

        public DataTable Payment_List_Sum(clsEntityPaymentAccount objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_PAYMENT_LIST_SUM";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadRcpt.Parameters.Add("PR_ACC", OracleDbType.Int32).Value = objEntity.AccntNameId;
            cmdReadRcpt.Parameters.Add("PR_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("PR_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("PR_CANCEL", OracleDbType.Int32).Value = objEntity.cnclStatus;
            cmdReadRcpt.Parameters.Add("PR_LDR", OracleDbType.Int32).Value = objEntity.LedgerId;
            if (objEntity.FromDate != DateTime.MinValue)
            {
                cmdReadRcpt.Parameters.Add("FROMDT", OracleDbType.Date).Value = objEntity.FromDate;
            }
            else
            {
                cmdReadRcpt.Parameters.Add("FROMDT", OracleDbType.Date).Value = null;
            }
            if (objEntity.ToDate != DateTime.MinValue)
            {
                cmdReadRcpt.Parameters.Add("TODT", OracleDbType.Date).Value = objEntity.ToDate;
            }
            else
            {
                cmdReadRcpt.Parameters.Add("TODT", OracleDbType.Date).Value = null;
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
            cmdReadRcpt.Parameters.Add("PR_PUR_STS", OracleDbType.Int32).Value = objEntity.ConfirmStatus;
            cmdReadRcpt.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }

        public DataTable CheckChequeNumbersAdded(clsEntityPaymentAccount objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_CHECK_CHEQUENOS";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_CHBKID", OracleDbType.Int32).Value = objEntity.ChequeBookId;
            cmdReadRcpt.Parameters.Add("R_CHQNO", OracleDbType.Int32).Value = objEntity.ChequeBookNumber;
            cmdReadRcpt.Parameters.Add("R_ID", OracleDbType.Int32).Value = objEntity.PaymentId;
            cmdReadRcpt.Parameters.Add("R_TYPE", OracleDbType.Int32).Value = 0;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }

        public DataTable ReadCreditNoteDtls(clsEntityPaymentAccount objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_CREDITNOTE_SETTLE_DTLS";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("F_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("F_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("F_LDGRID", OracleDbType.Int32).Value = objEntity.LedgerId;
            cmdReadRcpt.Parameters.Add("F_PAYID", OracleDbType.Int32).Value = objEntity.PaymentId;
            cmdReadRcpt.Parameters.Add("R_PAYLDGRID", OracleDbType.Int32).Value = objEntity.Payment_Ledgr_Id;
            cmdReadRcpt.Parameters.Add("F_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }

        public DataTable ReadSalesReturnbyId(clsEntityPaymentAccount objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_SALES_RETURN_BY_LEDID";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_LEDGERID", OracleDbType.Int32).Value = objEntity.LedgerId;
            cmdReadRcpt.Parameters.Add("R_CRDTID", OracleDbType.Int32).Value = objEntity.PaymentId;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }

        public DataTable ReadSalesReturnBalance(clsEntityPaymentAccount objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_SALES_RETURN_BALANCE";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("F_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("F_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("F_LDGRID", OracleDbType.Int32).Value = objEntity.PurchaseId;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }

        //evm-0043 start
        public DataTable ReadExpensebyId(clsEntityPaymentAccount objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_EXPENSE_BY_LEDID";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_LEDGERID", OracleDbType.Int32).Value = objEntity.LedgerId;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_PAYID", OracleDbType.Int32).Value = objEntity.PaymentId;
            cmdReadRcpt.Parameters.Add("R_PAYLDGRID", OracleDbType.Int32).Value = objEntity.Payment_Ledgr_Id;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }

        public DataTable ReadExpenseBalance(clsEntityPaymentAccount objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_EXPENSE_BALANCE";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("F_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("F_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("F_LDGRID", OracleDbType.Int32).Value = objEntity.ExpenceId;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        //end


    }
}

