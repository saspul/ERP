using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using DL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_AWMS;

namespace DL_Compzit.DataLayer_AWMS
{
   public class clsDataLayerInsuranceProvider
    {
       clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
        // This Method will fetch insurance provider type
        public DataTable ReadInsuranceType()
        {
            string strQueryReadInsuranceType = "INSURANCE_PROVIDER.SP_READ_INSURANCE_TYPE";
            OracleCommand cmdReadInsuranceType = new OracleCommand();
            cmdReadInsuranceType.CommandText = strQueryReadInsuranceType;
            cmdReadInsuranceType.CommandType = CommandType.StoredProcedure;
            cmdReadInsuranceType.Parameters.Add(" I_INSURANCETYPE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadInsuranceType);
            return dtCategory;
        }
        //EVM-0016
        // This Method adds insurance provider details to the table
        public void AddInsuranceProvider(clsEntityLayerInsuranceProvider objEntityInsurance,List<clsEntityLayerInsuranceProvider> objEntityInsList)
        {
            OracleTransaction tran;
             using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
             {
                 con.Open();
                 tran = con.BeginTransaction();
                 try
                    {
            string strQueryAddCategory = "INSURANCE_PROVIDER.SP_INS_PROVIDER_DETAILS";
            using (OracleCommand cmdAddInsurance = new OracleCommand(strQueryAddCategory,con))
            {
                cmdAddInsurance.CommandText = strQueryAddCategory;
                cmdAddInsurance.CommandType = CommandType.StoredProcedure;
                cmdAddInsurance.Parameters.Add("I_ID", OracleDbType.Int32).Value = objEntityInsurance.NextNumber;
                cmdAddInsurance.Parameters.Add("I_NAME", OracleDbType.Varchar2).Value = objEntityInsurance.Provider_Name;
                cmdAddInsurance.Parameters.Add("I_ADDRESS", OracleDbType.Varchar2).Value = objEntityInsurance.Provider_Address;
                cmdAddInsurance.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = objEntityInsurance.Organisation_id;
                cmdAddInsurance.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntityInsurance.Corporate_id;
                cmdAddInsurance.Parameters.Add("I_STATUS", OracleDbType.Int32).Value = objEntityInsurance.Status_id;
                cmdAddInsurance.Parameters.Add("I_INSUSERID", OracleDbType.Int32).Value = objEntityInsurance.User_Id;
                cmdAddInsurance.ExecuteNonQuery();
            }
                foreach (clsEntityLayerInsuranceProvider objEntityInsuranceForType in objEntityInsList)
                {
                    string strQueryAddProviderType = "INSURANCE_PROVIDER.SP_INS_PROVIDER_TYPE";
                    using (OracleCommand cmdAddInsType = new OracleCommand(strQueryAddProviderType, con))
                    {
                        cmdAddInsType.CommandText = strQueryAddProviderType;
                        cmdAddInsType.CommandType = CommandType.StoredProcedure;
                        cmdAddInsType.Parameters.Add("I_ID", OracleDbType.Int32).Value = objEntityInsurance.NextNumber;
                        cmdAddInsType.Parameters.Add("I_TYPE", OracleDbType.Int32).Value = objEntityInsuranceForType.Provider_Type;
                        cmdAddInsType.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntityInsurance.Corporate_id;

                        cmdAddInsType.ExecuteNonQuery();
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

        //EVM-0016
        // This Method adds insurance provider details to the table
        public void UpdateInsuranceProvider(clsEntityLayerInsuranceProvider objEntityInsurance, List<clsEntityLayerInsuranceProvider> objEntityInsList)
        {
            OracleTransaction tran;
             using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
             {
                 con.Open();
                 tran = con.BeginTransaction();
                 try
                 
                 {
            string strQueryUpdCategory = "INSURANCE_PROVIDER.SP_UPD_PROVIDER_DETAILS";
            using (OracleCommand cmdUpdInsurance = new OracleCommand(strQueryUpdCategory,con))
            {
                cmdUpdInsurance.CommandText = strQueryUpdCategory;
                cmdUpdInsurance.CommandType = CommandType.StoredProcedure;
                cmdUpdInsurance.Parameters.Add("I_ID", OracleDbType.Int32).Value = objEntityInsurance.InsuranceId;
                cmdUpdInsurance.Parameters.Add("I_NAME", OracleDbType.Varchar2).Value = objEntityInsurance.Provider_Name;
                cmdUpdInsurance.Parameters.Add("I_ADDRESS", OracleDbType.Varchar2).Value = objEntityInsurance.Provider_Address;
                cmdUpdInsurance.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = objEntityInsurance.Organisation_id;
                cmdUpdInsurance.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntityInsurance.Corporate_id;
                cmdUpdInsurance.Parameters.Add("I_STATUS", OracleDbType.Int32).Value = objEntityInsurance.Status_id;
                cmdUpdInsurance.Parameters.Add("I_UPDUSERID", OracleDbType.Int32).Value = objEntityInsurance.User_Id;
                cmdUpdInsurance.Parameters.Add("I_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdUpdInsurance.ExecuteNonQuery();
            }

            string strQueryDeleteProviderType = "INSURANCE_PROVIDER.SP_DELETE_PROVIDER_TYPE";
            using (OracleCommand cmdDeleteInsType = new OracleCommand(strQueryDeleteProviderType,con))
            {
                cmdDeleteInsType.CommandText = strQueryDeleteProviderType;
                cmdDeleteInsType.CommandType = CommandType.StoredProcedure;
                cmdDeleteInsType.Parameters.Add("I_ID", OracleDbType.Int32).Value = objEntityInsurance.InsuranceId;
                cmdDeleteInsType.ExecuteNonQuery();
            }

            foreach (clsEntityLayerInsuranceProvider objEntityInsuranceForType in objEntityInsList)
            {
                string strQueryAddProviderType = "INSURANCE_PROVIDER.SP_INS_PROVIDER_TYPE";
                using (OracleCommand cmdAddInsType = new OracleCommand(strQueryAddProviderType,con))
                {
                    cmdAddInsType.CommandText = strQueryAddProviderType;
                    cmdAddInsType.CommandType = CommandType.StoredProcedure;
                    cmdAddInsType.Parameters.Add("I_ID", OracleDbType.Int32).Value = objEntityInsurance.InsuranceId;
                    cmdAddInsType.Parameters.Add("I_TYPE", OracleDbType.Int32).Value = objEntityInsuranceForType.Provider_Type;
                    cmdAddInsType.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntityInsurance.Corporate_id;


                    cmdAddInsType.ExecuteNonQuery();
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
       //EVM-0016
        // This Method checks Product name in the database for duplication.
        public string CheckInsuranceProviderName(clsEntityLayerInsuranceProvider objEntityInsurance)
        {

            string strQueryCheckProductName = "INSURANCE_PROVIDER.SP_CHECK_INSURANCE_NAME";
            OracleCommand cmdCheckInsuranceName = new OracleCommand();
            cmdCheckInsuranceName.CommandText = strQueryCheckProductName;
            cmdCheckInsuranceName.CommandType = CommandType.StoredProcedure;
            cmdCheckInsuranceName.Parameters.Add("I_ID", OracleDbType.Int32).Value = objEntityInsurance.InsuranceId;
            cmdCheckInsuranceName.Parameters.Add("I_NAME", OracleDbType.Varchar2).Value = objEntityInsurance.Provider_Name;
            cmdCheckInsuranceName.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntityInsurance.Corporate_id;
            cmdCheckInsuranceName.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = objEntityInsurance.Organisation_id;
            cmdCheckInsuranceName.Parameters.Add("I_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckInsuranceName);
            string strReturn = cmdCheckInsuranceName.Parameters["I_COUNT"].Value.ToString();
            cmdCheckInsuranceName.Dispose();
            return strReturn;
        }

        // This Method will fetch insurance provider DEATILS BY ID
        public DataTable ReadInsuranceproviderById(clsEntityLayerInsuranceProvider objEntityInsurance)
        {
            string strQueryReadInsuranceType = "INSURANCE_PROVIDER.SP_READ_INSURANCE_BY_ID";
            OracleCommand cmdReadInsuranceType = new OracleCommand();
            cmdReadInsuranceType.CommandText = strQueryReadInsuranceType;
            cmdReadInsuranceType.CommandType = CommandType.StoredProcedure;
            cmdReadInsuranceType.Parameters.Add("I_ID", OracleDbType.Int32).Value = objEntityInsurance.InsuranceId;
            cmdReadInsuranceType.Parameters.Add(" I_INSURANCEDETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadInsuranceType);
            return dtCategory;
        }

        // This Method will fetch insurance provider DEATILS BY ID
        public DataTable ReadInsuranceTypeByPrvdrId(clsEntityLayerInsuranceProvider objEntityInsurance)
        {
            string strQueryReadInsuranceType = "INSURANCE_PROVIDER.SP_READ_INSRNCE_TYPE_BY_ID";
            OracleCommand cmdReadInsuranceType = new OracleCommand();
            cmdReadInsuranceType.CommandText = strQueryReadInsuranceType;
            cmdReadInsuranceType.CommandType = CommandType.StoredProcedure;
            cmdReadInsuranceType.Parameters.Add("I_ID", OracleDbType.Int32).Value = objEntityInsurance.InsuranceId;
            cmdReadInsuranceType.Parameters.Add(" I_TYPES", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadInsuranceType);
            return dtCategory;
        }
        //Method for cancel Insurance Provider
        public void CancelInsuranceProvider(clsEntityLayerInsuranceProvider objEntityInsurance)
        {
            string strQueryCancelInsurance = "INSURANCE_PROVIDER.SP_CANCEL_INSURANCE_PROVIDER";
            using (OracleCommand cmdCancelInsurance = new OracleCommand())
            {
                cmdCancelInsurance.CommandText = strQueryCancelInsurance;
                cmdCancelInsurance.CommandType = CommandType.StoredProcedure;
                cmdCancelInsurance.Parameters.Add("I_ID", OracleDbType.Int32).Value = objEntityInsurance.InsuranceId;
                cmdCancelInsurance.Parameters.Add("I_USERID", OracleDbType.Int32).Value = objEntityInsurance.User_Id;
                cmdCancelInsurance.Parameters.Add("I_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdCancelInsurance.Parameters.Add("I_REASON", OracleDbType.Varchar2).Value = objEntityInsurance.CancelReason;
                clsDataLayer.ExecuteNonQuery(cmdCancelInsurance);
            }
        }


        //Method for recall water card
        public void ReCallInsuranceProvider(clsEntityLayerInsuranceProvider objEntityInsurance)
        {
            string strQueryRecallInsurance = "INSURANCE_PROVIDER.SP_RECALL_INSURANCE_PROVIDER";
            using (OracleCommand cmdRecallInsurance = new OracleCommand())
            {
                cmdRecallInsurance.CommandText = strQueryRecallInsurance;
                cmdRecallInsurance.CommandType = CommandType.StoredProcedure;
                cmdRecallInsurance.Parameters.Add("I_ID", OracleDbType.Int32).Value = objEntityInsurance.InsuranceId;
                cmdRecallInsurance.Parameters.Add("I_USERID", OracleDbType.Int32).Value = objEntityInsurance.User_Id;
                cmdRecallInsurance.Parameters.Add("I_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdRecallInsurance);
            }
        }

        // This Method will fetch product category list
        public DataTable ReadInsuranceProviderList(clsEntityLayerInsuranceProvider objEntityInsurance)
        {
            string strQueryReadCategoryList = "INSURANCE_PROVIDER.SP_READ_INSURANCE_LIST";
            OracleCommand cmdReadCategoryList = new OracleCommand();
            cmdReadCategoryList.CommandText = strQueryReadCategoryList;
            cmdReadCategoryList.CommandType = CommandType.StoredProcedure;
            cmdReadCategoryList.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = objEntityInsurance.Organisation_id;
            cmdReadCategoryList.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntityInsurance.Corporate_id;
            cmdReadCategoryList.Parameters.Add("I_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadCategoryList);
            return dtCategoryList;
        }
        // This Method will fetch product category list BY SEARCH
        public DataTable ReadInsuranceProviderListBySearch(clsEntityLayerInsuranceProvider objEntityInsurance)
        {
            string strQueryReadCategoryListBySearch = "INSURANCE_PROVIDER.SP_READ_INSRNCE_LIST_BYSEARCH";
            OracleCommand cmdReadCategoryListBySearch = new OracleCommand();
            cmdReadCategoryListBySearch.CommandText = strQueryReadCategoryListBySearch;
            cmdReadCategoryListBySearch.CommandType = CommandType.StoredProcedure;
            cmdReadCategoryListBySearch.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = objEntityInsurance.Organisation_id;
            cmdReadCategoryListBySearch.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntityInsurance.Corporate_id;
            cmdReadCategoryListBySearch.Parameters.Add("I_INSTYPE", OracleDbType.Int32).Value = objEntityInsurance.InsuranceType;
            cmdReadCategoryListBySearch.Parameters.Add("I_OPTION", OracleDbType.Int32).Value = objEntityInsurance.Status_id;
            cmdReadCategoryListBySearch.Parameters.Add("I_CANCEL", OracleDbType.Int32).Value = objEntityInsurance.CancelStatus;
            cmdReadCategoryListBySearch.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityInsurance.CommonSearchTerm;
            cmdReadCategoryListBySearch.Parameters.Add("M_SEARCH_NAME", OracleDbType.Varchar2).Value = objEntityInsurance.SearchName;
            cmdReadCategoryListBySearch.Parameters.Add("M_SEARCH_TYPE", OracleDbType.Varchar2).Value = objEntityInsurance.SearchType;
            cmdReadCategoryListBySearch.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityInsurance.OrderColumn;
            cmdReadCategoryListBySearch.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityInsurance.OrderMethod;
            cmdReadCategoryListBySearch.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityInsurance.PageMaxSize;
            cmdReadCategoryListBySearch.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityInsurance.PageNumber;
            cmdReadCategoryListBySearch.Parameters.Add("I_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadCategoryListBySearch);
            return dtCategoryList;
        }
        public void Update_Provider_Status(clsEntityLayerInsuranceProvider objEntityInsurance)
        {
            string strQueryCancelInsurance = "INSURANCE_PROVIDER.SP_UPD_INS_PROVIDER_STS";
            using (OracleCommand cmdCancelInsurance = new OracleCommand())
            {
                cmdCancelInsurance.CommandText = strQueryCancelInsurance;
                cmdCancelInsurance.CommandType = CommandType.StoredProcedure;
                cmdCancelInsurance.Parameters.Add("I_ID", OracleDbType.Int32).Value = objEntityInsurance.InsuranceId;
                cmdCancelInsurance.Parameters.Add("I_USERID", OracleDbType.Int32).Value = objEntityInsurance.User_Id;
                cmdCancelInsurance.Parameters.Add("I_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdCancelInsurance.Parameters.Add("I_STATUS", OracleDbType.Int32).Value = objEntityInsurance.Status_id;
                clsDataLayer.ExecuteNonQuery(cmdCancelInsurance);
            }
        }
    }
}
