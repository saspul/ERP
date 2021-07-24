using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using DL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_GMS;

namespace DL_Compzit.DataLayer_GMS
{
    public class clsDataLayerInsuranceTypMaster
    {
        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
        // This Method adds job category details to the table
        public void AddInsuranceTyp(clsEntityLayerInsuranceTypMaster objEntityInsrTyp)
        {
            string strQueryAddInsuranceTyp = "INSURANCE_TYPE_MASTER.SP_INS_INSRNCE_TYPE_DETAILS";
            using (OracleCommand cmdAddInsuranceTyp = new OracleCommand())
            {
                cmdAddInsuranceTyp.CommandText = strQueryAddInsuranceTyp;
                cmdAddInsuranceTyp.CommandType = CommandType.StoredProcedure;
                cmdAddInsuranceTyp.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityInsrTyp.InsrTypname;
                cmdAddInsuranceTyp.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityInsrTyp.InsrTypStatus;
                cmdAddInsuranceTyp.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityInsrTyp.Organisation_Id;
                cmdAddInsuranceTyp.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityInsrTyp.CorpOffice_Id;
                cmdAddInsuranceTyp.Parameters.Add("C_INSUSERID", OracleDbType.Int32).Value = objEntityInsrTyp.User_Id;
                clsDataLayer.ExecuteNonQuery(cmdAddInsuranceTyp);
            }
        }
        public void UpdateInsuranceTyp(clsEntityLayerInsuranceTypMaster objEntityInsrTyp)
        {
            string strQueryUpdateInsuranceTyp = "INSURANCE_TYPE_MASTER.SP_UPD_INSRNCE_TYPE_DETAILS";
            using (OracleCommand cmdUpdateInsuranceTyp = new OracleCommand())
            {
                cmdUpdateInsuranceTyp.CommandText = strQueryUpdateInsuranceTyp;
                cmdUpdateInsuranceTyp.CommandType = CommandType.StoredProcedure;
                cmdUpdateInsuranceTyp.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityInsrTyp.InsrTypId;
                cmdUpdateInsuranceTyp.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityInsrTyp.InsrTypname;
                cmdUpdateInsuranceTyp.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityInsrTyp.InsrTypStatus;
                cmdUpdateInsuranceTyp.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityInsrTyp.Organisation_Id;
                cmdUpdateInsuranceTyp.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityInsrTyp.CorpOffice_Id;
                cmdUpdateInsuranceTyp.Parameters.Add("C_UPDUSERID", OracleDbType.Int32).Value = objEntityInsrTyp.User_Id;
                cmdUpdateInsuranceTyp.Parameters.Add("C_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdUpdateInsuranceTyp);
            }
        }
        // This Method checks job category name in the database for duplication.
        public string CheckInsuranceTypName(clsEntityLayerInsuranceTypMaster objEntityInsrTyp)
        {

            string strQueryInsuranceTypName = "INSURANCE_TYPE_MASTER.SP_CHECK_INSRNCE_TYPE_NAME";
            OracleCommand cmdCheckInsuranceTyp = new OracleCommand();
            cmdCheckInsuranceTyp.CommandText = strQueryInsuranceTypName;
            cmdCheckInsuranceTyp.CommandType = CommandType.StoredProcedure;
            cmdCheckInsuranceTyp.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityInsrTyp.InsrTypId;
            cmdCheckInsuranceTyp.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntityInsrTyp.InsrTypname;
            cmdCheckInsuranceTyp.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityInsrTyp.CorpOffice_Id;
            cmdCheckInsuranceTyp.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityInsrTyp.Organisation_Id;
            cmdCheckInsuranceTyp.Parameters.Add("C_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckInsuranceTyp);
            string strReturn = cmdCheckInsuranceTyp.Parameters["C_COUNT"].Value.ToString();
            cmdCheckInsuranceTyp.Dispose();
            return strReturn;
        }

        //Method for cancel job category
        public void CancelInsuranceTyp(clsEntityLayerInsuranceTypMaster objEntityInsrTyp)
        {
            string strQueryCancelInsuranceTyp = "INSURANCE_TYPE_MASTER.SP_CANCEL_INSRNCE_TYPE";
            using (OracleCommand cmdCancelInsuranceTyp = new OracleCommand())
            {
                cmdCancelInsuranceTyp.CommandText = strQueryCancelInsuranceTyp;
                cmdCancelInsuranceTyp.CommandType = CommandType.StoredProcedure;
                cmdCancelInsuranceTyp.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityInsrTyp.InsrTypId;
                cmdCancelInsuranceTyp.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityInsrTyp.User_Id;
                cmdCancelInsuranceTyp.Parameters.Add("C_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                cmdCancelInsuranceTyp.Parameters.Add("C_REASON", OracleDbType.Varchar2).Value = objEntityInsrTyp.Cancel_reason;
                clsDataLayer.ExecuteNonQuery(cmdCancelInsuranceTyp);
            }
        }
        // This Method will fetCH job category DEATILS BY ID
        public DataTable ReadInsuranceTypById(clsEntityLayerInsuranceTypMaster objEntityInsrTyp)
        {
            string strQueryReadInsuranceTyp = "INSURANCE_TYPE_MASTER.SP_READ_INSRNCE_TYPE_BY_ID";
            OracleCommand cmdReadInsuranceTyp = new OracleCommand();
            cmdReadInsuranceTyp.CommandText = strQueryReadInsuranceTyp;
            cmdReadInsuranceTyp.CommandType = CommandType.StoredProcedure;
            cmdReadInsuranceTyp.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityInsrTyp.InsrTypId;
            cmdReadInsuranceTyp.Parameters.Add("C_INSRTYPE_DETAILS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadInsuranceTyp);
            return dtCategory;
        }
        // This Method will fetch job category list
        public DataTable ReadInsuranceTypList(clsEntityLayerInsuranceTypMaster objEntityInsrTyp)
        {
            string strQueryReadInsrTypList = "INSURANCE_TYPE_MASTER.SP_READ_INSRNCE_TYPE_LIST";
            OracleCommand cmdReadInsrTypList = new OracleCommand();
            cmdReadInsrTypList.CommandText = strQueryReadInsrTypList;
            cmdReadInsrTypList.CommandType = CommandType.StoredProcedure;
            cmdReadInsrTypList.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityInsrTyp.Organisation_Id;
            cmdReadInsrTypList.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityInsrTyp.CorpOffice_Id;
            cmdReadInsrTypList.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntityInsrTyp.InsrTypStatus;
            cmdReadInsrTypList.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntityInsrTyp.Cancel_Status;
            cmdReadInsrTypList.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadInsrTypList);
            return dtCategoryList;
        }
        public DataTable CheckInsrncTypCnclSts(clsEntityLayerInsuranceTypMaster objEntityInsrTyp)
        {
            string strQueryReadEmpSlry = "INSURANCE_TYPE_MASTER.SP_CHECK_CNCL_STS";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadEmpSlry;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            cmdReadPayGrd.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityInsrTyp.InsrTypId;
            cmdReadPayGrd.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityInsrTyp.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityInsrTyp.CorpOffice_Id;
            cmdReadPayGrd.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmpSlry = new DataTable();
            dtEmpSlry = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtEmpSlry;
        }

    }
}
