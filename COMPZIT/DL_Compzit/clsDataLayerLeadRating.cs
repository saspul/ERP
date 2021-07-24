using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using Oracle.DataAccess.Client;
using System.Data;
// CREATED BY:WEM-0006
// CREATED DATE:17/08/2016
// REVIEWED BY:
// REVIEW DATE:
// This is the Data Layer for Adding Lead rating detail and also updating,canceling and viewing the same .

namespace DL_Compzit
{
   public class clsDataLayerLeadRating
    {

        // This Method adds Lead rating details to the database
       public void AddLeadRateMstr(clsEntityLeadRating objEntityLeadRateMstr)
        {
            string strQueryLeadRateMstr = "LEAD_RATE_MASTER.SP_INSERT_LEAD_RATE_MASTER";
            using (OracleCommand cmdAddLeadRate = new OracleCommand())
            {
                cmdAddLeadRate.CommandText = strQueryLeadRateMstr;
                cmdAddLeadRate.CommandType = CommandType.StoredProcedure;
                cmdAddLeadRate.Parameters.Add("LD_RATE_NAME", OracleDbType.Varchar2).Value = objEntityLeadRateMstr.LeadRateName;
                cmdAddLeadRate.Parameters.Add("LD_RATE_STATUS", OracleDbType.Int32).Value = objEntityLeadRateMstr.LeadRateStatus;
                cmdAddLeadRate.Parameters.Add("LD_ORG_ID", OracleDbType.Int32).Value = objEntityLeadRateMstr.Organisation_Id;
                cmdAddLeadRate.Parameters.Add("LD_CORPRT_ID", OracleDbType.Int32).Value = objEntityLeadRateMstr.CorpOffice_Id;
                cmdAddLeadRate.Parameters.Add("LD_INSUSERID", OracleDbType.Int32).Value = objEntityLeadRateMstr.LeadRateUserId;
                
                clsDataLayer.ExecuteNonQuery(cmdAddLeadRate);
            }
        }


