using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_HCM;
using EL_Compzit;
using CL_Compzit;
namespace DL_Compzit.DataLayer_HCM
{
    public class clsData_Emp_Perfomance_Evaluation
    {
        clsDataLayer objDatatLayer = new clsDataLayer();
        public DataTable ReadPerfomanceEvaluationList(clsEntity_Emp_perfomance_Evaluation objEntityPermne_Evltion)
        {
            DataTable dtReadPrfmcEvltion = new DataTable();
            using (OracleCommand cmdReadPerfmncTmplt = new OracleCommand())
            {
                cmdReadPerfmncTmplt.CommandText = "HCM_EMP_PERFOMANCE_EVALUATION.SP_READ_PRFMNC_EVLTION_LIST";
                cmdReadPerfmncTmplt.CommandType = CommandType.StoredProcedure;
                cmdReadPerfmncTmplt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPermne_Evltion.OrgId;
                cmdReadPerfmncTmplt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPermne_Evltion.CorpId;
                if (objEntityPermne_Evltion.frmDate != DateTime.MinValue)
                {
                    cmdReadPerfmncTmplt.Parameters.Add("P_FRM_DATE", OracleDbType.Date).Value = objEntityPermne_Evltion.frmDate;
                }
                else
                {
                    cmdReadPerfmncTmplt.Parameters.Add("P_FRM_DATE", OracleDbType.Date).Value = null;
                }
                if (objEntityPermne_Evltion.ToDate != DateTime.MinValue)
                {
                    cmdReadPerfmncTmplt.Parameters.Add("P_TO_DATE", OracleDbType.Date).Value = objEntityPermne_Evltion.ToDate;
                }
                else
                {
                    cmdReadPerfmncTmplt.Parameters.Add("P_TO_DATE", OracleDbType.Date).Value = null;
                }

                cmdReadPerfmncTmplt.Parameters.Add("P_RSPONCID", OracleDbType.Int32).Value = objEntityPermne_Evltion.RspnTypeId;
                cmdReadPerfmncTmplt.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtReadPrfmcEvltion = clsDataLayer.SelectDataTable(cmdReadPerfmncTmplt);
            }
            return dtReadPrfmcEvltion;

        }
        public DataTable ReadPerfomanceEvaluationCount(clsEntity_Emp_perfomance_Evaluation objEntityPermne_Evltion)
        {
            DataTable dtReadPrfmcEvltion = new DataTable();
            using (OracleCommand cmdReadPerfmncTmplt = new OracleCommand())
            {
                cmdReadPerfmncTmplt.CommandText = "HCM_EMP_PERFOMANCE_EVALUATION.SP_READ_PRFMNC_EVLTION_COUNT";
                cmdReadPerfmncTmplt.CommandType = CommandType.StoredProcedure;
                cmdReadPerfmncTmplt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPermne_Evltion.OrgId;
                cmdReadPerfmncTmplt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPermne_Evltion.CorpId;
                cmdReadPerfmncTmplt.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtReadPrfmcEvltion = clsDataLayer.SelectDataTable(cmdReadPerfmncTmplt);
            }
            return dtReadPrfmcEvltion;

        }
        public DataTable ReadPerfomanceEvltionById(clsEntity_Emp_perfomance_Evaluation objEntityPermne_Evltion)
        {
            DataTable dtReadPrfmcEvltn = new DataTable();
            using (OracleCommand cmdReadPerfmncTmplt = new OracleCommand())
            {
                cmdReadPerfmncTmplt.CommandText = "HCM_EMP_PERFOMANCE_EVALUATION.SP_READ_PRFMNC_EVLTION_BYID";
                cmdReadPerfmncTmplt.CommandType = CommandType.StoredProcedure;
                cmdReadPerfmncTmplt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPermne_Evltion.OrgId;
                cmdReadPerfmncTmplt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPermne_Evltion.CorpId;
                cmdReadPerfmncTmplt.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = objEntityPermne_Evltion.EmpUsrId;
                cmdReadPerfmncTmplt.Parameters.Add("P_ISSUEID", OracleDbType.Int32).Value = objEntityPermne_Evltion.IssueId;
                cmdReadPerfmncTmplt.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtReadPrfmcEvltn = clsDataLayer.SelectDataTable(cmdReadPerfmncTmplt);
            }
            return dtReadPrfmcEvltn;
        }
        public DataTable ReadGrpQstnById(clsEntity_Emp_perfomance_Evaluation objEntityPermne_Evltion)
        {
            DataTable dtReadPrfmcEvltn = new DataTable();
            using (OracleCommand cmdReadPerfmncTmplt = new OracleCommand())
            {
                cmdReadPerfmncTmplt.CommandText = "HCM_EMP_PERFOMANCE_EVALUATION.SP_READ_GRP_BYID";
                cmdReadPerfmncTmplt.CommandType = CommandType.StoredProcedure;
                cmdReadPerfmncTmplt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPermne_Evltion.OrgId;
                cmdReadPerfmncTmplt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPermne_Evltion.CorpId;
                cmdReadPerfmncTmplt.Parameters.Add("P_ISSUEID", OracleDbType.Int32).Value = objEntityPermne_Evltion.IssueId;
                cmdReadPerfmncTmplt.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtReadPrfmcEvltn = clsDataLayer.SelectDataTable(cmdReadPerfmncTmplt);
            }
            return dtReadPrfmcEvltn;
        }
        public DataTable ReadGrpId(clsEntity_Emp_perfomance_Evaluation objEntityPermne_Evltion)
        {
            DataTable dtReadPrfmcEvltn = new DataTable();
            using (OracleCommand cmdReadPerfmncTmplt = new OracleCommand())
            {
                cmdReadPerfmncTmplt.CommandText = "HCM_EMP_PERFOMANCE_EVALUATION.SP_READ_GRP_ID";
                cmdReadPerfmncTmplt.CommandType = CommandType.StoredProcedure;
                cmdReadPerfmncTmplt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPermne_Evltion.OrgId;
                cmdReadPerfmncTmplt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPermne_Evltion.CorpId;
                cmdReadPerfmncTmplt.Parameters.Add("P_ISSUEID", OracleDbType.Int32).Value = objEntityPermne_Evltion.IssueId;
                cmdReadPerfmncTmplt.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtReadPrfmcEvltn = clsDataLayer.SelectDataTable(cmdReadPerfmncTmplt);
            }
            return dtReadPrfmcEvltn;
        }
        public DataTable ReadQstnById(clsEntity_Emp_perfomance_Evaluation objEntityPermne_Evltion)
        {
            DataTable dtReadPrfmcEvltn = new DataTable();
            using (OracleCommand cmdReadPerfmncTmplt = new OracleCommand())
            {
                cmdReadPerfmncTmplt.CommandText = "HCM_EMP_PERFOMANCE_EVALUATION.SP_READ_QSTN_BY_ID";
                cmdReadPerfmncTmplt.CommandType = CommandType.StoredProcedure;
                cmdReadPerfmncTmplt.Parameters.Add("P_QSTN_STS", OracleDbType.Int32).Value = objEntityPermne_Evltion.QstnSts;
                cmdReadPerfmncTmplt.Parameters.Add("P_QSTN_ID", OracleDbType.Varchar2).Value = objEntityPermne_Evltion.QustnId;
                cmdReadPerfmncTmplt.Parameters.Add("P_GRP_ID", OracleDbType.Int32).Value = objEntityPermne_Evltion.GrpId;
                cmdReadPerfmncTmplt.Parameters.Add("P_ISSUEID", OracleDbType.Int32).Value = objEntityPermne_Evltion.IssueId;
                cmdReadPerfmncTmplt.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtReadPrfmcEvltn = clsDataLayer.SelectDataTable(cmdReadPerfmncTmplt);
            }
            return dtReadPrfmcEvltn;
        }

