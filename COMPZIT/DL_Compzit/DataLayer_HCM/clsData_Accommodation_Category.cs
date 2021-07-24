using CL_Compzit;
using EL_Compzit;
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
    public class clsData_Accommodation_Category
    {
        public void InsertAccomodationTemplate(clsEntity_Accommodation_Cat objEntityAccomdtncat, List<cls_Entity_Accommodation_Category_list> objAccomdntncatlist)
        {

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {

                    string strQueryInsertDsgn = "HCM_ACCOMMODATION_MSTR.SP_INS_ACCOMDTIN_CATGRY";
                    using (OracleCommand cmdInsertCertificateTemplate = new OracleCommand())
                    {

                        cmdInsertCertificateTemplate.Transaction = tran;
                        cmdInsertCertificateTemplate.Connection = con;
                        cmdInsertCertificateTemplate.CommandText = strQueryInsertDsgn;
                        cmdInsertCertificateTemplate.CommandType = CommandType.StoredProcedure;
                        clsEntityCommon objEntCommon = new clsEntityCommon();
                        clsDataLayer objDatatLayer = new clsDataLayer();
                        objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.HCM_ACCOMMODATION_CATEGORY);
                        objEntCommon.CorporateID = objEntityAccomdtncat.CorpId;
                        string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        objEntityAccomdtncat.AccommodationcatId = Convert.ToInt32(strNextNum);

                        cmdInsertCertificateTemplate.Parameters.Add("C_ACMDTN_ID", OracleDbType.Int32).Value = objEntityAccomdtncat.AccommodationcatId;
                        cmdInsertCertificateTemplate.Parameters.Add("C_ACMDTNNAME", OracleDbType.Varchar2).Value = objEntityAccomdtncat.AccommodationName;
                        cmdInsertCertificateTemplate.Parameters.Add("C_ACMDTNSTATUS", OracleDbType.Int32).Value = objEntityAccomdtncat.Status;
                        cmdInsertCertificateTemplate.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityAccomdtncat.OrgId;
                        cmdInsertCertificateTemplate.Parameters.Add("C_CORP_ID", OracleDbType.Int32).Value = objEntityAccomdtncat.CorpId;
                        cmdInsertCertificateTemplate.Parameters.Add("C_ACMDTN_INS_USR_ID", OracleDbType.Int32).Value = objEntityAccomdtncat.UserId;
                        cmdInsertCertificateTemplate.Parameters.Add("C_ACMDTN_INS_DATE", OracleDbType.Date).Value = objEntityAccomdtncat.Date;
                        cmdInsertCertificateTemplate.ExecuteNonQuery();
                    }


                    string strQueryInsertInterviewCatDtl = "HCM_ACCOMMODATION_MSTR.SP_INS_ACCOMDTIN_SUB";
                    foreach (cls_Entity_Accommodation_Category_list objIntCatDtl in objAccomdntncatlist)
                    {
                        using (OracleCommand cmdInsertInterviewCatDtl = new OracleCommand())
                        {
                            cmdInsertInterviewCatDtl.Transaction = tran;
                            cmdInsertInterviewCatDtl.Connection = con;
                            cmdInsertInterviewCatDtl.CommandText = strQueryInsertInterviewCatDtl;
                            cmdInsertInterviewCatDtl.CommandType = CommandType.StoredProcedure;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_ACMDTNSUB_ID", OracleDbType.Int32).Value = objEntityAccomdtncat.AccommodationcatId;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_ACMDTNSUBNAME", OracleDbType.Varchar2).Value = objIntCatDtl.AccommodationSubCatName;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_ACMDTNSUBSTATUS", OracleDbType.Int32).Value = objIntCatDtl.AccommodationSubCatStatus;
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


        public DataTable ReadAccommodationCatByID(clsEntity_Accommodation_Cat objEntityAccomdtncat)
        {
            DataTable dtInterviewCatByID = new DataTable();
            using (OracleCommand cmdReadInterviewCatByID = new OracleCommand())
            {
                cmdReadInterviewCatByID.CommandText = "HCM_ACCOMMODATION_MSTR.SP_READ_ACMDTNCAT_BYID";
                cmdReadInterviewCatByID.CommandType = CommandType.StoredProcedure;
                cmdReadInterviewCatByID.Parameters.Add("C_ACMDTN_ID", OracleDbType.Int32).Value = objEntityAccomdtncat.AccommodationcatId;
                cmdReadInterviewCatByID.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityAccomdtncat.OrgId;
                cmdReadInterviewCatByID.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityAccomdtncat.CorpId;
                cmdReadInterviewCatByID.Parameters.Add("C_DEPT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dtInterviewCatByID = clsDataLayer.SelectDataTable(cmdReadInterviewCatByID);
            }
            return dtInterviewCatByID;
        }


        public void UpdateAccommodationCat(clsEntity_Accommodation_Cat objEntityAccomdtncat, List<cls_Entity_Accommodation_Category_list> objEntityCertfctINSERTList, List<cls_Entity_Accommodation_Category_list> objEntityCertfctUPDATEList, List<cls_Entity_Accommodation_Category_list> objEntityCertfctDELETEList)
        {
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryUpdateDsgn = "HCM_ACCOMMODATION_MSTR.SP_UPD_ACCOMCAT";
                    //int intJobRlID = int.Parse( objEntityDsgn.CorpOfficeId.ToString()+objEntityDsgn.JobRoleId.ToString());
                    using (OracleCommand cmdUpdateCertfctBundel = new OracleCommand())
                    {
                        cmdUpdateCertfctBundel.Transaction = tran;
                        cmdUpdateCertfctBundel.Connection = con;
                        cmdUpdateCertfctBundel.CommandText = strQueryUpdateDsgn;
                        cmdUpdateCertfctBundel.CommandType = CommandType.StoredProcedure;
                        cmdUpdateCertfctBundel.Parameters.Add("C_ACMDTN_ID", OracleDbType.Int32).Value = objEntityAccomdtncat.AccommodationcatId;
                        cmdUpdateCertfctBundel.Parameters.Add("C_ACMDTNNAME", OracleDbType.Varchar2).Value = objEntityAccomdtncat.AccommodationName;
                        cmdUpdateCertfctBundel.Parameters.Add("C_ACMDTNSTATUS", OracleDbType.Int32).Value = objEntityAccomdtncat.Status;
                        cmdUpdateCertfctBundel.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityAccomdtncat.OrgId;
                        cmdUpdateCertfctBundel.Parameters.Add("C_CORP_ID", OracleDbType.Int32).Value = objEntityAccomdtncat.CorpId;
                        cmdUpdateCertfctBundel.Parameters.Add("C_ACMDTN_UPD_USR_ID", OracleDbType.Int32).Value = objEntityAccomdtncat.UserId;
                        cmdUpdateCertfctBundel.Parameters.Add("C_ACMDTN_UPD_DATE", OracleDbType.Date).Value = objEntityAccomdtncat.Date;
                        cmdUpdateCertfctBundel.ExecuteNonQuery();
                    }
                    //INSERT DTL
                    string strQueryInsertInterviewCatDtl = "HCM_ACCOMMODATION_MSTR.SP_INS_ACCOMDTIN_SUB";
                    foreach (cls_Entity_Accommodation_Category_list objIntCatDtl in objEntityCertfctINSERTList)
                    {
                        using (OracleCommand cmdInsertInterviewCatDtl = new OracleCommand())
                        {
                            cmdInsertInterviewCatDtl.Transaction = tran;
                            cmdInsertInterviewCatDtl.Connection = con;
                            cmdInsertInterviewCatDtl.CommandText = strQueryInsertInterviewCatDtl;
                            cmdInsertInterviewCatDtl.CommandType = CommandType.StoredProcedure;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_ACMDTNSUB_ID", OracleDbType.Int32).Value = objEntityAccomdtncat.AccommodationcatId;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_ACMDTNSUBNAME", OracleDbType.Varchar2).Value = objIntCatDtl.AccommodationSubCatName;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_ACMDTNSUBSTATUS", OracleDbType.Int32).Value = objIntCatDtl.AccommodationSubCatStatus;
                            cmdInsertInterviewCatDtl.ExecuteNonQuery();
                        }
                    }
                    //UPDATE
                    string strQueryUpdateInterviewCatDtl = "HCM_ACCOMMODATION_MSTR.SP_UPD_ACCOMDSUB_DTLS";
                    foreach (cls_Entity_Accommodation_Category_list objIntCatDtl in objEntityCertfctUPDATEList)
                    {
                        using (OracleCommand cmdUpdateInterviewCatDtl = new OracleCommand())
                        {
                            cmdUpdateInterviewCatDtl.Transaction = tran;
                            cmdUpdateInterviewCatDtl.Connection = con;
                            cmdUpdateInterviewCatDtl.CommandText = strQueryUpdateInterviewCatDtl;
                            cmdUpdateInterviewCatDtl.CommandType = CommandType.StoredProcedure;
                            cmdUpdateInterviewCatDtl.Parameters.Add("C_ACMDTNSUB_ID", OracleDbType.Int32).Value = objIntCatDtl.Accommodationsubcategrysid;
                            cmdUpdateInterviewCatDtl.Parameters.Add("C_ACMDTN_ID", OracleDbType.Int32).Value = objEntityAccomdtncat.AccommodationcatId;
                            cmdUpdateInterviewCatDtl.Parameters.Add("C_ACMDTNSUBNAME", OracleDbType.Varchar2).Value = objIntCatDtl.AccommodationSubCatName;
                            cmdUpdateInterviewCatDtl.Parameters.Add("C_ACMDTNSUBSTATUS", OracleDbType.Int32).Value = objIntCatDtl.AccommodationSubCatStatus;
                            cmdUpdateInterviewCatDtl.ExecuteNonQuery();
                        }
                    }
                    //DELETE
                    string strQueryDeleteInterviewCatDtl = "HCM_ACCOMMODATION_MSTR.SP_DEL_ACCOMDTNSUBCAT_DTLS";
                    foreach (cls_Entity_Accommodation_Category_list objIntCatDtl in objEntityCertfctDELETEList)
                    {
                        using (OracleCommand cmdUpdateInterviewCatDtl = new OracleCommand())
                        {
                            cmdUpdateInterviewCatDtl.Transaction = tran;
                            cmdUpdateInterviewCatDtl.Connection = con;
                            cmdUpdateInterviewCatDtl.CommandText = strQueryDeleteInterviewCatDtl;
                            cmdUpdateInterviewCatDtl.CommandType = CommandType.StoredProcedure;
                            cmdUpdateInterviewCatDtl.Parameters.Add("C_ACMDTNSUB_ID", OracleDbType.Int32).Value = objIntCatDtl.Accommodationsubcategrysid;
                            cmdUpdateInterviewCatDtl.Parameters.Add("C_ACMDTN_ID", OracleDbType.Int32).Value = objEntityAccomdtncat.AccommodationcatId;
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
        public string CheckDupCertificateTemplate(clsEntity_Accommodation_Cat objEntityAccomdtncat)
        {
            string strQueryCheckDsgnName = "HCM_ACCOMMODATION_MSTR.SP_CHECK_ACCOMDTNCAT";
            OracleCommand cmdCheckInterviewCategoryName = new OracleCommand();
            cmdCheckInterviewCategoryName.CommandText = strQueryCheckDsgnName;
            cmdCheckInterviewCategoryName.CommandType = CommandType.StoredProcedure;
            if (objEntityAccomdtncat.AccommodationcatId == 0)
            {
                cmdCheckInterviewCategoryName.Parameters.Add("C_ACMDTN_ID", OracleDbType.Int32).Value = null;
            }
            else
            {
                cmdCheckInterviewCategoryName.Parameters.Add("C_ACMDTN_ID", OracleDbType.Int32).Value = objEntityAccomdtncat.AccommodationcatId;
            }
            cmdCheckInterviewCategoryName.Parameters.Add("C_ACMDTNNAME", OracleDbType.Varchar2).Value = objEntityAccomdtncat.AccommodationName;
            cmdCheckInterviewCategoryName.Parameters.Add("I_ORG_ID", OracleDbType.Int32).Value = objEntityAccomdtncat.OrgId;
            cmdCheckInterviewCategoryName.Parameters.Add("I_CORPRT_ID", OracleDbType.Int32).Value = objEntityAccomdtncat.CorpId;
            cmdCheckInterviewCategoryName.Parameters.Add("I_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckInterviewCategoryName);
            string strReturn = cmdCheckInterviewCategoryName.Parameters["I_COUNT"].Value.ToString();
            cmdCheckInterviewCategoryName.Dispose();
            return strReturn;
        }



        public void CancelAccommodtincat(clsEntity_Accommodation_Cat objEntityAccomdtncat)
        {
            string strQueryCancelCertificateBundel = "HCM_ACCOMMODATION_MSTR.SP_CANCEL_ACCOMDTNCAT_MSTR";
            using (OracleCommand cmdCancelInterviewCat = new OracleCommand())
            {
                cmdCancelInterviewCat.CommandText = strQueryCancelCertificateBundel;
                cmdCancelInterviewCat.CommandType = CommandType.StoredProcedure;
                cmdCancelInterviewCat.Parameters.Add("C_ACMDTN_ID", OracleDbType.Int32).Value = objEntityAccomdtncat.AccommodationcatId;
                cmdCancelInterviewCat.Parameters.Add("C_ACMDTN_CNCL_DATE", OracleDbType.Date).Value = objEntityAccomdtncat.Date;
                cmdCancelInterviewCat.Parameters.Add("C_ACMDTN_CNCL_REASN", OracleDbType.Varchar2).Value = objEntityAccomdtncat.CancelReason;
                cmdCancelInterviewCat.Parameters.Add("C_ACMDTN_CNCL_USR_ID", OracleDbType.Int32).Value = objEntityAccomdtncat.UserId;
                cmdCancelInterviewCat.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityAccomdtncat.OrgId;
                cmdCancelInterviewCat.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityAccomdtncat.CorpId;
                cmdCancelInterviewCat.Parameters.Add("C_DEPT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                clsDataLayer.ExecuteNonQuery(cmdCancelInterviewCat);
            }
        }



        public DataTable ReadAccomdtncat(clsEntity_Accommodation_Cat objEntityAccomdtncat)
        {
            DataTable dtcertificatebundeltempList = new DataTable();
            using (OracleCommand cmdReadCertificatetempList = new OracleCommand())
            {
                cmdReadCertificatetempList.CommandText = "HCM_ACCOMMODATION_MSTR.SP_READ_ACCOMDTIN_SEARCH_LIST";
                cmdReadCertificatetempList.CommandType = CommandType.StoredProcedure;
                cmdReadCertificatetempList.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = objEntityAccomdtncat.OrgId;
                cmdReadCertificatetempList.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntityAccomdtncat.CorpId;
                if (objEntityAccomdtncat.AccommodationcatId == 0)
                {
                    cmdReadCertificatetempList.Parameters.Add("I_CAT_ID", OracleDbType.Int32).Value = null;
                }
                else
                {
                    cmdReadCertificatetempList.Parameters.Add("I_CAT_ID", OracleDbType.Int32).Value = objEntityAccomdtncat.AccommodationcatId;
                }
                cmdReadCertificatetempList.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntityAccomdtncat.Status;
                cmdReadCertificatetempList.Parameters.Add("C_CANCEL", OracleDbType.Int32).Value = objEntityAccomdtncat.CancelStatus;
                cmdReadCertificatetempList.Parameters.Add("I_DEPT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                //dtcertificatebundeltempList = clsDataLayer.SelectDataTable(cmdReadCertificatetempList);
              //  DataTable dtCust = new DataTable();
                dtcertificatebundeltempList = clsDataLayer.ExecuteReader(cmdReadCertificatetempList);
                return dtcertificatebundeltempList;
            }
           
        }


        public DataTable Readcatname(clsEntity_Accommodation_Cat objEntityAccomdtncat)
        {
            string strQueryReadProj = "HCM_ACCOMMODATION_MSTR.SP_READ_ACCMDTNCAT_BY_USRID";
            using (OracleCommand cmdReadProj = new OracleCommand())
            {
                cmdReadProj.CommandText = strQueryReadProj;
                cmdReadProj.CommandType = CommandType.StoredProcedure;

                cmdReadProj.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityAccomdtncat.OrgId;

                cmdReadProj.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCust = new DataTable();
                dtCust = clsDataLayer.ExecuteReader(cmdReadProj);
                return dtCust;
            }
        }
        public void StatusChangeAccoomdtn(clsEntity_Accommodation_Cat objEntityAccomdtncat)
        {
            string strQueryCancelInterviewCat = "HCM_ACCOMMODATION_MSTR.SP_STATUS_ACMDTN_MSTR";
            using (OracleCommand cmdCancelInterviewCat = new OracleCommand())
            {
                cmdCancelInterviewCat.CommandText = strQueryCancelInterviewCat;
                cmdCancelInterviewCat.CommandType = CommandType.StoredProcedure;
                cmdCancelInterviewCat.Parameters.Add("C_ACMDTN_ID", OracleDbType.Int32).Value = objEntityAccomdtncat.AccommodationcatId;
                cmdCancelInterviewCat.Parameters.Add("C_ACMDTN_UPD_DATE", OracleDbType.Date).Value = objEntityAccomdtncat.Date;
                cmdCancelInterviewCat.Parameters.Add("C_ACMDTN_UPD_USR_ID", OracleDbType.Int32).Value = objEntityAccomdtncat.UserId;
                cmdCancelInterviewCat.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityAccomdtncat.OrgId;
                cmdCancelInterviewCat.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityAccomdtncat.CorpId;
                clsDataLayer.ExecuteNonQuery(cmdCancelInterviewCat);
            }
        }
     
      
        public string CheckSubCat(cls_Entity_Accommodation_Category_list objEntityAccomdtncat)
        {
            string strQueryCheckDsgnName = "HCM_ACCOMMODATION_MSTR.SP_CHECK_SUB_CATEGORY";
            OracleCommand cmdReadProj = new OracleCommand();

            cmdReadProj.CommandText = strQueryCheckDsgnName;
            cmdReadProj.CommandType = CommandType.StoredProcedure;
            cmdReadProj.Parameters.Add("P_DETAILID", OracleDbType.Int32).Value = objEntityAccomdtncat.Accommodationsubcategrysid;
            cmdReadProj.Parameters.Add("D_DSGN", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadProj);
            string strReturn = cmdReadProj.Parameters["D_DSGN"].Value.ToString();
            cmdReadProj.Dispose();
            return strReturn;

        }
    }
}
