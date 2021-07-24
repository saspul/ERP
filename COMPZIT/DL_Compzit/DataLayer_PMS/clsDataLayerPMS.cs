using System;  
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_PMS;
using EL_Compzit;
/// <summary>
/// Summary description for clsDataLayerPMS
/// </summary>
/// 
namespace DL_Compzit.DataLayer_PMS
{
    public class clsDataLayerPMS
    {
        public DataTable ReadDocument()
        {
            string strQueryReadCountry = "PMS_APPROVALSET.SP_LOAD_DOCUMENTS";
            using (OracleCommand cmdReadType = new OracleCommand())
            {
                cmdReadType.CommandText = strQueryReadCountry;
                cmdReadType.CommandType = CommandType.StoredProcedure;
                cmdReadType.Parameters.Add("APPROVALSET_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtType = new DataTable();
                dtType = clsDataLayer.SelectDataTable(cmdReadType);
                return dtType;
            }
        }
        public DataTable ReadDepartments(clsEntityApprovalHierarchyTemp objEntity)
        {
            string strQueryReadCountry = "DOCUMENT_WORKFLOW.SP_SELECT_CORP_DEPT";
            OracleCommand cmdReadType = new OracleCommand();
                cmdReadType.CommandText = strQueryReadCountry;
                cmdReadType.CommandType = CommandType.StoredProcedure;
                cmdReadType.Parameters.Add("A_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
                cmdReadType.Parameters.Add("A_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
                cmdReadType.Parameters.Add("D_DEPT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtType = new DataTable();
                dtType = clsDataLayer.SelectDataTable(cmdReadType);
                return dtType;
           
        }
        public DataTable ReadDivisions(clsEntityApprovalHierarchyTemp objEntity)
        {
            string strQueryReadCountry = "DOCUMENT_WORKFLOW.SP_SELECT_CORP_DIV";
            OracleCommand cmdReadType = new OracleCommand();
             cmdReadType.CommandText = strQueryReadCountry;
                cmdReadType.CommandType = CommandType.StoredProcedure;
                cmdReadType.Parameters.Add("A_ORGID", OracleDbType.Int32).Value = objEntity.Organisation_id;
                cmdReadType.Parameters.Add("A_CORPID", OracleDbType.Int32).Value = objEntity.Corporate_id;
                cmdReadType.Parameters.Add("D_DIV", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtType = new DataTable();
                dtType = clsDataLayer.SelectDataTable(cmdReadType);
                return dtType;
          
        }
        public DataTable ReadHrchyName()
        {
            string strQueryReadCountry = "APPROVAL_HIERARCHY_TEMP.SP_READ_TEMP_NAME";
            using (OracleCommand cmdReadType = new OracleCommand())
            {
                cmdReadType.CommandText = strQueryReadCountry;
                cmdReadType.CommandType = CommandType.StoredProcedure;
                cmdReadType.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtType = new DataTable();
                dtType = clsDataLayer.SelectDataTable(cmdReadType);
                return dtType;
            }
        }
        public DataTable ReadDocumentwrk()
        {
            string strQueryReadAccommodation = "DOCUMENT_WORKFLOW.SP_READ_DOCUMENT";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public DataTable ReadDocwrkflw(clsEntityApprovalHierarchyTemp objentityPass1)
        {
            string strQueryReadAccommodation = "DOCUMENT_WORKFLOW.SP_READ_DOCWRKFLW";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("ADOC_ID", OracleDbType.Varchar2).Value = objentityPass1.Doc;
            cmdReadAccommodation.Parameters.Add("WRK_STS", OracleDbType.Int32).Value = objentityPass1.Status_id;
            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public DataTable ReadApprovalAss(clsEntityApprovalHierarchyTemp objentityPass1)
        {
            string strQueryReadAccommodation = "DOCUMENT_WORKFLOW.SP_READ_APPROVLA_ASSIGNMENT";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;

            cmdReadAccommodation.Parameters.Add("WRK_ID", OracleDbType.Int32).Value = objentityPass1.TempId;
            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public DataTable ReadDocwrkflwsts(clsEntityApprovalHierarchyTemp objentityPass1)
        {
            string strQueryReadAccommodation = "DOCUMENT_WORKFLOW.SP_READ_DOCWRKFLWSTS";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("A_ST", OracleDbType.Int32).Value = objentityPass1.Status_id;
            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public DataTable ReadDocwrkflwparent()
        {
            string strQueryReadAccommodation = "DOCUMENT_WORKFLOW.SP_READ_DOC_PAREN_DTLS";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public DataTable ReadDocwrkflwcncl()
        {
            string strQueryReadAccommodation = "DOCUMENT_WORKFLOW.SP_READ_DOCWRKFLWCNCL";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public DataTable Readwrkflwdtls(clsEntityApprovalHierarchyTemp objentityPass1)
        {
            string strQueryReadAccommodation = "DOCUMENT_WORKFLOW.SP_READ_DOCUMENTDTL";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("WRK_ID", OracleDbType.Int32).Value = objentityPass1.TempId;
            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public DataTable selectdep(clsEntityApprovalHierarchyTemp objentityPass1)
        {
            string strQueryReadAccommodation = "APPROVAL_HIERARCHY_TEMP.SP_SELECT_CORPDEPT";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("D_ID", OracleDbType.Varchar2).Value = objentityPass1.Dep;
            cmdReadAccommodation.Parameters.Add("D_DEPT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public DataTable selectdiv(clsEntityApprovalHierarchyTemp objentityPass1)
        {
            string strQueryReadAccommodation = "CORPORATE_DIVISION.SP_SELECT_CORPDIV";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("D_ID", OracleDbType.Varchar2).Value = objentityPass1.div;
            cmdReadAccommodation.Parameters.Add("D_DIV", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public DataTable Readwrkflwdi(clsEntityApprovalHierarchyTemp objentityPass1)
        {
            string strQueryReadAccommodation = "DOCUMENT_WORKFLOW.SP_READ_DOCWRKFLWID";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;

            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }

        public DataTable Readwrkflwparentid(clsEntityApprovalHierarchyTemp objentityPass1)
        {
            string strQueryReadAccommodation = "DOCUMENT_WORKFLOW.SP_READ_DOCWRKFLWPARENTID";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;

            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public DataTable Readwrkflwdid1(clsEntityApprovalHierarchyTemp objentityPass1)
        {
            string strQueryReadAccommodation = "DOCUMENT_WORKFLOW.SP_READ_DOCWRKFLWID1";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("A_NAME", OracleDbType.Varchar2).Value = objentityPass1.Name;
            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public void StatusChangeDocwrk(clsEntityApprovalHierarchyTemp objentityPass1)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQuery = "DOCUMENT_WORKFLOW.SP_STATUSCHNG_DOCWRKFLW";
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    using (OracleCommand cmdAddService = new OracleCommand(strQuery, con))
                    {
                        cmdAddService.Transaction = tran;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.CommandText = strQuery;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.Parameters.Add("P_ID", OracleDbType.Int32).Value = objentityPass1.TempId;
                        cmdAddService.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objentityPass1.Status_id;
                        clsDataLayer.ExecuteNonQuery(cmdAddService);
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

        public DataTable ReadSubtableDtls(clsEntityApprovalHierarchyTemp objEntityAcco)
        {
            string strQueryReadAccommodation = "DOCUMENT_WORKFLOW.SP_READ_SUBTABLE_DTL";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("A_ORGID", OracleDbType.Int32).Value = objEntityAcco.Organisation_id;
            cmdReadAccommodation.Parameters.Add("A_CORPID", OracleDbType.Int32).Value = objEntityAcco.Corporate_id;
            cmdReadAccommodation.Parameters.Add("A_ID", OracleDbType.Int32).Value = objEntityAcco.TempId;
            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }

        public void InsertDocumentWorkflow(clsEntityApprovalHierarchyTemp objEntityWrkflow, List<clsEntityApprovalHierarchyTemp> objEntityWrkflowMainList, List<clsEntityApprovalHierarchyTemp> objEntityWrkflowSubList, List<clsEntityApprovalHierarchyTemp> objEntitySubstituteList, List<clsEntityApprovalHierarchyTemp> objEntityApprvlRulesList)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryLeaveTyp = "DOCUMENT_WORKFLOW.SP_INSERT_WRKFLW";
                    using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp, con))
                    {
                        cmdAddService.Transaction = tran;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.Parameters.Add("P_CORPRT_ID", OracleDbType.Int32).Value = objEntityWrkflow.Corporate_id;
                        cmdAddService.Parameters.Add("P_ORG_ID", OracleDbType.Int32).Value = objEntityWrkflow.Organisation_id;
                        cmdAddService.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = objEntityWrkflow.User_Id;
                        cmdAddService.Parameters.Add("P_WRKFLW_NAME", OracleDbType.Varchar2).Value = objEntityWrkflow.Name;
                        cmdAddService.Parameters.Add("P_DOC_ID", OracleDbType.Int32).Value = objEntityWrkflow.Doc;
                        cmdAddService.Parameters.Add("P_WRKFLW_STATUS", OracleDbType.Int32).Value = objEntityWrkflow.Status_id;
                        cmdAddService.Parameters.Add("P_WRKFLW_DESCRIPTN", OracleDbType.Varchar2).Value = objEntityWrkflow.descr;
                        cmdAddService.Parameters.Add("P_WRKFLW_APRVL_TRNSFR", OracleDbType.Int32).Value = objEntityWrkflow.apptrans;
                        cmdAddService.Parameters.Add("P_WRKFLW_APRVR_MODFY", OracleDbType.Int32).Value = objEntityWrkflow.appmdf;
                        cmdAddService.Parameters.Add("P_WRKFLW_PRIORTY", OracleDbType.Int32).Value = objEntityWrkflow.prity;
                        cmdAddService.Parameters.Add("P_WRKFLW_CPRDEPT_IDS", OracleDbType.Varchar2).Value = objEntityWrkflow.Dep;
                        cmdAddService.Parameters.Add("P_WRKFLW_CPRDIV_IDS", OracleDbType.Varchar2).Value = objEntityWrkflow.div;
                        cmdAddService.Parameters.Add("P_HRCHY_ID", OracleDbType.Int32).Value = objEntityWrkflow.hrid;
                        cmdAddService.Parameters.Add("P_WRKFLW_APRVL_PNDNG_MSG_STS", OracleDbType.Int32).Value = objEntityWrkflow.appnd;
                        cmdAddService.Parameters.Add("P_WRKFLW_SMS_MSG_STS", OracleDbType.Int32).Value = objEntityWrkflow.sms;
                        cmdAddService.Parameters.Add("P_WRKFLW_DASHBRD_MSG_STS", OracleDbType.Int32).Value = objEntityWrkflow.dash;
                        cmdAddService.Parameters.Add("P_WRKFLW_TTC_EXCD_MSG_STS", OracleDbType.Int32).Value = objEntityWrkflow.ttc;
                        if (objEntityWrkflow.StartDate != DateTime.MinValue)
                        {
                            cmdAddService.Parameters.Add("P_WRKFLW_STRTDATE", OracleDbType.Date).Value = objEntityWrkflow.StartDate;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("P_WRKFLW_STRTDATE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        if (objEntityWrkflow.EndDate != DateTime.MinValue)
                        {
                            cmdAddService.Parameters.Add("P_WRKFLW_ENDDATE", OracleDbType.Date).Value = objEntityWrkflow.EndDate;
                        }
                        else
                        {
                            cmdAddService.Parameters.Add("P_WRKFLW_ENDDATE", OracleDbType.Date).Value = DBNull.Value;
                        }
                        cmdAddService.Parameters.Add("P_WRKFLW_MAJORITY_APRVL", OracleDbType.Int32).Value = objEntityWrkflow.MajorityAprvSts;
                        cmdAddService.Parameters.Add("P_WRKFLW_SINGLE_APRVL", OracleDbType.Int32).Value = objEntityWrkflow.SingleApprvlSts;
                        cmdAddService.Parameters.Add("P_WRKFLW_APPRVL_RULE_STS", OracleDbType.Int32).Value = objEntityWrkflow.ApprovalRuleSts;

                        cmdAddService.Parameters.Add("P_WRKFLW_ID_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                        cmdAddService.ExecuteNonQuery();
                        string strReturn = cmdAddService.Parameters["P_WRKFLW_ID_OUT"].Value.ToString();
                        objEntityWrkflow.TempId = Convert.ToInt32(strReturn);
                    }

                    foreach (clsEntityApprovalHierarchyTemp objDetail in objEntityApprvlRulesList)
                    {
                        string strQueryInsertSubDetails = "DOCUMENT_WORKFLOW.SP_INSERT_APPRVL_RULES";
                        using (OracleCommand cmdSubDetail = new OracleCommand(strQueryInsertSubDetails, con))
                        {
                            cmdSubDetail.Transaction = tran;
                            cmdSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdSubDetail.Parameters.Add("P_WRKFLWRULES_ID", OracleDbType.Int32).Value = objDetail.ApprvlRuleId;
                            cmdSubDetail.Parameters.Add("P_WRKFLW_ID", OracleDbType.Int32).Value = objEntityWrkflow.TempId;
                            cmdSubDetail.Parameters.Add("P_CNDTN_ID", OracleDbType.Int32).Value = objDetail.ConditionId;
                            cmdSubDetail.Parameters.Add("P_CNDTN_TYPE_ID", OracleDbType.Int32).Value = objDetail.ConditionTypeId;
                            if (objDetail.ConditionId == 1)
                            {
                                cmdSubDetail.Parameters.Add("P_WRKFLWRULESVAL_MAXVAL", OracleDbType.Int32).Value = objDetail.MaxVal;
                                cmdSubDetail.Parameters.Add("P_WRKFLWRULESVAL_MINVAL", OracleDbType.Int32).Value = objDetail.MinVal;
                                cmdSubDetail.Parameters.Add("P_WRKFLWRULESVAL_VALUES", OracleDbType.Varchar2).Value = null;
                            }
                            else
                            {
                                cmdSubDetail.Parameters.Add("P_WRKFLWRULESVAL_MAXVAL", OracleDbType.Int32).Value = null;
                                cmdSubDetail.Parameters.Add("P_WRKFLWRULESVAL_MINVAL", OracleDbType.Int32).Value = null;
                                cmdSubDetail.Parameters.Add("P_WRKFLWRULESVAL_VALUES", OracleDbType.Varchar2).Value = objDetail.CondtnValues;
                            }
                            cmdSubDetail.ExecuteNonQuery();
                        }
                    }

                    if (objEntityWrkflowMainList.Count > 0)
                    {
                        int[] WrkFlowDtlId = new int[objEntityWrkflowMainList.Count + objEntityWrkflowSubList.Count];
                        int[] TempDtlId = new int[objEntityWrkflowMainList.Count + objEntityWrkflowSubList.Count];

                        int RowCount = 0;
                        string strReturnSub = "";

                        //Main table
                        string strQueryInsertDetails = "DOCUMENT_WORKFLOW.SP_INSERT_WRKFLW_DTLS";
                        foreach (clsEntityApprovalHierarchyTemp objDetailSub in objEntityWrkflowMainList)
                        {
                            using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                            {
                                cmdAddInsertDetail.Transaction = tran;
                                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDetail.Parameters.Add("P_WRKFLW_ID", OracleDbType.Int32).Value = objEntityWrkflow.TempId;
                                cmdAddInsertDetail.Parameters.Add("P_WRKFLW_PARENT_DTL_ID", OracleDbType.Int32).Value = DBNull.Value;
                                cmdAddInsertDetail.Parameters.Add("P_WRKFLW_LEVEL", OracleDbType.Int32).Value = objDetailSub.Level;
                                cmdAddInsertDetail.Parameters.Add("P_DSGN_ID", OracleDbType.Int32).Value = objDetailSub.DesgId;
                                cmdAddInsertDetail.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = objDetailSub.EmployeeId;
                                cmdAddInsertDetail.Parameters.Add("P_WRKFLW_APRVL_MNDTRY_STS", OracleDbType.Int32).Value = objDetailSub.MajorityAprvSts;
                                cmdAddInsertDetail.Parameters.Add("P_WRKFLW_SUBSTUTE_STS", OracleDbType.Int32).Value = objDetailSub.SubstituteEmpSts;
                                cmdAddInsertDetail.Parameters.Add("P_WRKFLW_THRSHOLD_PRD_STS", OracleDbType.Int32).Value = objDetailSub.ThresholdPeriodMode;
                                cmdAddInsertDetail.Parameters.Add("P_WRKFLW_THRSHOLD_PERIOD", OracleDbType.Int32).Value = objDetailSub.ThresholdPeriodDays;
                                cmdAddInsertDetail.Parameters.Add("P_WRKFLW_APRVL_PENDING_MSG_STS", OracleDbType.Int32).Value = objDetailSub.AprvPendingSts;
                                cmdAddInsertDetail.Parameters.Add("P_WRKFLW_SMS_MSG_STS", OracleDbType.Int32).Value = objDetailSub.SmsSts;
                                cmdAddInsertDetail.Parameters.Add("P_WRKFLW_DASHBRD_MSG_STS ", OracleDbType.Int32).Value = objDetailSub.SystemSts;
                                cmdAddInsertDetail.Parameters.Add("P_WRKFLW_TTC_EXCD_MSG_STS", OracleDbType.Int32).Value = objDetailSub.TtExceededSts;
                                cmdAddInsertDetail.Parameters.Add("P_WRKFLWDTL_APRVR_MODFY", OracleDbType.Int32).Value = objDetailSub.CanModify;
                                cmdAddInsertDetail.Parameters.Add("P_WRKFLWDTL_MAIL_MSG_STS", OracleDbType.Int32).Value = objDetailSub.MailSts;
                                cmdAddInsertDetail.Parameters.Add("P_WRKFLWDTL_SKIP_LEVEL_STS", OracleDbType.Int32).Value = objDetailSub.SkipLvlSts;

                                cmdAddInsertDetail.Parameters.Add("P_WRKFLW_DTLID_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                cmdAddInsertDetail.ExecuteNonQuery();
                                string strReturn = cmdAddInsertDetail.Parameters["P_WRKFLW_DTLID_OUT"].Value.ToString();

                                WrkFlowDtlId[RowCount] = Convert.ToInt32(strReturn);
                                TempDtlId[RowCount] = objDetailSub.TempDtlId;
                            }

                            foreach (clsEntityApprovalHierarchyTemp objSubstutDtl in objEntitySubstituteList)
                            {
                                if (objSubstutDtl.Count == objDetailSub.Count)
                                {
                                    string strQueryInsertSubDetails = "DOCUMENT_WORKFLOW.SP_INSERT_SUBSTITUTE_EMP";
                                    using (OracleCommand cmdSubDetail = new OracleCommand(strQueryInsertSubDetails, con))
                                    {
                                        cmdSubDetail.Transaction = tran;
                                        cmdSubDetail.CommandType = CommandType.StoredProcedure;
                                        cmdSubDetail.Parameters.Add("P_DTL_ID", OracleDbType.Int32).Value = WrkFlowDtlId[RowCount];
                                        cmdSubDetail.Parameters.Add("P_DESG_ID", OracleDbType.Int32).Value = objSubstutDtl.DesgId;
                                        cmdSubDetail.Parameters.Add("P_EMP_ID", OracleDbType.Int32).Value = objSubstutDtl.EmployeeId;
                                        cmdSubDetail.Parameters.Add("P_WRKFLW_ID", OracleDbType.Int32).Value = objEntityWrkflow.TempId;
                                        cmdSubDetail.ExecuteNonQuery();
                                    }
                                }
                            }

                            RowCount++;
                        }

                        //Sub table
                        foreach (clsEntityApprovalHierarchyTemp objDetailSub in objEntityWrkflowSubList)
                        {
                            using (OracleCommand cmdAddInsertDetailSub = new OracleCommand(strQueryInsertDetails, con))
                            {
                                cmdAddInsertDetailSub.Transaction = tran;
                                cmdAddInsertDetailSub.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDetailSub.Parameters.Add("P_WRKFLW_ID", OracleDbType.Int32).Value = objEntityWrkflow.TempId;
                                if (objDetailSub.ParentId != 0)
                                {
                                    cmdAddInsertDetailSub.Parameters.Add("P_WRKFLW_PARENT_DTL_ID", OracleDbType.Int32).Value = WrkFlowDtlId[Array.IndexOf(TempDtlId, objDetailSub.ParentId)];
                                }
                                else
                                {
                                    cmdAddInsertDetailSub.Parameters.Add("P_WRKFLW_PARENT_DTL_ID", OracleDbType.Int32).Value = DBNull.Value;
                                }
                                cmdAddInsertDetailSub.Parameters.Add("P_WRKFLW_LEVEL", OracleDbType.Int32).Value = objDetailSub.Level;
                                cmdAddInsertDetailSub.Parameters.Add("P_DSGN_ID", OracleDbType.Int32).Value = objDetailSub.DesgId;
                                cmdAddInsertDetailSub.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = objDetailSub.EmployeeId;
                                cmdAddInsertDetailSub.Parameters.Add("P_WRKFLW_APRVL_MNDTRY_STS", OracleDbType.Int32).Value = objDetailSub.MajorityAprvSts;
                                cmdAddInsertDetailSub.Parameters.Add("P_WRKFLW_SUBSTUTE_STS", OracleDbType.Int32).Value = objDetailSub.SubstituteEmpSts;
                                cmdAddInsertDetailSub.Parameters.Add("P_WRKFLW_THRSHOLD_PRD_STS", OracleDbType.Int32).Value = objDetailSub.ThresholdPeriodMode;
                                cmdAddInsertDetailSub.Parameters.Add("P_WRKFLW_THRSHOLD_PERIOD", OracleDbType.Int32).Value = objDetailSub.ThresholdPeriodDays;
                                cmdAddInsertDetailSub.Parameters.Add("P_WRKFLW_APRVL_PENDING_MSG_STS", OracleDbType.Int32).Value = objDetailSub.AprvPendingSts;
                                cmdAddInsertDetailSub.Parameters.Add("P_WRKFLW_SMS_MSG_STS", OracleDbType.Int32).Value = objDetailSub.SmsSts;
                                cmdAddInsertDetailSub.Parameters.Add("P_WRKFLW_DASHBRD_MSG_STS ", OracleDbType.Int32).Value = objDetailSub.SystemSts;
                                cmdAddInsertDetailSub.Parameters.Add("P_WRKFLW_TTC_EXCD_MSG_STS", OracleDbType.Int32).Value = objDetailSub.TtExceededSts;
                                cmdAddInsertDetailSub.Parameters.Add("P_WRKFLWDTL_APRVR_MODFY", OracleDbType.Int32).Value = objDetailSub.CanModify;
                                cmdAddInsertDetailSub.Parameters.Add("P_WRKFLWDTL_MAIL_MSG_STS", OracleDbType.Int32).Value = objDetailSub.MailSts;
                                cmdAddInsertDetailSub.Parameters.Add("P_WRKFLWDTL_SKIP_LEVEL_STS", OracleDbType.Int32).Value = objDetailSub.SkipLvlSts;

                                cmdAddInsertDetailSub.Parameters.Add("P_WRKFLW_DTLID_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                cmdAddInsertDetailSub.ExecuteNonQuery();
                                strReturnSub = cmdAddInsertDetailSub.Parameters["P_WRKFLW_DTLID_OUT"].Value.ToString();

                            }

                            WrkFlowDtlId[RowCount] = Convert.ToInt32(strReturnSub);
                            TempDtlId[RowCount] = objDetailSub.TempDtlId;

                            foreach (clsEntityApprovalHierarchyTemp objSubstutDtl in objEntitySubstituteList)
                            {
                                if (objSubstutDtl.Count == objDetailSub.Count)
                                {
                                    string strQueryInsertSubDetails = "DOCUMENT_WORKFLOW.SP_INSERT_SUBSTITUTE_EMP";
                                    using (OracleCommand cmdSubDetail = new OracleCommand(strQueryInsertSubDetails, con))
                                    {
                                        cmdSubDetail.Transaction = tran;
                                        cmdSubDetail.CommandType = CommandType.StoredProcedure;
                                        cmdSubDetail.Parameters.Add("P_DTL_ID", OracleDbType.Int32).Value = WrkFlowDtlId[RowCount];
                                        cmdSubDetail.Parameters.Add("P_DESG_ID", OracleDbType.Int32).Value = objSubstutDtl.DesgId;
                                        cmdSubDetail.Parameters.Add("P_EMP_ID", OracleDbType.Int32).Value = objSubstutDtl.EmployeeId;
                                        cmdSubDetail.Parameters.Add("P_WRKFLW_ID", OracleDbType.Int32).Value = objEntityWrkflow.TempId;
                                        cmdSubDetail.ExecuteNonQuery();
                                    }
                                }
                            }

                            RowCount++;
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

        public DataTable ReadDocumentWrkflowList(clsEntityApprovalHierarchyTemp objEntityWrkflow)
        {
            string strQueryReadAccommodation = "DOCUMENT_WORKFLOW.SP_READ_WRKFLOW_LIST";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityWrkflow.Corporate_id;
            cmdReadAccommodation.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityWrkflow.Organisation_id;
            cmdReadAccommodation.Parameters.Add("P_DOC_ID", OracleDbType.Int32).Value = objEntityWrkflow.Doc;
            cmdReadAccommodation.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityWrkflow.Status_id;
            cmdReadAccommodation.Parameters.Add("P_CNCLSTS", OracleDbType.Int32).Value = objEntityWrkflow.CancelStatus;
            cmdReadAccommodation.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }

        public void UpdateDocumentWorkflow(clsEntityApprovalHierarchyTemp objEntityWrkflow, List<clsEntityApprovalHierarchyTemp> objEntityWrkflowUPDATEList, List<clsEntityApprovalHierarchyTemp> objEntityWrkflowDELETEList, List<clsEntityApprovalHierarchyTemp> objEntityWrkflowMainINSERTList, List<clsEntityApprovalHierarchyTemp> objEntityWrkflowSubINSERTList, List<clsEntityApprovalHierarchyTemp> objEntitySubstituteList, List<clsEntityApprovalHierarchyTemp> objEntityApprvlRulesList, List<clsEntityApprovalHierarchyTemp> objEntityApprvlRulesDELETEList)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    if (objEntityWrkflow.ReplaceApprvrSts == 0)
                    {
                        string strQueryLeaveTyp = "DOCUMENT_WORKFLOW.SP_UPDATE_WRKFLW";
                        using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp, con))
                        {
                            cmdAddService.Transaction = tran;
                            cmdAddService.CommandType = CommandType.StoredProcedure;
                            cmdAddService.Parameters.Add("P_WRKFLW_ID", OracleDbType.Int32).Value = objEntityWrkflow.TempId;
                            cmdAddService.Parameters.Add("P_WRKFLW_NAME", OracleDbType.Varchar2).Value = objEntityWrkflow.Name;
                            cmdAddService.Parameters.Add("P_DOC_ID", OracleDbType.Int32).Value = objEntityWrkflow.Doc;
                            cmdAddService.Parameters.Add("P_WRKFLW_STATUS", OracleDbType.Int32).Value = objEntityWrkflow.Status_id;
                            cmdAddService.Parameters.Add("P_WRKFLW_DESCRIPTN", OracleDbType.Varchar2).Value = objEntityWrkflow.descr;
                            cmdAddService.Parameters.Add("P_WRKFLW_APRVL_TRNSFR", OracleDbType.Int32).Value = objEntityWrkflow.apptrans;
                            cmdAddService.Parameters.Add("P_WRKFLW_APRVR_MODFY", OracleDbType.Int32).Value = objEntityWrkflow.appmdf;
                            cmdAddService.Parameters.Add("P_WRKFLW_PRIORTY", OracleDbType.Int32).Value = objEntityWrkflow.prity;
                            cmdAddService.Parameters.Add("P_WRKFLW_CPRDEPT_IDS", OracleDbType.Varchar2).Value = objEntityWrkflow.Dep;
                            cmdAddService.Parameters.Add("P_WRKFLW_CPRDIV_IDS", OracleDbType.Varchar2).Value = objEntityWrkflow.div;
                            cmdAddService.Parameters.Add("P_HRCHY_ID", OracleDbType.Int32).Value = objEntityWrkflow.hrid;
                            cmdAddService.Parameters.Add("P_WRKFLW_APRVL_PNDNG_MSG_STS", OracleDbType.Int32).Value = objEntityWrkflow.appnd;
                            cmdAddService.Parameters.Add("P_WRKFLW_SMS_MSG_STS", OracleDbType.Int32).Value = objEntityWrkflow.sms;
                            cmdAddService.Parameters.Add("P_WRKFLW_DASHBRD_MSG_STS", OracleDbType.Int32).Value = objEntityWrkflow.dash;
                            cmdAddService.Parameters.Add("P_WRKFLW_TTC_EXCD_MSG_STS", OracleDbType.Int32).Value = objEntityWrkflow.ttc;
                            if (objEntityWrkflow.StartDate != DateTime.MinValue)
                            {
                                cmdAddService.Parameters.Add("P_WRKFLW_STRTDATE", OracleDbType.Date).Value = objEntityWrkflow.StartDate;
                            }
                            else
                            {
                                cmdAddService.Parameters.Add("P_WRKFLW_STRTDATE", OracleDbType.Date).Value = DBNull.Value;
                            }
                            if (objEntityWrkflow.EndDate != DateTime.MinValue)
                            {
                                cmdAddService.Parameters.Add("P_WRKFLW_ENDDATE", OracleDbType.Date).Value = objEntityWrkflow.EndDate;
                            }
                            else
                            {
                                cmdAddService.Parameters.Add("P_WRKFLW_ENDDATE", OracleDbType.Date).Value = DBNull.Value;
                            }
                            cmdAddService.Parameters.Add("P_CONFIRM_STATUS", OracleDbType.Int32).Value = objEntityWrkflow.ConfirmSts;
                            cmdAddService.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = objEntityWrkflow.User_Id;
                            cmdAddService.Parameters.Add("P_WRKFLW_MAJORITY_APRVL", OracleDbType.Int32).Value = objEntityWrkflow.MajorityAprvSts;
                            cmdAddService.Parameters.Add("P_WRKFLW_SINGLE_APRVL", OracleDbType.Int32).Value = objEntityWrkflow.SingleApprvlSts;
                            cmdAddService.Parameters.Add("P_WRKFLW_APPRVL_RULE_STS", OracleDbType.Int32).Value = objEntityWrkflow.ApprovalRuleSts;
                            cmdAddService.ExecuteNonQuery();
                        }
                    }

                    if (objEntityWrkflow.ApprovalRuleSts == 0)
                    {
                        string strQueryDetails = "DOCUMENT_WORKFLOW.SP_DELETE_APPRVL_RULES_BYID";
                        using (OracleCommand cmdSubDetail = new OracleCommand(strQueryDetails, con))
                        {
                            cmdSubDetail.Transaction = tran;
                            cmdSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdSubDetail.Parameters.Add("P_WRKFLW_ID", OracleDbType.Int32).Value = objEntityWrkflow.TempId;
                            cmdSubDetail.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = objEntityWrkflow.User_Id;
                            cmdSubDetail.ExecuteNonQuery();
                        }
                    }

                    foreach (clsEntityApprovalHierarchyTemp objDetail in objEntityApprvlRulesDELETEList)
                    {
                        string strQueryInsertSubDetails = "DOCUMENT_WORKFLOW.SP_DELETE_APPRVL_RULES";
                        using (OracleCommand cmdSubDetail = new OracleCommand(strQueryInsertSubDetails, con))
                        {
                            cmdSubDetail.Transaction = tran;
                            cmdSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdSubDetail.Parameters.Add("P_WRKFLWRULES_ID", OracleDbType.Int32).Value = objDetail.ApprvlRuleId;
                            cmdSubDetail.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = objEntityWrkflow.User_Id;
                            cmdSubDetail.ExecuteNonQuery();
                        }
                    }

                    foreach (clsEntityApprovalHierarchyTemp objDetail in objEntityApprvlRulesList)
                    {
                        string strQueryInsertSubDetails = "DOCUMENT_WORKFLOW.SP_INSERT_APPRVL_RULES";
                        using (OracleCommand cmdSubDetail = new OracleCommand(strQueryInsertSubDetails, con))
                        {
                            cmdSubDetail.Transaction = tran;
                            cmdSubDetail.CommandType = CommandType.StoredProcedure;
                            cmdSubDetail.Parameters.Add("P_WRKFLWRULES_ID", OracleDbType.Int32).Value = objDetail.ApprvlRuleId;
                            cmdSubDetail.Parameters.Add("P_WRKFLW_ID", OracleDbType.Int32).Value = objEntityWrkflow.TempId;
                            cmdSubDetail.Parameters.Add("P_CNDTN_ID", OracleDbType.Int32).Value = objDetail.ConditionId;
                            cmdSubDetail.Parameters.Add("P_CNDTN_TYPE_ID", OracleDbType.Int32).Value = objDetail.ConditionTypeId;
                            if (objDetail.ConditionId == 1)
                            {
                                cmdSubDetail.Parameters.Add("P_WRKFLWRULESVAL_MAXVAL", OracleDbType.Int32).Value = objDetail.MaxVal;
                                cmdSubDetail.Parameters.Add("P_WRKFLWRULESVAL_MINVAL", OracleDbType.Int32).Value = objDetail.MinVal;
                                cmdSubDetail.Parameters.Add("P_WRKFLWRULESVAL_VALUES", OracleDbType.Varchar2).Value = null;
                            }
                            else
                            {
                                cmdSubDetail.Parameters.Add("P_WRKFLWRULESVAL_MAXVAL", OracleDbType.Int32).Value = null;
                                cmdSubDetail.Parameters.Add("P_WRKFLWRULESVAL_MINVAL", OracleDbType.Int32).Value = null;
                                cmdSubDetail.Parameters.Add("P_WRKFLWRULESVAL_VALUES", OracleDbType.Varchar2).Value = objDetail.CondtnValues;
                            }

                            cmdSubDetail.ExecuteNonQuery();
                        }
                    }

                    //Update and insert dtls
                    if (objEntityWrkflowUPDATEList.Count > 0)
                    {
                        foreach (clsEntityApprovalHierarchyTemp objDetailSub in objEntityWrkflowUPDATEList)
                        {
                            if (objDetailSub.DtlId != 0)
                            {
                                string strQueryInsertDetails = "DOCUMENT_WORKFLOW.SP_UPDATE_WRKFLW_DTLS";
                                using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                                {
                                    cmdAddInsertDetail.Transaction = tran;
                                    cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                    cmdAddInsertDetail.Parameters.Add("P_WRKFLW_DTL_ID", OracleDbType.Int32).Value = objDetailSub.DtlId;
                                    cmdAddInsertDetail.Parameters.Add("P_DSGN_ID", OracleDbType.Int32).Value = objDetailSub.DesgId;
                                    cmdAddInsertDetail.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = objDetailSub.EmployeeId;
                                    cmdAddInsertDetail.Parameters.Add("P_WRKFLW_APRVL_MNDTRY_STS", OracleDbType.Int32).Value = objDetailSub.MajorityAprvSts;
                                    cmdAddInsertDetail.Parameters.Add("P_WRKFLW_SUBSTUTE_STS", OracleDbType.Int32).Value = objDetailSub.SubstituteEmpSts;
                                    cmdAddInsertDetail.Parameters.Add("P_WRKFLW_THRSHOLD_PRD_STS", OracleDbType.Int32).Value = objDetailSub.ThresholdPeriodMode;
                                    cmdAddInsertDetail.Parameters.Add("P_WRKFLW_THRSHOLD_PERIOD", OracleDbType.Int32).Value = objDetailSub.ThresholdPeriodDays;
                                    cmdAddInsertDetail.Parameters.Add("P_WRKFLW_APRVL_PENDING_MSG_STS", OracleDbType.Int32).Value = objDetailSub.AprvPendingSts;
                                    cmdAddInsertDetail.Parameters.Add("P_WRKFLW_SMS_MSG_STS", OracleDbType.Int32).Value = objDetailSub.SmsSts;
                                    cmdAddInsertDetail.Parameters.Add("P_WRKFLW_DASHBRD_MSG_STS ", OracleDbType.Int32).Value = objDetailSub.SystemSts;
                                    cmdAddInsertDetail.Parameters.Add("P_WRKFLW_TTC_EXCD_MSG_STS", OracleDbType.Int32).Value = objDetailSub.TtExceededSts;
                                    cmdAddInsertDetail.Parameters.Add("P_WRKFLW_REPLACE_APPRVR_STS", OracleDbType.Int32).Value = objEntityWrkflow.ReplaceApprvrSts;
                                    cmdAddInsertDetail.Parameters.Add("P_WRKFLWDTL_APRVR_MODFY", OracleDbType.Int32).Value = objDetailSub.CanModify;
                                    cmdAddInsertDetail.Parameters.Add("P_WRKFLWDTL_MAIL_MSG_STS", OracleDbType.Int32).Value = objDetailSub.MailSts;
                                    cmdAddInsertDetail.Parameters.Add("P_WRKFLWDTL_SKIP_LEVEL_STS", OracleDbType.Int32).Value = objDetailSub.SkipLvlSts;
                                    cmdAddInsertDetail.ExecuteNonQuery();


                                    string strQueryDelete = "DOCUMENT_WORKFLOW.DELETE_SUBSTITUTE_EMPS";
                                    using (OracleCommand cmdDeleteDetail = new OracleCommand(strQueryDelete, con))
                                    {
                                        cmdDeleteDetail.Transaction = tran;
                                        cmdDeleteDetail.CommandType = CommandType.StoredProcedure;
                                        cmdDeleteDetail.Parameters.Add("P_DTL_ID", OracleDbType.Int32).Value = objDetailSub.DtlId;
                                        cmdDeleteDetail.ExecuteNonQuery();
                                    }

                                    foreach (clsEntityApprovalHierarchyTemp objSubstutDtl in objEntitySubstituteList)
                                    {
                                        if (objSubstutDtl.Count == objDetailSub.Count)
                                        {
                                            string strQueryInsertSubDetails = "DOCUMENT_WORKFLOW.SP_INSERT_SUBSTITUTE_EMP";
                                            using (OracleCommand cmdSubDetail = new OracleCommand(strQueryInsertSubDetails, con))
                                            {
                                                cmdSubDetail.Transaction = tran;
                                                cmdSubDetail.CommandType = CommandType.StoredProcedure;
                                                cmdSubDetail.Parameters.Add("P_DTL_ID", OracleDbType.Int32).Value = objDetailSub.DtlId;
                                                cmdSubDetail.Parameters.Add("P_DESG_ID", OracleDbType.Int32).Value = objSubstutDtl.DesgId;
                                                cmdSubDetail.Parameters.Add("P_EMP_ID", OracleDbType.Int32).Value = objSubstutDtl.EmployeeId;
                                                cmdSubDetail.Parameters.Add("P_WRKFLW_ID", OracleDbType.Int32).Value = objEntityWrkflow.TempId;
                                                cmdSubDetail.ExecuteNonQuery();
                                            }
                                        }
                                    }

                                }
                            }
                            else
                            {
                                if (objEntityWrkflow.ReplaceApprvrSts == 0)
                                {
                                    string strQueryInsertDetails = "DOCUMENT_WORKFLOW.SP_INSERT_WRKFLW_DTLS";
                                    using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                                    {
                                        cmdAddInsertDetail.Transaction = tran;
                                        cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                        cmdAddInsertDetail.Parameters.Add("P_WRKFLW_ID", OracleDbType.Int32).Value = objEntityWrkflow.TempId;
                                        if (objDetailSub.ParentId != 0)
                                        {
                                            cmdAddInsertDetail.Parameters.Add("P_WRKFLW_PARENT_DTL_ID", OracleDbType.Int32).Value = objDetailSub.ParentId;
                                        }
                                        else
                                        {
                                            cmdAddInsertDetail.Parameters.Add("P_WRKFLW_PARENT_DTL_ID", OracleDbType.Int32).Value = DBNull.Value;
                                        }
                                        cmdAddInsertDetail.Parameters.Add("P_WRKFLW_LEVEL", OracleDbType.Int32).Value = objDetailSub.Level;
                                        cmdAddInsertDetail.Parameters.Add("P_DSGN_ID", OracleDbType.Int32).Value = objDetailSub.DesgId;
                                        cmdAddInsertDetail.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = objDetailSub.EmployeeId;
                                        cmdAddInsertDetail.Parameters.Add("P_WRKFLW_APRVL_MNDTRY_STS", OracleDbType.Int32).Value = objDetailSub.MajorityAprvSts;
                                        cmdAddInsertDetail.Parameters.Add("P_WRKFLW_SUBSTUTE_STS", OracleDbType.Int32).Value = objDetailSub.SubstituteEmpSts;
                                        cmdAddInsertDetail.Parameters.Add("P_WRKFLW_THRSHOLD_PRD_STS", OracleDbType.Int32).Value = objDetailSub.ThresholdPeriodMode;
                                        cmdAddInsertDetail.Parameters.Add("P_WRKFLW_THRSHOLD_PERIOD", OracleDbType.Int32).Value = objDetailSub.ThresholdPeriodDays;
                                        cmdAddInsertDetail.Parameters.Add("P_WRKFLW_APRVL_PENDING_MSG_STS", OracleDbType.Int32).Value = objDetailSub.AprvPendingSts;
                                        cmdAddInsertDetail.Parameters.Add("P_WRKFLW_SMS_MSG_STS", OracleDbType.Int32).Value = objDetailSub.SmsSts;
                                        cmdAddInsertDetail.Parameters.Add("P_WRKFLW_DASHBRD_MSG_STS ", OracleDbType.Int32).Value = objDetailSub.SystemSts;
                                        cmdAddInsertDetail.Parameters.Add("P_WRKFLW_TTC_EXCD_MSG_STS", OracleDbType.Int32).Value = objDetailSub.TtExceededSts;
                                        cmdAddInsertDetail.Parameters.Add("P_WRKFLWDTL_APRVR_MODFY", OracleDbType.Int32).Value = objDetailSub.CanModify;
                                        cmdAddInsertDetail.Parameters.Add("P_WRKFLWDTL_MAIL_MSG_STS", OracleDbType.Int32).Value = objDetailSub.MailSts;
                                        cmdAddInsertDetail.Parameters.Add("P_WRKFLWDTL_SKIP_LEVEL_STS", OracleDbType.Int32).Value = objDetailSub.SkipLvlSts;
                                        
                                        cmdAddInsertDetail.Parameters.Add("P_WRKFLW_DTLID_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                        cmdAddInsertDetail.ExecuteNonQuery();
                                        string strReturn = cmdAddInsertDetail.Parameters["P_WRKFLW_DTLID_OUT"].Value.ToString();
                                        objDetailSub.DtlId = Convert.ToInt32(strReturn);

                                        foreach (clsEntityApprovalHierarchyTemp objSubstutDtl in objEntitySubstituteList)
                                        {
                                            if (objSubstutDtl.Count == objDetailSub.Count)
                                            {
                                                string strQueryInsertSubDetails = "DOCUMENT_WORKFLOW.SP_INSERT_SUBSTITUTE_EMP";
                                                using (OracleCommand cmdSubDetail = new OracleCommand(strQueryInsertSubDetails, con))
                                                {
                                                    cmdSubDetail.Transaction = tran;
                                                    cmdSubDetail.CommandType = CommandType.StoredProcedure;
                                                    cmdSubDetail.Parameters.Add("P_DTL_ID", OracleDbType.Int32).Value = objDetailSub.DtlId;
                                                    cmdSubDetail.Parameters.Add("P_DESG_ID", OracleDbType.Int32).Value = objSubstutDtl.DesgId;
                                                    cmdSubDetail.Parameters.Add("P_EMP_ID", OracleDbType.Int32).Value = objSubstutDtl.EmployeeId;
                                                    cmdSubDetail.Parameters.Add("P_WRKFLW_ID", OracleDbType.Int32).Value = objEntityWrkflow.TempId;
                                                    cmdSubDetail.ExecuteNonQuery();
                                                }
                                            }
                                        }

                                    }
                                }
                            }

                        }
                    }

                    if (objEntityWrkflow.ReplaceApprvrSts == 0)
                    {
                        //Delete dtls
                        foreach (clsEntityApprovalHierarchyTemp objDetailSub in objEntityWrkflowDELETEList)
                        {
                            string strQueryInsertDetails = "DOCUMENT_WORKFLOW.SP_DELETE_WRKFLW_DTLS_BYID";
                            using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                            {
                                cmdAddInsertDetail.Transaction = tran;
                                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDetail.Parameters.Add("P_WRKFLW_ID", OracleDbType.Int32).Value = objDetailSub.DtlId;
                                cmdAddInsertDetail.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = objEntityWrkflow.User_Id;
                                cmdAddInsertDetail.ExecuteNonQuery();
                            }
                        }

                        //Hierarchy changed
                        if (objEntityWrkflowMainINSERTList.Count > 0)
                        {
                            string strQueryDeleteDetails = "DOCUMENT_WORKFLOW.SP_DELETE_DTLS_BY_WRKFLOWID";
                            using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryDeleteDetails, con))
                            {
                                cmdAddInsertDetail.Transaction = tran;
                                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDetail.Parameters.Add("P_WRKFLW_ID", OracleDbType.Int32).Value = objEntityWrkflow.TempId;
                                cmdAddInsertDetail.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = objEntityWrkflow.User_Id;
                                cmdAddInsertDetail.ExecuteNonQuery();
                            }

                            int[] WrkFlowDtlId = new int[objEntityWrkflowMainINSERTList.Count + objEntityWrkflowSubINSERTList.Count];
                            int[] TempDtlId = new int[objEntityWrkflowMainINSERTList.Count + objEntityWrkflowSubINSERTList.Count];

                            int RowCount = 0;
                            string strReturnSub = "";

                            //Main table
                            string strQueryInsertDetails = "DOCUMENT_WORKFLOW.SP_INSERT_WRKFLW_DTLS";
                            foreach (clsEntityApprovalHierarchyTemp objDetailSub in objEntityWrkflowMainINSERTList)
                            {
                                using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                                {
                                    cmdAddInsertDetail.Transaction = tran;
                                    cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                    cmdAddInsertDetail.Parameters.Add("P_WRKFLW_ID", OracleDbType.Int32).Value = objEntityWrkflow.TempId;
                                    cmdAddInsertDetail.Parameters.Add("P_WRKFLW_PARENT_DTL_ID", OracleDbType.Int32).Value = DBNull.Value;
                                    cmdAddInsertDetail.Parameters.Add("P_WRKFLW_LEVEL", OracleDbType.Int32).Value = objDetailSub.Level;
                                    cmdAddInsertDetail.Parameters.Add("P_DSGN_ID", OracleDbType.Int32).Value = objDetailSub.DesgId;
                                    cmdAddInsertDetail.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = objDetailSub.EmployeeId;
                                    cmdAddInsertDetail.Parameters.Add("P_WRKFLW_APRVL_MNDTRY_STS", OracleDbType.Int32).Value = objDetailSub.MajorityAprvSts;
                                    cmdAddInsertDetail.Parameters.Add("P_WRKFLW_SUBSTUTE_STS", OracleDbType.Int32).Value = objDetailSub.SubstituteEmpSts;
                                    cmdAddInsertDetail.Parameters.Add("P_WRKFLW_THRSHOLD_PRD_STS", OracleDbType.Int32).Value = objDetailSub.ThresholdPeriodMode;
                                    cmdAddInsertDetail.Parameters.Add("P_WRKFLW_THRSHOLD_PERIOD", OracleDbType.Int32).Value = objDetailSub.ThresholdPeriodDays;
                                    cmdAddInsertDetail.Parameters.Add("P_WRKFLW_APRVL_PENDING_MSG_STS", OracleDbType.Int32).Value = objDetailSub.AprvPendingSts;
                                    cmdAddInsertDetail.Parameters.Add("P_WRKFLW_SMS_MSG_STS", OracleDbType.Int32).Value = objDetailSub.SmsSts;
                                    cmdAddInsertDetail.Parameters.Add("P_WRKFLW_DASHBRD_MSG_STS ", OracleDbType.Int32).Value = objDetailSub.SystemSts;
                                    cmdAddInsertDetail.Parameters.Add("P_WRKFLW_TTC_EXCD_MSG_STS", OracleDbType.Int32).Value = objDetailSub.TtExceededSts;
                                    cmdAddInsertDetail.Parameters.Add("P_WRKFLWDTL_APRVR_MODFY", OracleDbType.Int32).Value = objDetailSub.CanModify;
                                    cmdAddInsertDetail.Parameters.Add("P_WRKFLWDTL_MAIL_MSG_STS", OracleDbType.Int32).Value = objDetailSub.MailSts;
                                    cmdAddInsertDetail.Parameters.Add("P_WRKFLWDTL_SKIP_LEVEL_STS", OracleDbType.Int32).Value = objDetailSub.SkipLvlSts;

                                    cmdAddInsertDetail.Parameters.Add("P_WRKFLW_DTLID_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                    cmdAddInsertDetail.ExecuteNonQuery();
                                    string strReturn = cmdAddInsertDetail.Parameters["P_WRKFLW_DTLID_OUT"].Value.ToString();

                                    WrkFlowDtlId[RowCount] = Convert.ToInt32(strReturn);
                                    TempDtlId[RowCount] = objDetailSub.TempDtlId;
                                }

                                foreach (clsEntityApprovalHierarchyTemp objSubstutDtl in objEntitySubstituteList)
                                {
                                    if (objSubstutDtl.Count == objDetailSub.Count)
                                    {
                                        string strQueryInsertSubDetails = "DOCUMENT_WORKFLOW.SP_INSERT_SUBSTITUTE_EMP";
                                        using (OracleCommand cmdSubDetail = new OracleCommand(strQueryInsertSubDetails, con))
                                        {
                                            cmdSubDetail.Transaction = tran;
                                            cmdSubDetail.CommandType = CommandType.StoredProcedure;
                                            cmdSubDetail.Parameters.Add("P_DTL_ID", OracleDbType.Int32).Value = WrkFlowDtlId[RowCount];
                                            cmdSubDetail.Parameters.Add("P_DESG_ID", OracleDbType.Int32).Value = objSubstutDtl.DesgId;
                                            cmdSubDetail.Parameters.Add("P_EMP_ID", OracleDbType.Int32).Value = objSubstutDtl.EmployeeId;
                                            cmdSubDetail.Parameters.Add("P_WRKFLW_ID", OracleDbType.Int32).Value = objEntityWrkflow.TempId;
                                            cmdSubDetail.ExecuteNonQuery();
                                        }
                                    }
                                }

                                RowCount++;
                            }

                            //Sub table
                            foreach (clsEntityApprovalHierarchyTemp objDetailSub in objEntityWrkflowSubINSERTList)
                            {
                                using (OracleCommand cmdAddInsertDetailSub = new OracleCommand(strQueryInsertDetails, con))
                                {
                                    cmdAddInsertDetailSub.Transaction = tran;
                                    cmdAddInsertDetailSub.CommandType = CommandType.StoredProcedure;
                                    cmdAddInsertDetailSub.Parameters.Add("P_WRKFLW_ID", OracleDbType.Int32).Value = objEntityWrkflow.TempId;
                                    if (objDetailSub.ParentId != 0)
                                    {
                                        cmdAddInsertDetailSub.Parameters.Add("P_WRKFLW_PARENT_DTL_ID", OracleDbType.Int32).Value = WrkFlowDtlId[Array.IndexOf(TempDtlId, objDetailSub.ParentId)];
                                    }
                                    else
                                    {
                                        cmdAddInsertDetailSub.Parameters.Add("P_WRKFLW_PARENT_DTL_ID", OracleDbType.Int32).Value = DBNull.Value;
                                    }
                                    cmdAddInsertDetailSub.Parameters.Add("P_WRKFLW_LEVEL", OracleDbType.Int32).Value = objDetailSub.Level;
                                    cmdAddInsertDetailSub.Parameters.Add("P_DSGN_ID", OracleDbType.Int32).Value = objDetailSub.DesgId;
                                    cmdAddInsertDetailSub.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = objDetailSub.EmployeeId;
                                    cmdAddInsertDetailSub.Parameters.Add("P_WRKFLW_APRVL_MNDTRY_STS", OracleDbType.Int32).Value = objDetailSub.MajorityAprvSts;
                                    cmdAddInsertDetailSub.Parameters.Add("P_WRKFLW_SUBSTUTE_STS", OracleDbType.Int32).Value = objDetailSub.SubstituteEmpSts;
                                    cmdAddInsertDetailSub.Parameters.Add("P_WRKFLW_THRSHOLD_PRD_STS", OracleDbType.Int32).Value = objDetailSub.ThresholdPeriodMode;
                                    cmdAddInsertDetailSub.Parameters.Add("P_WRKFLW_THRSHOLD_PERIOD", OracleDbType.Int32).Value = objDetailSub.ThresholdPeriodDays;
                                    cmdAddInsertDetailSub.Parameters.Add("P_WRKFLW_APRVL_PENDING_MSG_STS", OracleDbType.Int32).Value = objDetailSub.AprvPendingSts;
                                    cmdAddInsertDetailSub.Parameters.Add("P_WRKFLW_SMS_MSG_STS", OracleDbType.Int32).Value = objDetailSub.SmsSts;
                                    cmdAddInsertDetailSub.Parameters.Add("P_WRKFLW_DASHBRD_MSG_STS ", OracleDbType.Int32).Value = objDetailSub.SystemSts;
                                    cmdAddInsertDetailSub.Parameters.Add("P_WRKFLW_TTC_EXCD_MSG_STS", OracleDbType.Int32).Value = objDetailSub.TtExceededSts;
                                    cmdAddInsertDetailSub.Parameters.Add("P_WRKFLWDTL_APRVR_MODFY", OracleDbType.Int32).Value = objDetailSub.CanModify;
                                    cmdAddInsertDetailSub.Parameters.Add("P_WRKFLWDTL_MAIL_MSG_STS", OracleDbType.Int32).Value = objDetailSub.MailSts;
                                    cmdAddInsertDetailSub.Parameters.Add("P_WRKFLWDTL_SKIP_LEVEL_STS", OracleDbType.Int32).Value = objDetailSub.SkipLvlSts;

                                    cmdAddInsertDetailSub.Parameters.Add("P_WRKFLW_DTLID_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                                    cmdAddInsertDetailSub.ExecuteNonQuery();
                                    strReturnSub = cmdAddInsertDetailSub.Parameters["P_WRKFLW_DTLID_OUT"].Value.ToString();

                                }

                                WrkFlowDtlId[RowCount] = Convert.ToInt32(strReturnSub);
                                TempDtlId[RowCount] = objDetailSub.TempDtlId;

                                foreach (clsEntityApprovalHierarchyTemp objSubstutDtl in objEntitySubstituteList)
                                {
                                    if (objSubstutDtl.Count == objDetailSub.Count)
                                    {
                                        string strQueryInsertSubDetails = "DOCUMENT_WORKFLOW.SP_INSERT_SUBSTITUTE_EMP";
                                        using (OracleCommand cmdSubDetail = new OracleCommand(strQueryInsertSubDetails, con))
                                        {
                                            cmdSubDetail.Transaction = tran;
                                            cmdSubDetail.CommandType = CommandType.StoredProcedure;
                                            cmdSubDetail.Parameters.Add("P_DTL_ID", OracleDbType.Int32).Value = WrkFlowDtlId[RowCount];
                                            cmdSubDetail.Parameters.Add("P_DESG_ID", OracleDbType.Int32).Value = objSubstutDtl.DesgId;
                                            cmdSubDetail.Parameters.Add("P_EMP_ID", OracleDbType.Int32).Value = objSubstutDtl.EmployeeId;
                                            cmdSubDetail.Parameters.Add("P_WRKFLW_ID", OracleDbType.Int32).Value = objEntityWrkflow.TempId;
                                            cmdSubDetail.ExecuteNonQuery();
                                        }
                                    }
                                }

                                RowCount++;
                            }

                        }

                        if (objEntityWrkflow.ConfirmSts == 1)
                        {
                            string strQueryDeleteDetails = "DOCUMENT_WORKFLOW.SP_INSERT_WRKFLOW_FLOATING";
                            using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryDeleteDetails, con))
                            {
                                cmdAddInsertDetail.Transaction = tran;
                                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDetail.Parameters.Add("P_WRKFLW_ID", OracleDbType.Int32).Value = objEntityWrkflow.TempId;
                                cmdAddInsertDetail.ExecuteNonQuery();
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

        public void ReopenWrkflow(clsEntityApprovalHierarchyTemp objEntityWrkflow)
        {
            string strQueryCnclCost = "DOCUMENT_WORKFLOW.SP_REOPEN_WRKFLOW";
            using (OracleCommand cmdAddInsertDetail = new OracleCommand())
            {
                cmdAddInsertDetail.CommandText = strQueryCnclCost;
                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                cmdAddInsertDetail.Parameters.Add("P_WRKFLW_ID", OracleDbType.Int32).Value = objEntityWrkflow.TempId;
                cmdAddInsertDetail.Parameters.Add("P_USR_ID", OracleDbType.Int32).Value = objEntityWrkflow.User_Id;
                clsDataLayer.ExecuteNonQuery(cmdAddInsertDetail);
            }
        }

        public DataTable ReadLowerHierarchyIds(clsEntityApprovalHierarchyTemp objEntityWrkflow)
        {
            string strQueryReadAccommodation = "DOCUMENT_WORKFLOW.SP_READ_LOWER_HRCHYS";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("P_WRKFLW_ID", OracleDbType.Int32).Value = objEntityWrkflow.DtlId;
            cmdReadAccommodation.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }

        public DataTable ReadSubstutEmptls(clsEntityApprovalHierarchyTemp objEntityWrkflow)
        {
            string strQueryReadAccommodation = "DOCUMENT_WORKFLOW.SP_READ_SUBSTITUTE_EMPS";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("P_DTL_ID", OracleDbType.Int32).Value = objEntityWrkflow.TempId;
            cmdReadAccommodation.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }

        public DataTable ReadApprovalConditions(clsEntityApprovalHierarchyTemp objEntityWrkflow)
        {
            string strQueryReadAccommodation = "DOCUMENT_WORKFLOW.SP_READ_CONDITIONS";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("P_DOC_ID", OracleDbType.Int32).Value = objEntityWrkflow.Doc;
            cmdReadAccommodation.Parameters.Add("P_WRKFLW_ID", OracleDbType.Int32).Value = objEntityWrkflow.TempId;
            cmdReadAccommodation.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }

        public DataTable ReadConditionTyps(clsEntityApprovalHierarchyTemp objEntityWrkflow)
        {
            string strQueryReadAccommodation = "DOCUMENT_WORKFLOW.SP_READ_CONDITION_TYPES";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("P_DOC_ID", OracleDbType.Int32).Value = objEntityWrkflow.Doc;
            cmdReadAccommodation.Parameters.Add("P_CONDITION_ID", OracleDbType.Int32).Value = objEntityWrkflow.ConditionId;
            cmdReadAccommodation.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }

        public DataTable ReadApprovalConditionVal(string Package, string Procedure, clsEntityApprovalHierarchyTemp objEntityWrkflow)
        {
            string strQueryReadAccommodation = Package + "." + Procedure;
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("P_CORPRT_ID", OracleDbType.Int32).Value = objEntityWrkflow.Corporate_id;
            cmdReadAccommodation.Parameters.Add("P_ORG_ID", OracleDbType.Int32).Value = objEntityWrkflow.Organisation_id;
            cmdReadAccommodation.Parameters.Add("P_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityWrkflow.Name1;
            cmdReadAccommodation.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }

        public DataTable ReadApprovalRules(clsEntityApprovalHierarchyTemp objEntityWrkflow)
        {
            string strQueryReadAccommodation = "DOCUMENT_WORKFLOW.SP_READ_APPRVL_RULES";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityWrkflow.Corporate_id;
            cmdReadAccommodation.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityWrkflow.Organisation_id;
            cmdReadAccommodation.Parameters.Add("P_WRKFLW_ID", OracleDbType.Int32).Value = objEntityWrkflow.TempId;
            cmdReadAccommodation.Parameters.Add("P_DEPT", OracleDbType.Varchar2).Value = objEntityWrkflow.Dep;
            cmdReadAccommodation.Parameters.Add("P_DIV", OracleDbType.Varchar2).Value = objEntityWrkflow.div;
            cmdReadAccommodation.Parameters.Add("P_DOC_ID", OracleDbType.Int32).Value = objEntityWrkflow.Doc;
            cmdReadAccommodation.Parameters.Add("P_CNDTN_ID", OracleDbType.Int32).Value = objEntityWrkflow.ConditionId;
            cmdReadAccommodation.Parameters.Add("P_CNDTN_TYPE_ID", OracleDbType.Int32).Value = objEntityWrkflow.ConditionTypeId;
            if (objEntityWrkflow.ConditionId == 1)
            {
                cmdReadAccommodation.Parameters.Add("P_WRKFLWRULESVAL_MAXVAL", OracleDbType.Int32).Value = objEntityWrkflow.MaxVal;
                cmdReadAccommodation.Parameters.Add("P_WRKFLWRULESVAL_MINVAL", OracleDbType.Int32).Value = objEntityWrkflow.MinVal;
                cmdReadAccommodation.Parameters.Add("P_WRKFLWRULESVAL_VALUES", OracleDbType.Varchar2).Value = null;
            }
            else
            {
                cmdReadAccommodation.Parameters.Add("P_WRKFLWRULESVAL_MAXVAL", OracleDbType.Int32).Value = null;
                cmdReadAccommodation.Parameters.Add("P_WRKFLWRULESVAL_MINVAL", OracleDbType.Int32).Value = null;
                cmdReadAccommodation.Parameters.Add("P_WRKFLWRULESVAL_VALUES", OracleDbType.Varchar2).Value = objEntityWrkflow.CondtnValues;
            }
            cmdReadAccommodation.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }

       
    }
}