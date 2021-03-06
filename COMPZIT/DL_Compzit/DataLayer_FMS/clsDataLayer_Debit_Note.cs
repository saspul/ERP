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
    public class clsDataLayer_Debit_Note
    {
        public DataTable ReadLeadger(clsEntity_Debit_Note objEntityCreditNote)
        {
            string strQueryReadRcpt = "FMS_DEBIT_NOTE.SP_READ_LEDGER";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityCreditNote.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityCreditNote.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable ReadPurchaseBalance(clsEntity_Debit_Note objEntity)
        {
            string strQueryReadRcpt = "FMS_PAYMENT_ACCOUNT.SP_READ_PURCHASE_BALANCE";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("F_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("F_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("F_LDGRID", OracleDbType.Int32).Value = objEntity.Cost_Centre_Id;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable ReadCostCenter(clsEntity_Debit_Note objEntityCreditNote)
        {
            string strQueryReadRcpt = "FMS_DEBIT_NOTE.SP_READ_COSTCENTER";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityCreditNote.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityCreditNote.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }
        public DataTable readRefFormate(clsEntityCommon ObjEntitySales)
        {
            string strQueryReadCustomerLdger = "FMS_DEBIT_NOTE.SP_RD_REF_FORMAT";
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
        public void AddCreditNote(clsEntity_Debit_Note objEntityCreditNote, List<clsEntity_Debit_Note> objEntitylLedgrList, List<clsEntity_Debit_Note> objEntityCostcentrList, List<clsEntity_Debit_Note> objEntitySaleList)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "FMS_DEBIT_NOTE.SP_INS_DEBIT_NOTE_MASTER";
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
                        clsCommonLibrary objCommon = new clsCommonLibrary();
                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.DEBIT_NOTE);
                        objEntCommon.CorporateID = objEntityCreditNote.Corporate_id;
                     

                        string strNextId1 = objDatatLayer.ReadNextNumber(objEntCommon);
                        string strNextId = objDatatLayer.ReadNextNumberSequanceForUI(objEntCommon);



                        objEntityCreditNote.Debit_Id = Convert.ToInt32(strNextId1);
                        //CHECKING FOR CORP GLOBAL SUB REF STATUS
                        int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intCorpId = 0; string strRefAccountCls = "0";
                        intCorpId = objEntityCreditNote.Corporate_id;
                        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Debit_Note);
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
                        int intOrgId = objEntityCreditNote.Organisation_id;
                        int intUsrId = objEntityCreditNote.User_Id;
                      //  objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Debit_Note);
                        DataTable dtFormate = readRefFormate(objEntCommon);
                        clsDataLayerDateAndTime objDataLayerDateTime = new clsDataLayerDateAndTime();
                        string CurrentDate = objDataLayerDateTime.DateAndTime().ToString("dd-MM-yyyy");
                        DateTime dtCurrentDate = objCommon.textToDateTime(CurrentDate);
                        int DtYear = dtCurrentDate.Year;
                        int DtMonth = dtCurrentDate.Month;
                        string refFormatByDiv = "";
                        string strRealFormat = "";
                        string dtyy = dtCurrentDate.ToString("yy");

                        clsDataLayer objBusinessLayer = new clsDataLayer();
                        clsEntityCommon objEntityCommon = new clsEntityCommon();

                        objEntityCommon.Organisation_Id = objEntityCreditNote.Organisation_id;
                        objEntityCommon.CorporateID = objEntityCreditNote.Corporate_id;
                        objEntityCommon.FinancialYrId = objEntityCreditNote.FinancialYrId;

                        DataTable dtCurrentFiscalYr = objBusinessLayer.ReadFinancialYearById(objEntityCommon);
                        DateTime dtFinStartDate = new DateTime();
                        DateTime dtFinEndDate = new DateTime();
                        if (dtCurrentFiscalYr.Rows.Count > 0)
                        {
                            dtFinStartDate = objCommon.textToDateTime(dtCurrentFiscalYr.Rows[0]["FINCYR_START_DT"].ToString());
                            dtFinEndDate = objCommon.textToDateTime(dtCurrentFiscalYr.Rows[0]["FINCYR_END_DT"].ToString());
                        }

                        if (dtFormate.Rows.Count > 0)
                        {
                            if (dtFormate.Rows[0]["REF_FORMATE"].ToString() != "")
                            {
                                refFormatByDiv = dtFormate.Rows[0]["REF_FORMATE"].ToString();
                                string strReferenceFormat = "";
                                strReferenceFormat = refFormatByDiv;
                                string[] arrReferenceSplit = strReferenceFormat.Split('*');
                                int intArrayRowCount = arrReferenceSplit.Length;
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
                                        strRealFormat = strRealFormat.Replace("#USR#", intUsrId.ToString());
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
                                }
                                objEntityCreditNote.Reference_Num = strRealFormat;
                            }
                        }
                        else
                        {

                            objEntityCreditNote.Reference_Num = strNextId;
                        }
                        objEntityCreditNote.RefSeqNo = Convert.ToInt32(strNextId);


                        //CHECKING SUB REF NUMBER
                        string Ref = ""; int SubRef = 1;
                        if (strRefAccountCls == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                        {
                            clsDataLayer_Account_Close objEmpAccntCls = new clsDataLayer_Account_Close();
                            clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
                            clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
                            clsDataLayer_Audit_Closing objEmpAuditCls = new clsDataLayer_Audit_Closing();

                            objEntityAccnt.FromDate = objEntityCreditNote.Debit_Date;
                            clsEntity_Debit_Note objEntityLayerStock1 = new clsEntity_Debit_Note();
                            objEntityLayerStock1.Date_From = objEntityCreditNote.Debit_Date;
                            objEntityAccnt.Corporate_id = intCorpId;
                            objEntityLayerStock1.Corporate_id = intCorpId;
                            objEntityAccnt.Organisation_id = intOrgId;
                            objEntityLayerStock1.Organisation_id = intOrgId;


                            objEntityAccnt.Corporate_id = intCorpId;
                            objEntityAudit.FromDate = objEntityCreditNote.Debit_Date; 
                            objEntityAccnt.Organisation_id = intOrgId;

                            DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
                            DataTable dtAuditCls = objEmpAuditCls.CheckAuditClosingDate(objEntityAudit);
                            if (dtAccntCls.Rows.Count > 0 || dtAuditCls.Rows.Count > 0)
                            {
                                DataTable dtRefFormat1 = ReadRefNumberByDate(objEntityLayerStock1);
                                if (dtRefFormat1.Rows.Count > 0)
                                {
                                    string strRef = "";
                                    if (dtRefFormat1.Rows[0]["DR_NOTE_REF_NXT_SUBNUM"].ToString() != "")
                                    {

                                        if (Convert.ToInt32(dtRefFormat1.Rows[0]["DR_NOTE_REF_NXT_SUBNUM"].ToString()) != 1)
                                        {
                                            strRef = dtRefFormat1.Rows[0]["DR_NOTE_REF"].ToString();
                                            strRef = strRef.TrimEnd('/');
                                            strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                        }
                                        else
                                        {
                                            strRef = dtRefFormat1.Rows[0]["DR_NOTE_REF"].ToString();
                                        }
                                    }
                                    else
                                    {
                                        strRef = dtRefFormat1.Rows[0]["DR_NOTE_REF"].ToString();
                                    }
                                    objEntityLayerStock1.Reference_Num = strRef;
                                    DataTable dtRefFormat = ReadRefNumberByDateLast(objEntityLayerStock1);
                                    if (dtRefFormat.Rows.Count > 0)
                                    {
                                        Ref = dtRefFormat.Rows[0]["DR_NOTE_REF"].ToString();
                                        if (dtRefFormat.Rows[0]["DR_NOTE_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["DR_NOTE_REF_NXT_SUBNUM"].ToString() != null)
                                        {
                                            SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["DR_NOTE_REF_NXT_SUBNUM"].ToString());
                                            objEntityCreditNote.RefSeqNo = Convert.ToInt32(dtRefFormat.Rows[0]["DR_NOTE_REF_NXT_SUBNUM"].ToString());
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
                                        objEntityCreditNote.Reference_Num = Ref;
                                        SubRef++;
                                    }
                                }
                            }
                        }


                        cmdAddService.CommandText = strQueryLeaveTyp;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCreditNote.Debit_Id;
                        cmdAddService.Parameters.Add("C_REF", OracleDbType.Varchar2).Value = objEntityCreditNote.Reference_Num;
                        cmdAddService.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityCreditNote.Debit_Date;
                        // cmdAddService.Parameters.Add("J_CURRID", OracleDbType.Int32).Value = objEntityCreditNote.CurrencyId;
                        cmdAddService.Parameters.Add("C_DESC", OracleDbType.Varchar2).Value = objEntityCreditNote.Description;
                        cmdAddService.Parameters.Add("C_AMNT", OracleDbType.Decimal).Value = objEntityCreditNote.Debit_Total;
                        cmdAddService.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCreditNote.Organisation_id;
                        cmdAddService.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCreditNote.Corporate_id;
                        cmdAddService.Parameters.Add("C_USRID", OracleDbType.Int32).Value = objEntityCreditNote.User_Id;
                        cmdAddService.Parameters.Add("J_SUBREFID", OracleDbType.Int32).Value = SubRef;
                        cmdAddService.Parameters.Add("J_CURRID", OracleDbType.Int32).Value = objEntityCreditNote.CurrencyId;
                        cmdAddService.Parameters.Add("J_REFNEXTSEQ", OracleDbType.Int32).Value = objEntityCreditNote.RefSeqNo;

                        cmdAddService.ExecuteNonQuery();
                    }

                    foreach (clsEntity_Debit_Note objDetail in objEntitylLedgrList)
                    {
                        string strQueryInsertDetails = "FMS_DEBIT_NOTE.SP_INS_LEDGR_DTL";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCreditNote.Debit_Id;
                            cmdAddInsertDetail.Parameters.Add("C_LEDGRID", OracleDbType.Int32).Value = objDetail.LedgerId;
                            cmdAddInsertDetail.Parameters.Add("C_AMNT", OracleDbType.Decimal).Value = objDetail.Ledger_Amount;
                            cmdAddInsertDetail.Parameters.Add("C_STS", OracleDbType.Int32).Value = objDetail.Credit_debit_Status;
                            cmdAddInsertDetail.Parameters.Add("C_LDGR_REMARKS", OracleDbType.Varchar2).Value = objDetail.Remarks;
                            cmdAddInsertDetail.Parameters.Add("C_LID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                            cmdAddInsertDetail.ExecuteNonQuery();
                            string strReturn = cmdAddInsertDetail.Parameters["C_LID"].Value.ToString();


                            foreach (clsEntity_Debit_Note objDetailSub in objEntityCostcentrList)
                            {

                                if (objDetail.Ledger_Debit_Id == objDetailSub.Ledger_Debit_Id)
                                {
                                    string strQueryInsertDetailsub = "FMS_DEBIT_NOTE.SP_INS_COSTCNTR_DTL";
                                    using (OracleCommand cmdAddInsertDetailS = new OracleCommand(strQueryInsertDetailsub, con))
                                    {
                                        cmdAddInsertDetailS.Transaction = tran;
                                        cmdAddInsertDetailS.CommandType = CommandType.StoredProcedure;
                                        cmdAddInsertDetailS.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCreditNote.Debit_Id;
                                        cmdAddInsertDetailS.Parameters.Add("C_LEDGRID", OracleDbType.Int32).Value = Convert.ToInt32(strReturn);
                                        cmdAddInsertDetailS.Parameters.Add("C_COSTCENTRID", OracleDbType.Int32).Value = objDetailSub.Cost_Centre_Id;
                                        cmdAddInsertDetailS.Parameters.Add("C_AMNT", OracleDbType.Decimal).Value = objDetailSub.Cost_Centre_Amt;
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

                                        cmdAddInsertDetailS.ExecuteNonQuery();
                                    }
                                }
                            }
                            foreach (clsEntity_Debit_Note objDetailSub in objEntitySaleList)
                            {

                                if (objDetail.Ledger_Debit_Id == objDetailSub.Ledger_Debit_Id)
                                {
                                    string strQueryInsertDetailsub = "FMS_DEBIT_NOTE.SP_INS_PURCHASE_DTL";
                                    using (OracleCommand cmdAddInsertDetailS = new OracleCommand(strQueryInsertDetailsub, con))
                                    {
                                        cmdAddInsertDetailS.Transaction = tran;
                                        cmdAddInsertDetailS.CommandType = CommandType.StoredProcedure;
                                        cmdAddInsertDetailS.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCreditNote.Debit_Id;
                                        cmdAddInsertDetailS.Parameters.Add("C_LEDGRID", OracleDbType.Int32).Value = Convert.ToInt32(strReturn);
                                        cmdAddInsertDetailS.Parameters.Add("C_SALEID", OracleDbType.Int32).Value = objDetailSub.Cost_Centre_Id;
                                        cmdAddInsertDetailS.Parameters.Add("C_AMNT", OracleDbType.Decimal).Value = objDetailSub.Cost_Centre_Amt;
                                        cmdAddInsertDetailS.Parameters.Add("C_PRCHS_SETTLE_AMNT", OracleDbType.Decimal).Value = objDetailSub.SalesRefSettleAmnt;
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
        public DataTable ReadCreditNoteList(clsEntity_Debit_Note objEntityCreditNote)
        {
            string strQueryReadEmpSlry = "FMS_DEBIT_NOTE.SP_READ_DEBIT_NOTE_LIST";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCreditNote.Organisation_id;
            cmdReadPayGrd.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCreditNote.Corporate_id;
            cmdReadPayGrd.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCreditNote.Debit_Id;
            cmdReadPayGrd.Parameters.Add("C_CNCL_STS", OracleDbType.Int32).Value = objEntityCreditNote.ConfirmStatus;
            cmdReadPayGrd.Parameters.Add("C_FROM_DATE", OracleDbType.Date).Value = objEntityCreditNote.Date_From;
            cmdReadPayGrd.Parameters.Add("C_TO_DATE", OracleDbType.Date).Value = objEntityCreditNote.Date_To;
            if (objEntityCreditNote.Date_From_FY == DateTime.MinValue)
            {
                cmdReadPayGrd.Parameters.Add("C_FROM_PERIOD", OracleDbType.Date).Value = null;
            }
            else
                cmdReadPayGrd.Parameters.Add("C_FROM_PERIOD", OracleDbType.Date).Value = objEntityCreditNote.Date_From_FY;
            if (objEntityCreditNote.Date_To_FY == DateTime.MinValue)
                cmdReadPayGrd.Parameters.Add("C_TO_PERIOD", OracleDbType.Date).Value = null;
            else
                cmdReadPayGrd.Parameters.Add("C_TO_PERIOD", OracleDbType.Date).Value = objEntityCreditNote.Date_To_FY;
            cmdReadPayGrd.Parameters.Add("C_STS", OracleDbType.Int32).Value = objEntityCreditNote.Status;
            cmdReadPayGrd.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
        public DataTable ReadCreditNote_By_ID(clsEntity_Debit_Note objEntityCreditNote)
        {
            string strQueryReadEmpSlry = "FMS_DEBIT_NOTE.SP_READ_DEBIT_NOTE_ID";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCreditNote.Organisation_id;
            cmdReadPayGrd.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCreditNote.Corporate_id;
            cmdReadPayGrd.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCreditNote.Debit_Id;
            cmdReadPayGrd.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
        public DataTable ReadCreditNote_Ledger_By_ID(clsEntity_Debit_Note objEntityCreditNote)
        {
            string strQueryReadEmpSlry = "FMS_DEBIT_NOTE.SP_READ_DEBIT_NOTE_LEDGER_ID";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCreditNote.Corporate_id;
            cmdReadPayGrd.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCreditNote.Debit_Id;
            cmdReadPayGrd.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
        //public DataTable ReadCreditNote_Ledger_Cost_By_ID(clsEntity_Debit_Note objEntityCreditNote)
        //{
        //    string strQueryReadEmpSlry = "FMS_DEBIT_NOTE.SP_READ_CREDIT_COST_CENTRE_ID";
        //    OracleCommand cmdReadPayGrd = new OracleCommand();
        //    cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
        //    cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
        //    cmdReadPayGrd.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCreditNote.Debit_Id;
        //    cmdReadPayGrd.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityCreditNote.Ledger_Debit_Id;
        //    cmdReadPayGrd.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCreditNote.Corporate_id;
        //    cmdReadPayGrd.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
        //    DataTable dtEmpSlry = new DataTable();
        //    dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
        //    return dtEmpSlry;
        //}
        public DataTable ReadLedgrBalance(clsEntity_Debit_Note objEntityCreditNote)
        {
            string strQueryReadEmpSlry = "FMS_DEBIT_NOTE.SP_READ_LEDGR_BAL_DTLS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityCreditNote.LedgerId;
            cmdReadPayGrd.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
        public void UpdateCredit_Note(clsEntity_Debit_Note ObjEntityCredit, List<clsEntity_Debit_Note> objEntityLedgerIns, List<clsEntity_Debit_Note> objEntityLedgerDel, List<clsEntity_Debit_Note> objEntityCostCenterIns, List<clsEntity_Debit_Note> objEntitySaleList)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "FMS_DEBIT_NOTE.SP_UPD_DEBIT_NOTE_MSTR";
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
                        string Ref = ""; int SubRef = 1;

                        if (ObjEntityCredit.Debit_Date != ObjEntityCredit.UpdCredit_date)
                        {
                            clsCommonLibrary objCommon = new clsCommonLibrary();
                            clsEntityCommon objEntCommon = new clsEntityCommon();
                            objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.DEBIT_NOTE);
                            objEntCommon.CorporateID = ObjEntityCredit.Corporate_id;
                            string strNextId = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                            // ObjEntityCredit.Debit_Id = Convert.ToInt32(strNextId);
                            //CHECKING FOR CORP GLOBAL SUB REF STATUS
                            int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intCorpId = 0; string strRefAccountCls = "0";
                            intCorpId = ObjEntityCredit.Corporate_id;
                            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Debit_Note);
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
                            int intOrgId = ObjEntityCredit.Organisation_id;
                            int intUsrId = ObjEntityCredit.User_Id;
                          //  objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Debit_Note);
                            DataTable dtFormate = readRefFormate(objEntCommon);
                            clsDataLayerDateAndTime objDataLayerDateTime = new clsDataLayerDateAndTime();
                            string CurrentDate = objDataLayerDateTime.DateAndTime().ToString("dd-MM-yyyy");
                            DateTime dtCurrentDate = objCommon.textToDateTime(CurrentDate);
                            int DtYear = dtCurrentDate.Year;
                            int DtMonth = dtCurrentDate.Month;
                            //CHECKING SUB REF NUMBER
                            if (strRefAccountCls == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                            {
                                clsDataLayer_Account_Close objEmpAccntCls = new clsDataLayer_Account_Close();
                                clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
                                clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
                                clsDataLayer_Audit_Closing objEmpAuditCls = new clsDataLayer_Audit_Closing();

                                objEntityAccnt.FromDate = ObjEntityCredit.Debit_Date;
                                clsEntity_Debit_Note objEntityLayerStock1 = new clsEntity_Debit_Note();
                                objEntityLayerStock1.Date_From = ObjEntityCredit.Debit_Date;
                                objEntityAccnt.Corporate_id = intCorpId;
                                objEntityLayerStock1.Corporate_id = intCorpId;
                                objEntityAccnt.Organisation_id = intOrgId;
                                objEntityLayerStock1.Organisation_id = intOrgId;

                                objEntityAccnt.Corporate_id = intCorpId;
                                objEntityAudit.FromDate = ObjEntityCredit.Debit_Date;
                                objEntityAccnt.Organisation_id = intOrgId;

                                DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
                                DataTable dtAuditCls = objEmpAuditCls.CheckAuditClosingDate(objEntityAudit);
                                if (dtAccntCls.Rows.Count > 0 || dtAuditCls.Rows.Count > 0)
                                {
                                    DataTable dtRefFormat1 = ReadRefNumberByDate(objEntityLayerStock1);
                                    if (dtRefFormat1.Rows.Count > 0)
                                    {
                                        string strRef = "";
                                        if (dtRefFormat1.Rows[0]["DR_NOTE_REF_NXT_SUBNUM"].ToString() != "")
                                        {

                                            if (Convert.ToInt32(dtRefFormat1.Rows[0]["DR_NOTE_REF_NXT_SUBNUM"].ToString()) != 1)
                                            {
                                                strRef = dtRefFormat1.Rows[0]["DR_NOTE_REF"].ToString();
                                                strRef = strRef.TrimEnd('/');
                                                strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                            }
                                            else
                                            {
                                                strRef = dtRefFormat1.Rows[0]["DR_NOTE_REF"].ToString();
                                            }
                                        }
                                        else
                                        {
                                            strRef = dtRefFormat1.Rows[0]["DR_NOTE_REF"].ToString();
                                        }
                                        objEntityLayerStock1.Reference_Num = strRef;
                                        DataTable dtRefFormat = ReadRefNumberByDateLast(objEntityLayerStock1);
                                        if (dtRefFormat.Rows.Count > 0)
                                        {
                                            if (ObjEntityCredit.Debit_Id != Convert.ToInt32(dtRefFormat.Rows[0]["DEBIT_NOTE_ID"].ToString()))
                                            {
                                                Ref = dtRefFormat.Rows[0]["DR_NOTE_REF"].ToString();
                                                if (dtRefFormat.Rows[0]["DR_NOTE_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["DR_NOTE_REF_NXT_SUBNUM"].ToString() != null)
                                                {
                                                    SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["DR_NOTE_REF_NXT_SUBNUM"].ToString());
                                                    ObjEntityCredit.RefSeqNo = Convert.ToInt32(dtRefFormat.Rows[0]["DR_NOTE_REF_NXT_SUBNUM"].ToString());
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
                                                ObjEntityCredit.Reference_Num = Ref;
                                                SubRef++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.Parameters.Add("P_PID", OracleDbType.Int32).Value = ObjEntityCredit.Debit_Id;
                        cmdAddService.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = ObjEntityCredit.Reference_Num;
                        cmdAddService.Parameters.Add("P_DATE", OracleDbType.Date).Value = ObjEntityCredit.Debit_Date;
                        cmdAddService.Parameters.Add("P_TOTALAMT", OracleDbType.Decimal).Value = ObjEntityCredit.Debit_Total;
                        cmdAddService.Parameters.Add("P_DESRTN", OracleDbType.Varchar2).Value = ObjEntityCredit.Description;
                        cmdAddService.Parameters.Add("P_USRID", OracleDbType.Int32).Value = ObjEntityCredit.User_Id;
                        cmdAddService.Parameters.Add("P_STS", OracleDbType.Int32).Value = ObjEntityCredit.ConfirmStatus;
                        cmdAddService.Parameters.Add("J_SUBREFID", OracleDbType.Int32).Value = SubRef;
                        cmdAddService.Parameters.Add("J_CURRID", OracleDbType.Int32).Value = ObjEntityCredit.CurrencyId;
                        cmdAddService.Parameters.Add("J_REFNEXTSEQ", OracleDbType.Int32).Value = ObjEntityCredit.RefSeqNo;

                        cmdAddService.ExecuteNonQuery();
                    }
                    foreach (clsEntity_Debit_Note objDetail in objEntityLedgerIns)
                    {
                        string StrCpyLedgerId = "";
                        string strQueryInsertDetails = "FMS_DEBIT_NOTE.SP_INS_LEDGR_DTL";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("C_ID", OracleDbType.Int32).Value = ObjEntityCredit.Debit_Id;
                            cmdAddInsertDetail.Parameters.Add("C_LEDGRID", OracleDbType.Int32).Value = objDetail.LedgerId;
                            cmdAddInsertDetail.Parameters.Add("C_AMNT", OracleDbType.Decimal).Value = objDetail.Ledger_Amount;
                            cmdAddInsertDetail.Parameters.Add("C_STS", OracleDbType.Int32).Value = objDetail.Credit_debit_Status;
                            cmdAddInsertDetail.Parameters.Add("C_LDGR_REMARKS", OracleDbType.Varchar2).Value = objDetail.Remarks;
                            cmdAddInsertDetail.Parameters.Add("C_LID", OracleDbType.Int32).Direction = ParameterDirection.Output;

                            cmdAddInsertDetail.ExecuteNonQuery();
                            string strReturn = cmdAddInsertDetail.Parameters["C_LID"].Value.ToString();
                            if (ObjEntityCredit.ConfirmStatus == 1)
                            {
                                string strQueryUpdateLedger = "FMS_DEBIT_NOTE.SP_UPDATE_LEDGER_MASTR";
                                using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryUpdateLedger, con))
                                {
                                    cmdAddSubDetail.Transaction = tran;
                                    cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                    cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetail.LedgerId;
                                    cmdAddSubDetail.Parameters.Add("C_STS", OracleDbType.Int32).Value = objDetail.Credit_debit_Status;
                                    cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = objDetail.Ledger_Amount;
                                    cmdAddSubDetail.ExecuteNonQuery();
                                }
                                string strQueryInsertVoucher = "FMS_DEBIT_NOTE.SP_INS_VOUCHER_ACCOUNT";
                                using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucher, con))
                                {
                                    cmdAddVoucher.Transaction = tran;
                                    cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                    cmdAddVoucher.Parameters.Add("P_PID", OracleDbType.Int32).Value = ObjEntityCredit.Debit_Id;
                                    cmdAddVoucher.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = ObjEntityCredit.Reference_Num;
                                    cmdAddVoucher.Parameters.Add("P_DATE", OracleDbType.Date).Value = ObjEntityCredit.Debit_Date;
                                    cmdAddVoucher.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetail.LedgerId;
                                    StrCpyLedgerId = Convert.ToString(objDetail.LedgerId);
                                    cmdAddVoucher.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = objDetail.Ledger_Amount;
                                    cmdAddVoucher.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = ObjEntityCredit.Organisation_id;
                                    cmdAddVoucher.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = ObjEntityCredit.Corporate_id;
                                    if (objDetail.Credit_debit_Status == 0)
                                    {
                                        cmdAddVoucher.Parameters.Add("P_VOCHR", OracleDbType.Int32).Value = 0;
                                    }
                                    else
                                    {
                                        cmdAddVoucher.Parameters.Add("P_VOCHR", OracleDbType.Int32).Value = 1;
                                    }
                                    cmdAddVoucher.Parameters.Add("P_DESC", OracleDbType.Varchar2).Value = ObjEntityCredit.Description;
                                    cmdAddVoucher.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = ObjEntityCredit.FinancialYrId;

                                    cmdAddVoucher.Parameters.Add("L_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;

                                    cmdAddVoucher.ExecuteNonQuery();
                                    string strReturnId = cmdAddVoucher.Parameters["L_ID"].Value.ToString();
                                    cmdAddVoucher.Dispose();
                                    ObjEntityCredit.VoucherID = Convert.ToInt32(strReturnId);
                                }

                                //-------------------------Debit-----------------------------------
                                if (objDetail.Credit_debit_Status == 0)
                                {
                                    //One credit field
                                    if (ObjEntityCredit.CreditCount == 1)
                                    {
                                        foreach (clsEntity_Debit_Note objDetailSub1 in objEntityLedgerIns)
                                        {
                                            if (Convert.ToInt32(StrCpyLedgerId) != objDetailSub1.LedgerId)
                                            {
                                                //get Credit field
                                                if (objDetailSub1.Credit_debit_Status == 1)
                                                {
                                                    string strQuerySubDetailsCost = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                                                    using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                                                    {
                                                        cmdAddSubDetail.Transaction = tran;
                                                        cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                        cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetailSub1.LedgerId;
                                                        cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = ObjEntityCredit.VoucherID;
                                                        cmdAddSubDetail.ExecuteNonQuery();

                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else //multiple credit field
                                    {
                                        //One debit field
                                        if (ObjEntityCredit.DebitCount == 1)
                                        {
                                            foreach (clsEntity_Debit_Note objDetailSub1 in objEntityLedgerIns)
                                            {
                                                if (Convert.ToInt32(StrCpyLedgerId) != objDetailSub1.LedgerId)
                                                {
                                                    string strQuerySubDetailsCost = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                                                    using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                                                    {
                                                        cmdAddSubDetail.Transaction = tran;
                                                        cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                        cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetailSub1.LedgerId;
                                                        cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = ObjEntityCredit.VoucherID;
                                                        cmdAddSubDetail.ExecuteNonQuery();
                                                    }
                                                }
                                            }
                                        }
                                        else //multiple debit field
                                        {
                                            foreach (clsEntity_Debit_Note objDetailSub1 in objEntityLedgerIns)
                                            {
                                                if (Convert.ToInt32(StrCpyLedgerId) == objDetailSub1.LedgerId)
                                                {
                                                    string strQuerySubDetailsCost = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                                                    using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                                                    {
                                                        cmdAddSubDetail.Transaction = tran;
                                                        cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                        cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetailSub1.LedgerId;
                                                        cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = ObjEntityCredit.VoucherID;
                                                        cmdAddSubDetail.ExecuteNonQuery();
                                                    }
                                                }
                                            }
                                        }

                                    }
                                }
                                //----------------------------Credit------------------------------
                                else if (objDetail.Credit_debit_Status == 1)
                                {
                                    //One debit field
                                    if (ObjEntityCredit.DebitCount == 1)
                                    {
                                        foreach (clsEntity_Debit_Note objDetailSub1 in objEntityLedgerIns)
                                        {
                                            if (Convert.ToInt32(StrCpyLedgerId) != objDetailSub1.LedgerId)
                                            {
                                                //Get Debit field
                                                if (objDetailSub1.Credit_debit_Status == 0)
                                                {
                                                    string strQuerySubDetailsCost = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                                                    using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                                                    {
                                                        cmdAddSubDetail.Transaction = tran;
                                                        cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                        cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetailSub1.LedgerId;
                                                        cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = ObjEntityCredit.VoucherID;
                                                        cmdAddSubDetail.ExecuteNonQuery();

                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else //multiple debit field
                                    {
                                        //One credit field
                                        if (ObjEntityCredit.CreditCount == 1)
                                        {
                                            foreach (clsEntity_Debit_Note objDetailSub1 in objEntityLedgerIns)
                                            {
                                                if (Convert.ToInt32(StrCpyLedgerId) != objDetailSub1.LedgerId)
                                                {
                                                    string strQuerySubDetailsCost = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                                                    using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                                                    {
                                                        cmdAddSubDetail.Transaction = tran;
                                                        cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                        cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetailSub1.LedgerId;
                                                        cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = ObjEntityCredit.VoucherID;
                                                        cmdAddSubDetail.ExecuteNonQuery();
                                                    }
                                                }
                                            }
                                        }
                                        else //multiple credit field
                                        {
                                            foreach (clsEntity_Debit_Note objDetailSub1 in objEntityLedgerIns)
                                            {
                                                if (Convert.ToInt32(StrCpyLedgerId) == objDetailSub1.LedgerId)
                                                {
                                                    string strQuerySubDetailsCost = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                                                    using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                                                    {
                                                        cmdAddSubDetail.Transaction = tran;
                                                        cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                        cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetailSub1.LedgerId;
                                                        cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = ObjEntityCredit.VoucherID;
                                                        cmdAddSubDetail.ExecuteNonQuery();
                                                    }
                                                }
                                            }
                                        }

                                    }
                                }
                            }

                            foreach (clsEntity_Debit_Note objDetailSub in objEntityCostCenterIns)
                            {

                                if (objDetail.Ledger_Debit_Id == objDetailSub.Ledger_Debit_Id)
                                {
                                    string strQueryInsertDetailsub = "FMS_DEBIT_NOTE.SP_INS_COSTCNTR_DTL";
                                    using (OracleCommand cmdAddInsertDetailS = new OracleCommand(strQueryInsertDetailsub, con))
                                    {
                                        cmdAddInsertDetailS.Transaction = tran;
                                        cmdAddInsertDetailS.CommandType = CommandType.StoredProcedure;
                                        cmdAddInsertDetailS.Parameters.Add("C_ID", OracleDbType.Int32).Value = ObjEntityCredit.Debit_Id;
                                        cmdAddInsertDetailS.Parameters.Add("C_LEDGRID", OracleDbType.Int32).Value = Convert.ToInt32(strReturn);
                                        cmdAddInsertDetailS.Parameters.Add("C_COSTCENTRID", OracleDbType.Int32).Value = objDetailSub.Cost_Centre_Id;
                                        cmdAddInsertDetailS.Parameters.Add("C_AMNT", OracleDbType.Decimal).Value = objDetailSub.Cost_Centre_Amt;
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
                                        cmdAddInsertDetailS.ExecuteNonQuery();
                                    }
                                    if (ObjEntityCredit.ConfirmStatus == 1)
                                    {
                                        string strQueryInsertVoucher = "FMS_COMMON.SP_INS_CSTCNTR_VOUCHER_ACCOUNT";
                                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                                        {
                                            if (objDetailSub.Cost_Centre_Id != 0)
                                            {
                                                cmdAddSubDetail.Transaction = tran;
                                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                cmdAddSubDetail.Parameters.Add("P_PID", OracleDbType.Int32).Value = ObjEntityCredit.Debit_Id;
                                                cmdAddSubDetail.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = ObjEntityCredit.Reference_Num;
                                                cmdAddSubDetail.Parameters.Add("P_DATE", OracleDbType.Date).Value = ObjEntityCredit.Debit_Date;
                                                cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetail.LedgerId;
                                                cmdAddSubDetail.Parameters.Add("P_COST_CNTR_ID", OracleDbType.Int32).Value = objDetailSub.Cost_Centre_Id;
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
                                                cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = objDetailSub.Cost_Centre_Amt;
                                                cmdAddSubDetail.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = ObjEntityCredit.Organisation_id;
                                                cmdAddSubDetail.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = ObjEntityCredit.Corporate_id;
                                                cmdAddSubDetail.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = ObjEntityCredit.FinancialYrId;
                                                if (objDetail.Credit_debit_Status == 0)
                                                {
                                                    cmdAddSubDetail.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 0;
                                                }
                                                else
                                                {
                                                    cmdAddSubDetail.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 1;
                                                }
                                                cmdAddSubDetail.Parameters.Add("P_CRNC_MST_ID", OracleDbType.Int32).Value = ObjEntityCredit.CurrencyId;
                                                cmdAddSubDetail.Parameters.Add("P_VOCHR_TYPE", OracleDbType.Int32).Value = 4;
                                                cmdAddSubDetail.Parameters.Add("P_VOCHR_ID", OracleDbType.Int32).Value = ObjEntityCredit.VoucherID;

                                                cmdAddSubDetail.ExecuteNonQuery();
                                            }
                                        }
                                       
                                    }
                                }
                            }
                            foreach (clsEntity_Debit_Note objDetailSub in objEntitySaleList)
                            {

                                if (objDetail.Ledger_Debit_Id == objDetailSub.Ledger_Debit_Id)
                                {
                                    string strQueryInsertDetailsub = "FMS_DEBIT_NOTE.SP_INS_PURCHASE_DTL";
                                    using (OracleCommand cmdAddInsertDetailS = new OracleCommand(strQueryInsertDetailsub, con))
                                    {
                                        cmdAddInsertDetailS.Transaction = tran;
                                        cmdAddInsertDetailS.CommandType = CommandType.StoredProcedure;
                                        cmdAddInsertDetailS.Parameters.Add("C_ID", OracleDbType.Int32).Value = ObjEntityCredit.Debit_Id;
                                        cmdAddInsertDetailS.Parameters.Add("C_LEDGRID", OracleDbType.Int32).Value = Convert.ToInt32(strReturn);
                                        cmdAddInsertDetailS.Parameters.Add("C_SALEID", OracleDbType.Int32).Value = objDetailSub.Cost_Centre_Id;
                                        cmdAddInsertDetailS.Parameters.Add("C_AMNT", OracleDbType.Decimal).Value = objDetailSub.Cost_Centre_Amt;
                                        cmdAddInsertDetailS.Parameters.Add("C_PRCHS_SETTLE_AMNT", OracleDbType.Decimal).Value = objDetailSub.SalesRefSettleAmnt;
                                        cmdAddInsertDetailS.ExecuteNonQuery();
                                    }

                                    if (ObjEntityCredit.ConfirmStatus == 1)
                                    {
                                        string strQuerySubSalesUpdate = "FMS_DEBIT_NOTE.SP_UPDATE_PURCHSE_BALANCE";
                                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubSalesUpdate, con))
                                        {
                                            cmdAddSubDetail.Transaction = tran;
                                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                            if (objDetailSub.Cost_Centre_Id != 0)
                                            {
                                                cmdAddSubDetail.Parameters.Add("C_SALEID", OracleDbType.Int32).Value = objDetailSub.Cost_Centre_Id;
                                            }
                                            cmdAddSubDetail.Parameters.Add("C_AMNT", OracleDbType.Decimal).Value = objDetailSub.Cost_Centre_Amt;
                                            cmdAddSubDetail.Parameters.Add("C_PRCHS_SETTLE_AMNT", OracleDbType.Decimal).Value = objDetailSub.SalesRefSettleAmnt;
                                            cmdAddSubDetail.ExecuteNonQuery();
                                        }
                                        if (objDetailSub.Cost_Centre_Id != 0)
                                        {
                                            //Debit note settlement
                                            if (objDetailSub.Cost_Centre_Amt != 0)
                                            {
                                                string strQueryInsertVoucherSettleDtls = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";  //Add settle amount details
                                                using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherSettleDtls, con))
                                                {
                                                    cmdAddVoucher.Transaction = tran;
                                                    cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                                    cmdAddVoucher.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = ObjEntityCredit.VoucherID;
                                                    cmdAddVoucher.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = objDetail.LedgerId;
                                                    cmdAddVoucher.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = objDetailSub.Cost_Centre_Amt;
                                                    cmdAddVoucher.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 3;
                                                    cmdAddVoucher.Parameters.Add("C_USRID", OracleDbType.Int32).Value = ObjEntityCredit.User_Id;
                                                    cmdAddVoucher.Parameters.Add("C_SALID", OracleDbType.Int32).Value = objDetailSub.Cost_Centre_Id;
                                                    cmdAddVoucher.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = ObjEntityCredit.Debit_Id;
                                                    cmdAddVoucher.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = objDetailSub.PurchaseActAmount;
                                                    cmdAddVoucher.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = objDetail.Ledger_Debit_Id;
                                                    cmdAddVoucher.ExecuteNonQuery();
                                                }
                                            }
                                            //Purchase settlement
                                            if (objDetailSub.SalesRefSettleAmnt != 0)
                                            {
                                                string strQueryInsertVoucherSettleDtls = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";  //Add settle amount details
                                                using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherSettleDtls, con))
                                                {
                                                    cmdAddVoucher.Transaction = tran;
                                                    cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                                    cmdAddVoucher.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = ObjEntityCredit.VoucherID;
                                                    cmdAddVoucher.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = objDetail.LedgerId;
                                                    cmdAddVoucher.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = objDetailSub.SalesRefSettleAmnt;
                                                    cmdAddVoucher.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 1;
                                                    cmdAddVoucher.Parameters.Add("C_USRID", OracleDbType.Int32).Value = ObjEntityCredit.User_Id;
                                                    cmdAddVoucher.Parameters.Add("C_SALID", OracleDbType.Int32).Value = objDetailSub.Cost_Centre_Id;
                                                    cmdAddVoucher.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = ObjEntityCredit.Debit_Id;
                                                    cmdAddVoucher.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = objDetailSub.BeforeSalesRefAmt;
                                                    cmdAddVoucher.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = objDetail.Ledger_Debit_Id;
                                                    cmdAddVoucher.ExecuteNonQuery();
                                                }
                                            }

                                        }
                                    }

                                }
                            }
                        }
                    }

                    //foreach (clsEntity_Debit_Note ObjEntityLdgrupdate in objEntityLedgerUpd)
                    //{
                    //    string StrCpyLedgerId = "";
                    //    if (ObjEntityLdgrupdate.LedgerId != 0)
                    //    {
                    //        string strQueryledger = "FMS_DEBIT_NOTE.SP_UPDATE_DEBIT_NOTE_LEDGER";
                    //        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryledger, con))
                    //        {
                    //            cmdAddSubDetail.Transaction = tran;
                    //            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                    //            cmdAddSubDetail.Parameters.Add("R_PYMNT_ID", OracleDbType.Int32).Value = ObjEntityCredit.Debit_Id;
                    //            cmdAddSubDetail.Parameters.Add("R_PYMNT_LD_ID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.Ledger_Debit_Id;
                    //            cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.LedgerId;
                    //            cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = ObjEntityLdgrupdate.Ledger_Amount;
                    //            cmdAddSubDetail.Parameters.Add("C_STS", OracleDbType.Int32).Value = ObjEntityLdgrupdate.Credit_debit_Status;


                    //            cmdAddSubDetail.ExecuteNonQuery();
                    //        }
                    //        if (ObjEntityCredit.ConfirmStatus == 1)
                    //        {
                    //            string strQueryUpdateLedger = "FMS_DEBIT_NOTE.SP_UPDATE_LEDGER_MASTR";
                    //            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryUpdateLedger, con))
                    //            {
                    //                cmdAddSubDetail.Transaction = tran;
                    //                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                    //                cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.LedgerId;
                    //                cmdAddSubDetail.Parameters.Add("C_STS", OracleDbType.Int32).Value = ObjEntityLdgrupdate.Credit_debit_Status;
                    //                cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = ObjEntityLdgrupdate.Ledger_Amount;
                    //                cmdAddSubDetail.ExecuteNonQuery();
                    //            }
                    //            string strQueryInsertVoucher = "FMS_DEBIT_NOTE.SP_INS_VOUCHER_ACCOUNT";
                    //            using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucher, con))
                    //            {
                    //                cmdAddVoucher.Transaction = tran;
                    //                cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                    //                cmdAddVoucher.Parameters.Add("P_PID", OracleDbType.Int32).Value = ObjEntityCredit.Debit_Id;
                    //                cmdAddVoucher.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = ObjEntityCredit.Reference_Num;
                    //                cmdAddVoucher.Parameters.Add("P_DATE", OracleDbType.Date).Value = ObjEntityCredit.Debit_Date;
                    //                cmdAddVoucher.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = ObjEntityLdgrupdate.LedgerId;
                    //                StrCpyLedgerId = Convert.ToString(ObjEntityLdgrupdate.LedgerId);
                    //                cmdAddVoucher.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = ObjEntityLdgrupdate.Ledger_Amount;
                    //                cmdAddVoucher.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = ObjEntityCredit.Organisation_id;
                    //                cmdAddVoucher.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = ObjEntityCredit.Corporate_id;
                    //                if (ObjEntityLdgrupdate.Credit_debit_Status == 0)
                    //                {
                    //                    cmdAddVoucher.Parameters.Add("P_VOCHR", OracleDbType.Int32).Value = 0;
                    //                }
                    //                else
                    //                {
                    //                    cmdAddVoucher.Parameters.Add("P_VOCHR", OracleDbType.Int32).Value = 1;
                    //                }
                    //                cmdAddVoucher.Parameters.Add("P_DESC", OracleDbType.Varchar2).Value = ObjEntityCredit.Description;
                    //                cmdAddVoucher.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = ObjEntityCredit.FinancialYrId;
                    //                cmdAddVoucher.Parameters.Add("L_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                    //                cmdAddVoucher.ExecuteNonQuery();
                    //                string strReturnId = cmdAddVoucher.Parameters["L_ID"].Value.ToString();
                    //                cmdAddVoucher.Dispose();
                    //                ObjEntityCredit.VoucherID = Convert.ToInt32(strReturnId);
                    //            }
                    //            foreach (clsEntity_Debit_Note objDetailSub in objEntityLedgerUpd)
                    //            {
                    //                if (Convert.ToInt32(StrCpyLedgerId) != objDetailSub.LedgerId)
                    //                {
                    //                    string strQuerySubDetailsCost = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                    //                    using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                    //                    {
                    //                        cmdAddSubDetail.Transaction = tran;
                    //                        cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                    //                        cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetailSub.LedgerId;
                    //                        cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = ObjEntityCredit.VoucherID;
                    //                        cmdAddSubDetail.ExecuteNonQuery();

                    //                    }
                    //                }

                    //            }
                    //        }


                    //        foreach (clsEntity_Debit_Note objDetailSub in objEntityCostCenterIns)
                    //        {

                    //            if (ObjEntityLdgrupdate.Ledger_Debit_Id == objDetailSub.Ledger_Debit_Id)
                    //            {
                    //                string strQueryInsertDetailsub = "FMS_DEBIT_NOTE.SP_INS_COSTCNTR_DTL";
                    //                using (OracleCommand cmdAddInsertDetailS = new OracleCommand(strQueryInsertDetailsub, con))
                    //                {
                    //                    cmdAddInsertDetailS.Transaction = tran;
                    //                    cmdAddInsertDetailS.CommandType = CommandType.StoredProcedure;
                    //                    cmdAddInsertDetailS.Parameters.Add("C_ID", OracleDbType.Int32).Value = ObjEntityCredit.Debit_Id;
                    //                    cmdAddInsertDetailS.Parameters.Add("C_LEDGRID", OracleDbType.Int32).Value = objDetailSub.Ledger_Debit_Id;
                    //                    cmdAddInsertDetailS.Parameters.Add("C_COSTCENTRID", OracleDbType.Int32).Value = objDetailSub.Cost_Centre_Id;
                    //                    cmdAddInsertDetailS.Parameters.Add("C_AMNT", OracleDbType.Decimal).Value = objDetailSub.Cost_Centre_Amt;
                    //                    if (objDetailSub.CostGrp1Id != 0)
                    //                    {
                    //                        cmdAddInsertDetailS.Parameters.Add("R_COST_GRP_ID_ONE", OracleDbType.Int32).Value = objDetailSub.CostGrp1Id;
                    //                    }
                    //                    else
                    //                    {
                    //                        cmdAddInsertDetailS.Parameters.Add("R_COST_GRP_ID_ONE", OracleDbType.Int32).Value = null;

                    //                    }
                    //                    if (objDetailSub.CostGrp2Id != 0)
                    //                    {
                    //                        cmdAddInsertDetailS.Parameters.Add("R_COST_GRP_ID_TWO", OracleDbType.Int32).Value = objDetailSub.CostGrp2Id;
                    //                    }
                    //                    else
                    //                    {
                    //                        cmdAddInsertDetailS.Parameters.Add("R_COST_GRP_ID_TWO", OracleDbType.Int32).Value = null;

                    //                    }
                    //                    cmdAddInsertDetailS.ExecuteNonQuery();
                    //                }


                    //                if (ObjEntityCredit.ConfirmStatus == 1)
                    //                {
                    //                    string strQuerySubSalesUpdate = "FMS_DEBIT_NOTE.SP_UPDATE_COSTCNTR";
                    //                    using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubSalesUpdate, con))
                    //                    {
                    //                        cmdAddSubDetail.Transaction = tran;
                    //                        cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                    //                        if (objDetailSub.Cost_Centre_Id != 0)
                    //                        {
                    //                            cmdAddSubDetail.Parameters.Add("P_CST_CNTRID", OracleDbType.Int32).Value = objDetailSub.Cost_Centre_Id;
                    //                        }
                    //                        else
                    //                        {
                    //                            cmdAddSubDetail.Parameters.Add("P_CST_CNTRID", OracleDbType.Int32).Value = null;
                    //                        }
                    //                        cmdAddSubDetail.Parameters.Add("R_COSTCNTR_AMT", OracleDbType.Decimal).Value = objDetailSub.Cost_Centre_Amt;
                    //                        cmdAddSubDetail.ExecuteNonQuery();
                    //                    }
                    //                }
                    //            }
                    //        }
                    //    }
                    //}

                    //foreach (clsEntity_Debit_Note objSubLdgr in objEntityLedgerDel)
                    //{
                    //    {
                    //        string strQueryChangeStatus = "FMS_DEBIT_NOTE.DETETE_CREDIT_LEDGER";
                    //        using (OracleCommand cmdChangeStatus = new OracleCommand())
                    //        {
                    //            cmdChangeStatus.CommandText = strQueryChangeStatus;
                    //            cmdChangeStatus.CommandType = CommandType.StoredProcedure;
                    //            cmdChangeStatus.Parameters.Add("P_PID", OracleDbType.Int32).Value = ObjEntityCredit.Debit_Id;
                    //            cmdChangeStatus.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objSubLdgr.Ledger_Debit_Id;
                    //            cmdChangeStatus.Parameters.Add("USRID", OracleDbType.Int32).Value = objSubLdgr.User_Id;
                    //            clsDataLayer.ExecuteNonQuery(cmdChangeStatus);
                    //        }
                    //    }
                    //}

                    tran.Commit();

                }

                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;

                }
            }

        }
        public DataTable CheckCreditNoteCnclSts(clsEntity_Debit_Note ObjEntityCredit)
        {
            string strQueryReadEmpSlry = "FMS_DEBIT_NOTE.SP_CHECK_CNCL_STS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("J_ID", OracleDbType.Int32).Value = ObjEntityCredit.Debit_Id;
            cmdReadPayGrd.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
        public void CancelCreditNote(clsEntity_Debit_Note ObjEntityCredit)
        {
            string strQueryReadEmpSlry = "FMS_DEBIT_NOTE.SP_CANCEL_DEBITNOTE";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("J_ID", OracleDbType.Int32).Value = ObjEntityCredit.Debit_Id;
            cmdReadPayGrd.Parameters.Add("J_CNCL_REASON", OracleDbType.Varchar2).Value = ObjEntityCredit.CancelReason;
            cmdReadPayGrd.Parameters.Add("J_USER_ID", OracleDbType.Int32).Value = ObjEntityCredit.User_Id;
            clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
        }

        public void CreditNoteReOpenById(clsEntity_Debit_Note ObjEntityCredit, List<clsEntity_Debit_Note> objEntityLedger, List<clsEntity_Debit_Note> objEntityLedgerCostCenter)
        {
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    foreach (clsEntity_Debit_Note objSubLdgr in objEntityLedger)
                    {
                        {
                            string strQueryUpdateLedger = "FMS_DEBIT_NOTE.SP_UPD_LDGR_ACNT_REOPEN";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryUpdateLedger, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objSubLdgr.LedgerId;
                                cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = objSubLdgr.Ledger_Amount;
                                cmdAddSubDetail.Parameters.Add("C_STS", OracleDbType.Int32).Value = objSubLdgr.Credit_debit_Status;
                                cmdAddSubDetail.ExecuteNonQuery();
                            }
                        }
                    }
                    foreach (clsEntity_Debit_Note objSubDetailCost in objEntityLedgerCostCenter)
                    {
                        {
                            string strQueryUpdateLedger = "FMS_DEBIT_NOTE.SP_REOPEN_COSTCNTR";
                            using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryUpdateLedger, con))
                            {
                                cmdAddSubDetail.Transaction = tran;
                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                if (objSubDetailCost.Cost_Centre_Id != 0)
                                {
                                    cmdAddSubDetail.Parameters.Add("P_CST_CNTRID", OracleDbType.Int32).Value = objSubDetailCost.Cost_Centre_Id;
                                    cmdAddSubDetail.Parameters.Add("P_SALE_ID", OracleDbType.Int32).Value = null;
                                }
                                else
                                {
                                    cmdAddSubDetail.Parameters.Add("P_CST_CNTRID", OracleDbType.Int32).Value = null;
                                    cmdAddSubDetail.Parameters.Add("P_SALE_ID", OracleDbType.Int32).Value = objSubDetailCost.Cost_Centre_Debit_Id;

                                }
                                cmdAddSubDetail.Parameters.Add("R_COSTCNTR_AMT", OracleDbType.Decimal).Value = objSubDetailCost.Cost_Centre_Amt;
                                cmdAddSubDetail.Parameters.Add("C_PRCHS_SETTLE_AMNT", OracleDbType.Decimal).Value = objSubDetailCost.SalesRefSettleAmnt;
                                cmdAddSubDetail.ExecuteNonQuery();
                            }
                        }
                    }
                    string strQueryVoucherDel = " FMS_DEBIT_NOTE.SP_DEL_VOUCHER_ACCOUNT_REOPEN";
                    using (OracleCommand cmdPerfmncTmplt = new OracleCommand())
                    {
                        cmdPerfmncTmplt.CommandText = strQueryVoucherDel;
                        cmdPerfmncTmplt.CommandType = CommandType.StoredProcedure;
                        cmdPerfmncTmplt.Parameters.Add("P_PID", OracleDbType.Int32).Value = ObjEntityCredit.Debit_Id;
                        cmdPerfmncTmplt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = ObjEntityCredit.Organisation_id;
                        cmdPerfmncTmplt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = ObjEntityCredit.Corporate_id;
                        clsDataLayer.ExecuteNonQuery(cmdPerfmncTmplt);
                    }
                    string strQueryMemoRsnCncl = " FMS_DEBIT_NOTE.SP_CREDIT_NOTE_REOPEN";
                    using (OracleCommand cmdPerfmncTmplt = new OracleCommand())
                    {
                        cmdPerfmncTmplt.CommandText = strQueryMemoRsnCncl;
                        cmdPerfmncTmplt.CommandType = CommandType.StoredProcedure;
                        cmdPerfmncTmplt.Parameters.Add("R_PID", OracleDbType.Int32).Value = ObjEntityCredit.Debit_Id;
                        cmdPerfmncTmplt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = ObjEntityCredit.Organisation_id;
                        cmdPerfmncTmplt.Parameters.Add("R_CORP_ID", OracleDbType.Int32).Value = ObjEntityCredit.Corporate_id;
                        cmdPerfmncTmplt.Parameters.Add("R_USR_ID", OracleDbType.Int32).Value = ObjEntityCredit.User_Id;
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
        public DataTable ReadRefNumberByDate(clsEntity_Debit_Note ObjEntityDebit)
        {
            string strQueryReadCustomerLdger = "FMS_DEBIT_NOTE.SP_RD_REF_BYDATE";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("S_DATE", OracleDbType.Date).Value = ObjEntityDebit.Date_From;
            cmdReadCustomerLdger.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntityDebit.Corporate_id;
            cmdReadCustomerLdger.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntityDebit.Organisation_id;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }
        public DataTable ReadRefNumberByDateLast(clsEntity_Debit_Note ObjEntityDebit)
        {
            string strQueryReadCustomerLdger = "FMS_DEBIT_NOTE.SP_RD_REF_BYDATE_LAST";
            OracleCommand cmdReadCustomerLdger = new OracleCommand();
            cmdReadCustomerLdger.CommandText = strQueryReadCustomerLdger;
            cmdReadCustomerLdger.CommandType = CommandType.StoredProcedure;
            cmdReadCustomerLdger.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntityDebit.Corporate_id;
            cmdReadCustomerLdger.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntityDebit.Organisation_id;
            cmdReadCustomerLdger.Parameters.Add("S_REF", OracleDbType.Varchar2).Value = ObjEntityDebit.Reference_Num;
            cmdReadCustomerLdger.Parameters.Add("PR_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCustomerLdger = new DataTable();
            dtCustomerLdger = clsDataLayer.ExecuteReader(cmdReadCustomerLdger);
            return dtCustomerLdger;
        }

        public DataTable ReadCorpDtls(clsEntity_Debit_Note ObjEntityCredit)
        {
            string strQueryReadTcs = "FMS_DEBIT_NOTE.SP_READ_CORP_DTLS";
            OracleCommand cmdReadTcs = new OracleCommand();
            cmdReadTcs.CommandText = strQueryReadTcs;
            cmdReadTcs.CommandType = CommandType.StoredProcedure;
            cmdReadTcs.Parameters.Add("S_ORGID", OracleDbType.Int32).Value = ObjEntityCredit.Organisation_id;
            cmdReadTcs.Parameters.Add("S_CORPID", OracleDbType.Int32).Value = ObjEntityCredit.Corporate_id;
            cmdReadTcs.Parameters.Add("S_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadTcs);
            return dtLeav;
        }
        public DataTable ReadCreditNote_Credit(clsEntity_Debit_Note objEntityCreditNote)
        {
            string strQueryReadEmpSlry = "FMS_DEBIT_NOTE.SP_READ_DEBIT_LEDGER_CR";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCreditNote.Corporate_id;
            cmdReadPayGrd.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCreditNote.Debit_Id;
            cmdReadPayGrd.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
        public DataTable ReadCreditNote_Debit(clsEntity_Debit_Note objEntityCreditNote)
        {
            string strQueryReadEmpSlry = "FMS_DEBIT_NOTE.SP_READ_DEBIT_LEDGER_DR";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCreditNote.Corporate_id;
            cmdReadPayGrd.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCreditNote.Debit_Id;
            cmdReadPayGrd.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }


        public DataTable ReadInvoiceDtls(clsEntity_Debit_Note objEntityCreditNote)
        {
            string strQueryReadEmpSlry = "FMS_DEBIT_NOTE.SP_READ_INVOICE_DTLS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCreditNote.Corporate_id;
            cmdReadPayGrd.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCreditNote.Organisation_id;
            cmdReadPayGrd.Parameters.Add("C_CR_LED_ID", OracleDbType.Int32).Value = objEntityCreditNote.Ledger_Debit_Id;
            cmdReadPayGrd.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }

        public void ConfirmCredit_Note(clsEntity_Debit_Note ObjEntityCredit, List<clsEntity_Debit_Note> objEntityLedgerIns, List<clsEntity_Debit_Note> objEntityLedgerDel, List<clsEntity_Debit_Note> objEntityCostCenterIns, List<clsEntity_Debit_Note> objEntitySaleList)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "FMS_DEBIT_NOTE.SP_CNFRM_DEBIT_NOTE_MSTR";
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
                        string Ref = ""; int SubRef = 1;

                        if (ObjEntityCredit.Debit_Date != ObjEntityCredit.UpdCredit_date)
                        {
                            clsCommonLibrary objCommon = new clsCommonLibrary();
                            clsEntityCommon objEntCommon = new clsEntityCommon();
                            objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.DEBIT_NOTE);
                            objEntCommon.CorporateID = ObjEntityCredit.Corporate_id;
                            string strNextId = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                            // ObjEntityCredit.Debit_Id = Convert.ToInt32(strNextId);
                            //CHECKING FOR CORP GLOBAL SUB REF STATUS
                            int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intCorpId = 0; string strRefAccountCls = "0";
                            intCorpId = ObjEntityCredit.Corporate_id;
                            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Debit_Note);
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
                            int intOrgId = ObjEntityCredit.Organisation_id;
                            int intUsrId = ObjEntityCredit.User_Id;
                            //  objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Debit_Note);
                            DataTable dtFormate = readRefFormate(objEntCommon);
                            clsDataLayerDateAndTime objDataLayerDateTime = new clsDataLayerDateAndTime();
                            string CurrentDate = objDataLayerDateTime.DateAndTime().ToString("dd-MM-yyyy");
                            DateTime dtCurrentDate = objCommon.textToDateTime(CurrentDate);
                            int DtYear = dtCurrentDate.Year;
                            int DtMonth = dtCurrentDate.Month;
                            //CHECKING SUB REF NUMBER
                            if (strRefAccountCls == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                            {
                                clsDataLayer_Account_Close objEmpAccntCls = new clsDataLayer_Account_Close();
                                clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
                                clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
                                clsDataLayer_Audit_Closing objEmpAuditCls = new clsDataLayer_Audit_Closing();

                                objEntityAccnt.FromDate = ObjEntityCredit.Debit_Date;
                                clsEntity_Debit_Note objEntityLayerStock1 = new clsEntity_Debit_Note();
                                objEntityLayerStock1.Date_From = ObjEntityCredit.Debit_Date;
                                objEntityAccnt.Corporate_id = intCorpId;
                                objEntityLayerStock1.Corporate_id = intCorpId;
                                objEntityAccnt.Organisation_id = intOrgId;
                                objEntityLayerStock1.Organisation_id = intOrgId;
                                objEntityAccnt.Corporate_id = intCorpId;
                                objEntityAudit.FromDate = ObjEntityCredit.Debit_Date;
                                objEntityAccnt.Organisation_id = intOrgId;
                                DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
                                DataTable dtAuditCls = objEmpAuditCls.CheckAuditClosingDate(objEntityAudit);
                                if (dtAccntCls.Rows.Count > 0 || dtAuditCls.Rows.Count > 0)
                                {
                                    DataTable dtRefFormat1 = ReadRefNumberByDate(objEntityLayerStock1);
                                    if (dtRefFormat1.Rows.Count > 0)
                                    {
                                        string strRef = "";
                                        if (dtRefFormat1.Rows[0]["DR_NOTE_REF_NXT_SUBNUM"].ToString() != "")
                                        {

                                            if (Convert.ToInt32(dtRefFormat1.Rows[0]["DR_NOTE_REF_NXT_SUBNUM"].ToString()) != 1)
                                            {
                                                strRef = dtRefFormat1.Rows[0]["DR_NOTE_REF"].ToString();
                                                strRef = strRef.TrimEnd('/');
                                                strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                            }
                                            else
                                            {
                                                strRef = dtRefFormat1.Rows[0]["DR_NOTE_REF"].ToString();
                                            }
                                        }
                                        else
                                        {
                                            strRef = dtRefFormat1.Rows[0]["DR_NOTE_REF"].ToString();
                                        }
                                        objEntityLayerStock1.Reference_Num = strRef;
                                        DataTable dtRefFormat = ReadRefNumberByDateLast(objEntityLayerStock1);
                                        if (dtRefFormat.Rows.Count > 0)
                                        {
                                            if (ObjEntityCredit.Debit_Id != Convert.ToInt32(dtRefFormat.Rows[0]["DEBIT_NOTE_ID"].ToString()))
                                            {
                                                Ref = dtRefFormat.Rows[0]["DR_NOTE_REF"].ToString();
                                                if (dtRefFormat.Rows[0]["DR_NOTE_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["DR_NOTE_REF_NXT_SUBNUM"].ToString() != null)
                                                {
                                                    SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["DR_NOTE_REF_NXT_SUBNUM"].ToString());
                                                    ObjEntityCredit.RefSeqNo = Convert.ToInt32(dtRefFormat.Rows[0]["DR_NOTE_REF_NXT_SUBNUM"].ToString());                                                
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
                                                ObjEntityCredit.Reference_Num = Ref;
                                                SubRef++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.Parameters.Add("P_PID", OracleDbType.Int32).Value = ObjEntityCredit.Debit_Id;
                        cmdAddService.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = ObjEntityCredit.Reference_Num;
                      
                        cmdAddService.Parameters.Add("P_USRID", OracleDbType.Int32).Value = ObjEntityCredit.User_Id;
                      
                        cmdAddService.Parameters.Add("J_SUBREFID", OracleDbType.Int32).Value = SubRef;
                        cmdAddService.Parameters.Add("J_REFNEXTSEQ", OracleDbType.Int32).Value = ObjEntityCredit.RefSeqNo;

                    
                        cmdAddService.ExecuteNonQuery();
                    }
                    foreach (clsEntity_Debit_Note objDetail in objEntityLedgerIns)
                    {
                        string StrCpyLedgerId = "";
                        
                         
                            if (ObjEntityCredit.ConfirmStatus == 1)
                            {
                                string strQueryUpdateLedger = "FMS_DEBIT_NOTE.SP_UPDATE_LEDGER_MASTR";
                                using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryUpdateLedger, con))
                                {
                                    cmdAddSubDetail.Transaction = tran;
                                    cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                    cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetail.LedgerId;
                                    cmdAddSubDetail.Parameters.Add("C_STS", OracleDbType.Int32).Value = objDetail.Credit_debit_Status;
                                    cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = objDetail.Ledger_Amount;
                                    cmdAddSubDetail.ExecuteNonQuery();
                                }
                                string strQueryInsertVoucher = "FMS_DEBIT_NOTE.SP_INS_VOUCHER_ACCOUNT";
                                using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucher, con))
                                {
                                    cmdAddVoucher.Transaction = tran;
                                    cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                    cmdAddVoucher.Parameters.Add("P_PID", OracleDbType.Int32).Value = ObjEntityCredit.Debit_Id;
                                    cmdAddVoucher.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = ObjEntityCredit.Reference_Num;
                                    cmdAddVoucher.Parameters.Add("P_DATE", OracleDbType.Date).Value = ObjEntityCredit.Debit_Date;
                                    cmdAddVoucher.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetail.LedgerId;
                                    StrCpyLedgerId = Convert.ToString(objDetail.LedgerId);
                                    cmdAddVoucher.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = objDetail.Ledger_Amount;
                                    cmdAddVoucher.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = ObjEntityCredit.Organisation_id;
                                    cmdAddVoucher.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = ObjEntityCredit.Corporate_id;
                                    if (objDetail.Credit_debit_Status == 0)
                                    {
                                        cmdAddVoucher.Parameters.Add("P_VOCHR", OracleDbType.Int32).Value = 0;
                                    }
                                    else
                                    {
                                        cmdAddVoucher.Parameters.Add("P_VOCHR", OracleDbType.Int32).Value = 1;
                                    }
                                    cmdAddVoucher.Parameters.Add("P_DESC", OracleDbType.Varchar2).Value = ObjEntityCredit.Description;
                                    cmdAddVoucher.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = ObjEntityCredit.FinancialYrId;

                                    cmdAddVoucher.Parameters.Add("L_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;

                                    cmdAddVoucher.ExecuteNonQuery();
                                    string strReturnId = cmdAddVoucher.Parameters["L_ID"].Value.ToString();
                                    cmdAddVoucher.Dispose();
                                    ObjEntityCredit.VoucherID = Convert.ToInt32(strReturnId);
                                }

                                //-------------------------Debit-----------------------------------
                                if (objDetail.Credit_debit_Status == 0)
                                {
                                    //One credit field
                                    if (ObjEntityCredit.CreditCount == 1)
                                    {
                                        foreach (clsEntity_Debit_Note objDetailSub1 in objEntityLedgerIns)
                                        {
                                            if (Convert.ToInt32(StrCpyLedgerId) != objDetailSub1.LedgerId)
                                            {
                                                //get Credit field
                                                if (objDetailSub1.Credit_debit_Status == 1)
                                                {
                                                    string strQuerySubDetailsCost = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                                                    using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                                                    {
                                                        cmdAddSubDetail.Transaction = tran;
                                                        cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                        cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetailSub1.LedgerId;
                                                        cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = ObjEntityCredit.VoucherID;
                                                        cmdAddSubDetail.ExecuteNonQuery();

                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else //multiple credit field
                                    {
                                        //One debit field
                                        if (ObjEntityCredit.DebitCount == 1)
                                        {
                                            foreach (clsEntity_Debit_Note objDetailSub1 in objEntityLedgerIns)
                                            {
                                                if (Convert.ToInt32(StrCpyLedgerId) != objDetailSub1.LedgerId)
                                                {
                                                    string strQuerySubDetailsCost = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                                                    using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                                                    {
                                                        cmdAddSubDetail.Transaction = tran;
                                                        cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                        cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetailSub1.LedgerId;
                                                        cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = ObjEntityCredit.VoucherID;
                                                        cmdAddSubDetail.ExecuteNonQuery();
                                                    }
                                                }
                                            }
                                        }
                                        else //multiple debit field
                                        {
                                            foreach (clsEntity_Debit_Note objDetailSub1 in objEntityLedgerIns)
                                            {
                                                if (Convert.ToInt32(StrCpyLedgerId) == objDetailSub1.LedgerId)
                                                {
                                                    string strQuerySubDetailsCost = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                                                    using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                                                    {
                                                        cmdAddSubDetail.Transaction = tran;
                                                        cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                        cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetailSub1.LedgerId;
                                                        cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = ObjEntityCredit.VoucherID;
                                                        cmdAddSubDetail.ExecuteNonQuery();
                                                    }
                                                }
                                            }
                                        }

                                    }
                                }
                                //----------------------------Credit------------------------------
                                else if (objDetail.Credit_debit_Status == 1)
                                {
                                    //One debit field
                                    if (ObjEntityCredit.DebitCount == 1)
                                    {
                                        foreach (clsEntity_Debit_Note objDetailSub1 in objEntityLedgerIns)
                                        {
                                            if (Convert.ToInt32(StrCpyLedgerId) != objDetailSub1.LedgerId)
                                            {
                                                //Get Debit field
                                                if (objDetailSub1.Credit_debit_Status == 0)
                                                {
                                                    string strQuerySubDetailsCost = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                                                    using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                                                    {
                                                        cmdAddSubDetail.Transaction = tran;
                                                        cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                        cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetailSub1.LedgerId;
                                                        cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = ObjEntityCredit.VoucherID;
                                                        cmdAddSubDetail.ExecuteNonQuery();

                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else //multiple debit field
                                    {
                                        //One credit field
                                        if (ObjEntityCredit.CreditCount == 1)
                                        {
                                            foreach (clsEntity_Debit_Note objDetailSub1 in objEntityLedgerIns)
                                            {
                                                if (Convert.ToInt32(StrCpyLedgerId) != objDetailSub1.LedgerId)
                                                {
                                                    string strQuerySubDetailsCost = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                                                    using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                                                    {
                                                        cmdAddSubDetail.Transaction = tran;
                                                        cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                        cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetailSub1.LedgerId;
                                                        cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = ObjEntityCredit.VoucherID;
                                                        cmdAddSubDetail.ExecuteNonQuery();
                                                    }
                                                }
                                            }
                                        }
                                        else //multiple credit field
                                        {
                                            foreach (clsEntity_Debit_Note objDetailSub1 in objEntityLedgerIns)
                                            {
                                                if (Convert.ToInt32(StrCpyLedgerId) == objDetailSub1.LedgerId)
                                                {
                                                    string strQuerySubDetailsCost = "FMS_COMMON.SP_INS_VOUCHER_ACCOUNT_DTLS";
                                                    using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                                                    {
                                                        cmdAddSubDetail.Transaction = tran;
                                                        cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                        cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetailSub1.LedgerId;
                                                        cmdAddSubDetail.Parameters.Add("R_VCH_ID", OracleDbType.Int32).Value = ObjEntityCredit.VoucherID;
                                                        cmdAddSubDetail.ExecuteNonQuery();
                                                    }
                                                }
                                            }
                                        }

                                    }
                                }
                            }


                            foreach (clsEntity_Debit_Note objDetailSub in objEntityCostCenterIns)
                            {

                                if (objDetail.Ledger_Debit_Id == objDetailSub.Ledger_Debit_Id)
                                {
                                  
                                    if (ObjEntityCredit.ConfirmStatus == 1)
                                    {
                                        string strQueryInsertVoucher = "FMS_COMMON.SP_INS_CSTCNTR_VOUCHER_ACCOUNT";
                                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQueryInsertVoucher, con))
                                        {
                                            if (objDetailSub.Cost_Centre_Id != 0)
                                            {
                                                cmdAddSubDetail.Transaction = tran;
                                                cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                                cmdAddSubDetail.Parameters.Add("P_PID", OracleDbType.Int32).Value = ObjEntityCredit.Debit_Id;
                                                cmdAddSubDetail.Parameters.Add("P_REF", OracleDbType.Varchar2).Value = ObjEntityCredit.Reference_Num;
                                                cmdAddSubDetail.Parameters.Add("P_DATE", OracleDbType.Date).Value = ObjEntityCredit.Debit_Date;
                                                cmdAddSubDetail.Parameters.Add("R_LD_ID", OracleDbType.Int32).Value = objDetail.LedgerId;
                                                cmdAddSubDetail.Parameters.Add("P_COST_CNTR_ID", OracleDbType.Int32).Value = objDetailSub.Cost_Centre_Id;
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
                                                cmdAddSubDetail.Parameters.Add("R_LDGR_AMT", OracleDbType.Decimal).Value = objDetailSub.Cost_Centre_Amt;
                                                cmdAddSubDetail.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = ObjEntityCredit.Organisation_id;
                                                cmdAddSubDetail.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = ObjEntityCredit.Corporate_id;
                                                cmdAddSubDetail.Parameters.Add("P_FINCIALID", OracleDbType.Int32).Value = ObjEntityCredit.FinancialYrId;
                                                if (objDetail.Credit_debit_Status == 0)
                                                {
                                                    cmdAddSubDetail.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 0;
                                                }
                                                else
                                                {
                                                    cmdAddSubDetail.Parameters.Add("P_VOUCHR_STS", OracleDbType.Int32).Value = 1;
                                                }
                                                cmdAddSubDetail.Parameters.Add("P_CRNC_MST_ID", OracleDbType.Int32).Value = ObjEntityCredit.CurrencyId;
                                                cmdAddSubDetail.Parameters.Add("P_VOCHR_TYPE", OracleDbType.Int32).Value = 4;
                                                cmdAddSubDetail.Parameters.Add("P_VOCHR_ID", OracleDbType.Int32).Value = ObjEntityCredit.VoucherID;

                                                cmdAddSubDetail.ExecuteNonQuery();
                                            }
                                        }

                                    }
                                }
                            }
                            foreach (clsEntity_Debit_Note objDetailSub in objEntitySaleList)
                            {

                                if (objDetail.Ledger_Debit_Id == objDetailSub.Ledger_Debit_Id)
                                {
                                 

                                    if (ObjEntityCredit.ConfirmStatus == 1)
                                    {
                                        string strQuerySubSalesUpdate = "FMS_DEBIT_NOTE.SP_UPDATE_PURCHSE_BALANCE";
                                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubSalesUpdate, con))
                                        {
                                            cmdAddSubDetail.Transaction = tran;
                                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                                            if (objDetailSub.Cost_Centre_Id != 0)
                                            {
                                                cmdAddSubDetail.Parameters.Add("C_SALEID", OracleDbType.Int32).Value = objDetailSub.Cost_Centre_Id;
                                            }
                                            cmdAddSubDetail.Parameters.Add("C_AMNT", OracleDbType.Decimal).Value = objDetailSub.Cost_Centre_Amt;
                                            cmdAddSubDetail.Parameters.Add("C_PRCHS_SETTLE_AMNT", OracleDbType.Decimal).Value = objDetailSub.SalesRefSettleAmnt;
                                            cmdAddSubDetail.ExecuteNonQuery();
                                        }
                                        if (objDetailSub.Cost_Centre_Id != 0)
                                        {
                                            //Debit note settlement
                                            if (objDetailSub.Cost_Centre_Amt != 0)
                                            {
                                                string strQueryInsertVoucherSettleDtls = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";  //Add settle amount details
                                                using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherSettleDtls, con))
                                                {
                                                    cmdAddVoucher.Transaction = tran;
                                                    cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                                    cmdAddVoucher.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = ObjEntityCredit.VoucherID;
                                                    cmdAddVoucher.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = objDetail.LedgerId;
                                                    cmdAddVoucher.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = objDetailSub.Cost_Centre_Amt;
                                                    cmdAddVoucher.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 3;
                                                    cmdAddVoucher.Parameters.Add("C_USRID", OracleDbType.Int32).Value = ObjEntityCredit.User_Id;
                                                    cmdAddVoucher.Parameters.Add("C_SALID", OracleDbType.Int32).Value = objDetailSub.Cost_Centre_Id;
                                                    cmdAddVoucher.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = ObjEntityCredit.Debit_Id;
                                                    cmdAddVoucher.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = objDetailSub.PurchaseActAmount;
                                                    cmdAddVoucher.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = objDetail.Ledger_Debit_Id;
                                                    cmdAddVoucher.ExecuteNonQuery();
                                                }
                                            }
                                            //Purchase settlement
                                            if (objDetailSub.SalesRefSettleAmnt != 0)
                                            {
                                                string strQueryInsertVoucherSettleDtls = "FMS_COMMON.SP_INS_VOCHR_SETTLEMENT";  //Add settle amount details
                                                using (OracleCommand cmdAddVoucher = new OracleCommand(strQueryInsertVoucherSettleDtls, con))
                                                {
                                                    cmdAddVoucher.Transaction = tran;
                                                    cmdAddVoucher.CommandType = CommandType.StoredProcedure;
                                                    cmdAddVoucher.Parameters.Add("C_VCHR_ID", OracleDbType.Int32).Value = ObjEntityCredit.VoucherID;
                                                    cmdAddVoucher.Parameters.Add("C_LDGR_ID", OracleDbType.Int32).Value = objDetail.LedgerId;
                                                    cmdAddVoucher.Parameters.Add("C_AMT", OracleDbType.Decimal).Value = objDetailSub.SalesRefSettleAmnt;
                                                    cmdAddVoucher.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = 1;
                                                    cmdAddVoucher.Parameters.Add("C_USRID", OracleDbType.Int32).Value = ObjEntityCredit.User_Id;
                                                    cmdAddVoucher.Parameters.Add("C_SALID", OracleDbType.Int32).Value = objDetailSub.Cost_Centre_Id;
                                                    cmdAddVoucher.Parameters.Add("C_TRNID", OracleDbType.Int32).Value = ObjEntityCredit.Debit_Id;
                                                    cmdAddVoucher.Parameters.Add("C_ACTAMT", OracleDbType.Decimal).Value = objDetailSub.BeforeSalesRefAmt;
                                                    cmdAddVoucher.Parameters.Add("C_TRNSCTN_LDGRID", OracleDbType.Int32).Value = objDetail.Ledger_Debit_Id;
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

        public DataTable ReadSalesbyId(clsEntity_Debit_Note ObjEntityDebit)
        {
            string strQueryReadRcpt = "FMS_DEBIT_NOTE.SP_READ_PURCHASE_BY_LEDID";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = ObjEntityDebit.Organisation_id;
            cmdReadRcpt.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = ObjEntityDebit.Corporate_id;
            cmdReadRcpt.Parameters.Add("R_LEDGERID", OracleDbType.Int32).Value = ObjEntityDebit.LedgerId;
            cmdReadRcpt.Parameters.Add("R_DBNTID", OracleDbType.Int32).Value = ObjEntityDebit.Debit_Id;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }

        public void DeletePurchaseLedgers(List<clsEntity_Debit_Note> ObjEntityDbtNoteCstCntrDEL)
        {
            foreach (clsEntity_Debit_Note objEntity in ObjEntityDbtNoteCstCntrDEL)
            {
                string strCommandText = "FMS_DEBIT_NOTE.SP_DELETE_ADDEDPRCHS";
                OracleCommand cmdReadRcpt = new OracleCommand();
                cmdReadRcpt.CommandText = strCommandText;
                cmdReadRcpt.CommandType = CommandType.StoredProcedure;
                cmdReadRcpt.Parameters.Add("J_CST_ID", OracleDbType.Int32).Value = objEntity.Cost_Centre_Debit_Id;
                clsDataLayer.ExecuteNonQuery(cmdReadRcpt);
            }
        }

        public DataTable ReadSalesReturnBalance(clsEntity_Debit_Note objEntity)
        {
            string strQueryReadRcpt = "FMS_DEBIT_NOTE.SP_READ_PRCHS_RETURN_BALANCE";
            OracleCommand cmdReadRcpt = new OracleCommand();
            cmdReadRcpt.CommandText = strQueryReadRcpt;
            cmdReadRcpt.CommandType = CommandType.StoredProcedure;
            cmdReadRcpt.Parameters.Add("F_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
            cmdReadRcpt.Parameters.Add("F_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
            cmdReadRcpt.Parameters.Add("F_LDGRID", OracleDbType.Int32).Value = objEntity.Cost_Centre_Id;
            cmdReadRcpt.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadRcpt);
            return dtCategory;
        }


    }
}
