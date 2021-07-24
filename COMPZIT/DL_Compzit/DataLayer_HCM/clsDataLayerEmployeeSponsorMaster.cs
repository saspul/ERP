using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Data;
using DL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_HCM;
namespace DL_Compzit.DataLayer_HCM
{
   public class clsDataLayerEmployeeSponsorMaster
    {
       public void AddEmployeeSponsor(clsEntityLayerEmployeeSponsorMaster objEntitySpnsrMstr)
        {
            string strQueryAddContractCat = "EMPLOYEE_SPONSOR.SP_INSERT_EMPLOYEE_SPONSOR";
            using (OracleCommand cmdAddContractCat = new OracleCommand())
            {
                cmdAddContractCat.CommandText = strQueryAddContractCat;
                cmdAddContractCat.CommandType = CommandType.StoredProcedure;
                cmdAddContractCat.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntitySpnsrMstr.Sponsor_Name;
                cmdAddContractCat.Parameters.Add("C_ADD1", OracleDbType.Varchar2).Value = objEntitySpnsrMstr.Address1;
                cmdAddContractCat.Parameters.Add("C_ADD2", OracleDbType.Varchar2).Value = objEntitySpnsrMstr.Address2;
                cmdAddContractCat.Parameters.Add("C_ADD3", OracleDbType.Varchar2).Value = objEntitySpnsrMstr.Address3;
                cmdAddContractCat.Parameters.Add("C_COUNTRYID", OracleDbType.Int32).Value = objEntitySpnsrMstr.CountryId;
                cmdAddContractCat.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntitySpnsrMstr.Organisation_Id;
                cmdAddContractCat.Parameters.Add("C_DOCNO", OracleDbType.Varchar2).Value = objEntitySpnsrMstr.SponsorDoc_No;
                cmdAddContractCat.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntitySpnsrMstr.CorpId;

                cmdAddContractCat.Parameters.Add("C_MOBILE", OracleDbType.Varchar2).Value = objEntitySpnsrMstr.Mobile_Number;
                cmdAddContractCat.Parameters.Add("C_PHONE", OracleDbType.Varchar2).Value = objEntitySpnsrMstr.Phone_Number;
                cmdAddContractCat.Parameters.Add("C_EMAIL", OracleDbType.Varchar2).Value = objEntitySpnsrMstr.Email_Address;
                cmdAddContractCat.Parameters.Add("C_FAX", OracleDbType.Varchar2).Value = objEntitySpnsrMstr.Fax_Number;
                cmdAddContractCat.Parameters.Add("C_USR_ID IN", OracleDbType.Int32).Value = objEntitySpnsrMstr.UserId;
          
                cmdAddContractCat.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntitySpnsrMstr.SponsrDate;

                cmdAddContractCat.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntitySpnsrMstr.Sponsor_Status;
                cmdAddContractCat.Parameters.Add("C_TYPE_ID", OracleDbType.Int32).Value = objEntitySpnsrMstr.SponsorType_Id;

                clsDataLayer.ExecuteNonQuery(cmdAddContractCat);
            }
        }
       public void UpdateEmployeeSponsor(clsEntityLayerEmployeeSponsorMaster objEntitySpnsrMstr)
        {
            string strQueryUpdateCntrctCat = "EMPLOYEE_SPONSOR.SP_UPD_EMPLOYEE_SPONSOR_DETAIL";
            using (OracleCommand cmdUpdateCntrctCat = new OracleCommand())
            {
                cmdUpdateCntrctCat.CommandText = strQueryUpdateCntrctCat;
                cmdUpdateCntrctCat.CommandType = CommandType.StoredProcedure;
                cmdUpdateCntrctCat.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntitySpnsrMstr.Sponsor_Name;
                cmdUpdateCntrctCat.Parameters.Add("C_ADD1", OracleDbType.Varchar2).Value = objEntitySpnsrMstr.Address1;
                cmdUpdateCntrctCat.Parameters.Add("C_ADD2", OracleDbType.Varchar2).Value = objEntitySpnsrMstr.Address2;
                cmdUpdateCntrctCat.Parameters.Add("C_ADD3", OracleDbType.Varchar2).Value = objEntitySpnsrMstr.Address3;
                cmdUpdateCntrctCat.Parameters.Add("C_COUNTRYID", OracleDbType.Int32).Value = objEntitySpnsrMstr.CountryId;
                cmdUpdateCntrctCat.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntitySpnsrMstr.Organisation_Id;
                cmdUpdateCntrctCat.Parameters.Add("C_DOCNO", OracleDbType.Varchar2).Value = objEntitySpnsrMstr.SponsorDoc_No;
                cmdUpdateCntrctCat.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntitySpnsrMstr.CorpId;

                cmdUpdateCntrctCat.Parameters.Add("C_MOBILE", OracleDbType.Varchar2).Value = objEntitySpnsrMstr.Mobile_Number;
                cmdUpdateCntrctCat.Parameters.Add("C_PHONE", OracleDbType.Varchar2).Value = objEntitySpnsrMstr.Phone_Number;
                cmdUpdateCntrctCat.Parameters.Add("C_EMAIL", OracleDbType.Varchar2).Value = objEntitySpnsrMstr.Email_Address;
                cmdUpdateCntrctCat.Parameters.Add("C_FAX", OracleDbType.Varchar2).Value = objEntitySpnsrMstr.Fax_Number;
                cmdUpdateCntrctCat.Parameters.Add("C_UPDUSERID", OracleDbType.Int32).Value = objEntitySpnsrMstr.UserId;

                cmdUpdateCntrctCat.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntitySpnsrMstr.SponsrDate;

                cmdUpdateCntrctCat.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntitySpnsrMstr.Sponsor_Status;
                cmdUpdateCntrctCat.Parameters.Add("C_TYPE_ID", OracleDbType.Int32).Value = objEntitySpnsrMstr.SponsorType_Id;
                cmdUpdateCntrctCat.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntitySpnsrMstr.Sponsor_Id;
                clsDataLayer.ExecuteNonQuery(cmdUpdateCntrctCat);
            }
        }
       public void ChangeEmployeeSponsor(clsEntityLayerEmployeeSponsorMaster objEntitySpnsrMstr)
        {
            string strQueryUpdateCntrctCat = "EMPLOYEE_SPONSOR.SP_UPD_EMPLOYEE_SPONSOR_STATUS";
            using (OracleCommand cmdUpdateCntrctCat = new OracleCommand())
            {
                cmdUpdateCntrctCat.CommandText = strQueryUpdateCntrctCat;
                cmdUpdateCntrctCat.CommandType = CommandType.StoredProcedure;
                cmdUpdateCntrctCat.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntitySpnsrMstr.Sponsor_Id;
                cmdUpdateCntrctCat.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntitySpnsrMstr.Sponsor_Status;
                clsDataLayer.ExecuteNonQuery(cmdUpdateCntrctCat);
            }
        }
         //This Method checks job category name in the database for duplication.
       public string CheckEmployeeSponsor(clsEntityLayerEmployeeSponsorMaster objEntitySpnsrMstr)
        {

            string strQueryCheckCatName = "EMPLOYEE_SPONSOR.SP_CHECK_SPONSOR_NAME";
            OracleCommand cmdCheckCntrctName = new OracleCommand();
            cmdCheckCntrctName.CommandText = strQueryCheckCatName;
            cmdCheckCntrctName.CommandType = CommandType.StoredProcedure;
            cmdCheckCntrctName.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntitySpnsrMstr.Sponsor_Id;
            cmdCheckCntrctName.Parameters.Add("C_NAME", OracleDbType.Varchar2).Value = objEntitySpnsrMstr.Sponsor_Name;
         
            cmdCheckCntrctName.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntitySpnsrMstr.Organisation_Id;
            cmdCheckCntrctName.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntitySpnsrMstr.CorpId;
            cmdCheckCntrctName.Parameters.Add("C_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCntrctName);
            string strReturn = cmdCheckCntrctName.Parameters["C_COUNT"].Value.ToString();
            cmdCheckCntrctName.Dispose();
            return strReturn;
        }

        //Method for cancel job category
       public void CancelEmployeeSponsor(clsEntityLayerEmployeeSponsorMaster objEntitySpnsrMstr)
        {
            string strQueryCancelCntrctCat = "EMPLOYEE_SPONSOR.SP_CANCEL_EMPLOYEE_SPONSOR";
            using (OracleCommand cmdCancelCntrctCat = new OracleCommand())
            {
                cmdCancelCntrctCat.CommandText = strQueryCancelCntrctCat;
                cmdCancelCntrctCat.CommandType = CommandType.StoredProcedure;
                cmdCancelCntrctCat.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntitySpnsrMstr.Sponsor_Id;
                cmdCancelCntrctCat.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntitySpnsrMstr.UserId;
                cmdCancelCntrctCat.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntitySpnsrMstr.SponsrDate;
                cmdCancelCntrctCat.Parameters.Add("C_REASON", OracleDbType.Varchar2).Value = objEntitySpnsrMstr.Cancel_Reason;
                clsDataLayer.ExecuteNonQuery(cmdCancelCntrctCat);
            }
        }
       public void ReCallEmployeeSponsor(clsEntityLayerEmployeeSponsorMaster objEntitySpnsrMstr)
       {
           string strQueryCancelCntrctCat = "EMPLOYEE_SPONSOR.SP_RECALL_EMPLOYEE_SPONSOR";
           using (OracleCommand cmdCancelCntrctCat = new OracleCommand())
           {
               cmdCancelCntrctCat.CommandText = strQueryCancelCntrctCat;
               cmdCancelCntrctCat.CommandType = CommandType.StoredProcedure;
               cmdCancelCntrctCat.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntitySpnsrMstr.Sponsor_Id;
               cmdCancelCntrctCat.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntitySpnsrMstr.UserId;
               cmdCancelCntrctCat.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntitySpnsrMstr.SponsrDate;
       
               clsDataLayer.ExecuteNonQuery(cmdCancelCntrctCat);
           }
       }
        ////Method for Recall Cancelled Complaint from job category master table so update cancel related fields
        //public void ReCallContractCategory(classEntityLayerContractCategory objEntityCntrctCat)
        //{
        //    string strQueryRecallCntrct = "CONTRACT_CATEGORY_MASTER.SP_RECALL_CNTRCT_CAT";
        //    OracleCommand cmdRecallCntrct = new OracleCommand();
        //    cmdRecallCntrct.CommandText = strQueryRecallCntrct;
        //    cmdRecallCntrct.CommandType = CommandType.StoredProcedure;
        //    cmdRecallCntrct.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntityCntrctCat.CntrctCatId;
        //    cmdRecallCntrct.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityCntrctCat.User_Id;
        //    cmdRecallCntrct.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityCntrctCat.D_Date;
        //    clsDataLayer.ExecuteNonQuery(cmdRecallCntrct);
        //}
       //// This Method will fetCH job EmployeeSponsor BY ID
       public DataTable ReadEmployeeSponsorById(clsEntityLayerEmployeeSponsorMaster objEntitySpnsrMstr)
        {
            string strQueryReadCntrctCatgry = "EMPLOYEE_SPONSOR.SP_READ_EMPLOYEE_SPONSOR_BY_ID";
            OracleCommand cmdReadCntrctCatgry = new OracleCommand();
            cmdReadCntrctCatgry.CommandText = strQueryReadCntrctCatgry;
            cmdReadCntrctCatgry.CommandType = CommandType.StoredProcedure;
            cmdReadCntrctCatgry.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntitySpnsrMstr.Organisation_Id;
            cmdReadCntrctCatgry.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntitySpnsrMstr.CorpId;
            cmdReadCntrctCatgry.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntitySpnsrMstr.Sponsor_Id;
            cmdReadCntrctCatgry.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadCntrctCatgry);
            return dtCategory;
        }

