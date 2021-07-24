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
   public class clsDataLayer_Crtfct_Verfctn_Process
    {

       public DataTable ReadCandidateLoad(clsEntity_Crtfct_Verfctn_Process objEntityjob)
        {
            string strQueryReadPayGrd = "CERTIFICATE_VERIFICATION.SP_READ_CANDIDATES";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityjob.OrgId;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpId;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityjob.UsrId;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
       public DataTable ReadCertfctBundl(clsEntity_Crtfct_Verfctn_Process objEntityjob)
        {
            string strQueryReadPayGrd = "CERTIFICATE_VERIFICATION.SP_READ_CERTIFCT_BUNDLE";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityjob.OrgId;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpId;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityjob.UsrId;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
       public DataTable ReadJobRole(clsEntity_Crtfct_Verfctn_Process objEntityjob)
       {
           string strQueryReadPayGrd = "CERTIFICATE_VERIFICATION.SP_READ_JOBROLE";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
           cmdReadJob.Parameters.Add("P_CANDID", OracleDbType.Int32).Value = objEntityjob.CandId;
           cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityjob.OrgId;
           cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpId;
           cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityjob.UsrId;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }
       public DataTable ReadCertfctBundle(clsEntity_Crtfct_Verfctn_Process objEntityjob)
       {
           string strQueryReadPayGrd = "CERTIFICATE_VERIFICATION.SP_READ_CERTFCTBUNDLE";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
           cmdReadJob.Parameters.Add("P_CERTBUNDLE_ID", OracleDbType.Int32).Value = objEntityjob.CertVerctnProcId;
           cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityjob.OrgId;
           cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpId;
           cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityjob.UsrId;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }


       public void InsertVerfcnProcess(clsEntity_Crtfct_Verfctn_Process objEntityTemp, List<clsEntity_Crtverfcn_Dtls> objEntityIntervShedule)
       {
           clsDataLayer objDatatLayer = new clsDataLayer();
           string strQueryReadPayGrd = "CERTIFICATE_VERIFICATION.SP_INSERT_CERTCT_VERIFCATION";
           OracleTransaction tran;
           //insert to main register table
           using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
           {
               con.Open();
               tran = con.BeginTransaction();

               try
               {

                   using (OracleCommand cmdInsertWtrFilng = new OracleCommand(strQueryReadPayGrd, con))
                   {
                       cmdInsertWtrFilng.Transaction = tran;

                       cmdInsertWtrFilng.CommandType = CommandType.StoredProcedure;

                     //  clsEntityCommon objEntCommon = new clsEntityCommon();
                     //  objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.WATER_BILLING);
                   //    objEntCommon.CorporateID = objEntityTemp.CorpOffice_Id;
                    //   string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                     //  objEntityTemp.NextTempId = Convert.ToInt32(strNextNum);

                       cmdInsertWtrFilng.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityTemp.NextProcId;
                       cmdInsertWtrFilng.Parameters.Add("P_CAND_ID", OracleDbType.Varchar2).Value = objEntityTemp.CandId;
                       cmdInsertWtrFilng.Parameters.Add("P_ROLEID ", OracleDbType.Int32).Value = objEntityTemp.DesgRoleId;
                       cmdInsertWtrFilng.Parameters.Add("P_CRTFCT_BUDLID ", OracleDbType.Int32).Value = objEntityTemp.CertVerctnProcId;
                       cmdInsertWtrFilng.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityTemp.OrgId;
                       cmdInsertWtrFilng.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityTemp.CorpId;
                       cmdInsertWtrFilng.Parameters.Add("P_INSUSERID", OracleDbType.Int32).Value = objEntityTemp.UsrId;
                       cmdInsertWtrFilng.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityTemp.D_Date;

                       cmdInsertWtrFilng.ExecuteNonQuery();

                   }
                   //insert to  Detail table
                   foreach (clsEntity_Crtverfcn_Dtls objDetail in objEntityIntervShedule)
                   {

                       string strQueryInsertDetail = "CERTIFICATE_VERIFICATION.SP_INSERT_CERTCT_DTLS";
                       using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                       {
                           cmdAddInsertDetail.Transaction = tran;
                           cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                           //cmdAddInsertDetail.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityTemp.;
                           cmdAddInsertDetail.Parameters.Add("P_NEXTID", OracleDbType.Int32).Value = objEntityTemp.NextProcId;
                           cmdAddInsertDetail.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objDetail.CertProcDtlName;
                           cmdAddInsertDetail.Parameters.Add("P_SUB_CHK", OracleDbType.Int32).Value = objDetail.DtlSubmit;
                           if (objDetail.Detaildate == DateTime.MinValue)
                               cmdAddInsertDetail.Parameters.Add("P_DATE", OracleDbType.Date).Value = null;
                           else
                               cmdAddInsertDetail.Parameters.Add("P_DATE", OracleDbType.Date).Value = objDetail.Detaildate;
                           cmdAddInsertDetail.Parameters.Add("P_VERIFYCHK", OracleDbType.Int32).Value = objDetail.Dtlverify;
                           cmdAddInsertDetail.Parameters.Add("P_DTLSTS", OracleDbType.Int32).Value = objDetail.DtlSts;
                           cmdAddInsertDetail.Parameters.Add("P_ACTFILENAME", OracleDbType.Varchar2).Value = objDetail.ActualFileName;
                           cmdAddInsertDetail.Parameters.Add("P_FILENAME", OracleDbType.Varchar2).Value = objDetail.FileName;
                           cmdAddInsertDetail.Parameters.Add("P_CORP", OracleDbType.Int32).Value = objEntityTemp.CorpId;
                           cmdAddInsertDetail.ExecuteNonQuery();
                       }
                   }

                   tran.Commit();
                  // return objEntityTemp.NextTempId;
               }

               catch (Exception e)
               {
                   tran.Rollback();
                   throw e;

               }

           }
       }

       

                 public DataTable ReadCrtVerfctnPrss(clsEntity_Crtfct_Verfctn_Process objEntityjob)
       {
           string strQueryReadPayGrd = "CERTIFICATE_VERIFICATION.SP_READ_CERTFCTPROSS";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
           cmdReadJob.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityjob.NextProcId;
           cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityjob.OrgId;
           cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpId;
           cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityjob.UsrId;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }



                 public DataTable ReadCrtVerfctnPrssDtls(clsEntity_Crtfct_Verfctn_Process objEntityjob)
       {
           string strQueryReadPayGrd = "CERTIFICATE_VERIFICATION.SP_READ_CERTFCTPROSS_DTLS";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
           cmdReadJob.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityjob.NextProcId;
           cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityjob.OrgId;
           cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpId;
           cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityjob.UsrId;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }

                 public void Update_VerfcnProcess(clsEntity_Crtfct_Verfctn_Process objEntityTemp, List<clsEntity_Crtverfcn_Dtls> objEntityIntervSheduleIns, List<clsEntity_Crtverfcn_Dtls> objEntityIntervSheduleUpd, string[] strarrCancldtlIds)
                 {
                     clsDataLayer objDatatLayer = new clsDataLayer();
                     string strQueryReadPayGrd = "CERTIFICATE_VERIFICATION.SP_UPDATE_CERTCT_VERIFCATION";
                     OracleTransaction tran;
                     //insert to main register table
                     using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
                     {
                         con.Open();
                         tran = con.BeginTransaction();

                         try
                         {

                             using (OracleCommand cmdInsertWtrFilng = new OracleCommand(strQueryReadPayGrd, con))
                             {
                                 cmdInsertWtrFilng.Transaction = tran;

                                 cmdInsertWtrFilng.CommandType = CommandType.StoredProcedure;

                                 clsEntityCommon objEntCommon = new clsEntityCommon();
                                 //objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INTERVIEW_TEMPLATE);
                                // objEntCommon.CorporateID = objEntityTemp.CorpOffice_Id;
                                 // string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                                 // objEntityTemp.NextTempId = Convert.ToInt32(strNextNum);

                                 cmdInsertWtrFilng.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityTemp.NextProcId;
                                 cmdInsertWtrFilng.Parameters.Add("P_CAND_ID", OracleDbType.Varchar2).Value = objEntityTemp.CandId;
                                 cmdInsertWtrFilng.Parameters.Add("P_ROLEID ", OracleDbType.Int32).Value = objEntityTemp.DesgRoleId;
                                 cmdInsertWtrFilng.Parameters.Add("P_CRTFCT_BUDLID ", OracleDbType.Int32).Value = objEntityTemp.CertVerctnProcId;
                                 cmdInsertWtrFilng.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityTemp.OrgId;
                                 cmdInsertWtrFilng.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityTemp.CorpId;
                                 cmdInsertWtrFilng.Parameters.Add("P_INSUSERID", OracleDbType.Int32).Value = objEntityTemp.UsrId;
                                 cmdInsertWtrFilng.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityTemp.D_Date;

                                 cmdInsertWtrFilng.ExecuteNonQuery();

                             }
                             //insert to  Detail table
                             foreach (clsEntity_Crtverfcn_Dtls objDetail in objEntityIntervSheduleIns)
                             {

                                 string strQueryInsertDetail = "CERTIFICATE_VERIFICATION.SP_INSERT_CERTCT_DTLS";
                                 using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                                 {
                                     cmdAddInsertDetail.Transaction = tran;
                                     cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                     cmdAddInsertDetail.Parameters.Add("P_NEXTID", OracleDbType.Int32).Value = objEntityTemp.NextProcId;
                                     cmdAddInsertDetail.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objDetail.CertProcDtlName;
                                     cmdAddInsertDetail.Parameters.Add("P_SUB_CHK", OracleDbType.Int32).Value = objDetail.DtlSubmit;
                                     if (objDetail.Detaildate == DateTime.MinValue)
                                         cmdAddInsertDetail.Parameters.Add("P_DATE", OracleDbType.Date).Value = null;
                                     else
                                         cmdAddInsertDetail.Parameters.Add("P_DATE", OracleDbType.Date).Value = objDetail.Detaildate;
                                     cmdAddInsertDetail.Parameters.Add("P_VERIFYCHK", OracleDbType.Int32).Value = objDetail.Dtlverify;
                                     cmdAddInsertDetail.Parameters.Add("P_DTLSTS", OracleDbType.Int32).Value = objDetail.DtlSts;
                                     cmdAddInsertDetail.Parameters.Add("P_ACTFILENAME", OracleDbType.Varchar2).Value = objDetail.ActualFileName;
                                     cmdAddInsertDetail.Parameters.Add("P_FILENAME", OracleDbType.Varchar2).Value = objDetail.FileName;
                                     cmdAddInsertDetail.Parameters.Add("P_CORP", OracleDbType.Int32).Value = objEntityTemp.CorpId;
                                     cmdAddInsertDetail.ExecuteNonQuery();
                                 }
                             }

                             //update to  Detail table
                             foreach (clsEntity_Crtverfcn_Dtls objDetail in objEntityIntervSheduleUpd)
                             {

                                 string strQueryInsertDetail = "CERTIFICATE_VERIFICATION.SP_UPDATE_CERTVERIFCATION_DTLS";
                                 using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                                 {
                                     cmdAddInsertDetail.Transaction = tran;
                                     cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                     cmdAddInsertDetail.Parameters.Add("P_NEXTID", OracleDbType.Int32).Value = objEntityTemp.NextProcId;
                                     cmdAddInsertDetail.Parameters.Add("P_DETL_ID", OracleDbType.Int32).Value = objDetail.CertVerctnProcId;
                                     cmdAddInsertDetail.Parameters.Add("P_DELCHK", OracleDbType.Int32).Value = objDetail.DelOrNot;
                                     cmdAddInsertDetail.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objDetail.CertProcDtlName;
                                     cmdAddInsertDetail.Parameters.Add("P_SUB_CHK", OracleDbType.Int32).Value = objDetail.DtlSubmit;
                                     if (objDetail.Detaildate == DateTime.MinValue)
                                         cmdAddInsertDetail.Parameters.Add("P_DATE", OracleDbType.Date).Value = null;
                                     else
                                         cmdAddInsertDetail.Parameters.Add("P_DATE", OracleDbType.Date).Value = objDetail.Detaildate;
                                     cmdAddInsertDetail.Parameters.Add("P_VERIFYCHK", OracleDbType.Int32).Value = objDetail.Dtlverify;
                                     cmdAddInsertDetail.Parameters.Add("P_DTLSTS", OracleDbType.Int32).Value = objDetail.DtlSts;
                                     cmdAddInsertDetail.Parameters.Add("P_ACTFILENAME", OracleDbType.Varchar2).Value = objDetail.ActualFileName;
                                     cmdAddInsertDetail.Parameters.Add("P_FILENAME", OracleDbType.Varchar2).Value = objDetail.FileName;
                                     cmdAddInsertDetail.Parameters.Add("P_CORP", OracleDbType.Int32).Value = objEntityTemp.CorpId;
                                     cmdAddInsertDetail.ExecuteNonQuery();
                                 }
                             }

                             //Cancel the rows that have been cancelled when editing in Detail table
                             foreach (string strDtlId in strarrCancldtlIds)
                             {
                                 if (strDtlId != "" && strDtlId != null)
                                 {
                                     int intDtlId = Convert.ToInt32(strDtlId);

                                     string strQueryCancelDetail = "CERTIFICATE_VERIFICATION.SP_CANCEL_CERTVERIFCATION_DTL";
                                     using (OracleCommand cmdCancelDetail = new OracleCommand(strQueryCancelDetail, con))
                                     {
                                         cmdCancelDetail.Transaction = tran;

                                         cmdCancelDetail.CommandType = CommandType.StoredProcedure;
                                         cmdCancelDetail.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityTemp.NextProcId;
                                         cmdCancelDetail.Parameters.Add("P_DETAIL_ID", OracleDbType.Int32).Value = intDtlId;

                                         cmdCancelDetail.ExecuteNonQuery();
                                     }
                                 }
                             }

                             tran.Commit();
                             //  return objEntityTemp.NextTempId;
                         }

                         catch (Exception e)
                         {
                             tran.Rollback();
                             throw e;

                         }

                     }
                 }
                 public void Cancel_Cerfct_Valdatn(clsEntity_Crtfct_Verfctn_Process objEntityTemp)
                 {
                     string strQueryReadPayGrd = "CERTIFICATE_VERIFICATION.SP_CANCELCERTCT_VERIFCATION";
                     using (OracleCommand cmdReadPayGrd = new OracleCommand())
                     {
                         cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                         cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                         cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityTemp.NextProcId;
                         cmdReadPayGrd.Parameters.Add("P_RESN", OracleDbType.Varchar2).Value = objEntityTemp.Cancel_Reason;
                         cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityTemp.D_Date;
                         cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityTemp.UsrId;
                         cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityTemp.OrgId;
                         cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityTemp.CorpId;

                         clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
                     }

                 }

                 public DataTable Read_Cerfct_ValdatnList(clsEntity_Crtfct_Verfctn_Process objEntityTemp)
                 {
                     string strQueryReadPayGrd = "CERTIFICATE_VERIFICATION.SP_READ_CERTCT_VERIFCATIONLIST";
                     OracleCommand cmdReadJob = new OracleCommand();
                     cmdReadJob.CommandText = strQueryReadPayGrd;
                     cmdReadJob.CommandType = CommandType.StoredProcedure;
                     cmdReadJob.Parameters.Add("P_CANCELSTS", OracleDbType.Int32).Value = objEntityTemp.Cancel_Status;
                     cmdReadJob.Parameters.Add("C_OPTION", OracleDbType.Int32).Value = objEntityTemp.Crfct_sts;
                     cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityTemp.OrgId;
                     cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityTemp.CorpId;
                     cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityTemp.UsrId;
                     cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                     DataTable dtCategory = new DataTable();
                     dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
                     return dtCategory;
                 }

                 public void ChangeReqToConplete(clsEntity_Crtfct_Verfctn_Process objEntityTemp)
                 {
                     string strQueryReadPayGrd = "CERTIFICATE_VERIFICATION.SP_STATUS_COMPLETE";
                     OracleCommand cmdReadJob = new OracleCommand();
                     cmdReadJob.CommandText = strQueryReadPayGrd;
                     cmdReadJob.CommandType = CommandType.StoredProcedure;
                     cmdReadJob.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityTemp.NextProcId;
                     cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityTemp.OrgId;
                     cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityTemp.CorpId;
                     cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityTemp.UsrId;

                     clsDataLayer.ExecuteNonQuery(cmdReadJob);
                 }

       


    }
}
