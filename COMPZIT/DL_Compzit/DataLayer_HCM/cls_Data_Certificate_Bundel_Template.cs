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
      public class cls_Data_Certificate_Bundel_Template
    {

           public void InsertCertificateTemplate(clsEntity_Certificate_Bundel_Template objEntityCertificateBundel, List<clsEntity_Certificate_Bundel_Template_details> objEntityCertificateBundeldtls)
        {

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {

                    string strQueryInsertDsgn = "CERTIFICATE_BUNDEL_TEMPLATE.SP_INS_CRTFCTBNDLTEMP";
                    using (OracleCommand cmdInsertCertificateTemplate = new OracleCommand())
                    {
                        cmdInsertCertificateTemplate.Transaction = tran;
                        cmdInsertCertificateTemplate.Connection = con;
                        cmdInsertCertificateTemplate.CommandText = strQueryInsertDsgn;
                        cmdInsertCertificateTemplate.CommandType = CommandType.StoredProcedure;
                        cmdInsertCertificateTemplate.Parameters.Add("C_CRTFCTBNDL_ID", OracleDbType.Int32).Value = objEntityCertificateBundel.CertificateBundelTempId;
                        cmdInsertCertificateTemplate.Parameters.Add("C_CRTFCTNAME", OracleDbType.Varchar2).Value = objEntityCertificateBundel.CertificateBundelName;
                        cmdInsertCertificateTemplate.Parameters.Add("C_CRTFCTSTAT", OracleDbType.Int32).Value = objEntityCertificateBundel.Status;
                        cmdInsertCertificateTemplate.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityCertificateBundel.OrgId;
                        cmdInsertCertificateTemplate.Parameters.Add("C_CORP_ID", OracleDbType.Int32).Value = objEntityCertificateBundel.CorpId;
                        cmdInsertCertificateTemplate.Parameters.Add("C_CRTFCT_INS_USR_ID", OracleDbType.Int32).Value = objEntityCertificateBundel.UserId;
                        cmdInsertCertificateTemplate.Parameters.Add("C_CRTFCT_INS_DATE", OracleDbType.Date).Value = objEntityCertificateBundel.Date;
                        cmdInsertCertificateTemplate.ExecuteNonQuery();
                    }


                    string strQueryInsertInterviewCatDtl = "CERTIFICATE_BUNDEL_TEMPLATE.SP_INS_CRTFCTTEMPDTLS";
                    foreach (clsEntity_Certificate_Bundel_Template_details objIntCatDtl in objEntityCertificateBundeldtls)
                    {
                        using (OracleCommand cmdInsertInterviewCatDtl = new OracleCommand())
                        {
                            cmdInsertInterviewCatDtl.Transaction = tran;
                            cmdInsertInterviewCatDtl.Connection = con;
                            cmdInsertInterviewCatDtl.CommandText = strQueryInsertInterviewCatDtl;
                            cmdInsertInterviewCatDtl.CommandType = CommandType.StoredProcedure;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CRFCTBNDL_ID", OracleDbType.Int32).Value = objIntCatDtl.CertificateBundelTemplateDetailsid;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CRTFCTBNDLNAME", OracleDbType.Varchar2).Value = objIntCatDtl.CertificateBundelTemplateDetailsName;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CRTFCTBNDLSTATUS", OracleDbType.Int32).Value = objIntCatDtl.CertificateBundelTemplateDetailsStatus;
                            cmdInsertInterviewCatDtl.ExecuteNonQuery();
                        }
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;

                }
            }
           }


           public void UpdateCertificateTemplate(clsEntity_Certificate_Bundel_Template objEntityCertificateBundel, List<clsEntity_Certificate_Bundel_Template_details> objEntityCertfctINSERTList, List<clsEntity_Certificate_Bundel_Template_details> objEntityCertfctUPDATEList, List<clsEntity_Certificate_Bundel_Template_details> objEntityCertfctDELETEList)
           {
               OracleTransaction tran;
               using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
               {
                   con.Open();
                   tran = con.BeginTransaction();
                   try
                   {
                       string strQueryUpdateDsgn = "CERTIFICATE_BUNDEL_TEMPLATE.SP_UPD_CRTFCTTEM";
                       //int intJobRlID = int.Parse( objEntityDsgn.CorpOfficeId.ToString()+objEntityDsgn.JobRoleId.ToString());
                       using (OracleCommand cmdUpdateCertfctBundel = new OracleCommand())
                       {
                           cmdUpdateCertfctBundel.Transaction = tran;
                           cmdUpdateCertfctBundel.Connection = con;
                           cmdUpdateCertfctBundel.CommandText = strQueryUpdateDsgn;
                           cmdUpdateCertfctBundel.CommandType = CommandType.StoredProcedure;
                           cmdUpdateCertfctBundel.Parameters.Add("C_CRTFCTBNDL_ID", OracleDbType.Int32).Value = objEntityCertificateBundel.CertificateBundelTempId;
                           cmdUpdateCertfctBundel.Parameters.Add("C_CRTFCTBNDLNAME", OracleDbType.Varchar2).Value = objEntityCertificateBundel.CertificateBundelName;
                           cmdUpdateCertfctBundel.Parameters.Add("C_CRTFCTBNDLSTATUS", OracleDbType.Int32).Value = objEntityCertificateBundel.Status;
                           cmdUpdateCertfctBundel.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityCertificateBundel.OrgId;
                           cmdUpdateCertfctBundel.Parameters.Add("C_CORP_ID", OracleDbType.Int32).Value = objEntityCertificateBundel.CorpId;
                           cmdUpdateCertfctBundel.Parameters.Add("C_CRTFCT_UPD_USR_ID", OracleDbType.Int32).Value = objEntityCertificateBundel.UserId;
                           cmdUpdateCertfctBundel.Parameters.Add("C_CRTFCT_UPD_DATE", OracleDbType.Date).Value = objEntityCertificateBundel.Date;
                           cmdUpdateCertfctBundel.ExecuteNonQuery();
                       }
                       //INSERT DTL
                       string strQueryInsertInterviewCatDtl = "CERTIFICATE_BUNDEL_TEMPLATE.SP_INS_CRTFCTBNDL_DTLS";
                       foreach (clsEntity_Certificate_Bundel_Template_details objIntCatDtl in objEntityCertfctINSERTList)
                       {
                           using (OracleCommand cmdInsertInterviewCatDtl = new OracleCommand())
                           {
                               cmdInsertInterviewCatDtl.Transaction = tran;
                               cmdInsertInterviewCatDtl.Connection = con;
                               cmdInsertInterviewCatDtl.CommandText = strQueryInsertInterviewCatDtl;
                               cmdInsertInterviewCatDtl.CommandType = CommandType.StoredProcedure;
                               cmdInsertInterviewCatDtl.Parameters.Add("C_CRTFCTBNDL_ID", OracleDbType.Int32).Value = objEntityCertificateBundel.CertificateBundelTempId;
                               cmdInsertInterviewCatDtl.Parameters.Add("C_CRTFCTBNDLNAME", OracleDbType.Varchar2).Value = objIntCatDtl.CertificateBundelTemplateDetailsName;
                               cmdInsertInterviewCatDtl.Parameters.Add("C_CRTFCTBNDLSTATUS", OracleDbType.Int32).Value = objIntCatDtl.CertificateBundelTemplateDetailsStatus;
                               cmdInsertInterviewCatDtl.ExecuteNonQuery();
                           }
                       }
                       //UPDATE
                       string strQueryUpdateInterviewCatDtl = "CERTIFICATE_BUNDEL_TEMPLATE.SP_UPD_CRTFCTBND_DTLS";
                       foreach (clsEntity_Certificate_Bundel_Template_details objIntCatDtl in objEntityCertfctUPDATEList)
                       {
                           using (OracleCommand cmdUpdateInterviewCatDtl = new OracleCommand())
                           {
                               cmdUpdateInterviewCatDtl.Transaction = tran;
                               cmdUpdateInterviewCatDtl.Connection = con;
                               cmdUpdateInterviewCatDtl.CommandText = strQueryUpdateInterviewCatDtl;
                               cmdUpdateInterviewCatDtl.CommandType = CommandType.StoredProcedure;
                               cmdUpdateInterviewCatDtl.Parameters.Add("C_CRTFCTBNDDTL_ID", OracleDbType.Int32).Value = objIntCatDtl.CertificateBundelTemplateDetailsid;
                               cmdUpdateInterviewCatDtl.Parameters.Add("C_CRTFCTBNDL_ID", OracleDbType.Int32).Value = objEntityCertificateBundel.CertificateBundelTempId;
                               cmdUpdateInterviewCatDtl.Parameters.Add("C_CRTFCTBNDLDTLNAME", OracleDbType.Varchar2).Value = objIntCatDtl.CertificateBundelTemplateDetailsName;
                               cmdUpdateInterviewCatDtl.Parameters.Add("C_CRTFCTBNDLSTATUS", OracleDbType.Int32).Value = objIntCatDtl.CertificateBundelTemplateDetailsStatus;
                               cmdUpdateInterviewCatDtl.ExecuteNonQuery();
                           }
                       }
                       //DELETE
                       string strQueryDeleteInterviewCatDtl = "CERTIFICATE_BUNDEL_TEMPLATE.SP_DEL_CRTFCTBND_DTLS";
                       foreach (clsEntity_Certificate_Bundel_Template_details objIntCatDtl in objEntityCertfctDELETEList)
                       {
                           using (OracleCommand cmdUpdateInterviewCatDtl = new OracleCommand())
                           {
                               cmdUpdateInterviewCatDtl.Transaction = tran;
                               cmdUpdateInterviewCatDtl.Connection = con;
                               cmdUpdateInterviewCatDtl.CommandText = strQueryDeleteInterviewCatDtl;
                               cmdUpdateInterviewCatDtl.CommandType = CommandType.StoredProcedure;
                               cmdUpdateInterviewCatDtl.Parameters.Add("C_CRTFCTBNDDTL_ID", OracleDbType.Int32).Value = objIntCatDtl.CertificateBundelTemplateDetailsid;
                               cmdUpdateInterviewCatDtl.Parameters.Add("C_CRTFCTBNDL_ID", OracleDbType.Int32).Value = objEntityCertificateBundel.CertificateBundelTempId;
                               cmdUpdateInterviewCatDtl.ExecuteNonQuery();
                           }
                       }
                       tran.Commit();
                   }
                   catch (Exception ex)
                   {
                       tran.Rollback();
                       throw ex;

                   }

               }
           }



           public DataTable ReadInterviewCatByID(clsEntity_Certificate_Bundel_Template objEntityCertificateBundel)
           {
               DataTable dtInterviewCatByID = new DataTable();
               using (OracleCommand cmdReadInterviewCatByID = new OracleCommand())
               {
                   cmdReadInterviewCatByID.CommandText = "CERTIFICATE_BUNDEL_TEMPLATE.SP_READ_CRTFCT_BYID";
                   cmdReadInterviewCatByID.CommandType = CommandType.StoredProcedure;
                   cmdReadInterviewCatByID.Parameters.Add("C_CRTFCTBNDL_ID", OracleDbType.Int32).Value = objEntityCertificateBundel.CertificateBundelTempId;
                   cmdReadInterviewCatByID.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityCertificateBundel.OrgId;
                   cmdReadInterviewCatByID.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCertificateBundel.CorpId;
                   cmdReadInterviewCatByID.Parameters.Add("C_DEPT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                   dtInterviewCatByID = clsDataLayer.SelectDataTable(cmdReadInterviewCatByID);
               }
               return dtInterviewCatByID;
           }


           public string CheckDupCertificateTemplate(clsEntity_Certificate_Bundel_Template objEntityCertificateBundel)
           {
               string strQueryCheckDsgnName = "CERTIFICATE_BUNDEL_TEMPLATE.SP_CHECK_CERTIFICATE_BUNDEL";
               OracleCommand cmdCheckInterviewCategoryName = new OracleCommand();
               cmdCheckInterviewCategoryName.CommandText = strQueryCheckDsgnName;
               cmdCheckInterviewCategoryName.CommandType = CommandType.StoredProcedure;
               if (objEntityCertificateBundel.CertificateBundelTempId == 0)
               {
                   cmdCheckInterviewCategoryName.Parameters.Add("I_CRTFCTBNDL_ID", OracleDbType.Int32).Value = null;
               }
               else
               {
                   cmdCheckInterviewCategoryName.Parameters.Add("I_CRTFCTBNDL_ID", OracleDbType.Int32).Value = objEntityCertificateBundel.CertificateBundelTempId;
               }
               cmdCheckInterviewCategoryName.Parameters.Add("I_CRTFCTBNDL_NAME", OracleDbType.Varchar2).Value = objEntityCertificateBundel.CertificateBundelName;
               cmdCheckInterviewCategoryName.Parameters.Add("I_ORG_ID", OracleDbType.Int32).Value = objEntityCertificateBundel.OrgId;
               cmdCheckInterviewCategoryName.Parameters.Add("I_CORPRT_ID", OracleDbType.Int32).Value = objEntityCertificateBundel.CorpId;
               cmdCheckInterviewCategoryName.Parameters.Add("I_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
               clsDataLayer.ExecuteScalar(ref cmdCheckInterviewCategoryName);
               string strReturn = cmdCheckInterviewCategoryName.Parameters["I_COUNT"].Value.ToString();
               cmdCheckInterviewCategoryName.Dispose();
               return strReturn;
           }



           public DataTable ReadCertificateTemplate(clsEntity_Certificate_Bundel_Template objEntityCertificateBundel)
        {
            DataTable dtcertificatebundeltempList = new DataTable();
            using (OracleCommand cmdReadCertificatetempList = new OracleCommand())
            {
                cmdReadCertificatetempList.CommandText = "CERTIFICATE_BUNDEL_TEMPLATE.SP_READ_CRTFCTBNDL_SEARCH_LIST";
                cmdReadCertificatetempList.CommandType = CommandType.StoredProcedure;
                cmdReadCertificatetempList.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCertificateBundel.OrgId;
                cmdReadCertificatetempList.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCertificateBundel.CorpId;
                cmdReadCertificatetempList.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntityCertificateBundel.Status;
                cmdReadCertificatetempList.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntityCertificateBundel.CancelStatus;
                cmdReadCertificatetempList.Parameters.Add("C_DEPT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtcertificatebundeltempList = clsDataLayer.SelectDataTable(cmdReadCertificatetempList);
            }
            return dtcertificatebundeltempList;
        }





           public void CancelCertificateBndl(clsEntity_Certificate_Bundel_Template objEntityCertificateBundel)
           {
               string strQueryCancelCertificateBundel = "CERTIFICATE_BUNDEL_TEMPLATE.SP_CANCEL_CRTFCTBNDL_MSTR";
               using (OracleCommand cmdCancelInterviewCat = new OracleCommand())
               {
                   cmdCancelInterviewCat.CommandText = strQueryCancelCertificateBundel;
                   cmdCancelInterviewCat.CommandType = CommandType.StoredProcedure;
                   cmdCancelInterviewCat.Parameters.Add("C_CRTFCTBNDL_ID", OracleDbType.Int32).Value = objEntityCertificateBundel.CertificateBundelTempId;
                   cmdCancelInterviewCat.Parameters.Add("C_CRTFCTBNDL_CNCL_DATE", OracleDbType.Date).Value = objEntityCertificateBundel.Date;
                   cmdCancelInterviewCat.Parameters.Add("C_CRTFCTBNDL_CNCL_REASN", OracleDbType.Varchar2).Value = objEntityCertificateBundel.CancelReason;
                   cmdCancelInterviewCat.Parameters.Add("C_CRTFCTBNDL_CNCL_USR_ID", OracleDbType.Int32).Value = objEntityCertificateBundel.UserId;
                   cmdCancelInterviewCat.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCertificateBundel.OrgId;
                   cmdCancelInterviewCat.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCertificateBundel.CorpId;
                   cmdCancelInterviewCat.Parameters.Add("C_DEPT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                   clsDataLayer.ExecuteNonQuery(cmdCancelInterviewCat);
               }
           }
           //status change InterviewCat 
           public void StatusChangeCertificateBundel(clsEntity_Certificate_Bundel_Template objEntityCertificateBundel)
           {
               string strQueryCancelInterviewCat = "CERTIFICATE_BUNDEL_TEMPLATE.SP_STATUS_CRTFCTBNDL_MSTR";
               using (OracleCommand cmdCancelInterviewCat = new OracleCommand())
               {
                   cmdCancelInterviewCat.CommandText = strQueryCancelInterviewCat;
                   cmdCancelInterviewCat.CommandType = CommandType.StoredProcedure;
                   cmdCancelInterviewCat.Parameters.Add("C_CRTFCTBNDL_ID", OracleDbType.Int32).Value = objEntityCertificateBundel.CertificateBundelTempId;
                   cmdCancelInterviewCat.Parameters.Add("C_CRTFCTBNDL_UPD_DATE", OracleDbType.Date).Value = objEntityCertificateBundel.Date;
                   cmdCancelInterviewCat.Parameters.Add("C_CRTFCTBNDL_UPD_USR_ID", OracleDbType.Int32).Value = objEntityCertificateBundel.UserId;
                   cmdCancelInterviewCat.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCertificateBundel.OrgId;
                   cmdCancelInterviewCat.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCertificateBundel.CorpId;
                   clsDataLayer.ExecuteNonQuery(cmdCancelInterviewCat);
               }
           }







      }
}

     