       //foR SERACH

       public DataTable ReadEmployeeSponsorBy_search(clsEntityLayerEmployeeSponsorMaster objEntitySpnsrMstr)
       {
           string strQueryReadCntrctCatgry = "EMPLOYEE_SPONSOR.SP_READ_SPONSOR_SEARCH";
           OracleCommand cmdReadCntrctCatgry = new OracleCommand();
           cmdReadCntrctCatgry.CommandText = strQueryReadCntrctCatgry;
           cmdReadCntrctCatgry.CommandType = CommandType.StoredProcedure;
           cmdReadCntrctCatgry.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntitySpnsrMstr.Organisation_Id;
           cmdReadCntrctCatgry.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntitySpnsrMstr.CorpId;
           cmdReadCntrctCatgry.Parameters.Add("C_TYPE", OracleDbType.Int32).Value = objEntitySpnsrMstr.SponsorType_Id;
           cmdReadCntrctCatgry.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntitySpnsrMstr.Sponsor_Status;
           cmdReadCntrctCatgry.Parameters.Add("C_CAN_STATUS", OracleDbType.Int32).Value = objEntitySpnsrMstr.Cancel_Status;
           cmdReadCntrctCatgry.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadCntrctCatgry);
           return dtCategory;
       }



       public DataTable ReadEmployeeSponsorcancld(clsEntityLayerEmployeeSponsorMaster objEntitySpnsrMstr)
       {
           string strQueryReadCntrctCatgry = "EMPLOYEE_SPONSOR.SP_READ_EMPLOYEE_SPONSOR_CANCL";
           OracleCommand cmdReadCntrctCatgry = new OracleCommand();
           cmdReadCntrctCatgry.CommandText = strQueryReadCntrctCatgry;
           cmdReadCntrctCatgry.CommandType = CommandType.StoredProcedure;
           cmdReadCntrctCatgry.Parameters.Add("C_ID", OracleDbType.Int32).Value = objEntitySpnsrMstr.Sponsor_Id;
           cmdReadCntrctCatgry.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntitySpnsrMstr.Organisation_Id;
           cmdReadCntrctCatgry.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntitySpnsrMstr.CorpId;
           cmdReadCntrctCatgry.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadCntrctCatgry);
           return dtCategory;
       }





        //Method for fetch country master table from database.
        public DataTable ReadCountry()
        {
            string strQueryReadCountry = "CUSTOMER_MASTER.SP_READ_COUNTRY";
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryReadCountry;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;
                cmdReadCountry.Parameters.Add("C_CNTRYTABLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCountry = new DataTable();
                dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
                return dtCountry;
            }
        }

        //Method for fetch Sponsor  type table from database.
        public DataTable ReadSponsorType()
        {
            string strQueryReadCountry = "EMPLOYEE_SPONSOR.SP_READ_EMPLOYEE_SPONSOR_TYPE";
            using (OracleCommand cmdReadType = new OracleCommand())
            {
                cmdReadType.CommandText = strQueryReadCountry;
                cmdReadType.CommandType = CommandType.StoredProcedure;
                cmdReadType.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtType = new DataTable();
                dtType = clsDataLayer.SelectDataTable(cmdReadType);
                return dtType;
            }
        }

        //// This Method will fetch EmployeeSponsor
        public DataTable ReadEmployeeSponsor(clsEntityLayerEmployeeSponsorMaster objEntitySpnsrMstr)
        {
            string strQueryReadCntrctList = "EMPLOYEE_SPONSOR.SP_READ_EMPLOYEE_SPONSOR_LIST";
            OracleCommand cmdReadCntrctList = new OracleCommand();
            cmdReadCntrctList.CommandText = strQueryReadCntrctList;
            cmdReadCntrctList.CommandType = CommandType.StoredProcedure;
            cmdReadCntrctList.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntitySpnsrMstr.Organisation_Id;
            cmdReadCntrctList.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntitySpnsrMstr.CorpId;
            cmdReadCntrctList.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategoryList = new DataTable();
            dtCategoryList = clsDataLayer.ExecuteReader(cmdReadCntrctList);
            return dtCategoryList;
        }
    }
}
