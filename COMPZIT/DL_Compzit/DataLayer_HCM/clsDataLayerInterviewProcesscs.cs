using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL_Compzit;
using DL_Compzit;
using EL_Compzit;
namespace DL_Compzit.DataLayer_HCM
{
   public class clsDataLayerInterviewProcesscs
    {
       public DataTable ReadDivision(clsEntityLayerInterviewProcess objEntityIntervewProcess)
        {
            string strQueryReadPayGrd = "INTERVIEW_PROCESS.SP_READ_DIVISION";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityIntervewProcess.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityIntervewProcess.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityIntervewProcess.User_Id;
            cmdReadJob.Parameters.Add("P_DEPTID", OracleDbType.Int32).Value = objEntityIntervewProcess.Deprt_Id;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
       public DataTable ReadDepartment(clsEntityLayerInterviewProcess objEntityIntervewProcess)
        {
            string strQueryReadPayGrd = "INTERVIEW_PROCESS.SP_READ_DEPRTMNT";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityIntervewProcess.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityIntervewProcess.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityIntervewProcess.User_Id;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
       public DataTable ReadDesignation(clsEntityLayerInterviewProcess objEntityIntervewProcess)
        {
            string strQueryReadPayGrd = "INTERVIEW_PROCESS.SP_READ_DESGNTN";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityIntervewProcess.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityIntervewProcess.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityIntervewProcess.User_Id;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }

       public DataTable ReadProject(clsEntityLayerInterviewProcess objEntityIntervewProcess)
        {
            string strQueryReadPrjct = "INTERVIEW_PROCESS.SP_READ_PROJECT";
            OracleCommand cmdReadPrjct = new OracleCommand();
            cmdReadPrjct.CommandText = strQueryReadPrjct;
            cmdReadPrjct.CommandType = CommandType.StoredProcedure;
            cmdReadPrjct.Parameters.Add("J_DIVID", OracleDbType.Int32).Value = objEntityIntervewProcess.DivId;
            cmdReadPrjct.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityIntervewProcess.Organisation_Id;
            cmdReadPrjct.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityIntervewProcess.CorpOffice_Id;
            cmdReadPrjct.Parameters.Add("J_USERID", OracleDbType.Int32).Value = objEntityIntervewProcess.User_Id;
            cmdReadPrjct.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPrjct);
            return dtCategory;
        }

       public DataTable ReadAprvdManPwrReqstList(clsEntityLayerInterviewProcess objEntityIntervewProcess)
        {
            string strQueryReadPayGrd = "INTERVIEW_PROCESS.SP_READ_MAN_PWRRQST_LIST";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;

            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityIntervewProcess.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityIntervewProcess.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityIntervewProcess.User_Id;
            cmdReadJob.Parameters.Add("P_DIVID", OracleDbType.Int32).Value = objEntityIntervewProcess.DivId;
            cmdReadJob.Parameters.Add("P_DEPID", OracleDbType.Int32).Value = objEntityIntervewProcess.Deprt_Id;
            cmdReadJob.Parameters.Add("P_PRJCTID", OracleDbType.Int32).Value = objEntityIntervewProcess.PrjctId;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }

       public DataTable ReadShrtlistedCandidateList(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           string strQueryReadPayGrd = "INTERVIEW_PROCESS.SP_READ_SRTLST_CANDIDATE_LIST";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;

           cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityIntervewProcess.Organisation_Id;
           cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityIntervewProcess.CorpOffice_Id;
           cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityIntervewProcess.User_Id;
           cmdReadJob.Parameters.Add("P_REQRMNTID", OracleDbType.Int32).Value = objEntityIntervewProcess.ReqrmntId;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }

       public DataTable ReadRqmntDetails(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           string strQueryReadPayGrd = "INTERVIEW_PROCESS.SP_READ_RQMNT_DTLS";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;

           cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityIntervewProcess.Organisation_Id;
           cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityIntervewProcess.CorpOffice_Id;
           cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityIntervewProcess.User_Id;
           cmdReadJob.Parameters.Add("P_REQRMNTID", OracleDbType.Int32).Value = objEntityIntervewProcess.ReqrmntId;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }

       public DataTable ReadEmpInfoById(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           string strQueryReadPayGrd = "INTERVIEW_PROCESS.SP_READ_EMP_DTLS";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityIntervewProcess.User_Id;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }

       public DataTable readSchdlList(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           string strQueryReadPayGrd = "INTERVIEW_PROCESS.SP_READ_SCHDL_DTLS";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityIntervewProcess.User_Id;
           cmdReadJob.Parameters.Add("P_REQMNT_ID", OracleDbType.Int32).Value = objEntityIntervewProcess.ReqrmntId;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }
       public DataTable readPanelDtls(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           string strQueryReadPayGrd = "INTERVIEW_PROCESS.SP_READ_PANEL_DTLS";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityIntervewProcess.SchdlLvlId;
           cmdReadJob.Parameters.Add("P_REQMNT_ID", OracleDbType.Int32).Value = objEntityIntervewProcess.ReqrmntId;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }
       public DataTable ReadScoreList()
       {
           string strQueryReadPayGrd = "INTERVIEW_PROCESS.SP_READ_SCORE_LIST";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }

       public DataTable ReadAsmntInfo(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           string strQueryReadPayGrd = "INTERVIEW_PROCESS.SP_READ_ASMNT_DTLS";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_SCHDL_ID", OracleDbType.Int32).Value = objEntityIntervewProcess.SchdlLvlId;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }

       public DataTable ReadAsmntNotChcked( clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           string strQueryReadPayGrd = "INTERVIEW_PROCESS.SP_READ_ASMNT_NOT_CHCK";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_SCHDL_ID", OracleDbType.Int32).Value = objEntityIntervewProcess.SchdlLvlId;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }

       public void insertEvaltnDtls(clsEntityLayerInterviewProcess objEntityIntervewProcess, List<clsEntityLayerScheduleLevelDtls> objEntityJobSubmsnDtlList, List<clsEntityLayerAssessmentDtls> objEntityAddtnlJobsList)
       {
           clsDataLayer objDatatLayer = new clsDataLayer();
           string strQueryInsertJobShdl = "INTERVIEW_PROCESS.SP_INSERT_INTERVW_PROCESS_MSTR";
           OracleTransaction tran;
           //insert to main INTERVIEW PROCESS MASTER table
           using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
           {
               con.Open();
               tran = con.BeginTransaction();

               try
               {

                   using (OracleCommand cmdInsertJobSchdlng = new OracleCommand(strQueryInsertJobShdl, con))
                   {
                       cmdInsertJobSchdlng.Transaction = tran;
                       cmdInsertJobSchdlng.CommandType = CommandType.StoredProcedure;

                       clsEntityCommon objEntCommon = new clsEntityCommon();
                       objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INTERVIEW_PROCESS_MASTER);
                       objEntCommon.CorporateID = objEntityIntervewProcess.CorpOffice_Id;
                       string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);

                       objEntityIntervewProcess.IntervewProcessId = Convert.ToInt32(strNextNum);

                       cmdInsertJobSchdlng.Parameters.Add("I_ID", OracleDbType.Int32).Value = objEntityIntervewProcess.IntervewProcessId;
                       cmdInsertJobSchdlng.Parameters.Add("I_RQRMNTID", OracleDbType.Int32).Value = objEntityIntervewProcess.ReqrmntId;
                       cmdInsertJobSchdlng.Parameters.Add("I_CANDID", OracleDbType.Int32).Value = objEntityIntervewProcess.CandId;
                       cmdInsertJobSchdlng.Parameters.Add("I_ORGID", OracleDbType.Int32).Value = objEntityIntervewProcess.Organisation_Id;
                       cmdInsertJobSchdlng.Parameters.Add("I_CORPID", OracleDbType.Int32).Value = objEntityIntervewProcess.CorpOffice_Id;
                       cmdInsertJobSchdlng.Parameters.Add("I_INSUSERID", OracleDbType.Int32).Value = objEntityIntervewProcess.User_Id;
                       cmdInsertJobSchdlng.Parameters.Add("I_INSDATE", OracleDbType.Date).Value = objEntityIntervewProcess.date;
                       cmdInsertJobSchdlng.ExecuteNonQuery();


                       //delete from assignment table

                       string strQueryInsertDetailSD = "INTERVIEW_PROCESS.SP_DELE_ASMNT_DTLS";
                       using (OracleCommand cmdAddInsertDetailSD = new OracleCommand(strQueryInsertDetailSD, con))
                       {

                           cmdAddInsertDetailSD.Transaction = tran;
                           cmdAddInsertDetailSD.CommandType = CommandType.StoredProcedure;
                           cmdAddInsertDetailSD.Parameters.Add("I_PROCESSID", OracleDbType.Int32).Value = objEntityIntervewProcess.IntervewProcessId;
                           cmdAddInsertDetailSD.ExecuteNonQuery();

                       }

                   }
                   //insert to  SCHEDULE LEVEL Detail table
                   foreach (clsEntityLayerScheduleLevelDtls objDetail in objEntityJobSubmsnDtlList)
                   {
                       string strQueryInsertDetail = "INTERVIEW_PROCESS.SP_INSERT_SCHDL_DTL";
                       using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                       {
                           cmdAddInsertDetail.Transaction = tran;
                           cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;


                           clsEntityCommon objEntCommon = new clsEntityCommon();
                           objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INTERVIEW_SCHEDULE_LEVEL);
                           objEntCommon.CorporateID = objEntityIntervewProcess.CorpOffice_Id;
                           string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                           objEntityIntervewProcess.SchdlLvlId = Convert.ToInt32(strNextNum);

                           cmdAddInsertDetail.Parameters.Add("I_ID", OracleDbType.Int32).Value = objEntityIntervewProcess.SchdlLvlId;
                           cmdAddInsertDetail.Parameters.Add("I_PROCESSID", OracleDbType.Int32).Value = objEntityIntervewProcess.IntervewProcessId;
                           if (objDetail.ScoreId == 0)
                           {
                               cmdAddInsertDetail.Parameters.Add("I_SCOREID", OracleDbType.Int32).Value = null;
                           }
                           else
                           {
                               cmdAddInsertDetail.Parameters.Add("I_SCOREID", OracleDbType.Int32).Value = objDetail.ScoreId;
                           }
                           if (objDetail.DescnId == 0)
                           {
                               cmdAddInsertDetail.Parameters.Add("I_DESCNID", OracleDbType.Int32).Value = null;
                           }
                           else
                           {
                               cmdAddInsertDetail.Parameters.Add("I_DESCNID", OracleDbType.Int32).Value = objDetail.DescnId;
                           }

                           if (objDetail.IntervewDate != DateTime.MinValue)
                           {
                               cmdAddInsertDetail.Parameters.Add("I_INTERDATE", OracleDbType.Date).Value = objDetail.IntervewDate;
                           }
                           else
                           {
                               cmdAddInsertDetail.Parameters.Add("I_INTERDATE", OracleDbType.Date).Value = null;
                           }
                           cmdAddInsertDetail.Parameters.Add("I_INTERVIER", OracleDbType.Int32).Value = objDetail.IntervewrId;
                           cmdAddInsertDetail.Parameters.Add("I_TEMPLDTL_ID", OracleDbType.Int32).Value = objDetail.SchdlLvlId;
                           cmdAddInsertDetail.ExecuteNonQuery();

                          


                           //insert to  ASSESSMENT DETAILS table
                           foreach (clsEntityLayerAssessmentDtls objDetailS in objEntityAddtnlJobsList)
                           {
                               string strQueryInsertDetailS = "INTERVIEW_PROCESS.SP_INSERT_ASMNT_DTLS";
                               using (OracleCommand cmdAddInsertDetailS = new OracleCommand(strQueryInsertDetailS, con))
                               {
                                   if (objDetail.SchdlLvlId == objDetailS.SchdlLvlAsmntId)
                                   {
                                       cmdAddInsertDetailS.Transaction = tran;
                                       cmdAddInsertDetailS.CommandType = CommandType.StoredProcedure;
                                       cmdAddInsertDetailS.Parameters.Add("I_PROCESSID", OracleDbType.Int32).Value = objEntityIntervewProcess.IntervewProcessId;
                                       cmdAddInsertDetailS.Parameters.Add("I_SCDLVLID", OracleDbType.Int32).Value = objEntityIntervewProcess.SchdlLvlId;
                                       cmdAddInsertDetailS.Parameters.Add("I_CTGRYDTL_ID", OracleDbType.Int32).Value = objDetailS.AsmntId;
                                       cmdAddInsertDetailS.Parameters.Add("I_SCORE", OracleDbType.Int32).Value = objDetailS.Score;
                                       cmdAddInsertDetailS.ExecuteNonQuery();
                                   }
                               }
                           }




                       }
                   }


                  

                   tran.Commit();

               }

               catch (Exception e)
               {
                   tran.Rollback();
                   throw e;

               }
           }
       }

