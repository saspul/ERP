
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
// CREATED BY:EVM-0008
// CREATED DATE:05/12/2016
// REVIEWED BY:
// REVIEW DATE:

namespace DL_Compzit.DataLayer_AWMS
{
   public class clsDataLayerHolidayMaster
    {
       clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
       public DataTable ReadHolType(clsEntityLayerHolidayMaster objEntityHol)
       {
           string strQueryReadHol = "HOLIDAY_MASTER.SP_READ_HOLIDAY_TYPE";
           OracleCommand cmdReadHol = new OracleCommand();
           cmdReadHol.CommandText = strQueryReadHol;
           cmdReadHol.CommandType = CommandType.StoredProcedure;
           cmdReadHol.Parameters.Add("W_VEH", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtHolTyp = new DataTable();
           dtHolTyp = clsDataLayer.ExecuteReader(cmdReadHol);
           return dtHolTyp;
       }

      

       public string Checksalaryprocess(clsEntityLayerHolidayMaster objEntityHol)
       {

           string strQueryReadHol = "HOLIDAY_MASTER.SP_CHECK_SALARY_PRS";
           OracleCommand cmdReadHol = new OracleCommand();
           cmdReadHol.CommandText = strQueryReadHol;
           cmdReadHol.CommandType = CommandType.StoredProcedure;
           cmdReadHol.Parameters.Add("H_ORGID", OracleDbType.Int32).Value = objEntityHol.Organisation_id;
           cmdReadHol.Parameters.Add("H_CORPID", OracleDbType.Int32).Value = objEntityHol.Corporate_id;
           cmdReadHol.Parameters.Add("H_DATE", OracleDbType.Date).Value = objEntityHol.HolidayDate;
           cmdReadHol.Parameters.Add("V_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
           clsDataLayer.ExecuteScalar(ref cmdReadHol);
           string strReturn = cmdReadHol.Parameters["V_COUNT"].Value.ToString();
           cmdReadHol.Dispose();
           return strReturn;
       }
       
       public string CheckHolTitle(clsEntityLayerHolidayMaster objEntityHol)
       {

           string strQueryReadHoldy = "HOLIDAY_MASTER.SP_CHECK_HOL_TITLE_NAME";
           OracleCommand cmdReadHol = new OracleCommand();
           cmdReadHol.CommandText = strQueryReadHoldy;
           cmdReadHol.CommandType = CommandType.StoredProcedure;
           cmdReadHol.Parameters.Add("H_ID", OracleDbType.Int32).Value = objEntityHol.Holdy_Id;
           cmdReadHol.Parameters.Add("H_NAME", OracleDbType.Varchar2).Value = objEntityHol.HolidayTitle;
          cmdReadHol.Parameters.Add("H_ORGID", OracleDbType.Int32).Value = objEntityHol.Organisation_id;
           cmdReadHol.Parameters.Add("H_CORPID", OracleDbType.Int32).Value = objEntityHol.Corporate_id;
           cmdReadHol.Parameters.Add("H_DATE", OracleDbType.Date).Value = objEntityHol.HolidayDate;
           cmdReadHol.Parameters.Add("H_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
           clsDataLayer.ExecuteScalar(ref cmdReadHol);
           string strReturn = cmdReadHol.Parameters["H_COUNT"].Value.ToString();
           cmdReadHol.Dispose();
           return strReturn;
       }

       public string CheckHolDate(clsEntityLayerHolidayMaster objEntityHol)
       {

           string strQueryReadHoldy = "HOLIDAY_MASTER.SP_CHECK_HOL_DATE";
           OracleCommand cmdReadHol = new OracleCommand();
           cmdReadHol.CommandText = strQueryReadHoldy;
           cmdReadHol.CommandType = CommandType.StoredProcedure;
           cmdReadHol.Parameters.Add("H_ID", OracleDbType.Int32).Value = objEntityHol.Holdy_Id;
           cmdReadHol.Parameters.Add("H_DATE", OracleDbType.Date).Value = objEntityHol.HolidayDate;
           cmdReadHol.Parameters.Add("H_ORGID", OracleDbType.Int32).Value = objEntityHol.Organisation_id;
           cmdReadHol.Parameters.Add("H_CORPID", OracleDbType.Int32).Value = objEntityHol.Corporate_id;
           cmdReadHol.Parameters.Add("H_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
           clsDataLayer.ExecuteScalar(ref cmdReadHol);
           string strReturn = cmdReadHol.Parameters["H_COUNT"].Value.ToString();
           cmdReadHol.Dispose();
           return strReturn;
       }


       // This Method adds holiday details to the table
       public void AddHolidayDetails(clsEntityLayerHolidayMaster objEntityHol)
       {
           string strQueryReadHol = "HOLIDAY_MASTER.SP_INS_HOLIDAY_DETAILS";
           using (OracleCommand cmdAddHol = new OracleCommand())
           {
               cmdAddHol.CommandText = strQueryReadHol;
               cmdAddHol.CommandType = CommandType.StoredProcedure;
              // cmdAddHol.Parameters.Add("H_STATUS", OracleDbType.Int32).Value = objEntityHol.Status_id;
               cmdAddHol.Parameters.Add("H_USERID", OracleDbType.Int32).Value = objEntityHol.User_Id;
               cmdAddHol.Parameters.Add("H_MODEID", OracleDbType.Int32).Value = objEntityHol.HolModeId;
               cmdAddHol.Parameters.Add("H_TYPEID", OracleDbType.Int32).Value = objEntityHol.HOlTypeId;
               cmdAddHol.Parameters.Add("H_TITLE", OracleDbType.Varchar2).Value = objEntityHol.HolidayTitle;
               cmdAddHol.Parameters.Add("H_ORGID", OracleDbType.Int32).Value = objEntityHol.Organisation_id;
               cmdAddHol.Parameters.Add("H_CORPID", OracleDbType.Int32).Value = objEntityHol.Corporate_id;
               cmdAddHol.Parameters.Add("H_DATE", OracleDbType.Date).Value = objEntityHol.HolidayDate;
               clsDataLayer.ExecuteNonQuery(cmdAddHol);
           }
       }

       // This Method update holiday details to the table
       public void UpdateHoldetails(clsEntityLayerHolidayMaster objEntityHol)
       {
           string strQueryReadHol = "HOLIDAY_MASTER.SP_UPD_HOLIDAY_DETAILS";
           using (OracleCommand cmdAddHol = new OracleCommand())
           {
               cmdAddHol.CommandText = strQueryReadHol;
               cmdAddHol.CommandType = CommandType.StoredProcedure;
               cmdAddHol.Parameters.Add("H_ID", OracleDbType.Int32).Value = objEntityHol.Holdy_Id;
              // cmdAddHol.Parameters.Add("H_STATUS", OracleDbType.Int32).Value = objEntityHol.Status_id;
               cmdAddHol.Parameters.Add("H_USERID", OracleDbType.Int32).Value = objEntityHol.User_Id;
               cmdAddHol.Parameters.Add("H_MODEID", OracleDbType.Int32).Value = objEntityHol.HolModeId;
               cmdAddHol.Parameters.Add("H_TYPEID", OracleDbType.Int32).Value = objEntityHol.HOlTypeId;
               cmdAddHol.Parameters.Add("H_NAME", OracleDbType.Varchar2).Value = objEntityHol.HolidayTitle;
               cmdAddHol.Parameters.Add("H_ORGID", OracleDbType.Int32).Value = objEntityHol.Organisation_id;
               cmdAddHol.Parameters.Add("H_CORPID", OracleDbType.Int32).Value = objEntityHol.Corporate_id;
               cmdAddHol.Parameters.Add("H_DATE", OracleDbType.Date).Value = objEntityHol.HolidayDate;
               cmdAddHol.Parameters.Add("H_CURNT_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                clsDataLayer.ExecuteNonQuery(cmdAddHol);
           }
       }

       // This Method Confirm holiday details to the table
       public void ConfirmHoliday(clsEntityLayerHolidayMaster objEntityHol)
       {
           string strQueryReadHol = "HOLIDAY_MASTER.SP_CONFM_HOLIDAY_DETAILS";
           using (OracleCommand cmdAddHol = new OracleCommand())
           {
               cmdAddHol.CommandText = strQueryReadHol;
               cmdAddHol.CommandType = CommandType.StoredProcedure;
               cmdAddHol.Parameters.Add("H_ID", OracleDbType.Int32).Value = objEntityHol.Holdy_Id;
               cmdAddHol.Parameters.Add("H_CONFM", OracleDbType.Int32).Value = objEntityHol.HOlConfmn;
           //    cmdAddHol.Parameters.Add("H_STATUS", OracleDbType.Int32).Value = objEntityHol.Status_id;
               cmdAddHol.Parameters.Add("H_USERID", OracleDbType.Int32).Value = objEntityHol.User_Id;
               cmdAddHol.Parameters.Add("H_MODEID", OracleDbType.Int32).Value = objEntityHol.HolModeId;
               cmdAddHol.Parameters.Add("H_TYPEID", OracleDbType.Int32).Value = objEntityHol.HOlTypeId;
               cmdAddHol.Parameters.Add("H_NAME", OracleDbType.Varchar2).Value = objEntityHol.HolidayTitle;
               cmdAddHol.Parameters.Add("H_ORGID", OracleDbType.Int32).Value = objEntityHol.Organisation_id;
               cmdAddHol.Parameters.Add("H_CORPID", OracleDbType.Int32).Value = objEntityHol.Corporate_id;
               cmdAddHol.Parameters.Add("H_DATE", OracleDbType.Date).Value = objEntityHol.HolidayDate;
               cmdAddHol.Parameters.Add("H_CURNT_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
               clsDataLayer.ExecuteNonQuery(cmdAddHol);
           }
       }

       // This Method Confirm holiday details to the table
       public void ReOpenHoliday(clsEntityLayerHolidayMaster objEntityHol)
       {
           string strQueryReadHol = "HOLIDAY_MASTER.SP_REOPEN_HOLIDAY";
           using (OracleCommand cmdAddHol = new OracleCommand())
           {
               cmdAddHol.CommandText = strQueryReadHol;
               cmdAddHol.CommandType = CommandType.StoredProcedure;
               cmdAddHol.Parameters.Add("H_ID", OracleDbType.Int32).Value = objEntityHol.Holdy_Id;
               cmdAddHol.Parameters.Add("H_CONFM", OracleDbType.Int32).Value = objEntityHol.HOlConfmn;
                cmdAddHol.Parameters.Add("H_USERID", OracleDbType.Int32).Value = objEntityHol.User_Id;
                cmdAddHol.Parameters.Add("H_ORGID", OracleDbType.Int32).Value = objEntityHol.Organisation_id;
               cmdAddHol.Parameters.Add("H_CORPID", OracleDbType.Int32).Value = objEntityHol.Corporate_id;
               cmdAddHol.Parameters.Add("H_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
               clsDataLayer.ExecuteNonQuery(cmdAddHol);
           }
       }

        // This Method read holiday details by id
       public DataTable ReadHolidaydetailsById(clsEntityLayerHolidayMaster objEntityHol)
       {
           string strQueryReadHol = "HOLIDAY_MASTER.SP_READ_HOL_DETAILS_BY_ID";
           OracleCommand cmdReadHol = new OracleCommand();
           cmdReadHol.CommandText = strQueryReadHol;
           cmdReadHol.CommandType = CommandType.StoredProcedure;
           cmdReadHol.Parameters.Add("H_ID", OracleDbType.Int32).Value = objEntityHol.Holdy_Id;
             cmdReadHol.Parameters.Add("H_HOL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtHolTyp = new DataTable();
           dtHolTyp = clsDataLayer.ExecuteReader(cmdReadHol);
           return dtHolTyp;


       }

       // This Method recall holiday details
       public void ReCallHolidayDetails(clsEntityLayerHolidayMaster objEntityHol)
       {
           string strQueryReadHol = "HOLIDAY_MASTER.SP_RECALL_HOL_DETAILS";
           using (OracleCommand cmdAddHol = new OracleCommand())
           {
               cmdAddHol.CommandText = strQueryReadHol;
               cmdAddHol.CommandType = CommandType.StoredProcedure;
               cmdAddHol.Parameters.Add("H_ID", OracleDbType.Int32).Value = objEntityHol.Holdy_Id;
               cmdAddHol.Parameters.Add("H_USERID", OracleDbType.Int32).Value = objEntityHol.User_Id;
               cmdAddHol.Parameters.Add("H_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
               clsDataLayer.ExecuteNonQuery(cmdAddHol);
           }
       }

       // This Method cancel holiday details
       public void CancelHoliday(clsEntityLayerHolidayMaster objEntityHol)
       {
           string strQueryReadHol = "HOLIDAY_MASTER.SP_CANCEL_HOL_DETAILS";
           using (OracleCommand cmdAddHol = new OracleCommand())
           {
               cmdAddHol.CommandText = strQueryReadHol;
               cmdAddHol.CommandType = CommandType.StoredProcedure;
               cmdAddHol.Parameters.Add("H_ID", OracleDbType.Int32).Value = objEntityHol.Holdy_Id;
               cmdAddHol.Parameters.Add("H_USERID", OracleDbType.Int32).Value = objEntityHol.User_Id;
               cmdAddHol.Parameters.Add("H_DATE", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
               cmdAddHol.Parameters.Add("H_CANRES", OracleDbType.Varchar2).Value = objEntityHol.CancelReason;
               clsDataLayer.ExecuteNonQuery(cmdAddHol);
           }
       }

       
           // This Method read holiday details by id
       public DataTable ReadHolidayListBySearch(clsEntityLayerHolidayMaster objEntityHol)
       {
           string strQueryReadHol = "HOLIDAY_MASTER.SP_READ_HOLIDAY_BYSEARCH";
           OracleCommand cmdReadHolbysrch = new OracleCommand();
           cmdReadHolbysrch.CommandText = strQueryReadHol;
           cmdReadHolbysrch.CommandType = CommandType.StoredProcedure;
            cmdReadHolbysrch.Parameters.Add("H_ORGID", OracleDbType.Int32).Value = objEntityHol.Organisation_id;
           cmdReadHolbysrch.Parameters.Add("H_CORPID", OracleDbType.Int32).Value = objEntityHol.Corporate_id;
          cmdReadHolbysrch.Parameters.Add("H_OPTION", OracleDbType.Int32).Value = objEntityHol.Status_id;
           cmdReadHolbysrch.Parameters.Add("H_CANCEL", OracleDbType.Int32).Value = objEntityHol.CancelStatus;
           cmdReadHolbysrch.Parameters.Add("H_YEAR", OracleDbType.Int32).Value = objEntityHol.HOlYear;
           cmdReadHolbysrch.Parameters.Add("H_HOL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtHolTyp = new DataTable();
           dtHolTyp = clsDataLayer.ExecuteReader(cmdReadHolbysrch);
           return dtHolTyp;

     
       }


       public DataTable ReadYr(clsEntityLayerHolidayMaster objEntityHol)
       {

           string strQueryReadHol = "HOLIDAY_MASTER.SP_READ_HOLIDAY_MAXYR";
           OracleCommand cmdReadHol = new OracleCommand();
           cmdReadHol.CommandText = strQueryReadHol;
           cmdReadHol.CommandType = CommandType.StoredProcedure;
           cmdReadHol.Parameters.Add("H_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtHolTyp = new DataTable();
           dtHolTyp = clsDataLayer.ExecuteReader(cmdReadHol);
           return dtHolTyp;
       }

       public DataTable LeavAlloctnConfrmCk(clsEntityLayerHolidayMaster objEntityHol)
       {
           string strQueryReadHol = "HOLIDAY_MASTER.SP_READ_LEAV_ALLOCN_CHK";
           OracleCommand cmdReadHolbysrch = new OracleCommand();
           cmdReadHolbysrch.CommandText = strQueryReadHol;
           cmdReadHolbysrch.CommandType = CommandType.StoredProcedure;
           cmdReadHolbysrch.Parameters.Add("H_DATE", OracleDbType.Date).Value = objEntityHol.HolidayDate;
           cmdReadHolbysrch.Parameters.Add("H_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtHolTyp = new DataTable();
           dtHolTyp = clsDataLayer.ExecuteReader(cmdReadHolbysrch);
           return dtHolTyp;


       }

    }
}
