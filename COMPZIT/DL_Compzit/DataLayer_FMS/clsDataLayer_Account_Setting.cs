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


namespace DL_Compzit.DataLayer_FMS
{
    public class clsDataLayer_Account_Setting
    {
        public DataTable ReadAccountGrpMapping(clsEntity_Account_Setting objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_ACCOUNT_SETTING.SP_READ_ACCOUNTMAPPING";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.OrgId;
            cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpId;
            cmdReadPayGrd.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.UserId;
            cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
        public DataTable ReadHeadGrpMapping(clsEntity_Account_Setting objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_ACCOUNT_SETTING.SP_READ_HEADMAPPING";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.OrgId;
            cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpId;
            cmdReadPayGrd.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.UserId;
            cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
        public DataTable ReadAccountGrp(clsEntity_Account_Setting objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_ACCOUNT_SETTING.SP_READ_ACCOUNTGROUP";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.OrgId;
            cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpId;
            cmdReadPayGrd.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.UserId;
            cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
        public DataTable ReadLedgerPurchase(clsEntity_Account_Setting objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_ACCOUNT_SETTING.SP_READ_LEDGER_PRCHS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.OrgId;
            cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpId;
            cmdReadPayGrd.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.UserId;
            cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
        public DataTable ReadLedgerSale(clsEntity_Account_Setting objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_ACCOUNT_SETTING.SP_READ_LEDGER_SALE";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.OrgId;
            cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpId;
            cmdReadPayGrd.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.UserId;
            cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
        public DataTable ReadFinancialYear(clsEntity_Account_Setting objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_ACCOUNT_SETTING.SP_READ_FINANCIAL_YEAR";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.OrgId;
            cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpId;
            cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
        public void InsertPrimaryAccountGroup(clsEntity_Account_Setting objEntity)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                        string strQueryChangeStatus = "FMS_ACCOUNT_SETTING.SP_INSERT_PRMRYGRPS";
                        using (OracleCommand cmdChangeStatus = new OracleCommand())
                        {
                            cmdChangeStatus.CommandText = strQueryChangeStatus;
                            cmdChangeStatus.CommandType = CommandType.StoredProcedure;
                            cmdChangeStatus.Parameters.Add("L_PRMRYGRP_ID", OracleDbType.Int32).Value = objEntity.PrimaryGrpId;
                            cmdChangeStatus.Parameters.Add("L_ACNT_GRP_ID", OracleDbType.Int32).Value = objEntity.AccountGrpId;
                            cmdChangeStatus.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntity.UserId;
                            cmdChangeStatus.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntity.OrgId;
                            cmdChangeStatus.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntity.CorpId;
                            clsDataLayer.ExecuteNonQuery(cmdChangeStatus);
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
        public void InsertAccount_Setting(clsEntity_Account_Setting objEntity, List<clsEntity_Account_Setting> ObjEntityGroup, List<clsEntity_Account_Setting> ObjEntityHead, List<clsEntity_Account_Setting> ObjEntityFinancialYear, List<clsEntity_Account_Setting> ObjEntityFYrCancel, List<clsEntity_Account_Setting> ObjEntityVersions, List<clsEntity_Account_Setting> objEntityPrmryGrp)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {

                    foreach (clsEntity_Account_Setting objSubDetail in ObjEntityGroup)
                    {

                        string strQuerySubDetails = "FMS_ACCOUNT_SETTING.SP_INS_ACCOUNT_GROUP";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetails, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            if (objSubDetail.MasterId != 0)
                            {
                                cmdAddSubDetail.Parameters.Add("A_MODUL_ID", OracleDbType.Int32).Value = objSubDetail.MasterId;
                            }
                            else
                            {
                                cmdAddSubDetail.Parameters.Add("A_MODUL_ID", OracleDbType.Int32).Value = null;
                            }
                            cmdAddSubDetail.Parameters.Add("A_GRP_ID", OracleDbType.Int32).Value = objSubDetail.AccountGrpId;
                            cmdAddSubDetail.Parameters.Add("A_USR_ID", OracleDbType.Int32).Value = objEntity.UserId;
                            cmdAddSubDetail.Parameters.Add("A_MD_ID", OracleDbType.Int32).Value = objSubDetail.ModuleId;
                            cmdAddSubDetail.Parameters.Add("A_ORG_ID", OracleDbType.Int32).Value = objEntity.OrgId;
                            cmdAddSubDetail.Parameters.Add("A_CORP_ID", OracleDbType.Int32).Value = objEntity.CorpId;

                            cmdAddSubDetail.ExecuteNonQuery();
                        }
                    }
                    foreach (clsEntity_Account_Setting objSubDetailCost in ObjEntityHead)
                    {
                        string strQuerySubDetailsCost = "FMS_ACCOUNT_SETTING.SP_INS_ACCOUNT_HEAD";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            if (objSubDetailCost.MasterId != 0)
                            {
                                cmdAddSubDetail.Parameters.Add("A_MODUL_ID", OracleDbType.Int32).Value = objSubDetailCost.MasterId;
                            }
                            else
                            {
                                cmdAddSubDetail.Parameters.Add("A_MODUL_ID", OracleDbType.Int32).Value = null;
                            }
                            cmdAddSubDetail.Parameters.Add("P_LID", OracleDbType.Int32).Value = objSubDetailCost.LedgerId;
                            cmdAddSubDetail.Parameters.Add("A_USR_ID", OracleDbType.Int32).Value = objEntity.UserId;
                            cmdAddSubDetail.Parameters.Add("A_ORG_ID", OracleDbType.Int32).Value = objEntity.OrgId;
                            cmdAddSubDetail.Parameters.Add("A_CORP_ID", OracleDbType.Int32).Value = objEntity.CorpId;
                            cmdAddSubDetail.Parameters.Add("A_MD_ID", OracleDbType.Int32).Value = objSubDetailCost.ModuleId;

                            cmdAddSubDetail.ExecuteNonQuery();
                        }
                    }
                    foreach (clsEntity_Account_Setting objSubDetailCost in ObjEntityFinancialYear)
                    {
                        string strQuerySubDetailsCost = "FMS_ACCOUNT_SETTING.SP_INS_ACCOUNT_FINANCIAL_YEAR";
                        using (OracleCommand cmdAddSubDetail = new OracleCommand(strQuerySubDetailsCost, con))
                        {
                            cmdAddSubDetail.Transaction = tran;
                            cmdAddSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddSubDetail.Parameters.Add("A_STARTDT", OracleDbType.Date).Value = objSubDetailCost.StartDate;
                            cmdAddSubDetail.Parameters.Add("P_ENDDT", OracleDbType.Date).Value = objSubDetailCost.EndDate;
                            cmdAddSubDetail.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objSubDetailCost.DefaultName;
                            cmdAddSubDetail.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objSubDetailCost.FinancialYearStatus;

                            cmdAddSubDetail.Parameters.Add("A_USR_ID", OracleDbType.Int32).Value = objEntity.UserId;
                            cmdAddSubDetail.Parameters.Add("A_ORG_ID", OracleDbType.Int32).Value = objEntity.OrgId;
                            cmdAddSubDetail.Parameters.Add("A_CORP_ID", OracleDbType.Int32).Value = objEntity.CorpId;
                            if (objSubDetailCost.FinancialYearID != 0)
                            {
                                cmdAddSubDetail.Parameters.Add("A_FY_ID", OracleDbType.Int32).Value = objSubDetailCost.FinancialYearID;
                            }
                            else
                            {
                                cmdAddSubDetail.Parameters.Add("A_FY_ID", OracleDbType.Int32).Value = null;
                            }
                            cmdAddSubDetail.ExecuteNonQuery();
                        }
                    }
                    foreach (clsEntity_Account_Setting objSubLdgr in ObjEntityFYrCancel)
                    {
                        string strQueryChangeStatus = "FMS_ACCOUNT_SETTING.SP_DEL_ACCOUNT_FINANCIAL_YEAR";
                        using (OracleCommand cmdChangeStatus = new OracleCommand())
                        {
                            cmdChangeStatus.CommandText = strQueryChangeStatus;
                            cmdChangeStatus.CommandType = CommandType.StoredProcedure;
                            cmdChangeStatus.Parameters.Add("A_FY_ID", OracleDbType.Int32).Value = objSubLdgr.FinancialYearID;
                            cmdChangeStatus.Parameters.Add("A_CORP_ID", OracleDbType.Int32).Value = objEntity.CorpId;
                            cmdChangeStatus.Parameters.Add("A_ORG_ID", OracleDbType.Int32).Value = objEntity.OrgId;
                            cmdChangeStatus.Parameters.Add("A_USR_ID", OracleDbType.Int32).Value = objEntity.UserId;
                            clsDataLayer.ExecuteNonQuery(cmdChangeStatus);
                        }
                    }
                    foreach (clsEntity_Account_Setting objSubLdgr in ObjEntityVersions)
                    {
                        string strQueryChangeStatus = "FMS_ACCOUNT_SETTING.SP_INS_DFLT_VERSION";
                        using (OracleCommand cmdChangeStatus = new OracleCommand())
                        {
                            cmdChangeStatus.CommandText = strQueryChangeStatus;
                            cmdChangeStatus.CommandType = CommandType.StoredProcedure;
                            cmdChangeStatus.Parameters.Add("A_CORP_ID", OracleDbType.Int32).Value = objEntity.CorpId;
                            if (objSubLdgr.VersionID != 0)
                            {
                                cmdChangeStatus.Parameters.Add("A_VRSN_ID", OracleDbType.Int32).Value = objSubLdgr.VersionID;
                            }
                            else
                            {
                                cmdChangeStatus.Parameters.Add("A_VRSN_ID", OracleDbType.Int32).Value = DBNull.Value;
                            }
                            cmdChangeStatus.Parameters.Add("A_VCHR_ID", OracleDbType.Int32).Value = objSubLdgr.VoucherID;
                            clsDataLayer.ExecuteNonQuery(cmdChangeStatus);
                        }
                    }
                    //foreach (clsEntity_Account_Setting objEntityPrmry in objEntityPrmryGrp)
                    //{
                    //    string strQueryChangeStatus = "FMS_ACCOUNT_SETTING.SP_INSERT_PRMRYGRPS";
                    //    using (OracleCommand cmdChangeStatus = new OracleCommand())
                    //    {
                    //        cmdChangeStatus.CommandText = strQueryChangeStatus;
                    //        cmdChangeStatus.CommandType = CommandType.StoredProcedure;
                    //        cmdChangeStatus.Parameters.Add("L_PRMRYGRP_ID", OracleDbType.Int32).Value = objEntityPrmry.PrimaryGrpId;
                    //        cmdChangeStatus.Parameters.Add("L_ACNT_GRP_ID", OracleDbType.Int32).Value = objEntityPrmry.AccountGrpId;
                    //        cmdChangeStatus.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntity.UserId;
                    //        cmdChangeStatus.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntity.OrgId;
                    //        cmdChangeStatus.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntity.CorpId;
                    //        clsDataLayer.ExecuteNonQuery(cmdChangeStatus);
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
        public DataTable CheckFinancialYear(clsEntity_Account_Setting objEntityAccount)
        {
            string strQueryReadEmpSlry = "FMS_ACCOUNT_SETTING.SP_CHK_ACCOUNT_FINANCIAL_YEAR";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("A_FY_ID", OracleDbType.Int32).Value = objEntityAccount.FinancialYearID;
            cmdReadPayGrd.Parameters.Add("A_CORP_ID", OracleDbType.Int32).Value = objEntityAccount.CorpId;
            cmdReadPayGrd.Parameters.Add("A_ORG_ID", OracleDbType.Int32).Value = objEntityAccount.OrgId;
            cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }

        public DataTable ReadLedgerByNature(clsEntity_Account_Setting objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_ACCOUNT_SETTING.SP_READ_LEDGER_BY_NATURE";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.OrgId;
            cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpId;
            cmdReadPayGrd.Parameters.Add("L_USERID", OracleDbType.Int32).Value = objEntityEmpSlry.UserId;
            cmdReadPayGrd.Parameters.Add("L_ACNT_NATURE_STS", OracleDbType.Int32).Value = objEntityEmpSlry.AccountNatureStatus;
            cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
        public DataTable ReadPrintVersions(clsEntity_Account_Setting objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_ACCOUNT_SETTING.SP_READ_PRINT_VERSIONS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.OrgId;
            cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpId;
            cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
        public DataTable ReadDefaultPrintVersions(clsEntity_Account_Setting objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_ACCOUNT_SETTING.SP_READ_DFLT_VERSION";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpId;
            cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }
        public DataTable ReadVoucherType(clsEntity_Account_Setting objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_ACCOUNT_SETTING.SP_READ_VOCHER_TYPE";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpId;
            cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }

        public DataTable ReadPrimaryGrpsMapped(clsEntity_Account_Setting objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_ACCOUNT_SETTING.SP_READ_PRIMARYGRPS_MAPPED";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.OrgId;
            cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpId;
            cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }

        public DataTable CheckPrimaryAccountGrp(clsEntity_Account_Setting objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_ACCOUNT_SETTING.SP_CHK_PRMARY_GRP";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("R_GRPID", OracleDbType.Int32).Value = objEntityEmpSlry.AccountGrpId;
            cmdReadPayGrd.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.OrgId;
            cmdReadPayGrd.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpId;
            cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }

        public DataTable ReadSelectedGrpOrLdgrLedger(clsEntity_Account_Setting objEntityEmpSlry)
        {
            string strQueryReadEmpSlry = "FMS_ACCOUNT_SETTING.SP_READ_SELECTED_GRPORLDGR";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityEmpSlry.OrgId;
            cmdReadPayGrd.Parameters.Add("L_CORPID", OracleDbType.Int32).Value = objEntityEmpSlry.CorpId;
            cmdReadPayGrd.Parameters.Add("L_ASMODID", OracleDbType.Int32).Value = objEntityEmpSlry.AsmodId;
            cmdReadPayGrd.Parameters.Add("L_LDGRRGP_STS", OracleDbType.Int32).Value = objEntityEmpSlry.LdgrGrpSts;
            cmdReadPayGrd.Parameters.Add("L_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }


    }
}
