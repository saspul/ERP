using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using Oracle.DataAccess.Client;
using System.Data;

// CREATED BY:EVM-0002
// CREATED DATE:22/05/2015
// REVIEWED BY:
// REVIEW DATE:

// This is the Data Layer for Adding Organisation detail and also updating,canceling and viewing the same .

namespace DL_Compzit
{
    public class clsDataLayerOrgType
    {
        // This Method adds Organisation details to the database
        public void AddOrgMstr(clsEntityOrgType objOrgMstr)
        {
            string strQueryAddOrgMstr = "ORGANISATION_TYPE.SP_INSERT_GN_ORG_TYPE";
            using (OracleCommand cmdAddOrg = new OracleCommand())
            {
                cmdAddOrg.CommandText = strQueryAddOrgMstr;
                cmdAddOrg.CommandType = CommandType.StoredProcedure;
                cmdAddOrg.Parameters.Add("O_NAME", OracleDbType.Varchar2).Value = objOrgMstr.OrgName;
                cmdAddOrg.Parameters.Add("O_STATUS", OracleDbType.Int32).Value = objOrgMstr.OrgStatus;
                cmdAddOrg.Parameters.Add("O_INS_USERID", OracleDbType.Int32).Value = objOrgMstr.OrgUserId;
                clsDataLayer.ExecuteNonQuery(cmdAddOrg);
            }
        }
        