        public void insert_Evaluatn_Dtls(clsEntity_Emp_perfomance_Evaluation objEntity, List<clsEntity_Emp_perfomance_Evaluation> objGrp, List<clsEntity_Emp_perfomance_Evaluation> objTotalList)
        {
            OracleTransaction tran;

            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    clsEntityCommon objEntityCommon = new clsEntityCommon();
                    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PERFOMANCE_EVALUATION);
                    objEntityCommon.CorporateID = objEntity.CorpId;
                    objEntityCommon.Organisation_Id = objEntity.OrgId;
                    string strNextId = objDatatLayer.ReadNextNumberWebForUI(objEntityCommon);
                    //objEntity.EvltnId=
                    string strQueryInsertUser = "HCM_EMP_PERFOMANCE_EVALUATION.SP_INSERT_EVLTN_MSTR";
                    using (OracleCommand cmdInsertEvltn = new OracleCommand())
                    {
                        cmdInsertEvltn.Transaction = tran;
                        cmdInsertEvltn.Connection = con;
                        cmdInsertEvltn.CommandText = strQueryInsertUser;
                        cmdInsertEvltn.CommandType = CommandType.StoredProcedure;
                        cmdInsertEvltn.Parameters.Add("P_EVLTN_ID", OracleDbType.Int32).Value = strNextId;
                        cmdInsertEvltn.Parameters.Add("P_TMPLT_ID", OracleDbType.Int32).Value = objEntity.PerfomanceId;
                        cmdInsertEvltn.Parameters.Add("P_ISSUE_ID", OracleDbType.Int32).Value = objEntity.IssueId;
                        cmdInsertEvltn.Parameters.Add("USR_ID", OracleDbType.Int32).Value = objEntity.EmpUsrId;
                        cmdInsertEvltn.Parameters.Add("EVL_USRID", OracleDbType.Int32).Value = objEntity.UsrId;
                        cmdInsertEvltn.Parameters.Add("EVL_RSPNSTYP", OracleDbType.Int32).Value = objEntity.EmpTyp;
                        cmdInsertEvltn.Parameters.Add("EVL_GOAL", OracleDbType.Varchar2).Value = objEntity.EvlComment;

                        cmdInsertEvltn.Parameters.Add("ORGID", OracleDbType.Int32).Value = objEntity.OrgId;
                        cmdInsertEvltn.Parameters.Add("CORPID", OracleDbType.Int32).Value = objEntity.CorpId;
                        cmdInsertEvltn.ExecuteNonQuery();
                    }
                    foreach (clsEntity_Emp_perfomance_Evaluation objGrpList in objGrp)
                    {

                        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PERFOMANCE_EVALUATION_GRP);
                        objEntityCommon.CorporateID = objEntity.CorpId;
                        objEntityCommon.Organisation_Id = objEntity.OrgId;
                        string strGrpNextId = objDatatLayer.ReadNextNumberWebForUI(objEntityCommon);


