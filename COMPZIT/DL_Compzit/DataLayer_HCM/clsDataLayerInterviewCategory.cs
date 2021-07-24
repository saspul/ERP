using System;
using System.Data;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit.EntityLayer_HCM;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataLayerInterviewCategory
    {
        //Methode of inserting values to Interview Category and Interview Category Details table.
        public void InsertInterviewCategory(clsEntityInterviewCategory objEntityInterviewCategory, List<clsEntityInterviewCategoryDetails> objInterviewCategoryDtls)
        {

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryInsertDsgn = "INTERVIEW_CATEGORY.SP_INS_INTERV_CTGRY_MSTR";
                    using (OracleCommand cmdInsertInterviewCat = new OracleCommand())
                    {
                        cmdInsertInterviewCat.Transaction = tran;
                        cmdInsertInterviewCat.Connection = con;
                        cmdInsertInterviewCat.CommandText = strQueryInsertDsgn;
                        cmdInsertInterviewCat.CommandType = CommandType.StoredProcedure;
                        cmdInsertInterviewCat.Parameters.Add("I_INTWCTGRY_ID", OracleDbType.Int32).Value = objEntityInterviewCategory.IntwCategoryId;
                        cmdInsertInterviewCat.Parameters.Add("I_INTWCTGRY_NAME", OracleDbType.Varchar2).Value = objEntityInterviewCategory.IntwCategoryName;
                        cmdInsertInterviewCat.Parameters.Add("I_INTWCTGRY_STATUS", OracleDbType.Int32).Value = objEntityInterviewCategory.IntwCategoryStatus;
                        cmdInsertInterviewCat.Parameters.Add("I_ORG_ID", OracleDbType.Int32).Value = objEntityInterviewCategory.OrgId;
                        cmdInsertInterviewCat.Parameters.Add("I_CORPRT_ID", OracleDbType.Int32).Value = objEntityInterviewCategory.CorpId;
                        cmdInsertInterviewCat.Parameters.Add("I_INTWCTGRY_INS_USR_ID", OracleDbType.Int32).Value = objEntityInterviewCategory.UserId;
                        cmdInsertInterviewCat.Parameters.Add("I_INTWCTGRY_INS_DATE", OracleDbType.Date).Value = objEntityInterviewCategory.Date;
                        cmdInsertInterviewCat.ExecuteNonQuery();
                    }


                    string strQueryInsertInterviewCatDtl = "INTERVIEW_CATEGORY.SP_INS_INTERV_CTGRY_DTLS";
                    foreach (clsEntityInterviewCategoryDetails objIntCatDtl in objInterviewCategoryDtls)
                    {
                        using (OracleCommand cmdInsertInterviewCatDtl = new OracleCommand())
                        {
                            cmdInsertInterviewCatDtl.Transaction = tran;
                            cmdInsertInterviewCatDtl.Connection = con;
                            cmdInsertInterviewCatDtl.CommandText = strQueryInsertInterviewCatDtl;
                            cmdInsertInterviewCatDtl.CommandType = CommandType.StoredProcedure;
                            cmdInsertInterviewCatDtl.Parameters.Add("I_INTWCTGRY_ID", OracleDbType.Int32).Value = objEntityInterviewCategory.IntwCategoryId;
                            cmdInsertInterviewCatDtl.Parameters.Add("I_INTWCTGRYDTL_NAME", OracleDbType.Varchar2).Value = objIntCatDtl.IntwCtgryDtlName;
                            cmdInsertInterviewCatDtl.Parameters.Add("I_DFLT_STATUS", OracleDbType.Int32).Value = objIntCatDtl.IntwCtgryDtlStatus;
                            cmdInsertInterviewCatDtl.ExecuteNonQuery();
                        }
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;

                }

            }
        }
        // This Method checks interviewCategory Name in the database for duplication
        public string CheckDupInterviewCategory(clsEntityInterviewCategory objEntityInterviewCategory)
        {
            string strQueryCheckDsgnName = "INTERVIEW_CATEGORY.SP_CHECK_GN_INTERV_CTGRY";
            OracleCommand cmdCheckInterviewCategoryName = new OracleCommand();
            cmdCheckInterviewCategoryName.CommandText = strQueryCheckDsgnName;
            cmdCheckInterviewCategoryName.CommandType = CommandType.StoredProcedure;
            if (objEntityInterviewCategory.IntwCategoryId == 0)
            {
                cmdCheckInterviewCategoryName.Parameters.Add("I_INTWCTGRY_ID", OracleDbType.Int32).Value = null;
            }
            else
            {
                cmdCheckInterviewCategoryName.Parameters.Add("I_INTWCTGRY_ID", OracleDbType.Int32).Value = objEntityInterviewCategory.IntwCategoryId;
            }
            cmdCheckInterviewCategoryName.Parameters.Add("I_INTWCTGRY_NAME", OracleDbType.Varchar2).Value = objEntityInterviewCategory.IntwCategoryName;
            cmdCheckInterviewCategoryName.Parameters.Add("I_ORG_ID", OracleDbType.Int32).Value = objEntityInterviewCategory.OrgId;
            cmdCheckInterviewCategoryName.Parameters.Add("I_CORPRT_ID", OracleDbType.Int32).Value = objEntityInterviewCategory.CorpId;
            cmdCheckInterviewCategoryName.Parameters.Add("I_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckInterviewCategoryName);
            string strReturn = cmdCheckInterviewCategoryName.Parameters["I_COUNT"].Value.ToString();
            cmdCheckInterviewCategoryName.Dispose();
            return strReturn;
        }
        //Methode of inserting values to Interview Category and Interview Category Details table. (objEntityInterviewCategory, objEntityIntwCatDtlINSERTList, objEntityIntwCatDtlUPDATEList, objEntityIntwCatDtlDELETEList)
        public void UpdateInterviewCategory(clsEntityInterviewCategory objEntityInterviewCategory, List<clsEntityInterviewCategoryDetails> objEntityIntwCatDtlINSERTList,List<clsEntityInterviewCategoryDetails> objEntityIntwCatDtlUPDATEList,List<clsEntityInterviewCategoryDetails> objEntityIntwCatDtlDELETEList)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryUpdateDsgn = "INTERVIEW_CATEGORY.SP_UPD_INTERV_CTGRY_MSTR";
                    //int intJobRlID = int.Parse( objEntityDsgn.CorpOfficeId.ToString()+objEntityDsgn.JobRoleId.ToString());
                    using (OracleCommand cmdUpdateInterviewCat = new OracleCommand())
                    {
                        cmdUpdateInterviewCat.Transaction = tran;
                        cmdUpdateInterviewCat.Connection = con;
                        cmdUpdateInterviewCat.CommandText = strQueryUpdateDsgn;
                        cmdUpdateInterviewCat.CommandType = CommandType.StoredProcedure;
                        cmdUpdateInterviewCat.Parameters.Add("I_INTWCTGRY_ID", OracleDbType.Int32).Value = objEntityInterviewCategory.IntwCategoryId;
                        cmdUpdateInterviewCat.Parameters.Add("I_INTWCTGRY_NAME", OracleDbType.Varchar2).Value = objEntityInterviewCategory.IntwCategoryName;
                        cmdUpdateInterviewCat.Parameters.Add("I_INTWCTGRY_STATUS", OracleDbType.Int32).Value = objEntityInterviewCategory.IntwCategoryStatus;
                        cmdUpdateInterviewCat.Parameters.Add("I_ORG_ID", OracleDbType.Int32).Value = objEntityInterviewCategory.OrgId;
                        cmdUpdateInterviewCat.Parameters.Add("I_CORPRT_ID", OracleDbType.Int32).Value = objEntityInterviewCategory.CorpId;
                        cmdUpdateInterviewCat.Parameters.Add("I_INTWCTGRY_UPD_USR_ID", OracleDbType.Int32).Value = objEntityInterviewCategory.UserId;
                        cmdUpdateInterviewCat.Parameters.Add("I_INTWCTGRY_UPD_DATE", OracleDbType.Date).Value = objEntityInterviewCategory.Date;
                        cmdUpdateInterviewCat.ExecuteNonQuery();
                    }
                    //INSERT DTL
                    string strQueryInsertInterviewCatDtl = "INTERVIEW_CATEGORY.SP_INS_INTERV_CTGRY_DTLS";
                    foreach (clsEntityInterviewCategoryDetails objIntCatDtl in objEntityIntwCatDtlINSERTList)
                    {
                        using (OracleCommand cmdInsertInterviewCatDtl = new OracleCommand())
                        {
                            cmdInsertInterviewCatDtl.Transaction = tran;
                            cmdInsertInterviewCatDtl.Connection = con;
                            cmdInsertInterviewCatDtl.CommandText = strQueryInsertInterviewCatDtl;
                            cmdInsertInterviewCatDtl.CommandType = CommandType.StoredProcedure;
                            cmdInsertInterviewCatDtl.Parameters.Add("I_INTWCTGRY_ID", OracleDbType.Int32).Value = objEntityInterviewCategory.IntwCategoryId;
                            cmdInsertInterviewCatDtl.Parameters.Add("I_INTWCTGRYDTL_NAME", OracleDbType.Varchar2).Value = objIntCatDtl.IntwCtgryDtlName;
                            cmdInsertInterviewCatDtl.Parameters.Add("I_DFLT_STATUS", OracleDbType.Int32).Value = objIntCatDtl.IntwCtgryDtlStatus;
                            cmdInsertInterviewCatDtl.ExecuteNonQuery();
                        }
                    }
                    //UPDATE
                    string strQueryUpdateInterviewCatDtl = "INTERVIEW_CATEGORY.SP_UPD_INTERV_CTGRY_DTLS";
                    foreach (clsEntityInterviewCategoryDetails objIntCatDtl in objEntityIntwCatDtlUPDATEList)
                    {
                        using (OracleCommand cmdUpdateInterviewCatDtl = new OracleCommand())
                        {
                            cmdUpdateInterviewCatDtl.Transaction = tran;
                            cmdUpdateInterviewCatDtl.Connection = con;
                            cmdUpdateInterviewCatDtl.CommandText = strQueryUpdateInterviewCatDtl;
                            cmdUpdateInterviewCatDtl.CommandType = CommandType.StoredProcedure;
                            cmdUpdateInterviewCatDtl.Parameters.Add("I_INTWCTGRYDTL_ID", OracleDbType.Int32).Value = objIntCatDtl.IntwCtgryDtlId;
                            cmdUpdateInterviewCatDtl.Parameters.Add("I_INTWCTGRY_ID", OracleDbType.Int32).Value = objEntityInterviewCategory.IntwCategoryId;
                            cmdUpdateInterviewCatDtl.Parameters.Add("I_INTWCTGRYDTL_NAME", OracleDbType.Varchar2).Value = objIntCatDtl.IntwCtgryDtlName;
                            cmdUpdateInterviewCatDtl.Parameters.Add("I_DFLT_STATUS", OracleDbType.Int32).Value = objIntCatDtl.IntwCtgryDtlStatus;
                            cmdUpdateInterviewCatDtl.ExecuteNonQuery();
                        }
                    }
                    //DELETE
                    string strQueryDeleteInterviewCatDtl = "INTERVIEW_CATEGORY.SP_DEL_INTERV_CTGRY_DTLS";
                    foreach (clsEntityInterviewCategoryDetails objIntCatDtl in objEntityIntwCatDtlDELETEList)
                    {
                        using (OracleCommand cmdUpdateInterviewCatDtl = new OracleCommand())
                        {
                            cmdUpdateInterviewCatDtl.Transaction = tran;
                            cmdUpdateInterviewCatDtl.Connection = con;
                            cmdUpdateInterviewCatDtl.CommandText = strQueryDeleteInterviewCatDtl;
                            cmdUpdateInterviewCatDtl.CommandType = CommandType.StoredProcedure;
                            cmdUpdateInterviewCatDtl.Parameters.Add("I_INTWCTGRYDTL_ID", OracleDbType.Int32).Value = objIntCatDtl.IntwCtgryDtlId;
                            cmdUpdateInterviewCatDtl.Parameters.Add("I_INTWCTGRY_ID", OracleDbType.Int32).Value = objEntityInterviewCategory.IntwCategoryId;
                            cmdUpdateInterviewCatDtl.ExecuteNonQuery();
                        }
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;

                }

            }
        }
        //Read InterviewCat list 
        public DataTable ReadInterviewCatList(clsEntityInterviewCategory objEntityInterviewCategory)
        {
            DataTable dtInterviewCatList = new DataTable();
            using (OracleCommand cmdReadInterviewCatList = new OracleCommand())
            {
                cmdReadInterviewCatList.CommandText = "INTERVIEW_CATEGORY.SP_READ_INTWCTGRY_LIST";
                cmdReadInterviewCatList.CommandType = CommandType.StoredProcedure;
                cmdReadInterviewCatList.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = objEntityInterviewCategory.OrgId;
                cmdReadInterviewCatList.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntityInterviewCategory.CorpId;
                cmdReadInterviewCatList.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntityInterviewCategory.IntwCategoryStatus;
                cmdReadInterviewCatList.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntityInterviewCategory.CancelStatus;
                cmdReadInterviewCatList.Parameters.Add("I_DEPT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtInterviewCatList = clsDataLayer.SelectDataTable(cmdReadInterviewCatList);
            }
            return dtInterviewCatList;
        }
        //Read InterviewCat BY ID 
        public DataTable ReadInterviewCatByID(clsEntityInterviewCategory objEntityInterviewCategory)
        {
            DataTable dtInterviewCatByID = new DataTable();
            using (OracleCommand cmdReadInterviewCatByID = new OracleCommand())
            {
                cmdReadInterviewCatByID.CommandText = "INTERVIEW_CATEGORY.SP_READ_INTWCTGRY_BYID";
                cmdReadInterviewCatByID.CommandType = CommandType.StoredProcedure;
                cmdReadInterviewCatByID.Parameters.Add("I_INTWCTGRY_ID", OracleDbType.Int32).Value = objEntityInterviewCategory.IntwCategoryId;
                cmdReadInterviewCatByID.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = objEntityInterviewCategory.OrgId;
                cmdReadInterviewCatByID.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntityInterviewCategory.CorpId;
                cmdReadInterviewCatByID.Parameters.Add("I_DEPT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtInterviewCatByID = clsDataLayer.SelectDataTable(cmdReadInterviewCatByID);
            }
            return dtInterviewCatByID;
        }
        // This Method delete Consultancy details 
        public void CancelInterviewCat(clsEntityInterviewCategory objEntityInterviewCategory)
        {
            string strQueryCancelInterviewCat = "INTERVIEW_CATEGORY.SP_CANCEL_INTWCTGRY_MSTR";
            using (OracleCommand cmdCancelInterviewCat = new OracleCommand())
            {
                cmdCancelInterviewCat.CommandText = strQueryCancelInterviewCat;
                cmdCancelInterviewCat.CommandType = CommandType.StoredProcedure;
                cmdCancelInterviewCat.Parameters.Add("I_INTWCTGRY_ID", OracleDbType.Int32).Value = objEntityInterviewCategory.IntwCategoryId;
                cmdCancelInterviewCat.Parameters.Add("I_INTWCTGRY_CNCL_DATE", OracleDbType.Date).Value = objEntityInterviewCategory.Date;
                cmdCancelInterviewCat.Parameters.Add("I_INTWCTGRY_CNCL_REASN", OracleDbType.Varchar2).Value = objEntityInterviewCategory.CancelReason;
                cmdCancelInterviewCat.Parameters.Add("I_INTWCTGRY_CNCL_USR_ID", OracleDbType.Int32).Value = objEntityInterviewCategory.UserId;
                cmdCancelInterviewCat.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = objEntityInterviewCategory.OrgId;
                cmdCancelInterviewCat.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntityInterviewCategory.CorpId;
                cmdCancelInterviewCat.Parameters.Add("I_DEPT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                clsDataLayer.ExecuteNonQuery(cmdCancelInterviewCat);
            }
        }
        //status change InterviewCat 
        public void StatusChangeInterviewCat(clsEntityInterviewCategory objEntityInterviewCategory)
        {
            string strQueryCancelInterviewCat = "INTERVIEW_CATEGORY.SP_STATUS_CH_INTWCTGRY_MSTR";
            using (OracleCommand cmdCancelInterviewCat = new OracleCommand())
            {
                cmdCancelInterviewCat.CommandText = strQueryCancelInterviewCat;
                cmdCancelInterviewCat.CommandType = CommandType.StoredProcedure;
                cmdCancelInterviewCat.Parameters.Add("I_INTWCTGRY_ID", OracleDbType.Int32).Value = objEntityInterviewCategory.IntwCategoryId;
                cmdCancelInterviewCat.Parameters.Add("I_INTWCTGRY_CNCL_DATE", OracleDbType.Date).Value = objEntityInterviewCategory.Date;
                cmdCancelInterviewCat.Parameters.Add("I_INTWCTGRY_CNCL_USR_ID", OracleDbType.Int32).Value = objEntityInterviewCategory.UserId;
                cmdCancelInterviewCat.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = objEntityInterviewCategory.OrgId;
                cmdCancelInterviewCat.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntityInterviewCategory.CorpId;
                clsDataLayer.ExecuteNonQuery(cmdCancelInterviewCat);
            }
        }
            
    }
}