       public DataTable readSchdlLVlEditInfoDtls(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           string strQueryReadPayGrd = "INTERVIEW_PROCESS.SP_READ_SCHDLEDIT_DTLS";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityIntervewProcess.User_Id;
           cmdReadJob.Parameters.Add("P_REQMNT_ID", OracleDbType.Int32).Value = objEntityIntervewProcess.ReqrmntId;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }
       public DataTable ReadAsmntEditDtls(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           string strQueryReadPayGrd = "INTERVIEW_PROCESS.SP_READ_ASMNTEDIT_DTLS";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityIntervewProcess.SchdlLvlId;
           cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityIntervewProcess.User_Id;
           cmdReadJob.Parameters.Add("P_REQMNT_ID", OracleDbType.Int32).Value = objEntityIntervewProcess.ReqrmntId;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }
       public DataTable CheckIntervProcessADDorUPD(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {

           string strQueryCheck = "INTERVIEW_PROCESS.SP_CHCK_INTERPRS_INS_OR_UPD";
           OracleCommand cmdCheck = new OracleCommand();
           cmdCheck.CommandText = strQueryCheck;
           cmdCheck.CommandType = CommandType.StoredProcedure;
           cmdCheck.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityIntervewProcess.CandId;
           cmdCheck.Parameters.Add("P_REQMNT_ID", OracleDbType.Int32).Value = objEntityIntervewProcess.ReqrmntId;
           cmdCheck.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdCheck);
           return dtCategory;
       }


