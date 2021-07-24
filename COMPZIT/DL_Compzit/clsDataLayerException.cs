using System;
using System.Data;
using Oracle.DataAccess.Client;
using System.Configuration;
using EL_Compzit;

// CREATED BY:EVM-0002
// CREATED DATE:14/05/2015
// REVIEWED BY:
// REVIEW DATE:

namespace DL_Compzit
{
    public class clsDataLayerException
    {
        public void AddException(clsEntityException objEntException)
        {
            //Inserting all details about exception to the bug tracing table in the database.
            string strQueryAddException = "EXCEPTION_TRACING.SP_INSERT_EXCEPTION";
            using (OracleCommand cmdAddException = new OracleCommand())
            {
                cmdAddException.CommandText = strQueryAddException;
                cmdAddException.CommandType = CommandType.StoredProcedure;
                cmdAddException.Parameters.Add("B_TYPE", OracleDbType.Varchar2).Value = 1;
                cmdAddException.Parameters.Add("B_MESSAGE", OracleDbType.Varchar2).Value = objEntException.Excmsg;
                cmdAddException.Parameters.Add("B_MODULE", OracleDbType.Varchar2).Value = objEntException.ExcModule;
                cmdAddException.Parameters.Add("B_METHODE", OracleDbType.Varchar2).Value = objEntException.ExcMethode;
                cmdAddException.Parameters.Add("B_DESCRIPTION", OracleDbType.Varchar2).Value = objEntException.ErrorDescription;
                cmdAddException.Parameters.Add("B_ORGID", OracleDbType.Varchar2).Value = 1;
                cmdAddException.Parameters.Add("B_CORID", OracleDbType.Varchar2).Value = 2;
                clsDataLayer.ExecuteNonQuery(cmdAddException);
            }
        }
    }
}
