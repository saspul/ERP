using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using Oracle.DataAccess.Client;
using System.Data;

// CREATED BY:EVM-0002
// CREATED DATE:28/03/2016
// REVIEWED BY:
// REVIEW DATE:

namespace DL_Compzit
{
    public class clsDataLayerProductRateAmendment
    {
        //creating the object for date and time data layer
        clsDataLayerDateAndTime objDataLayerDateAndTime = new clsDataLayerDateAndTime();

        // This Method check user enter product code already exist in the table or not
        public string CheckProductCode(clsEntityProductRateAmendment objEntityRateAmendment)
        {
            string strQueryCheckProductCode = "RATE_AMENDMENT.SP_CHECK_PRODUCT_CODE";
            OracleCommand cmdCheckProductCode = new OracleCommand();
            cmdCheckProductCode.CommandText = strQueryCheckProductCode;
            cmdCheckProductCode.CommandType = CommandType.StoredProcedure;
            cmdCheckProductCode.Parameters.Add("P_CODE", OracleDbType.Varchar2).Value = objEntityRateAmendment.Product_Ext_Code;
            cmdCheckProductCode.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityRateAmendment.Org_Id;
            cmdCheckProductCode.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityRateAmendment.Corp_Id;
            cmdCheckProductCode.Parameters.Add("P_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckProductCode);
            string strReturn = cmdCheckProductCode.Parameters["P_COUNT"].Value.ToString();
            cmdCheckProductCode.Dispose();
            return strReturn;
        }

        //Method for rate update the product on the basis of product code
        public void ProductRateUpdation(List<clsEntityProductRateAmendment> objEntityProductRateList)
        {
            foreach (clsEntityProductRateAmendment RateAmendment in objEntityProductRateList)
            {
                string strQueryUpdateRate = "RATE_AMENDMENT.SP_UPDATE_RATE";
                using (OracleCommand cmdUpdateRate = new OracleCommand())
                {
                    cmdUpdateRate.CommandText = strQueryUpdateRate;
                    cmdUpdateRate.CommandType = CommandType.StoredProcedure;
                    cmdUpdateRate.Parameters.Add("P_CODE", OracleDbType.Varchar2).Value = RateAmendment.Product_Ext_Code;
                    cmdUpdateRate.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = RateAmendment.Org_Id;
                    cmdUpdateRate.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = RateAmendment.Corp_Id;
                    cmdUpdateRate.Parameters.Add("P_RATE", OracleDbType.Decimal).Value = RateAmendment.Product_Rate;
                    cmdUpdateRate.Parameters.Add("P_USERID", OracleDbType.Int64).Value = RateAmendment.User_Id;
                    cmdUpdateRate.Parameters.Add("P_DATE", OracleDbType.Date).Value = objDataLayerDateAndTime.DateAndTime();
                    clsDataLayer.ExecuteNonQuery(cmdUpdateRate);
                }
            }
        }
        //Method for FETCHING PRODUCT DETAILS BY THE EXTERNAL APP CODE OF PRODUCT.
        public DataTable ReadPrdctDtlByExtCode(clsEntityProductRateAmendment objEntityRateAmendment)
        {
            string strReadPrdct = "RATE_AMENDMENT.SP_RD_PRDCT_DETAIL_BY_CODE";
            OracleCommand cmdReadPrdctDtl = new OracleCommand();
            cmdReadPrdctDtl.CommandText = strReadPrdct;
            cmdReadPrdctDtl.CommandType = CommandType.StoredProcedure;
            cmdReadPrdctDtl.Parameters.Add("P_CODE", OracleDbType.Varchar2).Value = objEntityRateAmendment.Product_Ext_Code;
            cmdReadPrdctDtl.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityRateAmendment.Org_Id;
            cmdReadPrdctDtl.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityRateAmendment.Corp_Id;
            cmdReadPrdctDtl.Parameters.Add("P_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtProduct = new DataTable();
            dtProduct = clsDataLayer.ExecuteReader(cmdReadPrdctDtl);
            return dtProduct;
        }

        //methode for fetching the division based on the user id
        public DataTable Read_Divisions(clsEntityProductRateAmendment objEntityRate)
        {
            string strReadDivision = "RATE_AMENDMENT.SP_READ_DIVISION";
            OracleCommand cmdReadDivision = new OracleCommand();
            cmdReadDivision.CommandText = strReadDivision;
            cmdReadDivision.CommandType = CommandType.StoredProcedure;
            cmdReadDivision.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityRate.User_Id;
            cmdReadDivision.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityRate.Org_Id;
            cmdReadDivision.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityRate.Corp_Id;
            cmdReadDivision.Parameters.Add("P_DIVISIONS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDivision = new DataTable();
            dtDivision = clsDataLayer.ExecuteReader(cmdReadDivision);
            return dtDivision;
        }

        //methode for fetching the divisions from the database
        public DataTable Read_All_Divisions(clsEntityProductRateAmendment objEntityRate)
        {
            string strReadDivision = "RATE_AMENDMENT.SP_READ_ALL_DIVISIONS";
            OracleCommand cmdReadDivision = new OracleCommand();
            cmdReadDivision.CommandText = strReadDivision;
            cmdReadDivision.CommandType = CommandType.StoredProcedure;
            cmdReadDivision.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityRate.Org_Id;
            cmdReadDivision.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityRate.Corp_Id;
            cmdReadDivision.Parameters.Add("P_DIVISIONS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtDivision = new DataTable();
            dtDivision = clsDataLayer.ExecuteReader(cmdReadDivision);
            return dtDivision;
        }

        // This Method check user enter product name already exist in the table or not
        public string CheckProductname(clsEntityProductRateAmendment objEntityRateAmendment)
        {
            string strQueryCheckProductname = "RATE_AMENDMENT.SP_CHECK_PRODUCT_NAME";
            OracleCommand cmdCheckProductname = new OracleCommand();
            cmdCheckProductname.CommandText = strQueryCheckProductname;
            cmdCheckProductname.CommandType = CommandType.StoredProcedure;
            cmdCheckProductname.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntityRateAmendment.Product_Name;
            cmdCheckProductname.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityRateAmendment.Org_Id;
            cmdCheckProductname.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityRateAmendment.Corp_Id;
            cmdCheckProductname.Parameters.Add("P_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckProductname);
            string strReturn = cmdCheckProductname.Parameters["P_COUNT"].Value.ToString();
            cmdCheckProductname.Dispose();
            return strReturn;
        }

    }
}