       public void updateEvaltnDtls(clsEntityLayerInterviewProcess objEntityIntervewProcess, List<clsEntityLayerScheduleLevelDtls> objEntityJobSubmsnDtlListAdd, List<clsEntityLayerScheduleLevelDtls> objEntityJobSubmsnDtlListUpdate, List<clsEntityLayerAssessmentDtls> objEntityAddtnlJobsListAdd, List<clsEntityLayerAssessmentDtls> objEntityAddtnlJobsListUpdate)
       {
           clsDataLayer objDatatLayer = new clsDataLayer();
           string strQueryInsertJobShdl = "INTERVIEW_PROCESS.SP_UPDATE_INTERVW_PROCESS_MSTR";
           OracleTransaction tran;
           //insert to main INTERVIEW PROCESS MASTER table
           using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
           {
               con.Open();
               tran = con.BeginTransaction();

               try
               {

                   using (OracleCommand cmdInsertJobSchdlng = new OracleCommand(strQueryInsertJobShdl, con))
                   {
                       cmdInsertJobSchdlng.Transaction = tran;
                       cmdInsertJobSchdlng.CommandType = CommandType.StoredProcedure;

                       cmdInsertJobSchdlng.Parameters.Add("I_ID", OracleDbType.Int32).Value = objEntityIntervewProcess.IntervewProcessId;
                       cmdInsertJobSchdlng.Parameters.Add("I_UPDUSERID", OracleDbType.Int32).Value = objEntityIntervewProcess.User_Id;
                       cmdInsertJobSchdlng.Parameters.Add("I_UPDDATE", OracleDbType.Date).Value = objEntityIntervewProcess.date;
                       cmdInsertJobSchdlng.ExecuteNonQuery();


                   }
                   //insert to  SCHEDULE LEVEL Detail table
                   foreach (clsEntityLayerScheduleLevelDtls objDetail in objEntityJobSubmsnDtlListAdd)
                   {
                       string strQueryInsertDetail = "INTERVIEW_PROCESS.SP_INSERT_SCHDL_DTL";
                       using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                       {
                           cmdAddInsertDetail.Transaction = tran;
                           cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;


                           clsEntityCommon objEntCommon = new clsEntityCommon();
                           objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INTERVIEW_SCHEDULE_LEVEL);
                           objEntCommon.CorporateID = objEntityIntervewProcess.CorpOffice_Id;
                           string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                           objEntityIntervewProcess.SchdlLvlId = Convert.ToInt32(strNextNum);


                           cmdAddInsertDetail.Parameters.Add("I_ID", OracleDbType.Int32).Value = objEntityIntervewProcess.SchdlLvlId;
                           cmdAddInsertDetail.Parameters.Add("I_PROCESSID", OracleDbType.Int32).Value = objEntityIntervewProcess.IntervewProcessId;
                           if (objDetail.ScoreId == 0)
                           {
                               cmdAddInsertDetail.Parameters.Add("I_SCOREID", OracleDbType.Int32).Value = null;
                           }
                           else
                           {
                               cmdAddInsertDetail.Parameters.Add("I_SCOREID", OracleDbType.Int32).Value = objDetail.ScoreId;
                           }
                           if (objDetail.DescnId == 0)
                           {
                               cmdAddInsertDetail.Parameters.Add("I_DESCNID", OracleDbType.Int32).Value = null;
                           }
                           else
                           {
                               cmdAddInsertDetail.Parameters.Add("I_DESCNID", OracleDbType.Int32).Value = objDetail.DescnId;
                           }
                           if (objDetail.IntervewDate != DateTime.MinValue)
                           {
                               cmdAddInsertDetail.Parameters.Add("I_INTERDATE", OracleDbType.Date).Value = objDetail.IntervewDate;
                           }
                           else
                           {
                               cmdAddInsertDetail.Parameters.Add("I_INTERDATE", OracleDbType.Date).Value = null;
                           }
                           cmdAddInsertDetail.Parameters.Add("I_INTERVIER", OracleDbType.Int32).Value = objDetail.IntervewrId;
                           cmdAddInsertDetail.Parameters.Add("I_TEMPLDTL_ID", OracleDbType.Int32).Value = objDetail.SchdlLvlId;
                           cmdAddInsertDetail.ExecuteNonQuery();


                          

                           //insert to  ASSESSMENT DETAILS table
                           foreach (clsEntityLayerAssessmentDtls objDetailS in objEntityAddtnlJobsListAdd)
                           {
                               string strQueryInsertDetailS = "INTERVIEW_PROCESS.SP_INSERT_ASMNT_DTLS";
                               using (OracleCommand cmdAddInsertDetailS = new OracleCommand(strQueryInsertDetailS, con))
                               {
                                   if (objDetail.SchdlLvlId == objDetailS.SchdlLvlAsmntId)
                                   {
                                      
                                       cmdAddInsertDetailS.Transaction = tran;
                                       cmdAddInsertDetailS.CommandType = CommandType.StoredProcedure;
                                       cmdAddInsertDetailS.Parameters.Add("I_PROCESSID", OracleDbType.Int32).Value = objEntityIntervewProcess.IntervewProcessId;
                                       cmdAddInsertDetailS.Parameters.Add("I_SCDLVLID", OracleDbType.Int32).Value = objEntityIntervewProcess.SchdlLvlId;
                                       cmdAddInsertDetailS.Parameters.Add("I_CTGRYDTL_ID", OracleDbType.Int32).Value = objDetailS.AsmntId;
                                       cmdAddInsertDetailS.Parameters.Add("I_SCORE", OracleDbType.Int32).Value = objDetailS.Score;
                                       cmdAddInsertDetailS.ExecuteNonQuery();
                                   }
                               }
                             
                           }




                       }
                   }


                   //UPDATE to  SCHEDULE LEVEL Detail table
                   foreach (clsEntityLayerScheduleLevelDtls objDetail in objEntityJobSubmsnDtlListUpdate)
                   {
                       string strQueryInsertDetail = "INTERVIEW_PROCESS.SP_UPDATE_SCHDL_DTL";
                       using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                       {
                           cmdAddInsertDetail.Transaction = tran;
                           cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                           cmdAddInsertDetail.Parameters.Add("I_ID", OracleDbType.Int32).Value = objDetail.SchdlTableId;
                           cmdAddInsertDetail.Parameters.Add("I_PROCESSID", OracleDbType.Int32).Value = objEntityIntervewProcess.IntervewProcessId;
                           if (objDetail.ScoreId == 0)
                           {
                               cmdAddInsertDetail.Parameters.Add("I_SCOREID", OracleDbType.Int32).Value = null;
                           }
                           else
                           {
                               cmdAddInsertDetail.Parameters.Add("I_SCOREID", OracleDbType.Int32).Value = objDetail.ScoreId;
                           }
                           if (objDetail.DescnId == 0)
                           {
                               cmdAddInsertDetail.Parameters.Add("I_DESCNID", OracleDbType.Int32).Value = null;
                           }
                           else
                           {
                               cmdAddInsertDetail.Parameters.Add("I_DESCNID", OracleDbType.Int32).Value = objDetail.DescnId;
                           }
                           if (objDetail.IntervewDate != DateTime.MinValue)
                           {
                               cmdAddInsertDetail.Parameters.Add("I_INTERDATE", OracleDbType.Date).Value = objDetail.IntervewDate;
                           }
                           else
                           {
                               cmdAddInsertDetail.Parameters.Add("I_INTERDATE", OracleDbType.Date).Value = null;
                           }
                           cmdAddInsertDetail.Parameters.Add("I_INTERVIER", OracleDbType.Int32).Value = objDetail.IntervewrId;
                           cmdAddInsertDetail.Parameters.Add("I_TEMPLDTL_ID", OracleDbType.Int32).Value = objDetail.SchdlLvlId;
                           cmdAddInsertDetail.ExecuteNonQuery();



                           int i = 0;

                           foreach (clsEntityLayerAssessmentDtls objDetailS in objEntityAddtnlJobsListAdd)
                           {
                               string strQueryInsertDetailS = "INTERVIEW_PROCESS.SP_INSERT_ASMNT_DTLS";
                               using (OracleCommand cmdAddInsertDetailS = new OracleCommand(strQueryInsertDetailS, con))
                               {
                                   if (objDetail.SchdlLvlId == objDetailS.SchdlLvlAsmntId)
                                   {
                                       if (i == 0)
                                       {
                                           //delete from assignment table

                                           string strQueryInsertDetailSD = "INTERVIEW_PROCESS.SP_DEL_ASMNT_DTLS";
                                           using (OracleCommand cmdAddInsertDetailSD = new OracleCommand(strQueryInsertDetailSD, con))
                                           {

                                               cmdAddInsertDetailSD.Transaction = tran;
                                               cmdAddInsertDetailSD.CommandType = CommandType.StoredProcedure;
                                               cmdAddInsertDetailSD.Parameters.Add("I_PROCESSID", OracleDbType.Int32).Value = objEntityIntervewProcess.IntervewProcessId;
                                               cmdAddInsertDetailSD.Parameters.Add("I_SCDLVLID", OracleDbType.Int32).Value = objDetail.SchdlTableId;
                                               cmdAddInsertDetailSD.ExecuteNonQuery();

                                           }
                                       }
                                       cmdAddInsertDetailS.Transaction = tran;
                                       cmdAddInsertDetailS.CommandType = CommandType.StoredProcedure;
                                       cmdAddInsertDetailS.Parameters.Add("I_PROCESSID", OracleDbType.Int32).Value = objEntityIntervewProcess.IntervewProcessId;
                                       cmdAddInsertDetailS.Parameters.Add("I_SCDLVLID", OracleDbType.Int32).Value = objDetail.SchdlTableId;
                                       cmdAddInsertDetailS.Parameters.Add("I_CTGRYDTL_ID", OracleDbType.Int32).Value = objDetailS.AsmntId;
                                       cmdAddInsertDetailS.Parameters.Add("I_SCORE", OracleDbType.Int32).Value = objDetailS.Score;
                                       cmdAddInsertDetailS.ExecuteNonQuery();
                                   }
                               }
                               i++;
                           }



                       }
                   }


                   //UPDATE to  ASSESSMENT DETAILS table
                   foreach (clsEntityLayerAssessmentDtls objDetailS in objEntityAddtnlJobsListUpdate)
                   {
                       string strQueryInsertDetailS = "INTERVIEW_PROCESS.SP_UPDATE_ASMNT_DTLS";
                       using (OracleCommand cmdAddInsertDetailS = new OracleCommand(strQueryInsertDetailS, con))
                       {
                           
                               cmdAddInsertDetailS.Transaction = tran;
                               cmdAddInsertDetailS.CommandType = CommandType.StoredProcedure;
                               cmdAddInsertDetailS.Parameters.Add("I_ID", OracleDbType.Int32).Value = objDetailS.AsmntTableId;
                               cmdAddInsertDetailS.Parameters.Add("I_PROCESSID", OracleDbType.Int32).Value = objEntityIntervewProcess.IntervewProcessId;
                               cmdAddInsertDetailS.Parameters.Add("I_SCDLVLID", OracleDbType.Int32).Value = objEntityIntervewProcess.SchdlLvlId;
                               cmdAddInsertDetailS.Parameters.Add("I_CTGRYDTL_ID", OracleDbType.Int32).Value = objDetailS.AsmntId;
                               cmdAddInsertDetailS.Parameters.Add("I_SCORE", OracleDbType.Int32).Value = objDetailS.Score;
                               cmdAddInsertDetailS.ExecuteNonQuery();
                           
                       }
                   }



                   tran.Commit();

               }

               catch (Exception e)
               {
                   tran.Rollback();
                   throw e;

               }
           }
       }


