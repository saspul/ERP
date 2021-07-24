using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL_Compzit;
using Oracle.DataAccess.Client;
using System.Data;

// CREATED BY:EVM-0002
// CREATED DATE:01/06/2016
// REVIEWED BY:
// REVIEW DATE:

namespace DL_Compzit
{
    public class clsDataLayerTermsTemplate
    {
        // This Method adds template details to the template master table
        clsDataLayerDateAndTime objDataLayerDate = new clsDataLayerDateAndTime();
        public void AddTemplateMaster(clsEntityTermsTemplate objEntityTemplate)
        {
            string strQueryAddTemplateMaster = "TERMS_TEMPLATE.SP_INSERT_TERMS";
            using (OracleCommand cmdAddTemp = new OracleCommand())
            {
                cmdAddTemp.CommandText = strQueryAddTemplateMaster;
                cmdAddTemp.CommandType = CommandType.StoredProcedure;
                cmdAddTemp.Parameters.Add("T_NAME", OracleDbType.Varchar2).Value = objEntityTemplate.Template_name;
                cmdAddTemp.Parameters.Add("T_TEMPLATE", OracleDbType.Int32).Value = objEntityTemplate.Template_Type;
                cmdAddTemp.Parameters.Add("T_DESCRIPTION", OracleDbType.Varchar2).Value = objEntityTemplate.Template_Description;
                cmdAddTemp.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityTemplate.Org_Id;
                cmdAddTemp.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityTemplate.Corp_Id;
                cmdAddTemp.Parameters.Add("T_STATUS", OracleDbType.Int32).Value = objEntityTemplate.Template_Status;
                cmdAddTemp.Parameters.Add("T_INSUSERID", OracleDbType.Int32).Value = objEntityTemplate.User_Id;
                cmdAddTemp.Parameters.Add("T_DATE", OracleDbType.Date).Value = objEntityTemplate.D_Date;
                clsDataLayer.ExecuteNonQuery(cmdAddTemp);
            }
        }

        //Method for change the active / inactive status of template master
        public void TemplateStatusChange(clsEntityTermsTemplate objEntityTerms)
        {
            string strQueryTemplateStatus = "TERMS_TEMPLATE.SP_UPDATE_STATUS";
            using (OracleCommand cmdTemplateStatus = new OracleCommand())
            {
                cmdTemplateStatus.CommandText = strQueryTemplateStatus;
                cmdTemplateStatus.CommandType = CommandType.StoredProcedure;
                cmdTemplateStatus.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityTerms.Template_Id;
                cmdTemplateStatus.Parameters.Add("T_STATUS", OracleDbType.Int32).Value = objEntityTerms.Template_Status;
                cmdTemplateStatus.Parameters.Add("T_USERID", OracleDbType.Int32).Value = objEntityTerms.User_Id;
                cmdTemplateStatus.Parameters.Add("T_DATE", OracleDbType.Date).Value = objEntityTerms.D_Date;
                clsDataLayer.ExecuteNonQuery(cmdTemplateStatus);
            }
        }

        //Method for Updating template details
        public void UpdateTemplate(clsEntityTermsTemplate objEntityTerms)
        {
            string strQueryUpdateTemplate = "TERMS_TEMPLATE.SP_UPDATE_TERMS";
            using (OracleCommand cmdUpdateTemplate = new OracleCommand())
            {
                cmdUpdateTemplate.CommandText = strQueryUpdateTemplate;
                cmdUpdateTemplate.CommandType = CommandType.StoredProcedure;
                cmdUpdateTemplate.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityTerms.Template_Id;
                cmdUpdateTemplate.Parameters.Add("T_TEMPLATE", OracleDbType.Int32).Value = objEntityTerms.Template_Type;
                cmdUpdateTemplate.Parameters.Add("T_NAME", OracleDbType.Varchar2).Value = objEntityTerms.Template_name;
                cmdUpdateTemplate.Parameters.Add("T_DESCRIPTION", OracleDbType.Varchar2).Value = objEntityTerms.Template_Description;
                cmdUpdateTemplate.Parameters.Add("T_STATUS", OracleDbType.Int32).Value = objEntityTerms.Template_Status;
                cmdUpdateTemplate.Parameters.Add("T_UPDUSERID", OracleDbType.Int32).Value = objEntityTerms.User_Id;
                cmdUpdateTemplate.Parameters.Add("T_DATE", OracleDbType.Date).Value = objEntityTerms.D_Date;
                clsDataLayer.ExecuteNonQuery(cmdUpdateTemplate);
            }
        }

        //Method for cancel Template
        public void CancelTemplate(clsEntityTermsTemplate objEntityTerms)
        {
            string strQueryCancelTerms = "TERMS_TEMPLATE.SP_CANCEL_TERMS";
            using (OracleCommand cmdCancelTerms = new OracleCommand())
            {
                cmdCancelTerms.CommandText = strQueryCancelTerms;
                cmdCancelTerms.CommandType = CommandType.StoredProcedure;
                cmdCancelTerms.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityTerms.Template_Id;
                cmdCancelTerms.Parameters.Add("T_USERID", OracleDbType.Int32).Value = objEntityTerms.User_Id;
                cmdCancelTerms.Parameters.Add("T_DATE", OracleDbType.Date).Value = objEntityTerms.D_Date;
                cmdCancelTerms.Parameters.Add("T_REASON", OracleDbType.Varchar2).Value = objEntityTerms.Cancel_Reason;
                clsDataLayer.ExecuteNonQuery(cmdCancelTerms);
            }
        }

