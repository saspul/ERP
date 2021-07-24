using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_PMS;
using EL_Compzit;
using CL_Compzit;
using System.Web;
namespace DL_Compzit.DataLayer_PMS
{
   public class clsDataLayerApprovalset
    {
        public DataTable ReadAppCondition()
        {
            string strQueryReadCountry = "PMS_APPROVALSET.SP_READ_APPR_CONDITION";
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

        public DataTable LoadAppCondition(clsEntityApprovalHierarchyTemp objentityPass)
        {
            string strQueryReadCountry = "PMS_APPROVALSET.SP_LOAD_CONDITIONS";
            using (OracleCommand cmdReadType = new OracleCommand())
            {
                cmdReadType.CommandText = strQueryReadCountry;
                cmdReadType.CommandType = CommandType.StoredProcedure;
                cmdReadType.Parameters.Add("APPROVALSET_DOCID", OracleDbType.Int32).Value = objentityPass.DesgId;
                cmdReadType.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtType = new DataTable();
                dtType = clsDataLayer.SelectDataTable(cmdReadType);
                return dtType;
            }
        }
        public DataTable LoadAppConditionType(clsEntityApprovalHierarchyTemp objentityPass)
        {
            string strQueryReadCountry = "PMS_APPROVALSET.SP_LOAD_CONDITIONSTYPE";
            using (OracleCommand cmdReadType = new OracleCommand())
            {
                cmdReadType.CommandText = strQueryReadCountry;
                cmdReadType.CommandType = CommandType.StoredProcedure;
                cmdReadType.Parameters.Add("APPROVALSET_CNDTNID ", OracleDbType.Int32).Value = objentityPass.Cond;
                cmdReadType.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtType = new DataTable();
                dtType = clsDataLayer.SelectDataTable(cmdReadType);
                return dtType;
            }
        }
        public DataTable ReadApprovalCnfmsts(clsEntityApprovalHierarchyTemp objentityPass)
        {
            string strQueryReadCountry = "PMS_APPROVALSET.SP_READ_APPROVALCNFMSTS";
            using (OracleCommand cmdReadType = new OracleCommand())
            {
                cmdReadType.CommandText = strQueryReadCountry;
                cmdReadType.CommandType = CommandType.StoredProcedure;
                cmdReadType.Parameters.Add("A_ID ", OracleDbType.Int32).Value = objentityPass.TempId;
                cmdReadType.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtType = new DataTable();
                dtType = clsDataLayer.SelectDataTable(cmdReadType);
                return dtType;
            }
        }
        public DataTable ReadAppConditionType()
        {
            string strQueryReadCountry = "PMS_APPROVALSET. SP_READ_APPR_CONDITION_TYPE";
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
        public DataSet ReadProcedurecnd(clsEntityApprovalHierarchyTemp objentityPass)
        {
            string strCommandText = "PMS_APPROVALSET.SP_READ_CND";
            using (OracleCommand cmdCommon = new OracleCommand())
            {
                cmdCommon.CommandText = strCommandText;
                cmdCommon.CommandType = CommandType.StoredProcedure;
                cmdCommon.Parameters.Add("ORGID", OracleDbType.Int32).Value = objentityPass.Organisation_id;
                cmdCommon.Parameters.Add("CORPID", OracleDbType.Int32).Value = objentityPass.Corporate_id;
                cmdCommon.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmdCommon.Parameters.Add("A_OUT1", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmdCommon.Parameters.Add("D_DEPT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                cmdCommon.Parameters.Add("D_DIV", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataSet dtGridDisp = new DataSet();
                dtGridDisp = clsDataLayer.SelectDataSet(cmdCommon);
                return dtGridDisp;
            }
        }

       

        public void insertApprovalSet(clsEntityApprovalHierarchyTemp objentityPass, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsList, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltn)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "PMS_APPROVALSET.SP_INS_APPROVAL_SET";

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp, con))
                    {
                        cmdAddService.Transaction = tran;
                     
                        cmdAddService.CommandText = strQueryLeaveTyp;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.Parameters.Add("AP_ID", OracleDbType.Int32).Value =1;
                        cmdAddService.Parameters.Add("AP_NAME", OracleDbType.Varchar2).Value = objentityPass.Name;
                        cmdAddService.Parameters.Add("AP_DESC", OracleDbType.Varchar2).Value = objentityPass.descr;
                        cmdAddService.Parameters.Add("DO_ID", OracleDbType.Int32).Value = objentityPass.DesgId;
                        cmdAddService.Parameters.Add("AP_CON_STATUS", OracleDbType.Int32).Value =0;

                        cmdAddService.Parameters.Add("COR_ID", OracleDbType.Int32).Value = objentityPass.Corporate_id;
                        cmdAddService.Parameters.Add("OR_ID", OracleDbType.Int32).Value = objentityPass.Organisation_id;

                        cmdAddService.Parameters.Add("A_IN_USR_ID", OracleDbType.Int32).Value = objentityPass.User_Id;
                        cmdAddService.Parameters.Add("A_INS_DATE ", OracleDbType.Date).Value = objentityPass.cDate;
                        cmdAddService.Parameters.Add("A_UPD_ID ", OracleDbType.Int32).Value = DBNull.Value;
                        cmdAddService.Parameters.Add("A_UPD_DATE ", OracleDbType.Date).Value = DBNull.Value;
                        cmdAddService.Parameters.Add("A_CNFM_ID ", OracleDbType.Int32).Value = DBNull.Value;
                        cmdAddService.Parameters.Add("A_CNFM_DATE ", OracleDbType.Date).Value = DBNull.Value;
                        cmdAddService.Parameters.Add("A_REOPEN_ID ", OracleDbType.Int32).Value = DBNull.Value;
                        cmdAddService.Parameters.Add("A_REOPEN_DATE ", OracleDbType.Date).Value = DBNull.Value;
                        cmdAddService.Parameters.Add("A_CNCL_USR_ID ", OracleDbType.Int32).Value = DBNull.Value;
                        cmdAddService.Parameters.Add("A_CNCL_DATE ", OracleDbType.Date).Value = DBNull.Value;
                        cmdAddService.Parameters.Add("A_CNCL_RSN ", OracleDbType.Varchar2).Value = DBNull.Value;

                        cmdAddService.ExecuteNonQuery();
                    }

                    foreach (clsEntityApprovalHierarchyTemp objDetail in objEntityTrficVioltnDetilsList)
                    {

                        string strQueryInsertDetails = "PMS_APPROVALSET.SP_INS_APPROVAL_SET_DTLS";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("AP_DTL_ID", OracleDbType.Int32).Value = 1;
                            cmdAddInsertDetail.Parameters.Add("AP_ID", OracleDbType.Int32).Value = 1;
                            cmdAddInsertDetail.Parameters.Add("CN_ID", OracleDbType.Int32).Value = objDetail.Cond;
                            cmdAddInsertDetail.Parameters.Add("CN_TY_ID", OracleDbType.Int32).Value = objDetail.type;
                            
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                    }

                    foreach (clsEntityApprovalHierarchyTemp objDetail in objEntityTrficVioltn)
                    {

                        string strQueryInsertDetails = "PMS_APPROVALSET.SP_INS_APPROVAL_SET_DTLSVALUE";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("AP_DTLVAL_ID", OracleDbType.Int32).Value = 1;
                            cmdAddInsertDetail.Parameters.Add("AP_DTL_ID", OracleDbType.Int32).Value = 1;
                            cmdAddInsertDetail.Parameters.Add("AP_DTL_MAXVAL", OracleDbType.Double).Value = objDetail.Max;
                            cmdAddInsertDetail.Parameters.Add("AP_DTL_MINVAL", OracleDbType.Double).Value = objDetail.Min;
                            cmdAddInsertDetail.Parameters.Add("AP_DTL_VALUES", OracleDbType.Varchar2).Value=   objDetail.Dep;
                            cmdAddInsertDetail.Parameters.Add("CND_ID", OracleDbType.Int32).Value = objDetail.Cond;
                            //cmdAddInsertDetail.Parameters.Add("AP_DTL_VALUES", OracleDbType.Varchar2).Value = 0;
                            cmdAddInsertDetail.ExecuteNonQuery();
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
        public DataTable Readappwname(clsEntityApprovalHierarchyTemp objentityPass1)
        {

            string strQueryRead = "PMS_APPROVALSET.SP_CHECK_DUP_APP";
            using (OracleCommand cmdReadType = new OracleCommand())
            {
                cmdReadType.CommandText = strQueryRead;
                cmdReadType.CommandType = CommandType.StoredProcedure;
                cmdReadType.Parameters.Add("A_CORPID", OracleDbType.Varchar2).Value = objentityPass1.Corporate_id;
                cmdReadType.Parameters.Add("A_ORGID", OracleDbType.Varchar2).Value = objentityPass1.Organisation_id;
                cmdReadType.Parameters.Add("APP_NAME", OracleDbType.Varchar2).Value = objentityPass1.Name;
                cmdReadType.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtType = new DataTable();
                dtType = clsDataLayer.SelectDataTable(cmdReadType);
                return dtType;
            }

        }
        public DataTable ReadAppsetsts(clsEntityApprovalHierarchyTemp objentityPass1)
        {
            string strQueryReadAccommodation = "PMS_APPROVALSET.SP_READ_APPSETSTS";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("A_ST", OracleDbType.Int32).Value = objentityPass1.Status_id;
            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public void cancelApprovalset(clsEntityApprovalHierarchyTemp objentityPass)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "PMS_APPROVALSET.SP_CANCEL_APPROVALSET";
            OracleTransaction tran;
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

                        cmdAddService.CommandText = strQueryLeaveTyp;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                     
                        cmdAddService.Parameters.Add("APP_ID", OracleDbType.Int32).Value = objentityPass.TempId;
                        cmdAddService.Parameters.Add("AT_CANCEL_USERID", OracleDbType.Int32).Value = objentityPass.User_Id;
                        cmdAddService.Parameters.Add("AT_CANCEL_DATE", OracleDbType.Date).Value = objentityPass.cDate;
                        cmdAddService.Parameters.Add("AT_CANCEL_REASON ", OracleDbType.Varchar2).Value = objentityPass.CancelReason;

                        cmdAddService.ExecuteNonQuery();
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
        public DataTable ReadApproval(clsEntityApprovalHierarchyTemp objentityPass1)
        {
            string strQueryReadAccommodation = "PMS_APPROVALSET.SP_READ_APPROVAL";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("AP_ID", OracleDbType.Int32).Value = objentityPass1.TempId ;
            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public void UpdateApprovalSet(clsEntityApprovalHierarchyTemp objentityPass, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsList, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltn, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListDele)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "PMS_APPROVALSET.SP_UPDATE_APPROVALSET";

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp, con))
                    {
                        cmdAddService.Transaction = tran;

                        cmdAddService.CommandText = strQueryLeaveTyp;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.Parameters.Add("APPROVALSET_ID", OracleDbType.Int32).Value = objentityPass.TempId;
                        cmdAddService.Parameters.Add("APPROVALSET_NAME", OracleDbType.Varchar2).Value = objentityPass.Name;
                        cmdAddService.Parameters.Add("APPROVALSET_DESC", OracleDbType.Varchar2).Value = objentityPass.descr;
                        cmdAddService.Parameters.Add("APPROVALSET_DOC_ID", OracleDbType.Int32).Value = objentityPass.DesgId;
                        cmdAddService.Parameters.Add("APPROVALSET_ORGID", OracleDbType.Int32).Value = objentityPass.Organisation_id;
                        cmdAddService.Parameters.Add("APPROVALSET_CORPID", OracleDbType.Int32).Value = objentityPass.Corporate_id;                    
                        cmdAddService.Parameters.Add("APPROVALSET_USRID", OracleDbType.Int32).Value = objentityPass.User_Id;
                       
                        cmdAddService.ExecuteNonQuery();
                    }

                    foreach (clsEntityApprovalHierarchyTemp objDetail in objEntityTrficVioltnDetilsList)
                    {

                        string strQueryInsertDetails = "PMS_APPROVALSET.SP_UPDATE_APPROVALSETDTL";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("APPROVALSET_DTLID", OracleDbType.Int32).Value = objDetail.DesgId;
                            cmdAddInsertDetail.Parameters.Add("APPROVALSET_ID", OracleDbType.Int32).Value = objDetail.TempId;
                            cmdAddInsertDetail.Parameters.Add("APPROVALSET_CNDTNID", OracleDbType.Int32).Value = objDetail.Cond;
                            cmdAddInsertDetail.Parameters.Add("APPROVALSET_TYPEID", OracleDbType.Int32).Value = objDetail.type;

                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                    }

                    foreach (clsEntityApprovalHierarchyTemp objDetail in objEntityTrficVioltn)
                    {

                        string strQueryInsertDetails = "PMS_APPROVALSET.SP_UPDATE_APPROVALSETVALUE";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("APPROVALSET_VALEID", OracleDbType.Int32).Value = objDetail.TempId;
                            cmdAddInsertDetail.Parameters.Add("APPROVALSET_DTLID ", OracleDbType.Int32).Value =objDetail.DesgId;
                            cmdAddInsertDetail.Parameters.Add("APPROVALSET_MAXVAL", OracleDbType.Double).Value = objDetail.Max;
                            cmdAddInsertDetail.Parameters.Add("APPROVALSET_MINVAL", OracleDbType.Double).Value = objDetail.Min;
                            cmdAddInsertDetail.Parameters.Add("APPROVALSET_DTLIST", OracleDbType.Varchar2).Value = objDetail.Dep;
                            cmdAddInsertDetail.Parameters.Add("CND_ID", OracleDbType.Int32).Value = objDetail.Cond;
                           // cmdAddInsertDetail.Parameters.Add("CND_ID", OracleDbType.Int32).Value = objDetail.Cond;
                            //cmdAddInsertDetail.Parameters.Add("AP_DTL_VALUES", OracleDbType.Varchar2).Value = 0;
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                    }
                    foreach (clsEntityApprovalHierarchyTemp objDetail in objEntityTrficVioltnDetilsListDele)
                    {
                        string strQueryInsertDetails = "PMS_APPROVALSET.SP_DELETE_APPROVALSETDETAILS";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("APPROVALSET_DET_ID", OracleDbType.Int32).Value = objDetail.TempId;
                            cmdAddInsertDetail.Parameters.Add("APPROVALSET_VALUE_ID", OracleDbType.Int32).Value = objDetail.DesgId ;
                            cmdAddInsertDetail.ExecuteNonQuery();
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
        public void updateApprovalSetconfrm(clsEntityApprovalHierarchyTemp objentityPass, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsList, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltn, List<clsEntityApprovalHierarchyTemp> objEntityTrficVioltnDetilsListDele)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "PMS_APPROVALSET.SP_CONFIRM_APPROVALSET";

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {
                    using (OracleCommand cmdAddService = new OracleCommand(strQueryLeaveTyp, con))
                    {
                        cmdAddService.Transaction = tran;

                        cmdAddService.CommandText = strQueryLeaveTyp;
                        cmdAddService.CommandType = CommandType.StoredProcedure;
                        cmdAddService.Parameters.Add("APPROVALSET_ID", OracleDbType.Int32).Value = objentityPass.TempId;
                        cmdAddService.Parameters.Add("APPROVALSET_NAME", OracleDbType.Varchar2).Value = objentityPass.Name;
                        cmdAddService.Parameters.Add("APPROVALSET_DESC", OracleDbType.Varchar2).Value = objentityPass.descr;
                        cmdAddService.Parameters.Add("APPROVALSET_DOC_ID", OracleDbType.Int32).Value = objentityPass.DesgId;
                        cmdAddService.Parameters.Add("APPROVALSET_ORGID", OracleDbType.Int32).Value = objentityPass.Organisation_id;
                        cmdAddService.Parameters.Add("APPROVALSET_CORPID", OracleDbType.Int32).Value = objentityPass.Corporate_id;
                        cmdAddService.Parameters.Add("APPROVALSET_USRID", OracleDbType.Int32).Value = objentityPass.User_Id;

                        cmdAddService.ExecuteNonQuery();
                    }

                    foreach (clsEntityApprovalHierarchyTemp objDetail in objEntityTrficVioltnDetilsList)
                    {

                        string strQueryInsertDetails = "PMS_APPROVALSET.SP_UPDATE_APPROVALSETDTL";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("APPROVALSET_DTLID", OracleDbType.Int32).Value = objDetail.DesgId;
                            cmdAddInsertDetail.Parameters.Add("APPROVALSET_ID", OracleDbType.Int32).Value = objDetail.TempId;
                            cmdAddInsertDetail.Parameters.Add("APPROVALSET_CNDTNID", OracleDbType.Int32).Value = objDetail.Cond;
                            cmdAddInsertDetail.Parameters.Add("APPROVALSET_TYPEID", OracleDbType.Int32).Value = objDetail.type;

                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                    }

                    foreach (clsEntityApprovalHierarchyTemp objDetail in objEntityTrficVioltn)
                    {

                        string strQueryInsertDetails = "PMS_APPROVALSET.SP_UPDATE_APPROVALSETVALUE";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("APPROVALSET_VALEID", OracleDbType.Int32).Value = objDetail.TempId;
                            cmdAddInsertDetail.Parameters.Add("APPROVALSET_DTLID ", OracleDbType.Int32).Value = objDetail.DesgId;
                            cmdAddInsertDetail.Parameters.Add("APPROVALSET_MAXVAL", OracleDbType.Double).Value = objDetail.Max;
                            cmdAddInsertDetail.Parameters.Add("APPROVALSET_MINVAL", OracleDbType.Double).Value = objDetail.Min;
                            cmdAddInsertDetail.Parameters.Add("APPROVALSET_DTLIST", OracleDbType.Varchar2).Value = objDetail.Dep;
                            cmdAddInsertDetail.Parameters.Add("CND_ID", OracleDbType.Int32).Value = objDetail.Cond;
                            // cmdAddInsertDetail.Parameters.Add("CND_ID", OracleDbType.Int32).Value = objDetail.Cond;
                            //cmdAddInsertDetail.Parameters.Add("AP_DTL_VALUES", OracleDbType.Varchar2).Value = 0;
                            cmdAddInsertDetail.ExecuteNonQuery();
                        }
                    }
                    foreach (clsEntityApprovalHierarchyTemp objDetail in objEntityTrficVioltnDetilsListDele)
                    {
                        string strQueryInsertDetails = "PMS_APPROVALSET.SP_DELETE_APPROVALSETDETAILS";
                        using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetails, con))
                        {
                            cmdAddInsertDetail.Transaction = tran;
                            cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                            cmdAddInsertDetail.Parameters.Add("APPROVALSET_DET_ID", OracleDbType.Int32).Value = objDetail.TempId;
                            cmdAddInsertDetail.Parameters.Add("APPROVALSET_VALUE_ID", OracleDbType.Int32).Value = objDetail.DesgId;
                            cmdAddInsertDetail.ExecuteNonQuery();
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
        public DataTable ReadApprovalActive(clsEntityApprovalHierarchyTemp objentityPass1)
        {
            string strQueryReadAccommodation = "PMS_APPROVALSET.SP_READ_APPROVALACTIVE";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("ADOC_ID", OracleDbType.Varchar2).Value = objentityPass1.Doc;
            cmdReadAccommodation.Parameters.Add("A_STS", OracleDbType.Int32).Value = objentityPass1.Status_id;
            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }

        public DataTable ReadApprovalAll(clsEntityApprovalHierarchyTemp objentityPass1)
        {
            string strQueryReadAccommodation = "PMS_APPROVALSET.SP_READ_APPROVALAll";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("ADOC_ID", OracleDbType.Varchar2).Value = objentityPass1.Doc;

            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }

        public DataTable ReadApprovallist(clsEntityApprovalHierarchyTemp objentityPass1)
        {
            string strQueryReadAccommodation = "PMS_APPROVALSET.SP_READ_APPROVALLIST";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("A_DESG", OracleDbType.Int32).Value = objentityPass1.DesgId;
            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public DataTable ReadApprovalcncl()
        {
            string strQueryReadAccommodation = "PMS_APPROVALSET.SP_READ_APPROVALCNCL";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;
            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }
        public void ReopenApprovalset(clsEntityApprovalHierarchyTemp objentityPass)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryLeaveTyp = "PMS_APPROVALSET.SP_REOPEN_APPROVALSET";
            OracleTransaction tran;
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

                        cmdAddService.CommandText = strQueryLeaveTyp;
                        cmdAddService.CommandType = CommandType.StoredProcedure;

                        cmdAddService.Parameters.Add("APPROVALSET_ID", OracleDbType.Int32).Value = objentityPass.TempId;
                        cmdAddService.Parameters.Add("APPROVALSET_ORGID", OracleDbType.Int32).Value = objentityPass.Organisation_id;
                        cmdAddService.Parameters.Add("APPROVALSET_CORPID", OracleDbType.Int32).Value = objentityPass.Corporate_id;
                        cmdAddService.Parameters.Add("APPROVALSET_USERID ", OracleDbType.Varchar2).Value = objentityPass.User_Id;

                        cmdAddService.ExecuteNonQuery();
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

        public DataTable ReadApprovalAss(clsEntityApprovalHierarchyTemp objentityPass1)
        {
            string strQueryReadAccommodation = "PMS_APPROVALSET.SP_READ_APPROVLA_ASSIGNMENT";
            OracleCommand cmdReadAccommodation = new OracleCommand();
            cmdReadAccommodation.CommandText = strQueryReadAccommodation;
            cmdReadAccommodation.CommandType = CommandType.StoredProcedure;

            cmdReadAccommodation.Parameters.Add("AP_ID", OracleDbType.Int32).Value = objentityPass1.TempId;
            cmdReadAccommodation.Parameters.Add("A_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtResult = new DataTable();
            dtResult = clsDataLayer.ExecuteReader(cmdReadAccommodation);
            return dtResult;
        }

        public DataTable ReadApprovalWrkflowList(clsEntityApprovalHierarchyTemp objEntityWrkflow)
        {
            string strQueryReadAccommodation = "PMS_APPROVALSET.SP_READ_APPROVAL_LIST";
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
    }
}