                        string strQueryInsertGrp = "HCM_EMP_PERFOMANCE_EVALUATION.SP_INSERT_EVLTN_GRP";
                        using (OracleCommand cmdInsertEvltn = new OracleCommand())
                        {
                            cmdInsertEvltn.Transaction = tran;
                            cmdInsertEvltn.Connection = con;
                            cmdInsertEvltn.CommandText = strQueryInsertGrp;
                            cmdInsertEvltn.CommandType = CommandType.StoredProcedure;
                            cmdInsertEvltn.Parameters.Add("P_EVLTN_GRP_ID", OracleDbType.Int32).Value = strGrpNextId;
                            cmdInsertEvltn.Parameters.Add("P_EVLTN_ID", OracleDbType.Int32).Value = strNextId;
                            cmdInsertEvltn.Parameters.Add("P_GRP_ID", OracleDbType.Int32).Value = objGrpList.GrpId;

                            cmdInsertEvltn.ExecuteNonQuery();
                        }

                        foreach (clsEntity_Emp_perfomance_Evaluation objList in objTotalList)
                        {

                            if (objList.GrpId == objGrpList.GrpId)
                            {
                                string strQueryInsertQstn = "HCM_EMP_PERFOMANCE_EVALUATION.SP_INSERT_EVLTN_QSTN";
                                using (OracleCommand cmdInsertEvltn = new OracleCommand())
                                {
                                    cmdInsertEvltn.Transaction = tran;
                                    cmdInsertEvltn.Connection = con;
                                    cmdInsertEvltn.CommandText = strQueryInsertQstn;
                                    cmdInsertEvltn.CommandType = CommandType.StoredProcedure;
                                    cmdInsertEvltn.Parameters.Add("P_EVLTN_GRP_ID", OracleDbType.Int32).Value = strGrpNextId;
                                    cmdInsertEvltn.Parameters.Add("P_EVLTN_ID", OracleDbType.Int32).Value = strNextId;

                                    cmdInsertEvltn.Parameters.Add("P_QSTN_ID", OracleDbType.Int32).Value = objList.QstnId;
                                    cmdInsertEvltn.Parameters.Add("P_TYP", OracleDbType.Int32).Value = objList.RspnTypeId;
                                    if (objList.RspnTypeId == 0)
                                    {
                                        cmdInsertEvltn.Parameters.Add("P_TEXT", OracleDbType.Varchar2).Value = objList.RateText;
                                        cmdInsertEvltn.Parameters.Add("P_RATE", OracleDbType.Int32).Value = null;
                                        cmdInsertEvltn.Parameters.Add("P_CHECK", OracleDbType.Int32).Value = null;
                                    }
                                    else if (objList.RspnTypeId == 1)
                                    {
                                        cmdInsertEvltn.Parameters.Add("P_TEXT", OracleDbType.Varchar2).Value = null;
                                        cmdInsertEvltn.Parameters.Add("P_RATE", OracleDbType.Int32).Value = objList.RateList;
                                        cmdInsertEvltn.Parameters.Add("P_CHECK", OracleDbType.Int32).Value = null;
                                    }

                                    else if (objList.RspnTypeId == 2)
                                    {
                                        cmdInsertEvltn.Parameters.Add("P_TEXT", OracleDbType.Varchar2).Value = null;
                                        cmdInsertEvltn.Parameters.Add("P_RATE", OracleDbType.Int32).Value = null;
                                        cmdInsertEvltn.Parameters.Add("P_CHECK", OracleDbType.Int32).Value = objList.Ratechk;

                                    }
                                    cmdInsertEvltn.ExecuteNonQuery();
                                }
                            }
                        }



                    }


