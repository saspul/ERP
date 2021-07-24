using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_HCM;
namespace DL_Compzit.DataLayer_HCM
{
    public class clsDataLayerVisaType
    {
        //add details to visa type table
        public void addDetails(clsEntityLayerVisaType objEntityVisa)
        {
            string strQueryUpdVehicle = "VISATYPE_MASTER.SP_INS_VISA_TYPE";
            using (OracleCommand cmdUpdOrgDetail = new OracleCommand())
            {
                cmdUpdOrgDetail.CommandText = strQueryUpdVehicle;
                cmdUpdOrgDetail.CommandType = CommandType.StoredProcedure;
                cmdUpdOrgDetail.Parameters.Add("IN_VNAME", OracleDbType.Varchar2).Value = objEntityVisa.VisaName;
                cmdUpdOrgDetail.Parameters.Add("IN_V_STATUS", OracleDbType.Int32).Value = objEntityVisa.Status;
                cmdUpdOrgDetail.Parameters.Add("IN_USR_ID", OracleDbType.Int32).Value = objEntityVisa.UserInsId;
                cmdUpdOrgDetail.Parameters.Add("IN_ORG_ID", OracleDbType.Int32).Value = objEntityVisa.OrgId;
                cmdUpdOrgDetail.Parameters.Add("IN_CORPRT_ID", OracleDbType.Int32).Value = objEntityVisa.CorpId;
                cmdUpdOrgDetail.Parameters.Add("IN_DATE", OracleDbType.Date).Value = objEntityVisa.InsDate;
                clsDataLayer.ExecuteNonQuery(cmdUpdOrgDetail);
            }
        }
        //read details from visa type table
        public DataTable ReadDetails(clsEntityLayerVisaType objEntityVisa)
        {
            string strQueryUpdVehicle = "VISATYPE_MASTER.SP_READ_VISA_TYPE";
            using (OracleCommand cmdUpdOrgDetail = new OracleCommand())
            {
                cmdUpdOrgDetail.CommandText = strQueryUpdVehicle;
                cmdUpdOrgDetail.CommandType = CommandType.StoredProcedure;
                cmdUpdOrgDetail.Parameters.Add("P_STATUS", OracleDbType.Int32).Value = objEntityVisa.Status;
                cmdUpdOrgDetail.Parameters.Add("P_CANCELSTS", OracleDbType.Int32).Value = objEntityVisa.Cancel_Status;
                cmdUpdOrgDetail.Parameters.Add("IN_ORG_ID", OracleDbType.Int32).Value = objEntityVisa.OrgId;
                cmdUpdOrgDetail.Parameters.Add("IN_CORPRT_ID", OracleDbType.Int32).Value = objEntityVisa.CorpId;
                cmdUpdOrgDetail.Parameters.Add("D_DSGN", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCheckOrg = new DataTable();
                dtCheckOrg = clsDataLayer.SelectDataTable(cmdUpdOrgDetail);
                return dtCheckOrg;
            }
        }
        //read visa name 
        public string ReadVisaName(clsEntityLayerVisaType objEntityVisa)
        {
            string strQueryReadOrg = "VISATYPE_MASTER.SP_CHECK_VISA_NAME";
            OracleCommand cmdCheckAccoName = new OracleCommand();
            cmdCheckAccoName.CommandText = strQueryReadOrg;
            cmdCheckAccoName.CommandType = CommandType.StoredProcedure;
            cmdCheckAccoName.Parameters.Add("V_ID", OracleDbType.Int32).Value = objEntityVisa.VisaId;     //emp17
            cmdCheckAccoName.Parameters.Add("IN_VNAME", OracleDbType.Varchar2).Value = objEntityVisa.VisaName;
            cmdCheckAccoName.Parameters.Add("IN_ORG_ID", OracleDbType.Int32).Value = objEntityVisa.OrgId;
            cmdCheckAccoName.Parameters.Add("IN_CORPRT_ID", OracleDbType.Int32).Value = objEntityVisa.CorpId; //emp17
            cmdCheckAccoName.Parameters.Add("D_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckAccoName);
            string strReturn = cmdCheckAccoName.Parameters["D_COUNT"].Value.ToString();
            cmdCheckAccoName.Dispose();
            return strReturn;

        }
        //update visa status 
        public void ChangeStatus(clsEntityLayerVisaType objEntityVisa)
        {
            string strQueryUpdVehicle = "VISATYPE_MASTER.SP_UPD_VISA_STATUS";
            using (OracleCommand cmdUpdOrgDetail = new OracleCommand())
            {
                cmdUpdOrgDetail.CommandText = strQueryUpdVehicle;
                cmdUpdOrgDetail.CommandType = CommandType.StoredProcedure;
                cmdUpdOrgDetail.Parameters.Add("IN_VISA_ID", OracleDbType.Int32).Value = objEntityVisa.VisaId;
                cmdUpdOrgDetail.Parameters.Add("IN_V_STATUS", OracleDbType.Int32).Value = objEntityVisa.Status;
                clsDataLayer.ExecuteNonQuery(cmdUpdOrgDetail);
            }
        }

        //Fetch data by Id 
        public DataTable getDetailsById(clsEntityLayerVisaType objEntityVisa)
        {
            string strQueryUpdVisa = "VISATYPE_MASTER.SP_GET_DATABYID";
            using (OracleCommand cmdUpdDetail = new OracleCommand())
            {
                cmdUpdDetail.CommandText = strQueryUpdVisa;
                cmdUpdDetail.CommandType = CommandType.StoredProcedure;
                cmdUpdDetail.Parameters.Add("IN_VISA_ID", OracleDbType.Int32).Value = objEntityVisa.VisaId;
                cmdUpdDetail.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCheckOrg = new DataTable();
                dtCheckOrg = clsDataLayer.SelectDataTable(cmdUpdDetail);
                return dtCheckOrg;
            }
        }

        //update visa Details 
        public void Update_Visa(clsEntityLayerVisaType objEntityVisa)
        {
            string strQueryUpdVehicle = "VISATYPE_MASTER.SP_UPD_VISA_DTLS";
            using (OracleCommand cmdUpdOrgDetail = new OracleCommand())
            {
                cmdUpdOrgDetail.CommandText = strQueryUpdVehicle;
                cmdUpdOrgDetail.CommandType = CommandType.StoredProcedure;
                cmdUpdOrgDetail.Parameters.Add("IN_VISA_ID", OracleDbType.Int32).Value = objEntityVisa.VisaId;
                cmdUpdOrgDetail.Parameters.Add("IN_VISA_NAME", OracleDbType.Varchar2).Value = objEntityVisa.VisaName;
                cmdUpdOrgDetail.Parameters.Add("IN_VISA_STATUS", OracleDbType.Int32).Value = objEntityVisa.Status;
                cmdUpdOrgDetail.Parameters.Add("IN_UPD_USR_ID", OracleDbType.Int32).Value = objEntityVisa.UserUpId;
                cmdUpdOrgDetail.Parameters.Add("IN_UPD_DATE", OracleDbType.Date).Value = objEntityVisa.UpDate;              
                clsDataLayer.ExecuteNonQuery(cmdUpdOrgDetail);
            }
        }

        //Method for cancel Visa Type
        public void Cancel_Visa(clsEntityLayerVisaType objEntityVisa)
        {
            string strQueryCancelVisa = "VISATYPE_MASTER.SP_CNCL_VISA";
            using (OracleCommand cmdCancelVisa = new OracleCommand())
            {
                cmdCancelVisa.CommandText = strQueryCancelVisa;
                cmdCancelVisa.CommandType = CommandType.StoredProcedure;
                cmdCancelVisa.Parameters.Add("P_VISAID", OracleDbType.Int32).Value = objEntityVisa.VisaId;
                cmdCancelVisa.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityVisa.UserCnclId;
                cmdCancelVisa.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityVisa.CnclDate;
                cmdCancelVisa.Parameters.Add("P_REASON", OracleDbType.Varchar2).Value = objEntityVisa.Cancel_Reason;
                clsDataLayer.ExecuteNonQuery(cmdCancelVisa);
            }
        }

    }
}