       //Method for check lead rate name already exist in the table or not.
       public string CheckLeadRateName(clsEntityLeadRating objEntityLeadRateMstr)
       {
           string strQueryCheckLeadRateName = "LEAD_RATE_MASTER.SP_CHECK_LEAD_RATE_NAME";
           OracleCommand cmdCheckLeadRateName = new OracleCommand();
           cmdCheckLeadRateName.CommandText = strQueryCheckLeadRateName;
           cmdCheckLeadRateName.CommandType = CommandType.StoredProcedure;
           cmdCheckLeadRateName.Parameters.Add("LD_ORGID", OracleDbType.Int32).Value = objEntityLeadRateMstr.Organisation_Id;
           cmdCheckLeadRateName.Parameters.Add("LD_CORPID", OracleDbType.Int32).Value = objEntityLeadRateMstr.CorpOffice_Id;
           cmdCheckLeadRateName.Parameters.Add("LD_NAME", OracleDbType.Varchar2).Value = objEntityLeadRateMstr.LeadRateName;
           cmdCheckLeadRateName.Parameters.Add("LD_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
           clsDataLayer.ExecuteScalar(ref cmdCheckLeadRateName);
           string strReturnCount = cmdCheckLeadRateName.Parameters["LD_COUNT"].Value.ToString();
           cmdCheckLeadRateName.Dispose();
           return strReturnCount; ;
       }


       //Method for read Lead rate by their id.
       public DataTable ReadLeadrateById(clsEntityLeadRating objEntityLeadRateMstr)
       {
           string strQueryReadLeadRateById = "LEAD_RATE_MASTER.SP_READ_LEAD_RATE_BYID";
           using (OracleCommand cmdReadLeadRateById = new OracleCommand())
           {
               cmdReadLeadRateById.CommandText = strQueryReadLeadRateById;
               cmdReadLeadRateById.CommandType = CommandType.StoredProcedure;
               cmdReadLeadRateById.Parameters.Add("LD_ID", OracleDbType.Int32).Value = objEntityLeadRateMstr.LeadRateId;
               cmdReadLeadRateById.Parameters.Add("LD_LEAD_RATE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCorpDept = new DataTable();
               dtCorpDept = clsDataLayer.SelectDataTable(cmdReadLeadRateById);
               return dtCorpDept;
           }
       }


       //Method for check Lead rate name already exist in the table or not at the time of updation
       public string CheckLeadRateNameUpdate(clsEntityLeadRating objEntityLeadRateMstr)
       {
           string strQueryCheckLeadRateNameUpdate = "LEAD_RATE_MASTER.SP_CHECK_LEAD_RATE_UPDATION";
           OracleCommand cmdCheckLeadRateNameUpdate = new OracleCommand();
           cmdCheckLeadRateNameUpdate.CommandText = strQueryCheckLeadRateNameUpdate;
           cmdCheckLeadRateNameUpdate.CommandType = CommandType.StoredProcedure;
           cmdCheckLeadRateNameUpdate.Parameters.Add("LD_ORGID", OracleDbType.Int32).Value = objEntityLeadRateMstr.Organisation_Id;
           cmdCheckLeadRateNameUpdate.Parameters.Add("LD_CORPID", OracleDbType.Int32).Value = objEntityLeadRateMstr.CorpOffice_Id;
           cmdCheckLeadRateNameUpdate.Parameters.Add("LD_ID", OracleDbType.Int32).Value = objEntityLeadRateMstr.LeadRateId;
           cmdCheckLeadRateNameUpdate.Parameters.Add("LD_NAME", OracleDbType.Varchar2).Value = objEntityLeadRateMstr.LeadRateName;
           cmdCheckLeadRateNameUpdate.Parameters.Add("LD_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
           clsDataLayer.ExecuteScalar(ref cmdCheckLeadRateNameUpdate);
           string strReturnCount = cmdCheckLeadRateNameUpdate.Parameters["LD_COUNT"].Value.ToString();
           cmdCheckLeadRateNameUpdate.Dispose();
           return strReturnCount; ;
       }


       //Method for Updating data about lead rate to the lead rating master table
       public void Update_LeadRate(clsEntityLeadRating objEntityLeadRateMstr)
       {
           string strQueryUpdateLeadRate = "LEAD_RATE_MASTER.SP_UPDATE_LEAD_RATE";
           OracleCommand cmdUpdateLeadRate = new OracleCommand();
           cmdUpdateLeadRate.CommandText = strQueryUpdateLeadRate;
           cmdUpdateLeadRate.CommandType = CommandType.StoredProcedure;
           cmdUpdateLeadRate.Parameters.Add("LD_ID", OracleDbType.Int32).Value = objEntityLeadRateMstr.LeadRateId;
           cmdUpdateLeadRate.Parameters.Add("LD_NAME", OracleDbType.Varchar2).Value = objEntityLeadRateMstr.LeadRateName;
           cmdUpdateLeadRate.Parameters.Add("LD_STATUS", OracleDbType.Int32).Value = objEntityLeadRateMstr.LeadRateStatus;
           cmdUpdateLeadRate.Parameters.Add("LD_UPDUSERID", OracleDbType.Int32).Value = objEntityLeadRateMstr.LeadRateUserId;
           cmdUpdateLeadRate.Parameters.Add("LD_UPDDATE", OracleDbType.Date).Value = objEntityLeadRateMstr.LeadRateDate;
           clsDataLayer.ExecuteNonQuery(cmdUpdateLeadRate);
       }
       public void Update_LeadRate_Sts(clsEntityLeadRating objEntityLeadRateMstr)
       {
           string strQueryUpdateLeadRate = "LEAD_RATE_MASTER.SP_UPDATE_LEAD_RATE_STS";
           OracleCommand cmdUpdateLeadRate = new OracleCommand();
           cmdUpdateLeadRate.CommandText = strQueryUpdateLeadRate;
           cmdUpdateLeadRate.CommandType = CommandType.StoredProcedure;
           cmdUpdateLeadRate.Parameters.Add("LD_ID", OracleDbType.Int32).Value = objEntityLeadRateMstr.LeadRateId;
           cmdUpdateLeadRate.Parameters.Add("LD_STATUS", OracleDbType.Int32).Value = objEntityLeadRateMstr.LeadRateStatus;
           cmdUpdateLeadRate.Parameters.Add("LD_UPDUSERID", OracleDbType.Int32).Value = objEntityLeadRateMstr.LeadRateUserId;
           cmdUpdateLeadRate.Parameters.Add("LD_UPDDATE", OracleDbType.Date).Value = objEntityLeadRateMstr.LeadRateDate;
           clsDataLayer.ExecuteNonQuery(cmdUpdateLeadRate);
       }

        // //Method for Cancel lead rating from lead rating master table so update cancel related fields
       public void Cancel_LeadRate(clsEntityLeadRating objEntityLeadRateMstr)
       {
           string strQueryCancelLeadRate = "LEAD_RATE_MASTER.SP_CANCEL_LEAD_RATE";
           OracleCommand cmdCancelLeadRate = new OracleCommand();
           cmdCancelLeadRate.CommandText = strQueryCancelLeadRate;
           cmdCancelLeadRate.CommandType = CommandType.StoredProcedure;
           cmdCancelLeadRate.Parameters.Add("LD_ID", OracleDbType.Int32).Value = objEntityLeadRateMstr.LeadRateId;
           cmdCancelLeadRate.Parameters.Add("LD_CANCEL_USERID", OracleDbType.Int32).Value = objEntityLeadRateMstr.LeadRateUserId;
           cmdCancelLeadRate.Parameters.Add("LD_CANCEL_DATE", OracleDbType.Date).Value = objEntityLeadRateMstr.LeadRateDate;
           cmdCancelLeadRate.Parameters.Add("LD_CANCEL_REASON", OracleDbType.Varchar2).Value = objEntityLeadRateMstr.LeadRateCancelReason;
           clsDataLayer.ExecuteNonQuery(cmdCancelLeadRate);
       }


       //Method for read lead rate for list view.
       public DataTable ReadLeadRateList(clsEntityLeadRating objEntityLeadRateMstr)
       {
           string strQueryReadLeadRateList = "LEAD_RATE_MASTER.SP_READ_LEAD_RATELIST";
           using (OracleCommand cmdReadLeadRateList = new OracleCommand())
           {
               cmdReadLeadRateList.CommandText = strQueryReadLeadRateList;
               cmdReadLeadRateList.CommandType = CommandType.StoredProcedure;
               cmdReadLeadRateList.Parameters.Add("LD_ORGID", OracleDbType.Int32).Value = objEntityLeadRateMstr.Organisation_Id;
               cmdReadLeadRateList.Parameters.Add("LD_CORPID", OracleDbType.Int32).Value = objEntityLeadRateMstr.CorpOffice_Id;
               cmdReadLeadRateList.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntityLeadRateMstr.LeadRateStatus;
               cmdReadLeadRateList.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntityLeadRateMstr.Cancel_Status;
               cmdReadLeadRateList.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityLeadRateMstr.CommonSearchTerm;
               cmdReadLeadRateList.Parameters.Add("M_SEARCH_NAME", OracleDbType.Varchar2).Value = objEntityLeadRateMstr.SearchName;
               cmdReadLeadRateList.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityLeadRateMstr.OrderColumn;
               cmdReadLeadRateList.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityLeadRateMstr.OrderMethod;
               cmdReadLeadRateList.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityLeadRateMstr.PageMaxSize;
               cmdReadLeadRateList.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityLeadRateMstr.PageNumber;
               cmdReadLeadRateList.Parameters.Add("LD_LEAD_RATE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtLeadrateList = new DataTable();
               dtLeadrateList = clsDataLayer.SelectDataTable(cmdReadLeadRateList);
               return dtLeadrateList;
           }
       }
    }
}