       public void CloseIntervewProcess(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           string strQueryReadById = "INTERVIEW_PROCESS.SP_CLOSE_INTERVW_PROCESS";
           using (OracleCommand cmdReadById = new OracleCommand())
           {
               OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
               con.Open();
               cmdReadById.Connection = con;
               cmdReadById.CommandText = strQueryReadById;
               cmdReadById.CommandType = CommandType.StoredProcedure;
               cmdReadById.Parameters.Add("I_ID", OracleDbType.Int32).Value = objEntityIntervewProcess.ReqrmntId;
               cmdReadById.Parameters.Add("I_CANDATE", OracleDbType.Date).Value = objEntityIntervewProcess.date;
               cmdReadById.Parameters.Add("I_CANUSR_ID", OracleDbType.Int32).Value = objEntityIntervewProcess.User_Id;
               cmdReadById.Parameters.Add("I_RSN", OracleDbType.Varchar2).Value = objEntityIntervewProcess.CancelReasn;
               cmdReadById.ExecuteNonQuery();
           }
       }

       public void holdIntervewProcess(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           string strQueryReadById = "INTERVIEW_PROCESS.SP_HOLD_INTERVW_PROCESS";
           using (OracleCommand cmdReadById = new OracleCommand())
           {
               OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
               con.Open();
               cmdReadById.Connection = con;
               cmdReadById.CommandText = strQueryReadById;
               cmdReadById.CommandType = CommandType.StoredProcedure;
               cmdReadById.Parameters.Add("I_ID", OracleDbType.Int32).Value = objEntityIntervewProcess.ReqrmntId;
               cmdReadById.ExecuteNonQuery();
           }
       }