        // This Method checks Template name in the database for duplication.
        public string CheckTemplateName(clsEntityTermsTemplate objEntityTerms)
        {
            string strQueryCheckTempName = "TERMS_TEMPLATE.SP_CHECK_TERMS_NAME";
            OracleCommand cmdCheckTempName = new OracleCommand();
            cmdCheckTempName.CommandText = strQueryCheckTempName;
            cmdCheckTempName.CommandType = CommandType.StoredProcedure;
            cmdCheckTempName.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityTerms.Template_Id;
            cmdCheckTempName.Parameters.Add("T_NAME", OracleDbType.Varchar2).Value = objEntityTerms.Template_name;
            cmdCheckTempName.Parameters.Add("T_TEMPLATE", OracleDbType.Int32).Value = objEntityTerms.Template_Type;
            cmdCheckTempName.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityTerms.Org_Id;
            cmdCheckTempName.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityTerms.Corp_Id;
            cmdCheckTempName.Parameters.Add("T_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckTempName);
            string strReturn = cmdCheckTempName.Parameters["T_COUNT"].Value.ToString();
            cmdCheckTempName.Dispose();
            return strReturn;
        }

        // This Method will fetch Template Detail by ID
        public DataTable ReadTemplateById(clsEntityTermsTemplate objEntityTerms)
        {
            string strQueryReadTempById = "TERMS_TEMPLATE.SP_READ_TERMS_BYID";
            OracleCommand cmdReadTempById = new OracleCommand();
            cmdReadTempById.CommandText = strQueryReadTempById;
            cmdReadTempById.CommandType = CommandType.StoredProcedure;
            cmdReadTempById.Parameters.Add("T_ID", OracleDbType.Int32).Value = objEntityTerms.Template_Id;
            cmdReadTempById.Parameters.Add("T_BANK", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtTemp = new DataTable();
            dtTemp = clsDataLayer.ExecuteReader(cmdReadTempById);
            return dtTemp;
        }

        
        // This Method will fetch template master table
        public DataTable ReadTempList(clsEntityTermsTemplate objEntityTerms)
        {
            string strQueryReadTempList = "TERMS_TEMPLATE.SP_READ_TERMSLIST";
            OracleCommand cmdReadTempList = new OracleCommand();
            cmdReadTempList.CommandText = strQueryReadTempList;
            cmdReadTempList.CommandType = CommandType.StoredProcedure;
            cmdReadTempList.Parameters.Add("T_OPTION", OracleDbType.Int32).Value = objEntityTerms.Template_Status;
            cmdReadTempList.Parameters.Add("T_CANCEL", OracleDbType.Int32).Value = objEntityTerms.Cancel_Status;
            cmdReadTempList.Parameters.Add("T_ORGID", OracleDbType.Int32).Value = objEntityTerms.Org_Id;
            cmdReadTempList.Parameters.Add("T_CORPID", OracleDbType.Int32).Value = objEntityTerms.Corp_Id;
            cmdReadTempList.Parameters.Add("M_COMMON_SEARCH_TERM", OracleDbType.Varchar2).Value = objEntityTerms.CommonSearchTerm;
            cmdReadTempList.Parameters.Add("M_SEARCH_NAME", OracleDbType.Varchar2).Value = objEntityTerms.SearchName;
            cmdReadTempList.Parameters.Add("M_SEARCH_TYPE", OracleDbType.Varchar2).Value = objEntityTerms.SearchType;
            cmdReadTempList.Parameters.Add("M_ORDER_COLUMN", OracleDbType.Int32).Value = objEntityTerms.OrderColumn;
            cmdReadTempList.Parameters.Add("M_ORDER_METHOD", OracleDbType.Int32).Value = objEntityTerms.OrderMethod;
            cmdReadTempList.Parameters.Add("M_PAGE_MAXSIZE", OracleDbType.Int32).Value = objEntityTerms.PageMaxSize;
            cmdReadTempList.Parameters.Add("M_PAGE_NUMBER", OracleDbType.Int32).Value = objEntityTerms.PageNumber;
            cmdReadTempList.Parameters.Add("T_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtList = new DataTable();
            dtList = clsDataLayer.ExecuteReader(cmdReadTempList);
            return dtList;
        }
        // This Method will fetch quotation template master
        public DataTable ReadTempMaster()
        {
            string strQueryReadTempMaster = "TERMS_TEMPLATE.SP_READ_QUOTATION_TEMPLATES";
            OracleCommand cmdReadTempMaster = new OracleCommand();
            cmdReadTempMaster.CommandText = strQueryReadTempMaster;
            cmdReadTempMaster.CommandType = CommandType.StoredProcedure;
            cmdReadTempMaster.Parameters.Add("T_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtList = new DataTable();
            dtList = clsDataLayer.ExecuteReader(cmdReadTempMaster);
            return dtList;
        }

    }
}
