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
    public class clsDataLayer_OverTime_Category
    {
        public DataTable ReadPaygrade(clsEntity_OverTime_Category objEntity_OverTime_Category)
        {
            string strQueryReadUsers = "OVERTIME_CATEGORY_MSTR.SP_READ_PAYGARDE";
            using (OracleCommand cmdReadOvertime = new OracleCommand())
            {
                cmdReadOvertime.CommandText = strQueryReadUsers;
                cmdReadOvertime.CommandType = CommandType.StoredProcedure;
                cmdReadOvertime.Parameters.Add("E_USERID", OracleDbType.Int32).Value = objEntity_OverTime_Category.User_Id;
                cmdReadOvertime.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntity_OverTime_Category.Organisation_id;
                cmdReadOvertime.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity_OverTime_Category.Corporate_id;
                cmdReadOvertime.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtPaygrade = new DataTable();
                dtPaygrade = clsDataLayer.ExecuteReader(cmdReadOvertime);
                return dtPaygrade;
            }
        }
        public void InsertOvrtmCategory(clsEntity_OverTime_Category objEntity_OverTime_Category,List<clsEntity_OverTIme_Category_List> objEntity_OverTIme_Category_List)
        {
            int OvrtmCatgrMasterId;
            int Corporate_id;
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strinsertovrtm = "OVERTIME_CATEGORY_MSTR.SP_INS_OVRTM_CATG_MSTR";
                    using (OracleCommand cmdInsOvertmCatg = new OracleCommand())
                    {
                        cmdInsOvertmCatg.Transaction = tran;
                        cmdInsOvertmCatg.Connection = con;

                        cmdInsOvertmCatg.CommandText = strinsertovrtm;
                        cmdInsOvertmCatg.CommandType = CommandType.StoredProcedure;
                        cmdInsOvertmCatg.Parameters.Add("P_OVRTMCATG_ID", OracleDbType.Int32).Value = objEntity_OverTime_Category.OvrtmCatgrMasterId;
                        cmdInsOvertmCatg.Parameters.Add("P_OVRTMCATG_NAME", OracleDbType.Varchar2).Value = objEntity_OverTime_Category.OvrtmCategoryName;
                        cmdInsOvertmCatg.Parameters.Add("P_OVRTMCATG_RATE", OracleDbType.Double).Value = objEntity_OverTime_Category.OvrtmCategoryRate;
                        cmdInsOvertmCatg.Parameters.Add("P_OVRTMCATG_STATUS", OracleDbType.Int32).Value = objEntity_OverTime_Category.Status_id;
                        cmdInsOvertmCatg.Parameters.Add("P_ORG_ID", OracleDbType.Int32).Value = objEntity_OverTime_Category.Organisation_id;
                        cmdInsOvertmCatg.Parameters.Add("P_CORPRT_ID", OracleDbType.Int32).Value = objEntity_OverTime_Category.Corporate_id;
                        cmdInsOvertmCatg.Parameters.Add("P_OVRTMCATG_INS_USR_ID", OracleDbType.Int32).Value = objEntity_OverTime_Category.User_Id;
                        cmdInsOvertmCatg.Parameters.Add("P_OVRTMCATG_INS_DATE", OracleDbType.Date).Value = objEntity_OverTime_Category.Date;
                        cmdInsOvertmCatg.ExecuteNonQuery();
                    }


                    string strinsertovrtmdtls = "OVERTIME_CATEGORY_MSTR.SP_INS_OVRTM_CATG_DTLS";

                    foreach (clsEntity_OverTIme_Category_List objovrtmdtl in objEntity_OverTIme_Category_List)
                    {
                        using (OracleCommand cmdinsImgrtnrndDtls = new OracleCommand())
                        {
                            cmdinsImgrtnrndDtls.Transaction = tran;
                            cmdinsImgrtnrndDtls.Connection = con;

                            cmdinsImgrtnrndDtls.CommandText = strinsertovrtmdtls;
                            cmdinsImgrtnrndDtls.CommandType = CommandType.StoredProcedure;
                            cmdinsImgrtnrndDtls.Parameters.Add("P_OVRTMCATG_DTLS_PAYG_ID", OracleDbType.Int32).Value = objovrtmdtl.PayGradeId;
                            cmdinsImgrtnrndDtls.Parameters.Add("P_OVRTMCATG_ID", OracleDbType.Int32).Value = objEntity_OverTime_Category.OvrtmCatgrMasterId;
                            cmdinsImgrtnrndDtls.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity_OverTime_Category.Corporate_id;
                            cmdinsImgrtnrndDtls.ExecuteNonQuery();
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


        //Read OverTime category

        public DataTable ReadOverTimeCateg(clsEntity_OverTime_Category objEntity_OverTime_Category)
        {
            DataTable dtOvrtm = new DataTable();
            using (OracleCommand cmdReadtOvrtm = new OracleCommand())
            {

                cmdReadtOvrtm.CommandText = "OVERTIME_CATEGORY_MSTR.SP_READ_OVRTM_CATG";
                cmdReadtOvrtm.CommandType = CommandType.StoredProcedure;
                cmdReadtOvrtm.Parameters.Add("P_OVRTMCATG_ID", OracleDbType.Int32).Value = objEntity_OverTime_Category.OvrtmCatgrMasterId;
                cmdReadtOvrtm.Parameters.Add("P_OVRTMCATG_NAME", OracleDbType.Varchar2).Value = objEntity_OverTime_Category.OvrtmCategoryName;
                cmdReadtOvrtm.Parameters.Add("P_OVRTMCATG_RATE", OracleDbType.Double).Value = objEntity_OverTime_Category.OvrtmCategoryRate;
                cmdReadtOvrtm.Parameters.Add("P_OVRTMCATG_STATUS", OracleDbType.Int32).Value = objEntity_OverTime_Category.Status_id;
                cmdReadtOvrtm.Parameters.Add("P_ORG_ID", OracleDbType.Int32).Value = objEntity_OverTime_Category.Organisation_id;
                cmdReadtOvrtm.Parameters.Add("P_CORPRT_ID", OracleDbType.Int32).Value = objEntity_OverTime_Category.Corporate_id;
                cmdReadtOvrtm.Parameters.Add("P_OVRTMCATG_CNCL_USR_ID", OracleDbType.Int32).Value = objEntity_OverTime_Category.CancelStatus;
                cmdReadtOvrtm.Parameters.Add("P_OVRTMCATG_INS_USR_ID", OracleDbType.Int32).Value = objEntity_OverTime_Category.User_Id;
                cmdReadtOvrtm.Parameters.Add("P_OVRTMCATG_INS_DATE", OracleDbType.Date).Value = objEntity_OverTime_Category.Date;
                cmdReadtOvrtm.Parameters.Add("P_OVRTMCATG", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                dtOvrtm = clsDataLayer.SelectDataTable(cmdReadtOvrtm);
            }
            return dtOvrtm;
        }
        public DataTable ReadOverTimeCategById(clsEntity_OverTime_Category objEntity_OverTime_Category)
        {
            clsEntity_OverTIme_Category_List objEntity_OverTIme_Category_List = new clsEntity_OverTIme_Category_List();
            DataTable dtOvrtm = new DataTable();
            using (OracleCommand cmdReadtOvrtmId = new OracleCommand())
            {

                cmdReadtOvrtmId.CommandText = "OVERTIME_CATEGORY_MSTR.SP_READ_OVRTM_CATG_BY_ID";
                cmdReadtOvrtmId.CommandType = CommandType.StoredProcedure;
                cmdReadtOvrtmId.Parameters.Add("P_OVRTMCATG_ID", OracleDbType.Int32).Value = objEntity_OverTime_Category.OvrtmCatgrMasterId;
                cmdReadtOvrtmId.Parameters.Add("P_OVRTMCATG_NAME", OracleDbType.Varchar2).Value = objEntity_OverTime_Category.OvrtmCategoryName;
                cmdReadtOvrtmId.Parameters.Add("P_OVRTMCATG_RATE", OracleDbType.Double).Value = objEntity_OverTime_Category.OvrtmCategoryRate;
                cmdReadtOvrtmId.Parameters.Add("P_OVRTMCATG_STATUS", OracleDbType.Int32).Value = objEntity_OverTime_Category.Status_id;
                cmdReadtOvrtmId.Parameters.Add("P_OVRTMCATG_DTLS_PAYG_ID", OracleDbType.Int32).Value = objEntity_OverTIme_Category_List.PayGradeId;
                cmdReadtOvrtmId.Parameters.Add("P_OVRTMCATG", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtOvrtm = clsDataLayer.SelectDataTable(cmdReadtOvrtmId);
            }
            return dtOvrtm;
        }

        public void UpdateOverTimeCategory(clsEntity_OverTime_Category objEntity_OverTime_Category, List<clsEntity_OverTIme_Category_List> objEntity_OverTIme_Category_List)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryOvrtm = "OVERTIME_CATEGORY_MSTR.SP_UPD_OVRTM_CATG";
                    using (OracleCommand cmdUpdtOvrtmId = new OracleCommand())
                    {
                        cmdUpdtOvrtmId.Transaction = tran;
                        cmdUpdtOvrtmId.Connection = con;
                        cmdUpdtOvrtmId.CommandText = strQueryOvrtm;
                        cmdUpdtOvrtmId.CommandType = CommandType.StoredProcedure;
                        cmdUpdtOvrtmId.Parameters.Add("P_OVRTMCATG_ID", OracleDbType.Int32).Value = objEntity_OverTime_Category.OvrtmCatgrMasterId;
                        cmdUpdtOvrtmId.Parameters.Add("P_OVRTMCATG_NAME", OracleDbType.Varchar2).Value = objEntity_OverTime_Category.OvrtmCategoryName;
                        cmdUpdtOvrtmId.Parameters.Add("P_OVRTMCATG_RATE", OracleDbType.Double).Value = objEntity_OverTime_Category.OvrtmCategoryRate;
                        cmdUpdtOvrtmId.Parameters.Add("P_OVRTMCATG_STATUS", OracleDbType.Int32).Value = objEntity_OverTime_Category.Status_id;
                        cmdUpdtOvrtmId.Parameters.Add("P_ORG_ID", OracleDbType.Int32).Value = objEntity_OverTime_Category.Organisation_id;
                        cmdUpdtOvrtmId.Parameters.Add("P_CORPRT_ID", OracleDbType.Int32).Value = objEntity_OverTime_Category.Corporate_id;
                        cmdUpdtOvrtmId.Parameters.Add("P_OVRTMCATG_INS_USR_ID", OracleDbType.Int32).Value = objEntity_OverTime_Category.User_Id;
                        cmdUpdtOvrtmId.Parameters.Add("P_OVRTMCATG_INS_DATE", OracleDbType.Date).Value = objEntity_OverTime_Category.Date;
                        clsDataLayer.ExecuteNonQuery(cmdUpdtOvrtmId);
                    }

                    string strdlttovrtmdtls = "OVERTIME_CATEGORY_MSTR.SP_DELETE_OVRTM_CATG_DTLS_ID";
                    foreach (clsEntity_OverTIme_Category_List objovrtmdtl in objEntity_OverTIme_Category_List)
                    {
                        using (OracleCommand cmddltImgrtnrndDtls = new OracleCommand())
                        {
                            cmddltImgrtnrndDtls.Transaction = tran;
                            cmddltImgrtnrndDtls.Connection = con;
                            cmddltImgrtnrndDtls.CommandText = strdlttovrtmdtls;
                            cmddltImgrtnrndDtls.CommandType = CommandType.StoredProcedure;
                            cmddltImgrtnrndDtls.Parameters.Add("P_OVRTMCATG_ID", OracleDbType.Int32).Value = objEntity_OverTime_Category.OvrtmCatgrMasterId;
                            cmddltImgrtnrndDtls.Parameters.Add("P_OVRTMCATG_DTLS_PAYG_ID", OracleDbType.Int32).Value = objovrtmdtl.PayGradeId;
                            cmddltImgrtnrndDtls.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity_OverTime_Category.Corporate_id;
                            cmddltImgrtnrndDtls.ExecuteNonQuery();
                        }
                    }


                    string strupdtovrtmdtls = "OVERTIME_CATEGORY_MSTR.SP_INS_OVRTM_CATG_DTLS";
                    foreach (clsEntity_OverTIme_Category_List objovrtmdtl in objEntity_OverTIme_Category_List)
                    {
                        using (OracleCommand cmdupdImgrtnrndDtls = new OracleCommand())
                        {
                            cmdupdImgrtnrndDtls.Transaction = tran;
                            cmdupdImgrtnrndDtls.Connection = con;
                            cmdupdImgrtnrndDtls.CommandText = strupdtovrtmdtls;
                            cmdupdImgrtnrndDtls.CommandType = CommandType.StoredProcedure;
                            cmdupdImgrtnrndDtls.Parameters.Add("P_OVRTMCATG_DTLS_PAYG_ID", OracleDbType.Int32).Value = objovrtmdtl.PayGradeId;
                            cmdupdImgrtnrndDtls.Parameters.Add("P_OVRTMCATG_ID", OracleDbType.Int32).Value = objEntity_OverTime_Category.OvrtmCatgrMasterId;
                            cmdupdImgrtnrndDtls.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntity_OverTime_Category.Corporate_id;
                            cmdupdImgrtnrndDtls.ExecuteNonQuery();
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

        // This Method to Cancel Over Time Category details
                 
        public void CancelOverTimeCategory(clsEntity_OverTime_Category objEntity_OverTime_Category)
        {
            string strQueryOvrtmCatg = "OVERTIME_CATEGORY_MSTR.SP_CANCEL_OVRTM_CATG";
            using (OracleCommand cmdOvrtm = new OracleCommand())
            {
                cmdOvrtm.CommandText = strQueryOvrtmCatg;
                cmdOvrtm.CommandType = CommandType.StoredProcedure;
                cmdOvrtm.Parameters.Add("P_OVRTMCATG_ID", OracleDbType.Int32).Value = objEntity_OverTime_Category.OvrtmCatgrMasterId;
                cmdOvrtm.Parameters.Add("P_OVRTMCATG_CNCL_USR_ID", OracleDbType.Int32).Value = objEntity_OverTime_Category.User_Id;
                cmdOvrtm.Parameters.Add("P_OVRTMCATG_CNCL_DATE", OracleDbType.Date).Value = objEntity_OverTime_Category.Date;
                cmdOvrtm.Parameters.Add("P_OVRTMCATG_CNCL_REASN", OracleDbType.Varchar2).Value = objEntity_OverTime_Category.CancelReason;
                clsDataLayer.ExecuteNonQuery(cmdOvrtm);
            }
        }

        // This Method checks Category name in the database for duplication.
        public string CheckCategoryName(clsEntity_OverTime_Category objEntity_OverTime_Category)
        {

            string strQueryCheckCatgName = "OVERTIME_CATEGORY_MSTR.SP_CHECK_CATEGORY_NAME";
            OracleCommand cmdCheckCatgName = new OracleCommand();
            cmdCheckCatgName.CommandText = strQueryCheckCatgName;
            cmdCheckCatgName.CommandType = CommandType.StoredProcedure;
            cmdCheckCatgName.Parameters.Add("P_OVRTMCATG_ID", OracleDbType.Int32).Value = objEntity_OverTime_Category.OvrtmCatgrMasterId;
            cmdCheckCatgName.Parameters.Add("P_OVRTMCATG_NAME", OracleDbType.Varchar2).Value = objEntity_OverTime_Category.OvrtmCategoryName;


            cmdCheckCatgName.Parameters.Add("P_CORPRT_ID", OracleDbType.Int32).Value = objEntity_OverTime_Category.Corporate_id;
            cmdCheckCatgName.Parameters.Add("P_ORG_ID", OracleDbType.Int32).Value = objEntity_OverTime_Category.Organisation_id;
            cmdCheckCatgName.Parameters.Add("P_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCatgName);
            string strReturn = cmdCheckCatgName.Parameters["P_COUNT"].Value.ToString();
            cmdCheckCatgName.Dispose();
            return strReturn;
        }

    }
}