                    tran.Commit();
                }

                   // tran.Commit();


                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;

                }

            }
        }

        public DataTable ReadEvltnAns(clsEntity_Emp_perfomance_Evaluation objEntityPermne_Evltion)
        {
            DataTable dtReadPrfmcEvltn = new DataTable();
            using (OracleCommand cmdReadPerfmncTmplt = new OracleCommand())
            {
                cmdReadPerfmncTmplt.CommandText = "HCM_EMP_PERFOMANCE_EVALUATION.SP_READ_PRFMNC_EVLTION_ANS";
                cmdReadPerfmncTmplt.CommandType = CommandType.StoredProcedure;
                cmdReadPerfmncTmplt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPermne_Evltion.OrgId;
                cmdReadPerfmncTmplt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPermne_Evltion.CorpId;
                cmdReadPerfmncTmplt.Parameters.Add("P_ISSUEID", OracleDbType.Int32).Value = objEntityPermne_Evltion.IssueId;
                cmdReadPerfmncTmplt.Parameters.Add("P_TMPLTID", OracleDbType.Int32).Value = objEntityPermne_Evltion.PerfomanceId;
                cmdReadPerfmncTmplt.Parameters.Add("P_EMP_USR_ID", OracleDbType.Int32).Value = objEntityPermne_Evltion.EmpUsrId;
                cmdReadPerfmncTmplt.Parameters.Add("P_EVLTR_UID", OracleDbType.Int32).Value = objEntityPermne_Evltion.UsrId;
                cmdReadPerfmncTmplt.Parameters.Add("P_RSPNS_TYP", OracleDbType.Int32).Value = objEntityPermne_Evltion.RspnTypeId;
                cmdReadPerfmncTmplt.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtReadPrfmcEvltn = clsDataLayer.SelectDataTable(cmdReadPerfmncTmplt);
            }
            return dtReadPrfmcEvltn;
        }

        public DataTable ReadEvltnAnsById(clsEntity_Emp_perfomance_Evaluation objEntityPermne_Evltion)
        {
            DataTable dtReadPrfmcEvltn = new DataTable();
            using (OracleCommand cmdReadPerfmncTmplt = new OracleCommand())
            {
                cmdReadPerfmncTmplt.CommandText = "HCM_EMP_PERFOMANCE_EVALUATION.SP_READ_ANS_QSTN_BY_ID";
                cmdReadPerfmncTmplt.CommandType = CommandType.StoredProcedure;
                cmdReadPerfmncTmplt.Parameters.Add("P_EEVLTN_GRP_ID", OracleDbType.Int32).Value = objEntityPermne_Evltion.EvltnGrpId;
                cmdReadPerfmncTmplt.Parameters.Add("P_GRP_ID", OracleDbType.Int32).Value = objEntityPermne_Evltion.GrpId;
                cmdReadPerfmncTmplt.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtReadPrfmcEvltn = clsDataLayer.SelectDataTable(cmdReadPerfmncTmplt);
            }
            return dtReadPrfmcEvltn;
        }
        public DataTable ReadEvltnGrpAns(clsEntity_Emp_perfomance_Evaluation objEntityPermne_Evltion)
        {
            DataTable dtReadPrfmcEvltn = new DataTable();
            using (OracleCommand cmdReadPerfmncTmplt = new OracleCommand())
            {
                cmdReadPerfmncTmplt.CommandText = "HCM_EMP_PERFOMANCE_EVALUATION.SP_READ_ANS_GRP_ID";
                cmdReadPerfmncTmplt.CommandType = CommandType.StoredProcedure;
                cmdReadPerfmncTmplt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPermne_Evltion.OrgId;
                cmdReadPerfmncTmplt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPermne_Evltion.CorpId;
                cmdReadPerfmncTmplt.Parameters.Add("P_ISSUEID", OracleDbType.Int32).Value = objEntityPermne_Evltion.IssueId;
                cmdReadPerfmncTmplt.Parameters.Add("P_TMPLTID", OracleDbType.Int32).Value = objEntityPermne_Evltion.PerfomanceId;
                cmdReadPerfmncTmplt.Parameters.Add("P_EMP_USR_ID", OracleDbType.Int32).Value = objEntityPermne_Evltion.EmpUsrId;
                cmdReadPerfmncTmplt.Parameters.Add("P_EVLTR_UID", OracleDbType.Int32).Value = objEntityPermne_Evltion.UsrId;
                cmdReadPerfmncTmplt.Parameters.Add("P_RSPNS_TYP", OracleDbType.Int32).Value = objEntityPermne_Evltion.RspnTypeId;
                cmdReadPerfmncTmplt.Parameters.Add("P_GRP_ID", OracleDbType.Int32).Value = objEntityPermne_Evltion.GrpId;
                cmdReadPerfmncTmplt.Parameters.Add("P_EVLTN_ID", OracleDbType.Int32).Value = objEntityPermne_Evltion.EvltnId;
                cmdReadPerfmncTmplt.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtReadPrfmcEvltn = clsDataLayer.SelectDataTable(cmdReadPerfmncTmplt);
            }
            return dtReadPrfmcEvltn;
        }

        public void Update_Evaluatn_Dtls(clsEntity_Emp_perfomance_Evaluation objEntity, List<clsEntity_Emp_perfomance_Evaluation> objGrp, List<clsEntity_Emp_perfomance_Evaluation> objTotalList)
        {
            OracleTransaction tran;

            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {

                    //objEntity.EvltnId=
                    string strQueryInsertUser = "HCM_EMP_PERFOMANCE_EVALUATION.SP_UPDATE_EVLTN_MSTR";
                    using (OracleCommand cmdInsertEvltn = new OracleCommand())
                    {
                        cmdInsertEvltn.Transaction = tran;
                        cmdInsertEvltn.Connection = con;
                        cmdInsertEvltn.CommandText = strQueryInsertUser;
                        cmdInsertEvltn.CommandType = CommandType.StoredProcedure;
                        cmdInsertEvltn.Parameters.Add("P_EVLTN_ID", OracleDbType.Int32).Value = objEntity.EvltnId;
                        cmdInsertEvltn.Parameters.Add("EVL_GOAL", OracleDbType.Varchar2).Value = objEntity.EvlComment;
                        cmdInsertEvltn.ExecuteNonQuery();
                    }

                    foreach (clsEntity_Emp_perfomance_Evaluation objList in objTotalList)
                    {


                        string strQueryInsertQstn = "HCM_EMP_PERFOMANCE_EVALUATION.SP_UPD_EVLTN_QSTN";
                        using (OracleCommand cmdInsertEvltn = new OracleCommand())
                        {
                            cmdInsertEvltn.Transaction = tran;
                            cmdInsertEvltn.Connection = con;
                            cmdInsertEvltn.CommandText = strQueryInsertQstn;
                            cmdInsertEvltn.CommandType = CommandType.StoredProcedure;
                            cmdInsertEvltn.Parameters.Add("P_QSTN_ID", OracleDbType.Int32).Value = objList.EvltnQstnId;

                            if (objList.RspnTypeId == 0)
                            {
                                cmdInsertEvltn.Parameters.Add("P_TEXT", OracleDbType.Varchar2).Value = objList.RateText;
                                cmdInsertEvltn.Parameters.Add("P_RATE", OracleDbType.Int32).Value = null;
                                cmdInsertEvltn.Parameters.Add("P_CHECK", OracleDbType.Int32).Value = null;
                            }
                            else if (objList.RspnTypeId == 1)
                            {
                                cmdInsertEvltn.Parameters.Add("P_TEXT", OracleDbType.Varchar2).Value = null;
                                cmdInsertEvltn.Parameters.Add("P_RATE", OracleDbType.Int32).Value = objList.RateList;
                                cmdInsertEvltn.Parameters.Add("P_CHECK", OracleDbType.Int32).Value = null;
                            }

                            else if (objList.RspnTypeId == 2)
                            {
                                cmdInsertEvltn.Parameters.Add("P_TEXT", OracleDbType.Varchar2).Value = null;
                                cmdInsertEvltn.Parameters.Add("P_RATE", OracleDbType.Int32).Value = null;
                                cmdInsertEvltn.Parameters.Add("P_CHECK", OracleDbType.Int32).Value = objList.Ratechk;

                            }
                            cmdInsertEvltn.ExecuteNonQuery();
                        }

                    }






                    tran.Commit();
                }

                   // tran.Commit();


                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;

                }

            }
        }
        public void Cnfrm_Evaluatn_Dtls(clsEntity_Emp_perfomance_Evaluation objEntity)
        {
            OracleTransaction tran;

            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {

                    //objEntity.EvltnId=
                    string strQueryInsertUser = "HCM_EMP_PERFOMANCE_EVALUATION.SP_CNFRM_EVLTN_MSTR";
                    using (OracleCommand cmdInsertEvltn = new OracleCommand())
                    {
                        cmdInsertEvltn.Transaction = tran;
                        cmdInsertEvltn.Connection = con;
                        cmdInsertEvltn.CommandText = strQueryInsertUser;
                        cmdInsertEvltn.CommandType = CommandType.StoredProcedure;
                        cmdInsertEvltn.Parameters.Add("P_EVLTN_ID", OracleDbType.Int32).Value = objEntity.EvltnId;
                        cmdInsertEvltn.ExecuteNonQuery();
                    }

                  

                    tran.Commit();
                }

                   // tran.Commit();


                catch (Exception e)
                {
                    tran.Rollback();
                    throw e;

                }

            }
        }

        public DataTable ReadUsrDtls(clsEntity_Emp_perfomance_Evaluation objEntityPermne_Evltion)
        {
            DataTable dtReadPrfmcEvltn = new DataTable();
            using (OracleCommand cmdReadPerfmncTmplt = new OracleCommand())
            {
                cmdReadPerfmncTmplt.CommandText = "HCM_EMP_PERFOMANCE_EVALUATION.SP_READ_EMPLOYEE_DTLS_BYID";
                cmdReadPerfmncTmplt.CommandType = CommandType.StoredProcedure;
                cmdReadPerfmncTmplt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPermne_Evltion.OrgId;
                cmdReadPerfmncTmplt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPermne_Evltion.CorpId;
                cmdReadPerfmncTmplt.Parameters.Add("P_TYP", OracleDbType.Int32).Value = objEntityPermne_Evltion.EmpTyp;
                cmdReadPerfmncTmplt.Parameters.Add("P_ISSUEID", OracleDbType.Int32).Value = objEntityPermne_Evltion.IssueId;
                cmdReadPerfmncTmplt.Parameters.Add("P_ISSUE_EMP_ID", OracleDbType.Int32).Value = objEntityPermne_Evltion.IssueEmpId;
                cmdReadPerfmncTmplt.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtReadPrfmcEvltn = clsDataLayer.SelectDataTable(cmdReadPerfmncTmplt);
            }
            return dtReadPrfmcEvltn;
        }
        public DataTable ReadEvltrsDtls(clsEntity_Emp_perfomance_Evaluation objEntityPermne_Evltion)
        {
            DataTable dtReadPrfmcEvltn = new DataTable();
            using (OracleCommand cmdReadPerfmncTmplt = new OracleCommand())
            {
                cmdReadPerfmncTmplt.CommandText = "HCM_EMP_PERFOMANCE_EVALUATION.SP_READ_EVLTRS_DTLS_BYID";
                cmdReadPerfmncTmplt.CommandType = CommandType.StoredProcedure;
                cmdReadPerfmncTmplt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPermne_Evltion.OrgId;
                cmdReadPerfmncTmplt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPermne_Evltion.CorpId;
                cmdReadPerfmncTmplt.Parameters.Add("P_TYP", OracleDbType.Int32).Value = objEntityPermne_Evltion.EmpTyp;
                cmdReadPerfmncTmplt.Parameters.Add("P_ISSUEID", OracleDbType.Int32).Value = objEntityPermne_Evltion.IssueId;
                cmdReadPerfmncTmplt.Parameters.Add("P_ISSUE_EMP_ID", OracleDbType.Int32).Value = objEntityPermne_Evltion.IssueEmpId;
                cmdReadPerfmncTmplt.Parameters.Add("P_ISSUE_EVLTR_ID", OracleDbType.Int32).Value = objEntityPermne_Evltion.UsrId;
                cmdReadPerfmncTmplt.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtReadPrfmcEvltn = clsDataLayer.SelectDataTable(cmdReadPerfmncTmplt);
            }
            return dtReadPrfmcEvltn;
        }
        public DataTable ReadUsrEvltr(clsEntity_Emp_perfomance_Evaluation objEntityPermne_Evltion)
        {
            DataTable dtReadPrfmcEvltn = new DataTable();
            using (OracleCommand cmdReadPerfmncTmplt = new OracleCommand())
            {
                cmdReadPerfmncTmplt.CommandText = "HCM_EMP_PERFOMANCE_EVALUATION.SP_READ_EVLTR_BYID";
                cmdReadPerfmncTmplt.CommandType = CommandType.StoredProcedure;
                cmdReadPerfmncTmplt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPermne_Evltion.OrgId;
                cmdReadPerfmncTmplt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPermne_Evltion.CorpId;
                cmdReadPerfmncTmplt.Parameters.Add("P_DEPT_ID", OracleDbType.Int32).Value = objEntityPermne_Evltion.DeptId;
                cmdReadPerfmncTmplt.Parameters.Add("P_DESG_ID", OracleDbType.Int32).Value = objEntityPermne_Evltion.DesgId;
                cmdReadPerfmncTmplt.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = objEntityPermne_Evltion.UsrId;
                cmdReadPerfmncTmplt.Parameters.Add("P_ISSUE_ID", OracleDbType.Int32).Value = objEntityPermne_Evltion.IssueId;
                cmdReadPerfmncTmplt.Parameters.Add("P_ISSUE_TYP", OracleDbType.Int32).Value = objEntityPermne_Evltion.IssueType;
                cmdReadPerfmncTmplt.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtReadPrfmcEvltn = clsDataLayer.SelectDataTable(cmdReadPerfmncTmplt);
            }
            return dtReadPrfmcEvltn;
        }
        public DataTable ReadUsrDesgDept(clsEntity_Emp_perfomance_Evaluation objEntityPermne_Evltion)
        {
            DataTable dtReadPrfmcEvltn = new DataTable();
            using (OracleCommand cmdReadPerfmncTmplt = new OracleCommand())
            {
                cmdReadPerfmncTmplt.CommandText = "HCM_EMP_PERFOMANCE_EVALUATION.SP_READ_USR_DTLS_BYID";
                cmdReadPerfmncTmplt.CommandType = CommandType.StoredProcedure;
                cmdReadPerfmncTmplt.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPermne_Evltion.OrgId;
                cmdReadPerfmncTmplt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPermne_Evltion.CorpId;
                cmdReadPerfmncTmplt.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityPermne_Evltion.UsrId;
                cmdReadPerfmncTmplt.Parameters.Add("POUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtReadPrfmcEvltn = clsDataLayer.SelectDataTable(cmdReadPerfmncTmplt);
            }
            return dtReadPrfmcEvltn;
        }
 
   
    }
}