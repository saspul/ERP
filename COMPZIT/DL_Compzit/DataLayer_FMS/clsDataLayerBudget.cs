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
    public class clsDataLayerBudget
    {
        public DataTable ReadFinancialYear(clsEntityLayerBudget objEntityEmpSlry)
        {
            string strCommandText = "FMS_BUDGET.SP_READ_ACT_FISCALYR";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strCommandText;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("F_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
                cmdReadPayGrd.Parameters.Add("F_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
                cmdReadPayGrd.Parameters.Add("F_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtEmpSlry = new DataTable();
                dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
                return dtEmpSlry;
            }
        }
        public DataTable ReadLedgerDdl(clsEntityJournal objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_BUDGET.SP_READ_LEDGER_DDL";
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

        public DataTable CheckDupName(clsEntityLayerBudget objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_BUDGET.SP_CHECK_DUP_NAME";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
            cmdReadPayGrd.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
            cmdReadPayGrd.Parameters.Add("B_YEAR", OracleDbType.Int32).Value = objEntityEmpSlry.Year;
            cmdReadPayGrd.Parameters.Add("B_MODE", OracleDbType.Int32).Value = objEntityEmpSlry.Mode;
            cmdReadPayGrd.Parameters.Add("B_NAME", OracleDbType.Varchar2).Value = objEntityEmpSlry.BudgtName;
            cmdReadPayGrd.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityEmpSlry.BudgetId;
            cmdReadPayGrd.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
        public DataTable ReadBudgetList(clsEntityLayerBudget objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_BUDGET.SP_READ_BUDGT_LIST";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
            cmdReadPayGrd.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
            cmdReadPayGrd.Parameters.Add("B_MODE", OracleDbType.Int32).Value = objEntityEmpSlry.Mode;
            cmdReadPayGrd.Parameters.Add("B_CNCL_STS", OracleDbType.Int32).Value = objEntityEmpSlry.ConfirmSts;
            cmdReadPayGrd.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
        public DataTable ReadBdgtDtlsById(clsEntityLayerBudget objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_BUDGET.SP_READ_BUDGT_DTL";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityEmpSlry.BudgetId;
            cmdReadPayGrd.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
            cmdReadPayGrd.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
            cmdReadPayGrd.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
        public DataTable ReadBdgtLedgrDtlsById(clsEntityLayerBudget objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_BUDGET.SP_READ_BUDGT_LEDGR_DTL";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityEmpSlry.BudgetId;
            cmdReadPayGrd.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
            cmdReadPayGrd.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
            cmdReadPayGrd.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
        public DataTable ReadBdgtCostCntrDtlsById(clsEntityLayerBudget objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_BUDGET.SP_READ_BUDGT_LDGRCOST_DTL";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityEmpSlry.BudgetId;
            cmdReadPayGrd.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
            cmdReadPayGrd.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
            cmdReadPayGrd.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
        public DataTable CheckBdgtCnclSts(clsEntityLayerBudget objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_BUDGET.SP_CHECK_CNCL_STS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityEmpSlry.BudgetId;
            cmdReadPayGrd.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
        public void CancelBudget(clsEntityLayerBudget objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_BUDGET.SP_CANCEL_BUDGET";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityEmpSlry.BudgetId;
            cmdReadPayGrd.Parameters.Add("B_CNCL_REASON", OracleDbType.Varchar2).Value = objEntityEmpSlry.Cancel_Reason;
            cmdReadPayGrd.Parameters.Add("B_USER_ID", OracleDbType.Int32).Value = objEntityEmpSlry.User_Id;
            clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
        }
        public DataTable ReadBdgtLedgrDtlsByIdMnth(clsEntityLayerBudget objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_BUDGET.SP_READ_BUDGT_LEDGR_DTL_MNT";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityEmpSlry.BudgetId;
            cmdReadPayGrd.Parameters.Add("B_MNTH", OracleDbType.Varchar2).Value = objEntityEmpSlry.BudgtName;
            cmdReadPayGrd.Parameters.Add("B_MNTH_YEAR", OracleDbType.Varchar2).Value = objEntityEmpSlry.Cancel_Reason;
            cmdReadPayGrd.Parameters.Add("B_MODE", OracleDbType.Int32).Value = objEntityEmpSlry.Mode;
            cmdReadPayGrd.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
            cmdReadPayGrd.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
            cmdReadPayGrd.Parameters.Add("B_FINYR", OracleDbType.Int32).Value = objEntityEmpSlry.Year;
            cmdReadPayGrd.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
              public DataTable ReadBdgtYear(clsEntityLayerBudget objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_BUDGET.SP_READ_BUDGT_YEAR";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("B_MNTH_YEAR", OracleDbType.Varchar2).Value = objEntityEmpSlry.Cancel_Reason;
            cmdReadPayGrd.Parameters.Add("B_MODE", OracleDbType.Int32).Value = objEntityEmpSlry.Mode;
            cmdReadPayGrd.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
            cmdReadPayGrd.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
            cmdReadPayGrd.Parameters.Add("B_FINYR", OracleDbType.Int32).Value = objEntityEmpSlry.Year;
            cmdReadPayGrd.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
        
        public DataTable ReadBdgtCostCntrDtlsByIdMnth(clsEntityLayerBudget objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_BUDGET.SP_READ_BUDGT_LDGRCOST_DTL_MNT";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityEmpSlry.BudgetId;
            cmdReadPayGrd.Parameters.Add("B_MNTH", OracleDbType.Varchar2).Value = objEntityEmpSlry.BudgtName;
            cmdReadPayGrd.Parameters.Add("B_MNTH_YEAR", OracleDbType.Varchar2).Value = objEntityEmpSlry.Cancel_Reason;
            cmdReadPayGrd.Parameters.Add("B_MODE", OracleDbType.Int32).Value = objEntityEmpSlry.Mode;
            cmdReadPayGrd.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.Org_Id;
            cmdReadPayGrd.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.Corp_Id;
            cmdReadPayGrd.Parameters.Add("B_FINYR", OracleDbType.Int32).Value = objEntityEmpSlry.Year;
            cmdReadPayGrd.Parameters.Add("B_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
        public void SubmitMonthDtls(clsEntityLayerBudget objEntityShortList, List<clsEntityBudgetLedgerDtl> objEntityJrnlLedgrList, List<clsEntityBudgetCostCntrDtl> objEntityJrnlCostcentrList)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "FMS_BUDGET.SP_UPD_BUDGET_MASTER_RVW";
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
                        cmdAddService.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityShortList.BudgetId;
                        cmdAddService.Parameters.Add("B_USRID", OracleDbType.Int32).Value = objEntityShortList.User_Id;
                        cmdAddService.Parameters.Add("B_STS", OracleDbType.Varchar2).Value = objEntityShortList.BudgtName;
                        cmdAddService.Parameters.Add("B_TYPE", OracleDbType.Int32).Value = objEntityShortList.ConfirmSts;
                        cmdAddService.ExecuteNonQuery();
                    }

                    foreach (clsEntityBudgetLedgerDtl objDetail in objEntityJrnlLedgrList)
                    {
                        string strQueryInsertDetails = "FMS_BUDGET.SP_UPD_LEDGR_REASN";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("B_ID", OracleDbType.Int32).Value = objDetail.BudgetLedgerId;
                            cmdAddInsertDetail.Parameters.Add("B_REASN", OracleDbType.Varchar2).Value = objDetail.Reason;
                            cmdAddInsertDetail.Parameters.Add("B_MNTH", OracleDbType.Varchar2).Value = objEntityShortList.BudgtName;
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                    }
                    foreach (clsEntityBudgetCostCntrDtl objDetailSub in objEntityJrnlCostcentrList)
                    {
                        string strQueryInsertDetailsub = "FMS_BUDGET.SP_UPD_COSTCNTR_REASN";
                        using (OracleCommand cmdAddInsertDetailS = new OracleCommand(strQueryInsertDetailsub, con))
                        {
                            cmdAddInsertDetailS.Transaction = tran;
                            cmdAddInsertDetailS.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetailS.Parameters.Add("B_ID", OracleDbType.Int32).Value = objDetailSub.BudgetId;
                            cmdAddInsertDetailS.Parameters.Add("B_COSTID", OracleDbType.Int32).Value = objDetailSub.BudgetCostCntrId;
                            cmdAddInsertDetailS.Parameters.Add("B_REASN", OracleDbType.Varchar2).Value = objDetailSub.Reason;
                            cmdAddInsertDetailS.Parameters.Add("B_MNTH", OracleDbType.Varchar2).Value = objEntityShortList.BudgtName;
                            cmdAddInsertDetailS.ExecuteNonQuery();
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
        public void AddBudgetDtls(clsEntityLayerBudget objEntityShortList, List<clsEntityBudgetLedgerDtl> objEntityJrnlLedgrList, List<clsEntityBudgetCostCntrDtl> objEntityJrnlCostcentrList)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "FMS_BUDGET.SP_INS_BUDGET_MASTER";
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
                        string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        objEntityShortList.BudgetId = Convert.ToInt32(strNextNum);
                        cmdAddService.CommandText = strQueryLeaveTyp;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityShortList.BudgetId;
                        cmdAddService.Parameters.Add("B_NAME", OracleDbType.Varchar2).Value = objEntityShortList.BudgtName;
                        cmdAddService.Parameters.Add("B_YEAR", OracleDbType.Int32).Value = objEntityShortList.Year;
                        cmdAddService.Parameters.Add("B_MODE", OracleDbType.Int32).Value = objEntityShortList.Mode;
                        cmdAddService.Parameters.Add("B_ORGID", OracleDbType.Int32).Value = objEntityShortList.Org_Id;
                        cmdAddService.Parameters.Add("B_CORPID", OracleDbType.Int32).Value = objEntityShortList.Corp_Id;
                        cmdAddService.Parameters.Add("B_USRID", OracleDbType.Int32).Value = objEntityShortList.User_Id;
                        cmdAddService.Parameters.Add("B_L_CC_MODE", OracleDbType.Int32).Value = objEntityShortList.LedgerCC_Mode;
                        cmdAddService.ExecuteNonQuery();
                    }

                    foreach (clsEntityBudgetLedgerDtl objDetail in objEntityJrnlLedgrList)
                    {
                        string strQueryInsertDetails = "FMS_BUDGET.SP_INS_LEDGR_DTL";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("B_BDGTID", OracleDbType.Int32).Value = objEntityShortList.BudgetId;
                            cmdAddInsertDetail.Parameters.Add("B_LEDGRID", OracleDbType.Int32).Value = objDetail.LedgerId;
                            if (objDetail.TotAmntJan != 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_JAN", OracleDbType.Decimal).Value = objDetail.TotAmntJan;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_JAN", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetail.TotAmntFeb != 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_FEB", OracleDbType.Decimal).Value = objDetail.TotAmntFeb;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_FEB", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetail.TotAmntMar != 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_MAR", OracleDbType.Decimal).Value = objDetail.TotAmntMar;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_MAR", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetail.TotAmntApr != 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_APR", OracleDbType.Decimal).Value = objDetail.TotAmntApr;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_APR", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetail.TotAmntMay != 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_MAY", OracleDbType.Decimal).Value = objDetail.TotAmntMay;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_MAY", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetail.TotAmntJun != 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_JUN", OracleDbType.Decimal).Value = objDetail.TotAmntJun;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_JUN", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetail.TotAmntJul != 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_JUL", OracleDbType.Decimal).Value = objDetail.TotAmntJul;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_JUL", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetail.TotAmntAug != 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_AUG", OracleDbType.Decimal).Value = objDetail.TotAmntAug;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_AUG", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetail.TotAmntSep != 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_SEP", OracleDbType.Decimal).Value = objDetail.TotAmntSep;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_SEP", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetail.TotAmntOct != 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_OCT", OracleDbType.Decimal).Value = objDetail.TotAmntOct;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_OCT", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetail.TotAmntNov != 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_NOV", OracleDbType.Decimal).Value = objDetail.TotAmntNov;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_NOV", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetail.TotAmntDec != 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_DEC", OracleDbType.Decimal).Value = objDetail.TotAmntDec;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_DEC", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            cmdAddInsertDetail.Parameters.Add("B_AMNT_TOTAL", OracleDbType.Decimal).Value = objDetail.LedgerTotal;
                            cmdAddInsertDetail.Parameters.Add("B_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                            cmdAddInsertDetail.ExecuteNonQuery();
                            string strReturn = cmdAddInsertDetail.Parameters["B_ID"].Value.ToString();
                        }
                    }

                    foreach (clsEntityBudgetCostCntrDtl objDetailSub in objEntityJrnlCostcentrList)
                    {
                        string strQueryInsertDetailsub = "FMS_BUDGET.SP_INS_COSTCNTR_DTL";
                        using (OracleCommand cmdAddInsertDetailS = new OracleCommand(strQueryInsertDetailsub, con))
                        {
                            cmdAddInsertDetailS.Transaction = tran;
                            cmdAddInsertDetailS.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetailS.Parameters.Add("B_BDGTID", OracleDbType.Int32).Value = objEntityShortList.BudgetId;
                            //  cmdAddInsertDetailS.Parameters.Add("B_BDGTLEDGRID", OracleDbType.Int32).Value = Convert.ToInt32(strReturn);                         
                            cmdAddInsertDetailS.Parameters.Add("B_COSTCENTRID", OracleDbType.Int32).Value = objDetailSub.CostCenterId;
                            if (objDetailSub.TotAmntJan != 0)
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_JAN", OracleDbType.Decimal).Value = objDetailSub.TotAmntJan;
                            }
                            else
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_JAN", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetailSub.TotAmntFeb != 0)
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_FEB", OracleDbType.Decimal).Value = objDetailSub.TotAmntFeb;
                            }
                            else
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_FEB", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetailSub.TotAmntMar != 0)
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_MAR", OracleDbType.Decimal).Value = objDetailSub.TotAmntMar;
                            }
                            else
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_MAR", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetailSub.TotAmntApr != 0)
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_APR", OracleDbType.Decimal).Value = objDetailSub.TotAmntApr;
                            }
                            else
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_APR", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetailSub.TotAmntMay != 0)
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_MAY", OracleDbType.Decimal).Value = objDetailSub.TotAmntMay;
                            }
                            else
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_MAY", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetailSub.TotAmntJun != 0)
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_JUN", OracleDbType.Decimal).Value = objDetailSub.TotAmntJun;
                            }
                            else
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_JUN", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetailSub.TotAmntJul != 0)
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_JUL", OracleDbType.Decimal).Value = objDetailSub.TotAmntJul;
                            }
                            else
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_JUL", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetailSub.TotAmntAug != 0)
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_AUG", OracleDbType.Decimal).Value = objDetailSub.TotAmntAug;
                            }
                            else
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_AUG", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetailSub.TotAmntSep != 0)
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_SEP", OracleDbType.Decimal).Value = objDetailSub.TotAmntSep;
                            }
                            else
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_SEP", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetailSub.TotAmntOct != 0)
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_OCT", OracleDbType.Decimal).Value = objDetailSub.TotAmntOct;
                            }
                            else
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_OCT", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetailSub.TotAmntNov != 0)
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_NOV", OracleDbType.Decimal).Value = objDetailSub.TotAmntNov;
                            }
                            else
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_NOV", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetailSub.TotAmntDec != 0)
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_DEC", OracleDbType.Decimal).Value = objDetailSub.TotAmntDec;
                            }
                            else
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_DEC", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            cmdAddInsertDetailS.Parameters.Add("B_AMNT_TOTAL", OracleDbType.Decimal).Value = objDetailSub.CCTotal;

                            cmdAddInsertDetailS.ExecuteNonQuery();
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


        public void EditBudgetDtls(clsEntityLayerBudget objEntityShortList, List<clsEntityBudgetLedgerDtl> objEntityJrnlLedgrList, List<clsEntityBudgetCostCntrDtl> objEntityJrnlCostcentrList)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "FMS_BUDGET.SP_UPD_BUDGET_MASTER";
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
                        cmdAddService.Parameters.Add("B_ID", OracleDbType.Int32).Value = objEntityShortList.BudgetId;
                        cmdAddService.Parameters.Add("B_USRID", OracleDbType.Int32).Value = objEntityShortList.User_Id;
                        cmdAddService.Parameters.Add("B_STS", OracleDbType.Int32).Value = objEntityShortList.ConfirmSts;
                        cmdAddService.Parameters.Add("B_L_CC_MODE", OracleDbType.Int32).Value = objEntityShortList.LedgerCC_Mode;
                        cmdAddService.ExecuteNonQuery();
                    }

                    foreach (clsEntityBudgetLedgerDtl objDetail in objEntityJrnlLedgrList)
                    {
                        string strQueryInsertDetails = "FMS_BUDGET.SP_INS_LEDGR_DTL";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("B_BDGTID", OracleDbType.Int32).Value = objEntityShortList.BudgetId;
                            cmdAddInsertDetail.Parameters.Add("B_LEDGRID", OracleDbType.Int32).Value = objDetail.LedgerId;
                            if (objDetail.TotAmntJan != 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_JAN", OracleDbType.Decimal).Value = objDetail.TotAmntJan;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_JAN", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetail.TotAmntFeb != 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_FEB", OracleDbType.Decimal).Value = objDetail.TotAmntFeb;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_FEB", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetail.TotAmntMar != 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_MAR", OracleDbType.Decimal).Value = objDetail.TotAmntMar;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_MAR", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetail.TotAmntApr != 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_APR", OracleDbType.Decimal).Value = objDetail.TotAmntApr;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_APR", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetail.TotAmntMay != 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_MAY", OracleDbType.Decimal).Value = objDetail.TotAmntMay;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_MAY", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetail.TotAmntJun != 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_JUN", OracleDbType.Decimal).Value = objDetail.TotAmntJun;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_JUN", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetail.TotAmntJul != 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_JUL", OracleDbType.Decimal).Value = objDetail.TotAmntJul;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_JUL", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetail.TotAmntAug != 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_AUG", OracleDbType.Decimal).Value = objDetail.TotAmntAug;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_AUG", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetail.TotAmntSep != 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_SEP", OracleDbType.Decimal).Value = objDetail.TotAmntSep;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_SEP", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetail.TotAmntOct != 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_OCT", OracleDbType.Decimal).Value = objDetail.TotAmntOct;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_OCT", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetail.TotAmntNov != 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_NOV", OracleDbType.Decimal).Value = objDetail.TotAmntNov;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_NOV", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetail.TotAmntDec != 0)
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_DEC", OracleDbType.Decimal).Value = objDetail.TotAmntDec;
                            }
                            else
                            {
                                cmdAddInsertDetail.Parameters.Add("B_AMNT_DEC", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            cmdAddInsertDetail.Parameters.Add("B_AMNT_TOTAL", OracleDbType.Decimal).Value = objDetail.LedgerTotal;
                            cmdAddInsertDetail.Parameters.Add("B_ID", OracleDbType.Int32).Direction = ParameterDirection.Output;
                            cmdAddInsertDetail.ExecuteNonQuery();
                            string strReturn = cmdAddInsertDetail.Parameters["B_ID"].Value.ToString();

                        }
                    }
                    foreach (clsEntityBudgetCostCntrDtl objDetailSub in objEntityJrnlCostcentrList)
                    {

                        string strQueryInsertDetailsub = "FMS_BUDGET.SP_INS_COSTCNTR_DTL";
                        using (OracleCommand cmdAddInsertDetailS = new OracleCommand(strQueryInsertDetailsub, con))
                        {
                            cmdAddInsertDetailS.Transaction = tran;
                            cmdAddInsertDetailS.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetailS.Parameters.Add("B_BDGTID", OracleDbType.Int32).Value = objEntityShortList.BudgetId;
                            // cmdAddInsertDetailS.Parameters.Add("B_BDGTLEDGRID", OracleDbType.Int32).Value = Convert.ToInt32(strReturn);
                            cmdAddInsertDetailS.Parameters.Add("B_COSTCENTRID", OracleDbType.Int32).Value = objDetailSub.CostCenterId;
                            if (objDetailSub.TotAmntJan != 0)
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_JAN", OracleDbType.Decimal).Value = objDetailSub.TotAmntJan;
                            }
                            else
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_JAN", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetailSub.TotAmntFeb != 0)
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_FEB", OracleDbType.Decimal).Value = objDetailSub.TotAmntFeb;
                            }
                            else
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_FEB", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetailSub.TotAmntMar != 0)
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_MAR", OracleDbType.Decimal).Value = objDetailSub.TotAmntMar;
                            }
                            else
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_MAR", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetailSub.TotAmntApr != 0)
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_APR", OracleDbType.Decimal).Value = objDetailSub.TotAmntApr;
                            }
                            else
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_APR", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetailSub.TotAmntMay != 0)
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_MAY", OracleDbType.Decimal).Value = objDetailSub.TotAmntMay;
                            }
                            else
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_MAY", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetailSub.TotAmntJun != 0)
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_JUN", OracleDbType.Decimal).Value = objDetailSub.TotAmntJun;
                            }
                            else
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_JUN", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetailSub.TotAmntJul != 0)
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_JUL", OracleDbType.Decimal).Value = objDetailSub.TotAmntJul;
                            }
                            else
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_JUL", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetailSub.TotAmntAug != 0)
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_AUG", OracleDbType.Decimal).Value = objDetailSub.TotAmntAug;
                            }
                            else
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_AUG", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetailSub.TotAmntSep != 0)
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_SEP", OracleDbType.Decimal).Value = objDetailSub.TotAmntSep;
                            }
                            else
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_SEP", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetailSub.TotAmntOct != 0)
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_OCT", OracleDbType.Decimal).Value = objDetailSub.TotAmntOct;
                            }
                            else
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_OCT", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetailSub.TotAmntNov != 0)
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_NOV", OracleDbType.Decimal).Value = objDetailSub.TotAmntNov;
                            }
                            else
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_NOV", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            if (objDetailSub.TotAmntDec != 0)
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_DEC", OracleDbType.Decimal).Value = objDetailSub.TotAmntDec;
                            }
                            else
                            {
                                cmdAddInsertDetailS.Parameters.Add("B_AMNT_DEC", OracleDbType.Decimal).Value = DBNull.Value;
                            }
                            cmdAddInsertDetailS.Parameters.Add("B_AMNT_TOTAL", OracleDbType.Decimal).Value = objDetailSub.CCTotal;
                            cmdAddInsertDetailS.ExecuteNonQuery();
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
    }
}

