using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_FMS;
using CL_Compzit;
using EL_Compzit;

namespace DL_Compzit.DataLayer_FMS
{
    public class clsDataLayer_Postdated_Cheque
    {
        public DataTable ReadChequeBooks(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQueryReadCustomerLdger = "FMS_POSTDATED_CHEQUE.SP_READ_CHEQUEBOOK";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("LEDGER_ID", OracleDbType.Int32).Value = objEntityCheque.LedgerId;
            cmdReadCustomerLdger.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public DataTable ReadChequeBook_CancelIds(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQueryReadCustomerLdger = "FMS_POSTDATED_CHEQUE.SP_READ_CHEQUEBOOK_CANCELIDS";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("P_CHKBOK_ID", OracleDbType.Int32).Value = objEntityCheque.ChequeBookId;
            cmdReadCustomerLdger.Parameters.Add("B_BANKID", OracleDbType.Int32).Value = objEntityCheque.LedgerId;
            cmdReadCustomerLdger.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public DataTable ReadChequeBook_UsedIds(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQueryReadCustomerLdger = "FMS_POSTDATED_CHEQUE.SP_READ_CHEQUEBOOK_USED_IDS";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("P_CHKBOK_ID", OracleDbType.Int32).Value = objEntityCheque.ChequeBookId;
            cmdReadCustomerLdger.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public DataTable Read_SupplierLeadger(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQueryReadRcpt = "FMS_POSTDATED_CHEQUE.SP_READ_SUPPLIER_LEDGER";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityCheque.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable ReadRefFormate(clsEntityCommon ObjEntityCommon)
        {
            string strQueryReadCustomerLdger = "FMS_POSTDATED_CHEQUE.SP_RD_REF_FORMAT";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("S_MOD_ID", OracleDbType.Int32).Value = ObjEntityCommon.SectionId;
            cmdReadCustomerLdger.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntityCommon.CorporateID;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }

        //0039
        public DataTable Read_PayemntLedgerByIDForPrint(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_LDGR_DTLS_BYID_PRNT";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadRcpt.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityCheque.PaymentId;
            cmdReadRcpt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
            cmdReadRcpt.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }


        public DataTable Read_PayemntByID(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQueryReadRcpt = "FMS_POSTDATED_CHEQUE.SP_READ_CHEQUED_BYID";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadRcpt.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityCheque.PaymentId;
            cmdReadRcpt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityCheque.Organisation_id;
            cmdReadRcpt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
            cmdReadRcpt.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }

        public DataTable Read_PayemntCostByID(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_PAYMENT_COST_BYID";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadRcpt.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityCheque.PaymentId;
            cmdReadRcpt.Parameters.Add("P_LID", OracleDbType.Int32).Value = objEntityCheque.Payment_Ledgr_Id;
            cmdReadRcpt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
            cmdReadRcpt.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }

        public DataTable ReadCorpDtls(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQueryReadTcs = "FMS_PAYMENT_ACCOUNT.SP_READ_CORP_DTLS";
            OracleCommand cmdReadTcs = new OracleCommand();
            cmdReadTcs.CommandText = strQueryReadTcs;
            cmdReadTcs.CommandType = CommandType.StoredProcedure;
            cmdReadTcs.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = objEntityCheque.Organisation_id;
            cmdReadTcs.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
            cmdReadTcs.Parameters.Add("S_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadTcs);
            return dtLeav;
        }

        public DataTable AccntBalancebyId(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_ACCNTBALANCE_BYID";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadRcpt.Parameters.Add("R_LEDGERID", OracleDbType.Int32).Value = objEntityCheque.LedgerId;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityCheque.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        //end





        public DataTable ReadRefNumberByDate(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQueryReadCustomerLdger = "FMS_POSTDATED_CHEQUE.SP_RD_REF_BYDATE";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("S_DATE", OracleDbType.Date).Value = objEntityCheque.PostdatedChequeDate;
            cmdReadCustomerLdger.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
            cmdReadCustomerLdger.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = objEntityCheque.Organisation_id;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public DataTable ReadRefNumberByDateLast(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQueryReadCustomerLdger = "FMS_POSTDATED_CHEQUE.SP_RD_REF_BYDATE_LAST";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
            cmdReadCustomerLdger.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = objEntityCheque.Organisation_id;
            cmdReadCustomerLdger.Parameters.Add("S_REF", OracleDbType.Varchar2).Value = objEntityCheque.RefNumber;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public void InsertPostDatedCheque(clsEntity_Postdated_Cheque objEntityCheque, List<clsEntity_Postdated_Cheque> objEntityChequeList)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "FMS_POSTDATED_CHEQUE.SP_INS_POSTDATED_CHEQUE";
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
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.FMS_POSTDATED_CHEQUE);
                        objEntCommon.CorporateID = objEntityCheque.Corporate_id;
                        string strNextId1 = objDatatLayer.ReadNextNumber(objEntCommon);
                        string strNextId = objDatatLayer.ReadNextNumberSequanceForUI(objEntCommon);
                        objEntityCheque.PostDatedChequeId = Convert.ToInt32(strNextId1);
                        int intCorpId = objEntityCheque.Corporate_id;
                        int intOrgId = objEntityCheque.Organisation_id;
                        DataTable dtFormate = ReadRefFormate(objEntCommon);
                        int intUsrRolMstrId = 0;
                        string strRefAccountCls = "0";
                        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.FMS_POSTDATED_CHEQUE);
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
                                    strRealFormat = strRealFormat.Replace("#USR#", objEntityCheque.User_Id.ToString());
                                }
                                if (strRealFormat.Contains("#YER#"))
                                {
                                    strRealFormat = strRealFormat.Replace("#YER#", DtYear.ToString());
                                }
                                if (strRealFormat.Contains("#YY#"))
                                {
                                    strRealFormat = strRealFormat.Replace("#YY#", dtyy.ToString());
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
                            objEntityCheque.RefNumber = strRealFormat;
                        }
                        else
                        {

                            objEntityCheque.RefNumber = strNextId;
                        }
                        objEntityCheque.SequenceRef = Convert.ToInt32(strNextId);
                        //CHECKING SUB REF NUMBER
                        string Ref = ""; int SubRef = 1;
                        if (strRefAccountCls == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                        {
                            clsDataLayer_Account_Close objEmpAccntCls = new clsDataLayer_Account_Close();

                            clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();

                            clsDataLayer_Audit_Closing objBusinessAudit = new clsDataLayer_Audit_Closing();
                            clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
                            objEntityAudit.FromDate = objEntityCheque.PostdatedChequeDate;
                            objEntityAudit.Corporate_id = intCorpId;
                            objEntityAudit.Organisation_id = intOrgId;

                            objEntityAccnt.FromDate = objEntityCheque.PostdatedChequeDate;
                            objEntityAccnt.Corporate_id = intCorpId;
                            objEntityAccnt.Organisation_id = intOrgId;

                            objEntityCheque.Corporate_id = intCorpId;
                            objEntityCheque.Organisation_id = intOrgId;
                            DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
                            clsEntity_Postdated_Cheque objEntityCheques = new clsEntity_Postdated_Cheque();
                            objEntityCheques.Corporate_id = intCorpId;
                            objEntityCheques.Organisation_id = intOrgId;

                            DataTable dtAuditCls = objBusinessAudit.CheckAuditClosingDate(objEntityAudit);
                            if (dtAccntCls.Rows.Count > 0 || dtAuditCls.Rows.Count > 0)
                            {
                                DataTable dtRefFormat1 = ReadRefNumberByDate(objEntityCheque);
                                if (dtRefFormat1.Rows.Count > 0)
                                {
                                    string strRef = "";
                                    if (dtRefFormat1.Rows[0]["PST_CHEQUE_REF_NXT_SUBNUM"].ToString() != "")
                                    {
                                        if (Convert.ToInt32(dtRefFormat1.Rows[0]["PST_CHEQUE_REF_NXT_SUBNUM"].ToString()) != 1)
                                        {
                                            strRef = dtRefFormat1.Rows[0]["PST_CHEQUE_REF"].ToString();
                                            strRef = strRef.TrimEnd('/');
                                            strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                        }
                                        else
                                        {
                                            strRef = dtRefFormat1.Rows[0]["PST_CHEQUE_REF"].ToString();
                                        }
                                    }
                                    else
                                    {
                                        strRef = dtRefFormat1.Rows[0]["PST_CHEQUE_REF"].ToString();
                                    }

                                    objEntityCheques.RefNumber = strRef;
                                    DataTable dtRefFormat = ReadRefNumberByDateLast(objEntityCheques);
                                    if (dtRefFormat.Rows.Count > 0)
                                    {
                                        Ref = dtRefFormat.Rows[0]["PST_CHEQUE_REF"].ToString();
                                        if (dtRefFormat.Rows[0]["PST_CHEQUE_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["PST_CHEQUE_REF_NXT_SUBNUM"].ToString() != null)
                                        {
                                            SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["PST_CHEQUE_REF_NXT_SUBNUM"].ToString());
                                            objEntityCheque.SequenceRef = Convert.ToInt32(dtRefFormat.Rows[0]["PST_CHEQUE_REF_SEQNUM"].ToString());
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
                                        objEntityCheque.RefNumber = Ref;
                                        SubRef++;
                                    }

                                }
                            }
                        }
                        cmdAddService.CommandText = strQueryLeaveTyp;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityCheque.PostDatedChequeId;
                        cmdAddService.Parameters.Add("P_TYPE", OracleDbType.Int32).Value = objEntityCheque.TransactionType;
                        cmdAddService.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = objEntityCheque.RefNumber;
                        cmdAddService.Parameters.Add("P_ACCID", OracleDbType.Int32).Value = objEntityCheque.LedgerId;
                        cmdAddService.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityCheque.PostdatedChequeDate;
                        cmdAddService.Parameters.Add("P_SUPID", OracleDbType.Int32).Value = objEntityCheque.PartId;
                        if (objEntityCheque.TransactionType == 0)
                        {
                            cmdAddService.Parameters.Add("P_PAYEE", OracleDbType.Varchar2).Value = objEntityCheque.Payee;
                            cmdAddService.Parameters.Add("P_CHQ_ISSUE", OracleDbType.Int32).Value = objEntityCheque.IssueStatus;
                            if (objEntityCheque.ChequeIssueDate != DateTime.MinValue)
                                cmdAddService.Parameters.Add("P_CHQ_ISUE_DATE", OracleDbType.Date).Value = objEntityCheque.ChequeIssueDate;
                            else
                                cmdAddService.Parameters.Add("P_CHQ_ISUE_DATE", OracleDbType.Date).Value = null;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("P_PAYEE", OracleDbType.Varchar2).Value = DBNull.Value;
                            cmdAddService.Parameters.Add("P_CHQ_ISSUE", OracleDbType.Int32).Value = DBNull.Value;
                            cmdAddService.Parameters.Add("P_CHQ_ISUE_DATE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        cmdAddService.Parameters.Add("P_CURNCY", OracleDbType.Int32).Value = objEntityCheque.CurrencyId;
                        if (objEntityCheque.Description != "" && objEntityCheque.Description != null)
                            cmdAddService.Parameters.Add("P_DESRTN", OracleDbType.Varchar2).Value = objEntityCheque.Description;
                        else
                            cmdAddService.Parameters.Add("P_DESRTN", OracleDbType.Varchar2).Value = null;
                        cmdAddService.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityCheque.Organisation_id;
                        cmdAddService.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
                        cmdAddService.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityCheque.User_Id;
                        cmdAddService.Parameters.Add("P_SUBREFID", OracleDbType.Int32).Value = SubRef;
                        cmdAddService.Parameters.Add("P_SEQNUM", OracleDbType.Int32).Value = objEntityCheque.SequenceRef;
                        cmdAddService.Parameters.Add("P_AMOUNT", OracleDbType.Int32).Value = objEntityCheque.TotalAmount;
                        if (objEntityCheque.Method == 1 && objEntityCheque.SalesId != 0)
                        {
                            cmdAddService.Parameters.Add("P_SALES_ID", OracleDbType.Int32).Value = objEntityCheque.SalesId;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("P_SALES_ID", OracleDbType.Int32).Value = DBNull.Value;
                        }
                        if (objEntityCheque.Method == 1 && objEntityCheque.PurchaseId != 0)
                        {
                            cmdAddService.Parameters.Add("P_PURCHS_ID", OracleDbType.Int32).Value = objEntityCheque.PurchaseId;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("P_PURCHS_ID", OracleDbType.Int32).Value = DBNull.Value;
                        }
                        if (objEntityCheque.Method == 2 && objEntityCheque.ExpIncmLedgerId != 0)
                        {
                            cmdAddService.Parameters.Add("P_EXPINCM_LDGR_ID", OracleDbType.Int32).Value = objEntityCheque.ExpIncmLedgerId;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("P_EXPINCM_LDGR_ID", OracleDbType.Int32).Value = DBNull.Value;
                        }
                        cmdAddService.Parameters.Add("P_METHOD_STS", OracleDbType.Int32).Value = objEntityCheque.Method;
                        cmdAddService.Parameters.Add("P_CLRNC_LDGRID", OracleDbType.Int32).Value = objEntityCheque.ClearanceLedger;

                        cmdAddService.ExecuteNonQuery();
                    }
                    foreach (clsEntity_Postdated_Cheque objSubDetail in objEntityChequeList)
                    {
                            string strQuerySubDetails = "FMS_POSTDATED_CHEQUE.SP_INS_CHEQUE_DTLS";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetails, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddSubDetail.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityCheque.PostDatedChequeId;
                                if (objEntityCheque.TransactionType == 0)
                                {
                                    cmdAddSubDetail.Parameters.Add("P_CHBKID", OracleDbType.Int32).Value = objSubDetail.ChequeBookId;
                                    cmdAddSubDetail.Parameters.Add("P_BANK", OracleDbType.Varchar2).Value = DBNull.Value;
                                    cmdAddSubDetail.Parameters.Add("P_IBAN", OracleDbType.Varchar2).Value = DBNull.Value;
                                }
                                else
                                {
                                    cmdAddSubDetail.Parameters.Add("P_CHBKID", OracleDbType.Int32).Value = DBNull.Value;
                                    cmdAddSubDetail.Parameters.Add("P_BANK", OracleDbType.Varchar2).Value = objSubDetail.Bank;
                                    cmdAddSubDetail.Parameters.Add("P_IBAN", OracleDbType.Varchar2).Value = objSubDetail.Iban;
                                }
                                cmdAddSubDetail.Parameters.Add("P_CHBKNO", OracleDbType.Int32).Value = objSubDetail.ChequeBookNo;
                                cmdAddSubDetail.Parameters.Add("P_CHBKDATE", OracleDbType.Date).Value = objSubDetail.ChequeDate;
                                cmdAddSubDetail.Parameters.Add("P_CHBKAMT", OracleDbType.Decimal).Value = objSubDetail.ChequeAmount;
                                if (objSubDetail.Remarks != "" && objSubDetail.Remarks != null)
                                    cmdAddSubDetail.Parameters.Add("P_REMRK", OracleDbType.Varchar2).Value = objSubDetail.Remarks;
                                else
                                    cmdAddSubDetail.Parameters.Add("P_REMRK", OracleDbType.Varchar2).Value = null;
                                cmdAddSubDetail.ExecuteNonQuery();
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
        public DataTable PostDatedCheque_List(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQueryReadRcpt = "FMS_POSTDATED_CHEQUE.SP_READ_POSTDATED_CHEQUE_LIST";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadRcpt.Parameters.Add("PR_ACC", OracleDbType.Int32).Value = objEntityCheque.LedgerId;
            cmdReadRcpt.Parameters.Add("PR_ORGID", OracleDbType.Int32).Value = objEntityCheque.Organisation_id;
            cmdReadRcpt.Parameters.Add("PR_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
            cmdReadRcpt.Parameters.Add("PR_CANCEL", OracleDbType.Int32).Value = objEntityCheque.Status;
            if (objEntityCheque.ChequeDate != DateTime.MinValue)
            {
                cmdReadRcpt.Parameters.Add("FROMDT", OracleDbType.Date).Value = objEntityCheque.ChequeDate;
            }
            else
            {
                cmdReadRcpt.Parameters.Add("FROMDT", OracleDbType.Date).Value = null;
            }
            if (objEntityCheque.ChequeIssueDate != DateTime.MinValue)
            {
                cmdReadRcpt.Parameters.Add("TODT", OracleDbType.Date).Value = objEntityCheque.ChequeIssueDate;
            }
            else
            {
                cmdReadRcpt.Parameters.Add("TODT", OracleDbType.Date).Value = null;
            }
            if (objEntityCheque.FiancialStatDate != DateTime.MinValue)
            {
                cmdReadRcpt.Parameters.Add("S_START_DATE", OracleDbType.Date).Value = objEntityCheque.FiancialStatDate;
            }
            else
            {
                cmdReadRcpt.Parameters.Add("S_START_DATE", OracleDbType.Date).Value = null;
            }
            if (objEntityCheque.FiancialEndDate != DateTime.MinValue)
            {
                cmdReadRcpt.Parameters.Add("S_END_DATE", OracleDbType.Date).Value = objEntityCheque.FiancialEndDate;
            }
            else
            {
                cmdReadRcpt.Parameters.Add("S_END_DATE", OracleDbType.Date).Value = null;
            }
            cmdReadRcpt.Parameters.Add("PR_STS", OracleDbType.Int32).Value = objEntityCheque.ConfirmStatus;
            cmdReadRcpt.Parameters.Add("PR_TYPE", OracleDbType.Int32).Value = objEntityCheque.TransactionType;
            cmdReadRcpt.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable Read_PostDatedChequeByID(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQueryReadRcpt = "FMS_POSTDATED_CHEQUE.SP_READ_POSTDATED_CHEUQE_BYID";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityCheque.PostDatedChequeId;
            cmdReadRcpt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityCheque.Organisation_id;
            cmdReadRcpt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
            cmdReadRcpt.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable Read_Cheque_Dtls_ById(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQueryReadRcpt = "FMS_POSTDATED_CHEQUE.SP_READ_CHEUQE_DTLS_BYID";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityCheque.PostDatedChequeId;
            cmdReadRcpt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityCheque.Organisation_id;
            cmdReadRcpt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
            cmdReadRcpt.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public void UpdatePostDatedCheque(clsEntity_Postdated_Cheque objEntityCheque, List<clsEntity_Postdated_Cheque> objEntityChequeList)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "FMS_POSTDATED_CHEQUE.SP_UPD_POSTDATED_CHEQUE";
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
                        if (objEntityCheque.PostdatedChequeDate != objEntityCheque.UpdChequeDate)
                        {
                            clsEntityCommon objEntCommon = new clsEntityCommon();
                            objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.FMS_POSTDATED_CHEQUE);
                            objEntCommon.CorporateID = objEntityCheque.Corporate_id;
                            int intCorpId = objEntityCheque.Corporate_id;
                            int intOrgId = objEntityCheque.Organisation_id;
                            DataTable dtFormate = ReadRefFormate(objEntCommon);
                            int intUsrRolMstrId = 0;
                            string strRefAccountCls = "0";
                            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.FMS_POSTDATED_CHEQUE);
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
                                objEntityAudit.FromDate = objEntityCheque.PostdatedChequeDate;
                                objEntityAudit.Corporate_id = intCorpId;
                                objEntityAudit.Organisation_id = intOrgId;
                                objEntityAccnt.FromDate = objEntityCheque.PostdatedChequeDate;
                                objEntityCheque.PostdatedChequeDate = objEntityCheque.PostdatedChequeDate;
                                objEntityAccnt.Corporate_id = intCorpId;
                                objEntityCheque.Corporate_id = intCorpId;
                                objEntityAccnt.Organisation_id = intOrgId;
                                objEntityCheque.Organisation_id = intOrgId;
                                DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
                                clsEntity_Postdated_Cheque objEntityChk = new clsEntity_Postdated_Cheque();
                                objEntityChk.Corporate_id = intCorpId;
                                objEntityChk.Organisation_id = intOrgId;
                                DataTable dtAuditCls = objBusinessAudit.CheckAuditClosingDate(objEntityAudit);
                                if (dtAccntCls.Rows.Count > 0 || dtAuditCls.Rows.Count > 0)
                                {
                                    DataTable dtRefFormat1 = ReadRefNumberByDate(objEntityCheque);
                                    if (dtRefFormat1.Rows.Count > 0)
                                    {
                                        string strRef = "";
                                        if (dtRefFormat1.Rows[0]["PST_CHEQUE_REF_NXT_SUBNUM"].ToString() != "")
                                        {
                                            if (Convert.ToInt32(dtRefFormat1.Rows[0]["PST_CHEQUE_REF_NXT_SUBNUM"].ToString()) != 1)
                                            {
                                                strRef = dtRefFormat1.Rows[0]["PST_CHEQUE_REF"].ToString();
                                                strRef = strRef.TrimEnd('/');
                                                strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                            }
                                            else
                                            {
                                                strRef = dtRefFormat1.Rows[0]["PST_CHEQUE_REF"].ToString(); ;
                                            }
                                        }
                                        else
                                        {
                                            strRef = dtRefFormat1.Rows[0]["PST_CHEQUE_REF"].ToString();

                                        }

                                        objEntityChk.RefNumber = strRef;
                                        DataTable dtRefFormat = ReadRefNumberByDateLast(objEntityChk);
                                        if (dtRefFormat.Rows.Count > 0)
                                        {
                                            if (objEntityCheque.PostDatedChequeId != Convert.ToInt32(dtRefFormat.Rows[0]["PST_CHEQUE_ID"].ToString()))
                                            {
                                                Ref = dtRefFormat.Rows[0]["PST_CHEQUE_REF"].ToString();
                                                if (dtRefFormat.Rows[0]["PST_CHEQUE_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["PST_CHEQUE_REF_NXT_SUBNUM"].ToString() != null)
                                                {
                                                    SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["PST_CHEQUE_REF_NXT_SUBNUM"].ToString());
                                                    objEntityCheque.SequenceRef = Convert.ToInt32(dtRefFormat.Rows[0]["PST_CHEQUE_REF_SEQNUM"].ToString());
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
                                                objEntityCheque.RefNumber = Ref;
                                                SubRef++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        cmdAddService.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityCheque.PostDatedChequeId;
                        cmdAddService.Parameters.Add("P_TYPE", OracleDbType.Int32).Value = objEntityCheque.TransactionType;
                        cmdAddService.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = objEntityCheque.RefNumber;
                        cmdAddService.Parameters.Add("P_ACCID", OracleDbType.Int32).Value = objEntityCheque.LedgerId;
                        cmdAddService.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityCheque.PostdatedChequeDate;
                        cmdAddService.Parameters.Add("P_SUPID", OracleDbType.Int32).Value = objEntityCheque.PartId;
                        if (objEntityCheque.TransactionType == 0)
                        {
                            cmdAddService.Parameters.Add("P_PAYEE", OracleDbType.Varchar2).Value = objEntityCheque.Payee;
                            cmdAddService.Parameters.Add("P_CHQ_ISSUE", OracleDbType.Int32).Value = objEntityCheque.IssueStatus;
                            if (objEntityCheque.ChequeIssueDate != DateTime.MinValue)
                                cmdAddService.Parameters.Add("P_CHQ_ISUE_DATE", OracleDbType.Date).Value = objEntityCheque.ChequeIssueDate;
                            else
                                cmdAddService.Parameters.Add("P_CHQ_ISUE_DATE", OracleDbType.Date).Value = null;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("P_PAYEE", OracleDbType.Varchar2).Value = DBNull.Value;
                            cmdAddService.Parameters.Add("P_CHQ_ISSUE", OracleDbType.Int32).Value = DBNull.Value;
                            cmdAddService.Parameters.Add("P_CHQ_ISUE_DATE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        cmdAddService.Parameters.Add("P_CURNCY", OracleDbType.Int32).Value = objEntityCheque.CurrencyId;
                        if (objEntityCheque.Description != "" && objEntityCheque.Description != null)
                            cmdAddService.Parameters.Add("P_DESRTN", OracleDbType.Varchar2).Value = objEntityCheque.Description;
                        else
                            cmdAddService.Parameters.Add("P_DESRTN", OracleDbType.Varchar2).Value = null;
                        cmdAddService.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityCheque.Organisation_id;
                        cmdAddService.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
                        cmdAddService.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityCheque.User_Id;
                        cmdAddService.Parameters.Add("P_SUBREFID", OracleDbType.Int32).Value = SubRef;
                        cmdAddService.Parameters.Add("P_SEQNUM", OracleDbType.Int32).Value = objEntityCheque.SequenceRef;
                        cmdAddService.Parameters.Add("P_AMOUNT", OracleDbType.Decimal).Value = objEntityCheque.TotalAmount;
                        cmdAddService.Parameters.Add("P_COFRM_STS", OracleDbType.Int32).Value = objEntityCheque.ConfirmStatus;
                        if (objEntityCheque.Method == 1 && objEntityCheque.SalesId != 0)
                        {
                            cmdAddService.Parameters.Add("P_SALES_ID", OracleDbType.Int32).Value = objEntityCheque.SalesId;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("P_SALES_ID", OracleDbType.Int32).Value = DBNull.Value;
                        }
                        if (objEntityCheque.Method == 1 && objEntityCheque.PurchaseId != 0)
                        {
                            cmdAddService.Parameters.Add("P_PURCHS_ID", OracleDbType.Int32).Value = objEntityCheque.PurchaseId;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("P_PURCHS_ID", OracleDbType.Int32).Value = DBNull.Value;
                        }
                        if (objEntityCheque.Method == 2 && objEntityCheque.ExpIncmLedgerId != 0)
                        {
                            cmdAddService.Parameters.Add("P_EXPINCM_LDGR_ID", OracleDbType.Int32).Value = objEntityCheque.ExpIncmLedgerId;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("P_EXPINCM_LDGR_ID", OracleDbType.Int32).Value = DBNull.Value;
                        }
                        cmdAddService.Parameters.Add("P_CLRNC_LDGRID", OracleDbType.Int32).Value = objEntityCheque.ClearanceLedger;

                        cmdAddService.ExecuteNonQuery();
                    }

                    //if method 2 or 3
                    if (objEntityCheque.Method != 0)
                    {
                        //on confirm
                        if (objEntityCheque.ConfirmStatus == 1)
                        {
                            //update clearance ledger balance
                            string strQueryUpdateLedger = "FMS_POSTDATED_CHEQUE.SP_UPD_LEDGER_BALANCE";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryUpdateLedger, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddSubDetail.Parameters.Add("P_LD_ID", OracleDbType.Int32).Value = objEntityCheque.ClearanceLedger;
                                cmdAddSubDetail.Parameters.Add("P_LDGR_AMT", OracleDbType.Decimal).Value = objEntityCheque.TotalAmount;
                                if (objEntityCheque.TransactionType == 0)
                                {
                                    cmdAddSubDetail.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 1;
                                }
                                else if (objEntityCheque.TransactionType == 1)
                                {
                                    cmdAddSubDetail.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 0;
                                }
                                cmdAddSubDetail.ExecuteNonQuery();
                            }

                            //Insert clearance ledger to Vocher Account
                            string strQueryInsertVoucher = "FMS_POSTDATED_CHEQUE.SP_INS_VOUCHER_ACCOUNT";
                            using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucher, con))
                            {
                                cmdAddVoucher.Transaction = tran;
                                cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                cmdAddVoucher.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityCheque.PostDatedChequeId;
                                cmdAddVoucher.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = objEntityCheque.RefNumber;
                                cmdAddVoucher.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityCheque.PostdatedChequeDate;
                                cmdAddVoucher.Parameters.Add("P_LD_ID", OracleDbType.Int32).Value = objEntityCheque.ClearanceLedger;
                                cmdAddVoucher.Parameters.Add("P_LDGR_AMT", OracleDbType.Decimal).Value = objEntityCheque.TotalAmount;
                                cmdAddVoucher.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityCheque.Organisation_id;
                                cmdAddVoucher.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
                                cmdAddVoucher.Parameters.Add("P_DESC", OracleDbType.Varchar2).Value = objEntityCheque.Description;
                                cmdAddVoucher.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = objEntityCheque.FinancialYrId;
                                if (objEntityCheque.TransactionType == 0)
                                {
                                    cmdAddVoucher.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 1;
                                }
                                else if (objEntityCheque.TransactionType == 1)
                                {
                                    cmdAddVoucher.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 0;
                                }
                                if (objEntityCheque.TransactionType == 0)
                                {
                                    cmdAddVoucher.Parameters.Add("P_VOUCHR_TYP", OracleDbType.Int32).Value = 7;
                                }
                                else if (objEntityCheque.TransactionType == 1)
                                {
                                    cmdAddVoucher.Parameters.Add("P_VOUCHR_TYP", OracleDbType.Int32).Value = 8;
                                }
                                cmdAddVoucher.Parameters.Add("P_VOUCHR_CLRNC_STS", OracleDbType.Int32).Value = 1;

                                cmdAddVoucher.Parameters.Add("L_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                cmdAddVoucher.ExecuteNonQuery();
                                string strReturn = cmdAddVoucher.Parameters["L_ID"].Value.ToString();
                                cmdAddVoucher.Dispose();
                                objEntityCheque.VoucherClrncId = Convert.ToInt32(strReturn);
                            }
                        }
                    }

                    //insert cheque details
                    foreach (clsEntity_Postdated_Cheque objSubDetail in objEntityChequeList)
                    {
                        string strQuerySubDetails = "FMS_POSTDATED_CHEQUE.SP_INS_CHEQUE_DTLS";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetails, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityCheque.PostDatedChequeId;
                            if (objEntityCheque.TransactionType == 0)
                            {
                                cmdAddSubDetail.Parameters.Add("P_CHBKID", OracleDbType.Int32).Value = objSubDetail.ChequeBookId;
                                cmdAddSubDetail.Parameters.Add("P_BANK", OracleDbType.Varchar2).Value = DBNull.Value;
                                cmdAddSubDetail.Parameters.Add("P_IBAN", OracleDbType.Varchar2).Value = DBNull.Value;
                            }
                            else
                            {
                                cmdAddSubDetail.Parameters.Add("P_CHBKID", OracleDbType.Int32).Value = DBNull.Value;
                                cmdAddSubDetail.Parameters.Add("P_BANK", OracleDbType.Varchar2).Value = objSubDetail.Bank;
                                cmdAddSubDetail.Parameters.Add("P_IBAN", OracleDbType.Varchar2).Value = objSubDetail.Iban;
                            }
                            cmdAddSubDetail.Parameters.Add("P_CHBKNO", OracleDbType.Int32).Value = objSubDetail.ChequeBookNo;
                            cmdAddSubDetail.Parameters.Add("P_CHBKDATE", OracleDbType.Date).Value = objSubDetail.ChequeDate;
                            cmdAddSubDetail.Parameters.Add("P_CHBKAMT", OracleDbType.Decimal).Value = objSubDetail.ChequeAmount;
                            if (objSubDetail.Remarks != "" && objSubDetail.Remarks != null)
                                cmdAddSubDetail.Parameters.Add("P_REMRK", OracleDbType.Varchar2).Value = objSubDetail.Remarks;
                            else
                                cmdAddSubDetail.Parameters.Add("P_REMRK", OracleDbType.Varchar2).Value = null;
                            cmdAddSubDetail.ExecuteNonQuery();
                        }

                        //if method 2 or 3
                        if (objEntityCheque.Method != 0)
                        {
                            //on confirm
                            if (objEntityCheque.ConfirmStatus == 1)
                            {
                                //Insert cheque details to Vocher Account
                                string strQueryInsertVoucher = "FMS_POSTDATED_CHEQUE.SP_INS_VOUCHER_ACCOUNT";
                                using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucher, con))
                                {
                                    cmdAddVoucher.Transaction = tran;
                                    cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                    cmdAddVoucher.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityCheque.PostDatedChequeId;
                                    cmdAddVoucher.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = objEntityCheque.RefNumber;
                                    cmdAddVoucher.Parameters.Add("P_DATE", OracleDbType.Date).Value = objSubDetail.ChequeDate;
                                    cmdAddVoucher.Parameters.Add("P_LD_ID", OracleDbType.Int32).Value = objEntityCheque.PartId;
                                    cmdAddVoucher.Parameters.Add("P_LDGR_AMT", OracleDbType.Decimal).Value = objSubDetail.ChequeAmount;
                                    cmdAddVoucher.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityCheque.Organisation_id;
                                    cmdAddVoucher.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
                                    cmdAddVoucher.Parameters.Add("P_DESC", OracleDbType.Varchar2).Value = objSubDetail.Remarks;
                                    cmdAddVoucher.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = objEntityCheque.FinancialYrId;
                                    if (objEntityCheque.TransactionType == 0)
                                    {
                                        cmdAddVoucher.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 0;
                                    }
                                    else if (objEntityCheque.TransactionType == 1)
                                    {
                                        cmdAddVoucher.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 1;
                                    }
                                    if (objEntityCheque.TransactionType == 0)
                                    {
                                        cmdAddVoucher.Parameters.Add("P_VOUCHR_TYP", OracleDbType.Int32).Value = 7;
                                    }
                                    else if (objEntityCheque.TransactionType == 1)
                                    {
                                        cmdAddVoucher.Parameters.Add("P_VOUCHR_TYP", OracleDbType.Int32).Value = 8;
                                    }
                                    cmdAddVoucher.Parameters.Add("P_VOUCHR_CLRNC_STS", OracleDbType.Int32).Value = 0;

                                    cmdAddVoucher.Parameters.Add("L_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                    cmdAddVoucher.ExecuteNonQuery();
                                    string strReturn = cmdAddVoucher.Parameters["L_ID"].Value.ToString();
                                    cmdAddVoucher.Dispose();
                                    objEntityCheque.VoucherId = Convert.ToInt32(strReturn);
                                }

                                //voucher details table
                                string strQueryInsertVoucherDtls = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS"; //cheques to clearance
                                using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherDtls, con))
                                {
                                    cmdAddVoucher.Transaction = tran;
                                    cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                    cmdAddVoucher.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objEntityCheque.ClearanceLedger;
                                    cmdAddVoucher.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = objEntityCheque.VoucherId;
                                    cmdAddVoucher.ExecuteNonQuery();
                                }

                                string strQueryInsertVoucherAccDtls = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";  //clearance to cheques
                                using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherAccDtls, con))
                                {
                                    cmdAddVoucher.Transaction = tran;
                                    cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                    cmdAddVoucher.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objEntityCheque.PartId;
                                    cmdAddVoucher.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = objEntityCheque.VoucherClrncId;
                                    cmdAddVoucher.ExecuteNonQuery();
                                }


                            }
                        }
                    }

                    //on confirm
                    if (objEntityCheque.ConfirmStatus == 1)
                    {
                        //update party ledger balance
                        string strQueryUpdateLedger1 = "FMS_POSTDATED_CHEQUE.SP_UPD_LEDGER_BALANCE";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryUpdateLedger1, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("P_LD_ID", OracleDbType.Int32).Value = objEntityCheque.PartId;
                            cmdAddSubDetail.Parameters.Add("P_LDGR_AMT", OracleDbType.Decimal).Value = objEntityCheque.TotalAmount;
                            if (objEntityCheque.TransactionType == 0)
                            {
                                cmdAddSubDetail.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 0;
                            }
                            else if (objEntityCheque.TransactionType == 1)
                            {
                                cmdAddSubDetail.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 1;
                            }
                            cmdAddSubDetail.ExecuteNonQuery();
                        }

                        //--------sale/purchase settlement-------

                        //if method 2
                        if (objEntityCheque.Method == 1)
                        {
                            //update sale/purchase balance
                            string strQuerySubSalesUpdate = "FMS_POSTDATED_CHEQUE.SP_UPD_SALE_PURCHASE_BALANCE";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubSalesUpdate, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                if (objEntityCheque.TransactionType == 0)
                                {
                                    cmdAddSubDetail.Parameters.Add("P_LD_ID", OracleDbType.Int32).Value = objEntityCheque.PurchaseId;
                                }
                                else if (objEntityCheque.TransactionType == 1)
                                {
                                    cmdAddSubDetail.Parameters.Add("P_LD_ID", OracleDbType.Int32).Value = objEntityCheque.SalesId;
                                }
                                cmdAddSubDetail.Parameters.Add("P_LDGR_AMT", OracleDbType.Decimal).Value = objEntityCheque.TotalAmount;
                                cmdAddSubDetail.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = objEntityCheque.TransactionType;
                                cmdAddSubDetail.ExecuteNonQuery();
                            }

                            //insert into sale/purchase voucher settlemnt
                            string strQueryInsertVoucherSettleDtls = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";  //Add settle amount details
                            using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherSettleDtls, con))
                            {
                                cmdAddVoucher.Transaction = tran;
                                cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                cmdAddVoucher.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = objEntityCheque.VoucherClrncId;
                                cmdAddVoucher.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = objEntityCheque.PartId;
                                cmdAddVoucher.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = objEntityCheque.TotalAmount;
                                if (objEntityCheque.TransactionType == 0)
                                {
                                    cmdAddVoucher.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 1;
                                }
                                else if (objEntityCheque.TransactionType == 1)
                                {
                                    cmdAddVoucher.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 0;
                                }
                                cmdAddVoucher.Parameters.Add("C_USRID", OracleDbType.Int32).Value = objEntityCheque.User_Id;
                                if (objEntityCheque.TransactionType == 0)
                                {
                                    cmdAddVoucher.Parameters.Add("C_SALID", OracleDbType.Int32).Value = objEntityCheque.PurchaseId;
                                }
                                else if (objEntityCheque.TransactionType == 1)
                                {
                                    cmdAddVoucher.Parameters.Add("C_SALID", OracleDbType.Int32).Value = objEntityCheque.SalesId;
                                }
                                cmdAddVoucher.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = objEntityCheque.PostDatedChequeId;
                                cmdAddVoucher.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = objEntityCheque.SalePurchaseAmnt;
                                cmdAddVoucher.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = objEntityCheque.PostDatedChequeId;
                                cmdAddVoucher.ExecuteNonQuery();
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

        public void CancelPostDatedCheque(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQuerylWelfare = "FMS_POSTDATED_CHEQUE.SP_DEL_POSTDATED_CHEQUE";
            using (OracleCommand cmdlWelfare = new OracleCommand())
            {
                cmdlWelfare.CommandText = strQuerylWelfare;
                cmdlWelfare.CommandType = CommandType.StoredProcedure;
                cmdlWelfare.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityCheque.PostDatedChequeId;
                cmdlWelfare.Parameters.Add("USRID", OracleDbType.Int32).Value = objEntityCheque.User_Id;
                cmdlWelfare.Parameters.Add("CNSL_RSN", OracleDbType.Varchar2).Value = objEntityCheque.CancelReason;
                clsDataLayer.ExecuteNonQuery(cmdlWelfare);
            }
        }
        public void UpdateChequePaidRejectStatus(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQuerylWelfare = "FMS_POSTDATED_CHEQUE.SP_UPD_STATUS_POSTDATED_CHEQUE";
            using (OracleCommand cmdlWelfare = new OracleCommand())
            {
                cmdlWelfare.CommandText = strQuerylWelfare;
                cmdlWelfare.CommandType = CommandType.StoredProcedure;
                cmdlWelfare.Parameters.Add("P_CK_PID", OracleDbType.Int32).Value = objEntityCheque.ChequeBookId;
                cmdlWelfare.Parameters.Add("USRID", OracleDbType.Int32).Value = objEntityCheque.User_Id;
                cmdlWelfare.Parameters.Add("P_STS", OracleDbType.Int32).Value = objEntityCheque.Status;
                clsDataLayer.ExecuteNonQuery(cmdlWelfare);
            }
        }
        public void Confirm_List(clsEntity_Postdated_Cheque objEntityCheque, List<clsEntity_Postdated_Cheque> objEntityChequeList)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQuerylWelfare = "FMS_POSTDATED_CHEQUE.SP_UPD_CONFIRM_STATUS_LIST";
                    using (OracleCommand cmdlWelfare = new OracleCommand(strQuerylWelfare, con))
                    {
                        cmdlWelfare.Transaction = tran;
                        cmdlWelfare.CommandType = CommandType.StoredProcedure;

                        cmdlWelfare.CommandText = strQuerylWelfare;
                        cmdlWelfare.CommandType = CommandType.StoredProcedure;
                        cmdlWelfare.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityCheque.PostDatedChequeId;
                        cmdlWelfare.Parameters.Add("USRID", OracleDbType.Int32).Value = objEntityCheque.User_Id;
                        cmdlWelfare.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityCheque.Organisation_id;
                        cmdlWelfare.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
                        cmdlWelfare.ExecuteNonQuery();
                    }

                    //if method 2 or 3
                    if (objEntityCheque.Method != 0)
                    {
                        //on confirm
                        if (objEntityCheque.ConfirmStatus == 1)
                        {
                            //update clearance ledger balance
                            string strQueryUpdateLedger = "FMS_POSTDATED_CHEQUE.SP_UPD_LEDGER_BALANCE";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryUpdateLedger, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddSubDetail.Parameters.Add("P_LD_ID", OracleDbType.Int32).Value = objEntityCheque.ClearanceLedger;
                                cmdAddSubDetail.Parameters.Add("P_LDGR_AMT", OracleDbType.Decimal).Value = objEntityCheque.TotalAmount;
                                if (objEntityCheque.TransactionType == 0)
                                {
                                    cmdAddSubDetail.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 1;
                                }
                                else if (objEntityCheque.TransactionType == 1)
                                {
                                    cmdAddSubDetail.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 0;
                                }
                                cmdAddSubDetail.ExecuteNonQuery();
                            }

                            //Insert clearance ledger to Vocher Account
                            string strQueryInsertVoucher = "FMS_POSTDATED_CHEQUE.SP_INS_VOUCHER_ACCOUNT";
                            using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucher, con))
                            {
                                cmdAddVoucher.Transaction = tran;
                                cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                cmdAddVoucher.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityCheque.PostDatedChequeId;
                                cmdAddVoucher.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = objEntityCheque.RefNumber;
                                cmdAddVoucher.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityCheque.PostdatedChequeDate;
                                cmdAddVoucher.Parameters.Add("P_LD_ID", OracleDbType.Int32).Value = objEntityCheque.ClearanceLedger;
                                cmdAddVoucher.Parameters.Add("P_LDGR_AMT", OracleDbType.Decimal).Value = objEntityCheque.TotalAmount;
                                cmdAddVoucher.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityCheque.Organisation_id;
                                cmdAddVoucher.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
                                cmdAddVoucher.Parameters.Add("P_DESC", OracleDbType.Varchar2).Value = objEntityCheque.Description;
                                cmdAddVoucher.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = objEntityCheque.FinancialYrId;
                                if (objEntityCheque.TransactionType == 0)
                                {
                                    cmdAddVoucher.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 1;
                                }
                                else if (objEntityCheque.TransactionType == 1)
                                {
                                    cmdAddVoucher.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 0;
                                }
                                if (objEntityCheque.TransactionType == 0)
                                {
                                    cmdAddVoucher.Parameters.Add("P_VOUCHR_TYP", OracleDbType.Int32).Value = 7;
                                }
                                else if (objEntityCheque.TransactionType == 1)
                                {
                                    cmdAddVoucher.Parameters.Add("P_VOUCHR_TYP", OracleDbType.Int32).Value = 8;
                                }
                                cmdAddVoucher.Parameters.Add("P_VOUCHR_CLRNC_STS", OracleDbType.Int32).Value = 1;

                                cmdAddVoucher.Parameters.Add("L_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                cmdAddVoucher.ExecuteNonQuery();
                                string strReturn = cmdAddVoucher.Parameters["L_ID"].Value.ToString();
                                cmdAddVoucher.Dispose();
                                objEntityCheque.VoucherClrncId = Convert.ToInt32(strReturn);
                            }
                        }
                    }

                    //cheque details
                    foreach (clsEntity_Postdated_Cheque objSubDetail in objEntityChequeList)
                    {

                        //if method 2 or 3
                        if (objEntityCheque.Method != 0)
                        {
                            //on confirm
                            if (objEntityCheque.ConfirmStatus == 1)
                            {
                                //Insert cheque details to Vocher Account
                                string strQueryInsertVoucher = "FMS_POSTDATED_CHEQUE.SP_INS_VOUCHER_ACCOUNT";
                                using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucher, con))
                                {
                                    cmdAddVoucher.Transaction = tran;
                                    cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                    cmdAddVoucher.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityCheque.PostDatedChequeId;
                                    cmdAddVoucher.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = objEntityCheque.RefNumber;
                                    cmdAddVoucher.Parameters.Add("P_DATE", OracleDbType.Date).Value = objSubDetail.ChequeDate;
                                    cmdAddVoucher.Parameters.Add("P_LD_ID", OracleDbType.Int32).Value = objEntityCheque.PartId;
                                    cmdAddVoucher.Parameters.Add("P_LDGR_AMT", OracleDbType.Decimal).Value = objSubDetail.ChequeAmount;
                                    cmdAddVoucher.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityCheque.Organisation_id;
                                    cmdAddVoucher.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
                                    cmdAddVoucher.Parameters.Add("P_DESC", OracleDbType.Varchar2).Value = objSubDetail.Remarks;
                                    cmdAddVoucher.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = objEntityCheque.FinancialYrId;
                                    if (objEntityCheque.TransactionType == 0)
                                    {
                                        cmdAddVoucher.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 0;
                                    }
                                    else if (objEntityCheque.TransactionType == 1)
                                    {
                                        cmdAddVoucher.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 1;
                                    }
                                    if (objEntityCheque.TransactionType == 0)
                                    {
                                        cmdAddVoucher.Parameters.Add("P_VOUCHR_TYP", OracleDbType.Int32).Value = 7;
                                    }
                                    else if (objEntityCheque.TransactionType == 1)
                                    {
                                        cmdAddVoucher.Parameters.Add("P_VOUCHR_TYP", OracleDbType.Int32).Value = 8;
                                    }
                                    cmdAddVoucher.Parameters.Add("P_VOUCHR_CLRNC_STS", OracleDbType.Int32).Value = 0;

                                    cmdAddVoucher.Parameters.Add("L_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                    cmdAddVoucher.ExecuteNonQuery();
                                    string strReturn = cmdAddVoucher.Parameters["L_ID"].Value.ToString();
                                    cmdAddVoucher.Dispose();
                                    objEntityCheque.VoucherId = Convert.ToInt32(strReturn);
                                }

                                //voucher details table
                                string strQueryInsertVoucherDtls = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS"; //cheques to clearance
                                using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherDtls, con))
                                {
                                    cmdAddVoucher.Transaction = tran;
                                    cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                    cmdAddVoucher.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objEntityCheque.ClearanceLedger;
                                    cmdAddVoucher.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = objEntityCheque.VoucherId;
                                    cmdAddVoucher.ExecuteNonQuery();
                                }

                                string strQueryInsertVoucherAccDtls = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";  //clearance to cheques
                                using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherAccDtls, con))
                                {
                                    cmdAddVoucher.Transaction = tran;
                                    cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                    cmdAddVoucher.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objEntityCheque.PartId;
                                    cmdAddVoucher.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = objEntityCheque.VoucherClrncId;
                                    cmdAddVoucher.ExecuteNonQuery();
                                }

                            }
                        }

                    }

                    //on confirm
                    if (objEntityCheque.ConfirmStatus == 1)
                    {
                        //update party ledger balance
                        string strQueryUpdateLedger1 = "FMS_POSTDATED_CHEQUE.SP_UPD_LEDGER_BALANCE";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryUpdateLedger1, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("P_LD_ID", OracleDbType.Int32).Value = objEntityCheque.PartId;
                            cmdAddSubDetail.Parameters.Add("P_LDGR_AMT", OracleDbType.Decimal).Value = objEntityCheque.TotalAmount;
                            if (objEntityCheque.TransactionType == 0)
                            {
                                cmdAddSubDetail.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 0;
                            }
                            else if (objEntityCheque.TransactionType == 1)
                            {
                                cmdAddSubDetail.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 1;
                            }
                            cmdAddSubDetail.ExecuteNonQuery();
                        }

                        //--------sale/purchase settlement-------

                        //if method 2
                        if (objEntityCheque.Method == 1)
                        {
                            //update sale/purchase balance
                            string strQuerySubSalesUpdate = "FMS_POSTDATED_CHEQUE.SP_UPD_SALE_PURCHASE_BALANCE";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubSalesUpdate, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                if (objEntityCheque.TransactionType == 0)
                                {
                                    cmdAddSubDetail.Parameters.Add("P_LD_ID", OracleDbType.Int32).Value = objEntityCheque.PurchaseId;
                                }
                                else if (objEntityCheque.TransactionType == 1)
                                {
                                    cmdAddSubDetail.Parameters.Add("P_LD_ID", OracleDbType.Int32).Value = objEntityCheque.SalesId;
                                }
                                cmdAddSubDetail.Parameters.Add("P_LDGR_AMT", OracleDbType.Decimal).Value = objEntityCheque.TotalAmount;
                                cmdAddSubDetail.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = objEntityCheque.TransactionType;
                                cmdAddSubDetail.ExecuteNonQuery();
                            }

                            //insert into sale/purchase voucher settlemnt
                            string strQueryInsertVoucherSettleDtls = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";  //Add settle amount details
                            using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherSettleDtls, con))
                            {
                                cmdAddVoucher.Transaction = tran;
                                cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                cmdAddVoucher.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = objEntityCheque.VoucherClrncId;
                                cmdAddVoucher.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = objEntityCheque.PartId;
                                cmdAddVoucher.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = objEntityCheque.TotalAmount;
                                if (objEntityCheque.TransactionType == 0)
                                {
                                    cmdAddVoucher.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 1;
                                }
                                else if (objEntityCheque.TransactionType == 1)
                                {
                                    cmdAddVoucher.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 0;
                                }
                                cmdAddVoucher.Parameters.Add("C_USRID", OracleDbType.Int32).Value = objEntityCheque.User_Id;
                                if (objEntityCheque.TransactionType == 0)
                                {
                                    cmdAddVoucher.Parameters.Add("C_SALID", OracleDbType.Int32).Value = objEntityCheque.PurchaseId;
                                }
                                else if (objEntityCheque.TransactionType == 1)
                                {
                                    cmdAddVoucher.Parameters.Add("C_SALID", OracleDbType.Int32).Value = objEntityCheque.SalesId;
                                }
                                cmdAddVoucher.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = objEntityCheque.PostDatedChequeId;
                                cmdAddVoucher.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = objEntityCheque.SalePurchaseAmnt;
                                cmdAddVoucher.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = objEntityCheque.PostDatedChequeId;
                                cmdAddVoucher.ExecuteNonQuery();
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

        public void Reopen_list(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQuerylWelfare = "FMS_POSTDATED_CHEQUE.SP_UPD_REOPEN_STATUS_LIST";
            using (OracleCommand cmdlWelfare = new OracleCommand())
            {
                cmdlWelfare.CommandText = strQuerylWelfare;
                cmdlWelfare.CommandType = CommandType.StoredProcedure;
                cmdlWelfare.Parameters.Add("P_PID", OracleDbType.Int32).Value = objEntityCheque.PostDatedChequeId;
                cmdlWelfare.Parameters.Add("USRID", OracleDbType.Int32).Value = objEntityCheque.User_Id;
                cmdlWelfare.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityCheque.Organisation_id;
                cmdlWelfare.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
                cmdlWelfare.Parameters.Add("P_LDGR_AMT", OracleDbType.Decimal).Value = objEntityCheque.TotalAmount;
                cmdlWelfare.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = objEntityCheque.TransactionType;
                cmdlWelfare.Parameters.Add("P_PARTYID", OracleDbType.Int32).Value = objEntityCheque.PartId;
                cmdlWelfare.Parameters.Add("P_SALES_ID", OracleDbType.Int32).Value = objEntityCheque.SalesId;
                cmdlWelfare.Parameters.Add("P_PURCHASE_ID", OracleDbType.Int32).Value = objEntityCheque.PurchaseId;
                cmdlWelfare.Parameters.Add("P_CLEARANCEID", OracleDbType.Int32).Value = objEntityCheque.ClearanceLedger;
                clsDataLayer.ExecuteNonQuery(cmdlWelfare);
            }
        }
        public DataTable CheckChequeConfirmed(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQueryReadCustomerLdger = "FMS_POSTDATED_CHEQUE.SP_CHK_CHEQUE_CNFRM";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("PR_PUR", OracleDbType.Int32).Value = objEntityCheque.PostDatedChequeId;
            cmdReadCustomerLdger.Parameters.Add("PR_ORGID", OracleDbType.Int32).Value = objEntityCheque.Organisation_id;
            cmdReadCustomerLdger.Parameters.Add("PR_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public DataTable CheckChequeCanceled(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQueryReadCustomerLdger = "FMS_POSTDATED_CHEQUE.SP_CHK_CHEQUE_CANCEL";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("PR_PUR", OracleDbType.Int32).Value = objEntityCheque.PostDatedChequeId;
            cmdReadCustomerLdger.Parameters.Add("PR_ORGID", OracleDbType.Int32).Value = objEntityCheque.Organisation_id;
            cmdReadCustomerLdger.Parameters.Add("PR_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public DataTable CheckChequePaid(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQueryReadCustomerLdger = "FMS_POSTDATED_CHEQUE.SP_CHK_CHEQUE_PAID_COUNT";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("PR_PUR", OracleDbType.Int32).Value = objEntityCheque.PostDatedChequeId;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public DataTable CheckChequeIsPaid_Reject(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQueryReadCustomerLdger = "FMS_POSTDATED_CHEQUE.SP_CHK_CHEQUE_IS_PAID_REJECT";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("PR_PUR", OracleDbType.Int32).Value = objEntityCheque.PostDatedChequeId;
            cmdReadCustomerLdger.Parameters.Add("P_CHK_ID", OracleDbType.Int32).Value = objEntityCheque.ChequeBookId;
            cmdReadCustomerLdger.Parameters.Add("P_STS", OracleDbType.Int32).Value = objEntityCheque.Status;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public DataTable Read_Cheque_Dtls_By_ChequeId(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQueryReadRcpt = "FMS_POSTDATED_CHEQUE.SP_READ_CHEUQE_DTLS_BY_CHK_ID";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCheque.PostDatedChequeId;
            cmdReadRcpt.Parameters.Add("CHBK_ID", OracleDbType.Int32).Value = objEntityCheque.ChequeBookId;
            cmdReadRcpt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityCheque.Organisation_id;
            cmdReadRcpt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
            cmdReadRcpt.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable Read_Cheque_Dtls_Payment(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQueryReadRcpt = "FMS_POSTDATED_CHEQUE.SP_CHK_CHEQUE_IS_PAID_PAYMENT";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("PR_PUR", OracleDbType.Int32).Value = objEntityCheque.PostDatedChequeId;
            cmdReadRcpt.Parameters.Add("P_CHK_ID", OracleDbType.Int32).Value = objEntityCheque.ChequeBookId;
            cmdReadRcpt.Parameters.Add("P_TYPE", OracleDbType.Int32).Value = objEntityCheque.Status;
            cmdReadRcpt.Parameters.Add("P_METHOD", OracleDbType.Int32).Value = objEntityCheque.Method;
            cmdReadRcpt.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable CheckDupBankAcNum(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQueryReadRcpt = "FMS_POSTDATED_CHEQUE.SP_CHK_CHEQUE_DUP";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("P_BANK", OracleDbType.Varchar2).Value = objEntityCheque.Bank;
            cmdReadRcpt.Parameters.Add("P_ACNUM", OracleDbType.Varchar2).Value = objEntityCheque.CancelReason;
            cmdReadRcpt.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityCheque.PostDatedChequeId;
            //cmdReadRcpt.Parameters.Add("P_TYPE", OracleDbType.Int32).Value = 0;
            cmdReadRcpt.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }

        //Report

        public DataTable Read_CustmerLeadger(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQueryReadRcpt = "FMS_POSTDATED_CHEQUE.SP_READ_CUSTOMER_LEDGER";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityCheque.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable Read_PostdatedCheque_Report_List(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQueryReadRcpt = "FMS_POSTDATED_CHEQUE.SP_READ_POSTDATED_CHEQUE_LIST";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            if (objEntityCheque.ChequeIssueDate != DateTime.MinValue)
                cmdReadRcpt.Parameters.Add("UPTO_DATE", OracleDbType.Date).Value = objEntityCheque.ChequeIssueDate;
            else
                cmdReadRcpt.Parameters.Add("UPTO_DATE", OracleDbType.Date).Value = null;
            cmdReadRcpt.Parameters.Add("PR_STS", OracleDbType.Int32).Value = objEntityCheque.Status;
            cmdReadRcpt.Parameters.Add("PR_TRAN_TYPE", OracleDbType.Int32).Value = objEntityCheque.TransactionType;
            cmdReadRcpt.Parameters.Add("PARTY_STS", OracleDbType.Int32).Value = objEntityCheque.IssueStatus;
            if (objEntityCheque.LedgerId != 0)
                cmdReadRcpt.Parameters.Add("BANK", OracleDbType.Int32).Value = objEntityCheque.LedgerId;
            else
                cmdReadRcpt.Parameters.Add("BANK", OracleDbType.Int32).Value = null;
            if (objEntityCheque.PartId != 0)
                cmdReadRcpt.Parameters.Add("PARTY", OracleDbType.Int32).Value = objEntityCheque.PartId;
            else
                cmdReadRcpt.Parameters.Add("PARTY", OracleDbType.Int32).Value = null;
            cmdReadRcpt.Parameters.Add("PR_ORGID", OracleDbType.Int32).Value = objEntityCheque.Organisation_id;
            cmdReadRcpt.Parameters.Add("PR_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
            cmdReadRcpt.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable Read_PostdatedCheque_Home_List(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQueryReadRcpt = "FMS_POSTDATED_CHEQUE.SP_RD_POSTDAT_CHEQUE_LIST_HOM";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            if (objEntityCheque.ChequeIssueDate != DateTime.MinValue)
                cmdReadRcpt.Parameters.Add("UPTO_DATE", OracleDbType.Date).Value = objEntityCheque.ChequeIssueDate;
            else
                cmdReadRcpt.Parameters.Add("UPTO_DATE", OracleDbType.Date).Value = null;
            cmdReadRcpt.Parameters.Add("PR_ORGID", OracleDbType.Int32).Value = objEntityCheque.Organisation_id;
            cmdReadRcpt.Parameters.Add("PR_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
            cmdReadRcpt.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }

        public DataTable ReadChqNoByChqbkId(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_CHEQUEBOOK";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityCheque.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_CHBKID", OracleDbType.Int32).Value = objEntityCheque.ChequeBookId;
            cmdReadRcpt.Parameters.Add("R_ID", OracleDbType.Int32).Value = objEntityCheque.PostDatedChequeId;
            cmdReadRcpt.Parameters.Add("R_TYPE", OracleDbType.Int32).Value = 1;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }

        public DataTable ReadSalesPurchase(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQueryReadCustomerLdger = "FMS_POSTDATED_CHEQUE.SP_READ_SALE_PURCHASES";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
            cmdReadCustomerLdger.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityCheque.Organisation_id;
            cmdReadCustomerLdger.Parameters.Add("P_TRANSACTIONID", OracleDbType.Int32).Value = objEntityCheque.TransactionType;
            cmdReadCustomerLdger.Parameters.Add("P_PARTYID", OracleDbType.Int32).Value = objEntityCheque.PartId;
            cmdReadCustomerLdger.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }

        public DataTable ReadIncomeExpenses(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQueryReadCustomerLdger = "FMS_POSTDATED_CHEQUE.SP_READ_INCOME_EXPENSE_LDGRS";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
            cmdReadCustomerLdger.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityCheque.Organisation_id;
            cmdReadCustomerLdger.Parameters.Add("P_TRANSACTIONID", OracleDbType.Int32).Value = objEntityCheque.TransactionType;
            cmdReadCustomerLdger.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }

        public DataTable CheckChequeNumbersAdded(clsEntity_Postdated_Cheque objEntityCheque)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_CHECK_CHEQUENOS";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityCheque.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityCheque.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_CHBKID", OracleDbType.Int32).Value = objEntityCheque.ChequeBookId;
            cmdReadRcpt.Parameters.Add("R_CHQNO", OracleDbType.Int32).Value = objEntityCheque.ChequeBookNo;
            cmdReadRcpt.Parameters.Add("R_ID", OracleDbType.Int32).Value = objEntityCheque.PostDatedChequeId;
            cmdReadRcpt.Parameters.Add("R_TYPE", OracleDbType.Int32).Value = 1;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }



    }
}