        // This Method displays Organisation  details from the database
        public DataTable GridDisplay(clsEntityOrgType objOrg)
        {
            string strQueryGridOrg = "ORGANISATION_TYPE.SP_READ_GN_ORG_TYPE";
            using (OracleCommand cmdGrid = new OracleCommand())
            {
                cmdGrid.CommandText = strQueryGridOrg;
                cmdGrid.CommandType = CommandType.StoredProcedure;
                cmdGrid.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objOrg.OrgStatus;
                cmdGrid.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objOrg.Cancel_Status;
                cmdGrid.Parameters.Add("O_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtGridDisp = new DataTable();
                dtGridDisp = clsDataLayer.SelectDataTable(cmdGrid);
                return dtGridDisp;
            }
        }
        // This Method Updates the Status of Organisation in the database
        public void UpdateStatus(clsEntityOrgType objOrg)
        {
            string strQueryUpdateStatus = "ORGANISATION_TYPE.SP_UPDATE_GN_ORG_ACTIVE";
            using (OracleCommand cmdUpdateStatus = new OracleCommand())
            {
                cmdUpdateStatus.CommandText = strQueryUpdateStatus;
                cmdUpdateStatus.CommandType = CommandType.StoredProcedure;
                cmdUpdateStatus.Parameters.Add("O_ID", OracleDbType.Int32).Value = objOrg.OrgTypId;
                cmdUpdateStatus.Parameters.Add("O_STATUS", OracleDbType.Int32).Value = objOrg.OrgStatus;
                cmdUpdateStatus.Parameters.Add("O_UPD_USR_ID", OracleDbType.Int32).Value = objOrg.OrgUserId;
                cmdUpdateStatus.Parameters.Add("O_UPD_DATE", OracleDbType.Date).Value = objOrg.OrgDate;
                clsDataLayer.ExecuteNonQuery(cmdUpdateStatus);
            }
        }
        // This Method select the details from the database when Edit and View Button is Clicked
        public DataTable EditViewOrg(clsEntityOrgType objOrg)
        {
            string strQueryEditViewOrg = "ORGANISATION_TYPE.SP_READ_GN_ORG_BYID";
            using (OracleCommand cmdEditView = new OracleCommand())
            {
                cmdEditView.CommandText = strQueryEditViewOrg;
                cmdEditView.CommandType = CommandType.StoredProcedure;
                cmdEditView.Parameters.Add("O_ID", OracleDbType.Int32).Value = objOrg.OrgTypId;
                cmdEditView.Parameters.Add("O_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtEditViewOrg = new DataTable();
                dtEditViewOrg = clsDataLayer.SelectDataTable(cmdEditView);
                return dtEditViewOrg;
            }
        }
        // This Method Updates  Organisation details  to the database
        public void UpdateOrg(clsEntityOrgType objOrg)
        {
            string strQueryUpdOrg = "ORGANISATION_TYPE.SP_UPDATE_GN_ORG_TYPE";
            using (OracleCommand cmdUpdateOrg = new OracleCommand())
            {
                cmdUpdateOrg.CommandText = strQueryUpdOrg;
                cmdUpdateOrg.CommandType = CommandType.StoredProcedure;
                cmdUpdateOrg.Parameters.Add("O_ID", OracleDbType.Int32).Value = objOrg.OrgTypId;
                cmdUpdateOrg.Parameters.Add("O_NAME", OracleDbType.Varchar2).Value = objOrg.OrgName;
                cmdUpdateOrg.Parameters.Add("O_STATUS", OracleDbType.Int32).Value = objOrg.OrgStatus;
                cmdUpdateOrg.Parameters.Add("O_UPD_USR_ID", OracleDbType.Int32).Value = objOrg.OrgUserId;
                cmdUpdateOrg.Parameters.Add("O_UPD_DATE", OracleDbType.Date).Value = objOrg.OrgDate;
                clsDataLayer.ExecuteNonQuery(cmdUpdateOrg);
            }
        }
        //This method updates cancel user id and cancel reason to the database when cancel is clicked
        public void UpdateCancelClick(clsEntityOrgType objOrg)
        {
            string strQueryUpdateCancel = "ORGANISATION_TYPE.SP_CANCEL_GN_ORGTYPE";
            using (OracleCommand cmdUpadateCancel = new OracleCommand())
            {
                cmdUpadateCancel.CommandText = strQueryUpdateCancel;
                cmdUpadateCancel.CommandType = CommandType.StoredProcedure;
                cmdUpadateCancel.Parameters.Add("O_ID", OracleDbType.Int32).Value = objOrg.OrgTypId;
                cmdUpadateCancel.Parameters.Add("O_CNCL_USR_ID", OracleDbType.Int32).Value = objOrg.OrgUserId;
                cmdUpadateCancel.Parameters.Add("O_CNCL_DATE", OracleDbType.Date).Value = objOrg.OrgDate;
                cmdUpadateCancel.Parameters.Add("O_CNCL_REASON", OracleDbType.Varchar2).Value = objOrg.OrgCancelReason;
                clsDataLayer.ExecuteNonQuery(cmdUpadateCancel);
            }
        }
        // This Method for checking organisation type already existed on the table.
        public DataTable CheckOrgType(clsEntityOrgType objOrg)
        {
            string strQueryCheckOrgType = "ORGANISATION_TYPE.SP_CHECK_ORGTYPE_NAME";
            using (OracleCommand cmdcheckOrgType = new OracleCommand())
            {
                cmdcheckOrgType.CommandText = strQueryCheckOrgType;
                cmdcheckOrgType.CommandType = CommandType.StoredProcedure;
                cmdcheckOrgType.Parameters.Add("O_NAME", OracleDbType.Varchar2).Value = objOrg.OrgName;
                cmdcheckOrgType.Parameters.Add("O_TYPE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCheckOrg = new DataTable();
                dtCheckOrg = clsDataLayer.SelectDataTable(cmdcheckOrgType);
                return dtCheckOrg;
            }
        }
        //Method for check organisation type name wheather it existed already in the time of updation
        public string CheckOrgTypeUpdation(clsEntityOrgType objOrg)
        {
            string strQueryCheckOrgTypeUpdate = "ORGANISATION_TYPE.SP_CHECK_ORGTYPE_NAMEUPDATE";
            OracleCommand cmdcheckOrgTypeUpdate = new OracleCommand();
            cmdcheckOrgTypeUpdate.CommandText = strQueryCheckOrgTypeUpdate;
            cmdcheckOrgTypeUpdate.CommandType = CommandType.StoredProcedure;
            cmdcheckOrgTypeUpdate.Parameters.Add("O_ID", OracleDbType.Int32).Value = objOrg.OrgTypId;
            cmdcheckOrgTypeUpdate.Parameters.Add("O_NAME", OracleDbType.Varchar2).Value = objOrg.OrgName;
            cmdcheckOrgTypeUpdate.Parameters.Add("O_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdcheckOrgTypeUpdate);
            string strReturnCount = cmdcheckOrgTypeUpdate.Parameters["O_COUNT"].Value.ToString();
            cmdcheckOrgTypeUpdate.Dispose();
            return strReturnCount; ;
        }
    }
}
