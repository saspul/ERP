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
   public class clsDataLayer_Arrivl_Confrmtn
    {

        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();

        public DataTable ReadArrvlConfrmtnList(clsEntity_Arrivl_Confrmtn objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "ARVVL_CONFRMTN.SP_READ_ARVVL_CONFRMTN_LIST";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
            if (objEntityVisaQuot.FromDate == DateTime.MinValue)
            {
                cmdReadPayGrd.Parameters.Add("P_DATE_FRM", OracleDbType.Date).Value = null;
            }
            else
            cmdReadPayGrd.Parameters.Add("P_DATE_FRM", OracleDbType.Date).Value = objEntityVisaQuot.FromDate;
            if (objEntityVisaQuot.ToDate == DateTime.MinValue)
            {
                cmdReadPayGrd.Parameters.Add("P_DATE_TO", OracleDbType.Date).Value = null;
            }
            else
            cmdReadPayGrd.Parameters.Add("P_DATE_TO", OracleDbType.Date).Value = objEntityVisaQuot.ToDate;
            cmdReadPayGrd.Parameters.Add("P_ARVDSTS", OracleDbType.Int32).Value = objEntityVisaQuot.ArrvedStsId;
            cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityVisaQuot.UserId;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.Orgid;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpOffice;
            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPayGrd);
            return dtCategory;
        }

        public void StatusChangeArrvlConfrmtn(clsEntity_Arrivl_Confrmtn objEntityVisaQuot)
         {
             string strQueryReadPayGrd = "ARVVL_CONFRMTN.SP_CHANGE_ARRVLSTS";
             using (OracleCommand cmdReadPayGrd = new OracleCommand())
             {
                 cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                 cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                 cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityVisaQuot.CandId;
                 cmdReadPayGrd.Parameters.Add("P_DATENOW", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                 cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityVisaQuot.UserId;
                 cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.Orgid;
                 cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpOffice;

                 clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
             }

         }
        public void Intw_skip_StatusChange(clsEntity_Arrivl_Confrmtn objEntityVisaQuot)
        {
            string strQueryReadPayGrd = "ARVVL_CONFRMTN.SP_CHANGE_INTW_SKP_STATUS";
            using (OracleCommand cmdReadPayGrd = new OracleCommand())
            {
                cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityVisaQuot.CandId;
                //cmdReadPayGrd.Parameters.Add("P_DATENOW", OracleDbType.Date).Value = objDataLayerDate.DateAndTime();
                //cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityVisaQuot.UserId;
                //cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityVisaQuot.Orgid;
                //cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityVisaQuot.CorpOffice;

                clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
            }

        }
    }
}