       public void ReopenIntervewProcess(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           string strQueryReadById = "INTERVIEW_PROCESS.SP_REOPEN_INTERVW_PROCESS";
           using (OracleCommand cmdReadById = new OracleCommand())
           {
               OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
               con.Open();
               cmdReadById.Connection = con;
               cmdReadById.CommandText = strQueryReadById;
               cmdReadById.CommandType = CommandType.StoredProcedure;
               cmdReadById.Parameters.Add("I_ID", OracleDbType.Int32).Value = objEntityIntervewProcess.ReqrmntId;
               cmdReadById.ExecuteNonQuery();
           }
       }

       public DataTable checkCandStatus(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           string strQueryReadPayGrd = "INTERVIEW_PROCESS.SP_CHCK_CAND_STS";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityIntervewProcess.User_Id;
           cmdReadJob.Parameters.Add("P_REQMNT_ID", OracleDbType.Int32).Value = objEntityIntervewProcess.ReqrmntId;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }
       public DataTable readQualifiedLevel(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           string strQueryReadPayGrd = "INTERVIEW_PROCESS.SP_CHCK_QUALFD_STS";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityIntervewProcess.User_Id;
           cmdReadJob.Parameters.Add("P_REQMNT_ID", OracleDbType.Int32).Value = objEntityIntervewProcess.ReqrmntId;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }
       public void updateStatus(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           string strQueryReadById = "INTERVIEW_PROCESS.SP_UPD_STS";
           using (OracleCommand cmdReadById = new OracleCommand())
           {
               OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
               con.Open();
               cmdReadById.Connection = con;
               cmdReadById.CommandText = strQueryReadById;
               cmdReadById.CommandType = CommandType.StoredProcedure;
               cmdReadById.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityIntervewProcess.User_Id;
               cmdReadById.Parameters.Add("P_REQMNT_ID", OracleDbType.Int32).Value = objEntityIntervewProcess.ReqrmntId;
               cmdReadById.ExecuteNonQuery();
           }
       }

       public DataTable readCompleteLevel(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           string strQueryReadPayGrd = "INTERVIEW_PROCESS.SP_CHCK_CMPLTD_LVLS";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityIntervewProcess.User_Id;
           cmdReadJob.Parameters.Add("P_REQMNT_ID", OracleDbType.Int32).Value = objEntityIntervewProcess.ReqrmntId;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }

       public DataTable Read_Corp_Details(clsEntityLayerInterviewProcess objEntityIntervewProcess)
       {
           string strQueryReadPayGrd = "INTERVIEW_PROCESS.SP_READ_CORPORATE_ADDR";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_ORG", OracleDbType.Int32).Value = objEntityIntervewProcess.Organisation_Id;
           cmdReadJob.Parameters.Add("P_CORP", OracleDbType.Int32).Value = objEntityIntervewProcess.CorpOffice_Id;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }
       
    }
}
