using CL_Compzit;
using EL_Compzit;
using EL_Compzit.Entity_Layer_HCM;
using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DL_Compzit.DataLayer_HCM
{
    public class clsData_Memo_Reason_Master
    {
       // clsData_Memo_Reason_Master objDataLayeMemoReason = new clsData_Memo_Reason_Master();
        public void AddMemoReason(clsEntity_Memo_Reason_Master objEntityMemoReason)
        {

            OracleTransaction tran;


            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();

                tran = con.BeginTransaction();

                try
                {
                    string strQueryAddMemoReason = "HCM_MEMO_RSN.SP_ADD_REASON";
                    using (OracleCommand cmdAddMemoReason = new OracleCommand(strQueryAddMemoReason, con))
                    {
                        cmdAddMemoReason.CommandType = CommandType.StoredProcedure;
                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.HCM_LEAVE_TYPE_MASTER);
                        objEntCommon.CorporateID = objEntityMemoReason.Corporate_id;


                        cmdAddMemoReason.Parameters.Add("P_ORG_ID", OracleDbType.Int32).Value = objEntityMemoReason.Organisation_id;
                        cmdAddMemoReason.Parameters.Add("P_CORPRT_ID", OracleDbType.Int32).Value = objEntityMemoReason.Corporate_id;
                        cmdAddMemoReason.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntityMemoReason.MemoRsnName;
                        cmdAddMemoReason.Parameters.Add("P_DESC", OracleDbType.Varchar2).Value = objEntityMemoReason.MemoDesc;
                        cmdAddMemoReason.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityMemoReason.MemoStatus;
                        cmdAddMemoReason.Parameters.Add("P_INS_USRID", OracleDbType.Int32).Value = objEntityMemoReason.User_Id;
                        cmdAddMemoReason.Parameters.Add("P_INS_DATE", OracleDbType.Date).Value = objEntityMemoReason.MemoUserDate;
                        cmdAddMemoReason.ExecuteNonQuery();
                    
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

        public DataTable ReadLMemoResn(clsEntity_Memo_Reason_Master objEntityMemoReason)
        {
            string strQueryReadMemoResn = "HCM_MEMO_RSN.SP_REASN_LIST";
            OracleCommand cmdReadMemoResn = new OracleCommand();
            cmdReadMemoResn.CommandText = strQueryReadMemoResn;
            cmdReadMemoResn.CommandType = CommandType.StoredProcedure;

            cmdReadMemoResn.Parameters.Add("P_ORG_ID", OracleDbType.Int32).Value = objEntityMemoReason.Organisation_id;
            cmdReadMemoResn.Parameters.Add("P_CORPRT_ID", OracleDbType.Int32).Value = objEntityMemoReason.Corporate_id;
            cmdReadMemoResn.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadMemoResn);
            return dtLeav;

        }
        public DataTable ReadLMemoResnById(clsEntity_Memo_Reason_Master objEntityMemoReason)
        {
            string strQueryReadMemoResn = "HCM_MEMO_RSN.SP_READ_REASN_BYID";
            OracleCommand cmdReadMemoResn = new OracleCommand();
            cmdReadMemoResn.CommandText = strQueryReadMemoResn;
            cmdReadMemoResn.CommandType = CommandType.StoredProcedure;

           
            cmdReadMemoResn.Parameters.Add("P_RSN_ID", OracleDbType.Int32).Value = objEntityMemoReason.MemoId;
            cmdReadMemoResn.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtLeav = new DataTable();
            dtLeav = clsDataLayer.ExecuteReader(cmdReadMemoResn);
            return dtLeav;

        }


        public void UpdateMemoReason(clsEntity_Memo_Reason_Master objEntityMemoReason)
        {
            string strQueryupdMemoRsn = "HCM_MEMO_RSN.SP_UPDATE_REASON";
            using (OracleCommand cmdUpdMemoRsn = new OracleCommand())
            {
                cmdUpdMemoRsn.CommandText = strQueryupdMemoRsn;
                cmdUpdMemoRsn.CommandType = CommandType.StoredProcedure;
                cmdUpdMemoRsn.Parameters.Add("P_ORG_ID", OracleDbType.Int32).Value = objEntityMemoReason.Organisation_id;
                cmdUpdMemoRsn.Parameters.Add("P_CORPRT_ID", OracleDbType.Int32).Value = objEntityMemoReason.Corporate_id;
                cmdUpdMemoRsn.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntityMemoReason.MemoRsnName;
                cmdUpdMemoRsn.Parameters.Add("P_DESC", OracleDbType.Varchar2).Value = objEntityMemoReason.MemoDesc;
                cmdUpdMemoRsn.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityMemoReason.MemoStatus;
                cmdUpdMemoRsn.Parameters.Add("P_UPD_USRID", OracleDbType.Int32).Value = objEntityMemoReason.User_Id;
                cmdUpdMemoRsn.Parameters.Add("P_UPD_DATE", OracleDbType.Date).Value = objEntityMemoReason.MemoUserDate;
                cmdUpdMemoRsn.Parameters.Add("P_RSN_ID", OracleDbType.Int32).Value = objEntityMemoReason.MemoId;
                clsDataLayer.ExecuteNonQuery(cmdUpdMemoRsn);
            }
        }

        public void CancelMemoReason(clsEntity_Memo_Reason_Master objEntityMemoReason)
        {
            string strQueryMemoRsnCncl = " HCM_MEMO_RSN.SP_CANCEL_MEMO_RSN";
            using (OracleCommand cmdMemoRsn = new OracleCommand())
            {
                cmdMemoRsn.CommandText = strQueryMemoRsnCncl;
                cmdMemoRsn.CommandType = CommandType.StoredProcedure;
                cmdMemoRsn.Parameters.Add("P_RSN_ID", OracleDbType.Int32).Value = objEntityMemoReason.MemoId;
                cmdMemoRsn.Parameters.Add("P_RSN_CNSL_USRID", OracleDbType.Int32).Value = objEntityMemoReason.User_Id;
                cmdMemoRsn.Parameters.Add("P_RSN_CNSL_DATE", OracleDbType.Date).Value = objEntityMemoReason.MemoUserDate;
                cmdMemoRsn.Parameters.Add("P_RSN_CNSL_RSN", OracleDbType.Varchar2).Value = objEntityMemoReason.MemoCnclRsn;
                clsDataLayer.ExecuteNonQuery(cmdMemoRsn);
            }
        }

        public DataTable ReadMemoResnList(clsEntity_Memo_Reason_Master objEntityMemoReason)
        {
           
            using (OracleCommand cmdReadSrchList = new OracleCommand())
            {
                cmdReadSrchList.CommandText = "HCM_MEMO_RSN.SP_READ_MEMORSN_SEARCH_LIST";
                cmdReadSrchList.CommandType = CommandType.StoredProcedure;
                cmdReadSrchList.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityMemoReason.Organisation_id;
                cmdReadSrchList.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityMemoReason.Corporate_id;

                cmdReadSrchList.Parameters.Add("P_OPTION", OracleDbType.Int32).Value = objEntityMemoReason.MemoStatus;
                cmdReadSrchList.Parameters.Add("P_CANCEL", OracleDbType.Int32).Value = objEntityMemoReason.CnclStatus;
                cmdReadSrchList.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtRsn = new DataTable();
                dtRsn = clsDataLayer.ExecuteReader(cmdReadSrchList);
                return dtRsn;
            }

        }

        public void ChangeMemoStatus(clsEntity_Memo_Reason_Master objEntityMemoReason)
        {
            string strQueryUpdsts = "HCM_MEMO_RSN.SP_UPD_MEMO_STATUS";
            using (OracleCommand cmdUpdOrgDetail = new OracleCommand())
            {
                cmdUpdOrgDetail.CommandText = strQueryUpdsts;
                cmdUpdOrgDetail.CommandType = CommandType.StoredProcedure;
                cmdUpdOrgDetail.Parameters.Add("P_RSN_ID", OracleDbType.Int32).Value = objEntityMemoReason.MemoId;
                cmdUpdOrgDetail.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityMemoReason.MemoStatus;
                clsDataLayer.ExecuteNonQuery(cmdUpdOrgDetail);
            }
        }

        public string CheckCategoryName(clsEntity_Memo_Reason_Master objEntityMemoReason)
        {

            string strQueryCheckCategoryName = "HCM_MEMO_RSN.SP_CHECK_CONDUCT_CATGRY_NAME";
            OracleCommand cmdCheckCategoryName = new OracleCommand();
            cmdCheckCategoryName.CommandText = strQueryCheckCategoryName;
            cmdCheckCategoryName.CommandType = CommandType.StoredProcedure;
            cmdCheckCategoryName.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityMemoReason.MemoId;
            cmdCheckCategoryName.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityMemoReason.MemoRsnName;
            cmdCheckCategoryName.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityMemoReason.Corporate_id;
            cmdCheckCategoryName.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityMemoReason.Organisation_id;
            cmdCheckCategoryName.Parameters.Add("C_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCategoryName);
            string strReturn = cmdCheckCategoryName.Parameters["C_COUNT"].Value.ToString();
            cmdCheckCategoryName.Dispose();
            return strReturn;
        }
  
    }
}
