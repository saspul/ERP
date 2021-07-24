using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_HCM;
using DL_Compzit;
using EL_Compzit;

namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataLayer_AccntSetting
    {
        public DataTable ReadEmployeLeaveDetails(clsEntity_AccountSettings objEntityAccountSettings)
        {
            string strQueryReadEmploy = "HCM_ACCOUNT_SETTINGS.SP_READ_EMPLOYEE";
            OracleCommand cmdReadEmp = new OracleCommand();
            cmdReadEmp.CommandText = strQueryReadEmploy;
            cmdReadEmp.CommandType = CommandType.StoredProcedure;
            cmdReadEmp.Parameters.Add("U_ORG_ID", OracleDbType.Int32).Value = objEntityAccountSettings.OrgId;
            cmdReadEmp.Parameters.Add("U_CRPRT_ID", OracleDbType.Int32).Value = objEntityAccountSettings.CorpId;

            cmdReadEmp.Parameters.Add("U_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtEmployee = new DataTable();
            dtEmployee = clsDataLayer.ExecuteReader(cmdReadEmp);
            return dtEmployee;

        }
    }
}
