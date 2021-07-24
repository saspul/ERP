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
   public class clsDataLayer_Exit_Intrvw_Process
    {
       public DataTable ReadDtlsList(clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess)
       {
           string strQueryReadDesg = "EXIT_INTRVW_PROCESS.SP_READ_DTLS_LIST";
           using (OracleCommand cmdReadDesg = new OracleCommand())
           {
               cmdReadDesg.CommandText = strQueryReadDesg;
               cmdReadDesg.CommandType = CommandType.StoredProcedure;               
               cmdReadDesg.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCust = new DataTable();
               dtCust = clsDataLayer.ExecuteReader(cmdReadDesg);
               return dtCust;
           }
       }
       public DataTable ReadDesignation(clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess)
       {
           string strQueryReadDesg = "EXIT_INTRVW_PROCESS.SP_READ_DESIGNATION";
           using (OracleCommand cmdReadDesg = new OracleCommand())
           {
               cmdReadDesg.CommandText = strQueryReadDesg;
               cmdReadDesg.CommandType = CommandType.StoredProcedure;
               cmdReadDesg.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.OrgId;
               cmdReadDesg.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.CorpId;
               cmdReadDesg.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCust = new DataTable();
               dtCust = clsDataLayer.ExecuteReader(cmdReadDesg);
               return dtCust;
           }
       }
       public DataTable ReadEmployee(clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess)
       {
           string strQueryReadDesg = "EXIT_INTRVW_PROCESS.SP_READ_USERS";
           using (OracleCommand cmdReadDesg = new OracleCommand())
           {
               cmdReadDesg.CommandText = strQueryReadDesg;
               cmdReadDesg.CommandType = CommandType.StoredProcedure;
               cmdReadDesg.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.OrgId;
               cmdReadDesg.Parameters.Add("E_CORPID", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.CorpId;
               cmdReadDesg.Parameters.Add("E_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCust = new DataTable();
               dtCust = clsDataLayer.ExecuteReader(cmdReadDesg);
               return dtCust;
           }
       }
       public DataTable ReadEmployeeDlts(clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess)
       {
           string strQueryReadDesg = "EXIT_INTRVW_PROCESS.SP_READ_EMP_DTLS";
           using (OracleCommand cmdReadDesg = new OracleCommand())
           {
               cmdReadDesg.CommandText = strQueryReadDesg;
               cmdReadDesg.CommandType = CommandType.StoredProcedure;
               cmdReadDesg.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.EmpId;
               cmdReadDesg.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCust = new DataTable();
               dtCust = clsDataLayer.ExecuteReader(cmdReadDesg);
               return dtCust;
           }
       }
       public DataTable ReadEmployeeDivsn(clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess)
       {
           string strQueryReadDesg = "EXIT_INTRVW_PROCESS.SP_READ_EMPLOYEE_DIVSN";
           using (OracleCommand cmdReadDesg = new OracleCommand())
           {
               cmdReadDesg.CommandText = strQueryReadDesg;
               cmdReadDesg.CommandType = CommandType.StoredProcedure;
               cmdReadDesg.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.EmpId;
               cmdReadDesg.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCust = new DataTable();
               dtCust = clsDataLayer.ExecuteReader(cmdReadDesg);
               return dtCust;
           }
       }
       public DataTable ReadQuestions(clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess)
       {
           string strQueryReadDesg = "EXIT_INTRVW_PROCESS.SP_READ_QUESTIONS";
           using (OracleCommand cmdReadDesg = new OracleCommand())
           {
               cmdReadDesg.CommandText = strQueryReadDesg;
               cmdReadDesg.CommandType = CommandType.StoredProcedure;
               cmdReadDesg.Parameters.Add("P_DESGID", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.DesgId;
               cmdReadDesg.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCust = new DataTable();
               dtCust = clsDataLayer.ExecuteReader(cmdReadDesg);
               return dtCust;
           }
       }    

       public void InsertQuestions(clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess, List<clsEntityLayer_Exit_Intrvw_Process_List> objEntityExitIntrvwProcessList)
       {
           clsDataLayer objDatatLayer = new clsDataLayer();
           string strQueryInsertJobShdl = "EXIT_INTRVW_PROCESS.SP_INS_QUESTIONS_MSTR";
           OracleTransaction tran;
           //insert to main INTERVIEW PROCESS MASTER table
           using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
           {
               con.Open();
               tran = con.BeginTransaction();

               try
               {

                   using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertJobShdl, con))
                   {
                       
                       clsEntityCommon objEntCommon = new clsEntityCommon();
                       objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.EXIT_INTERVIEW_PROCESS);
                       objEntCommon.CorporateID = objEntityExitIntrvwProcess.CorpId;
                       string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);

                       objEntityExitIntrvwProcess.NextId = Convert.ToInt32(strNextNum);

                       cmdAddInsertDetail.Transaction = tran;
                       cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;


                       //clsEntityCommon objEntCommon = new clsEntityCommon();
                       //objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.INTERVIEW_SCHEDULE_LEVEL);
                       //objEntCommon.CorporateID = objEntityIntervewProcess.CorpOffice_Id;
                       //string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                       //objEntityIntervewProcess.SchdlLvlId = Convert.ToInt32(strNextNum);

                       cmdAddInsertDetail.Parameters.Add("E_INTRVW_MSTR_ID", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.NextId;
                       cmdAddInsertDetail.Parameters.Add("E_USR_ID", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.EmpId;
                       cmdAddInsertDetail.Parameters.Add("E_DSGN_ID", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.DesgId;
                       cmdAddInsertDetail.Parameters.Add("E_INS_USR_ID", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.InsId;
                       cmdAddInsertDetail.Parameters.Add("E_INS_DATE", OracleDbType.Date).Value = objEntityExitIntrvwProcess.InsDate;
                       cmdAddInsertDetail.Parameters.Add("E_CNFRM_STS", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.CnfrmSts;
                       cmdAddInsertDetail.ExecuteNonQuery();
                   }
                           //insert to  ASSESSMENT DETAILS table
                           foreach (clsEntityLayer_Exit_Intrvw_Process_List objDetailS in objEntityExitIntrvwProcessList)
                           {
                               string strQueryInsertDetailS = "EXIT_INTRVW_PROCESS.SP_INS_QUESTIONS_DTLS";
                               using (OracleCommand cmdAddInsertDetailS = new OracleCommand(strQueryInsertDetailS, con))
                               {
                                  
                                       cmdAddInsertDetailS.Transaction = tran;
                                       cmdAddInsertDetailS.CommandType = CommandType.StoredProcedure;
                                       cmdAddInsertDetailS.Parameters.Add("E_INTRVW_MSTR_ID", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.NextId;
                                       cmdAddInsertDetailS.Parameters.Add("E_INTRVW_ANSWER", OracleDbType.Varchar2).Value = objDetailS.Ques;
                                       cmdAddInsertDetailS.Parameters.Add("E_EXTINTRVQT_ID", OracleDbType.Int32).Value = objDetailS.QuesId;
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

       public void UpdateQuestions(clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess, List<clsEntityLayer_Exit_Intrvw_Process_List> objEntityExitIntrvwProcessList)
       {
           clsDataLayer objDatatLayer = new clsDataLayer();
           string strQueryInsertJobShdl = "EXIT_INTRVW_PROCESS.SP_UPD_ANSWER_MSTR";
           OracleTransaction tran;
           //insert to main INTERVIEW PROCESS MASTER table
           using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
           {
               con.Open();
               tran = con.BeginTransaction();

               try
               {

                   using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertJobShdl, con))
                   {

                       //clsEntityCommon objEntCommon = new clsEntityCommon();
                       //objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.EXIT_INTERVIEW_PROCESS);
                       //objEntCommon.CorporateID = objEntityExitIntrvwProcess.CorpId;
                       //string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);

                       //objEntityExitIntrvwProcess.NextId = Convert.ToInt32(strNextNum);

                       cmdAddInsertDetail.Transaction = tran;
                       cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;


                       cmdAddInsertDetail.Parameters.Add("E_INTRVW_MSTR_ID", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.NextId;
                       cmdAddInsertDetail.Parameters.Add("E_USR_ID", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.EmpId;
                       cmdAddInsertDetail.Parameters.Add("E_DSGN_ID", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.DesgId;
                       cmdAddInsertDetail.Parameters.Add("UPD_USR_ID", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.InsId;
                       cmdAddInsertDetail.Parameters.Add("UPD_DATE", OracleDbType.Date).Value = objEntityExitIntrvwProcess.InsDate;
                       cmdAddInsertDetail.Parameters.Add("E_CNFRM_STS", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.CnfrmSts;
                       cmdAddInsertDetail.ExecuteNonQuery();
                   }
                   string strQueryDelDetailS = "EXIT_INTRVW_PROCESS.SP_DEL_ANSWER_DTLS";
                   using (OracleCommand cmdAddInsertDetailS = new OracleCommand(strQueryDelDetailS, con))
                   {

                       cmdAddInsertDetailS.Transaction = tran;
                       cmdAddInsertDetailS.CommandType = CommandType.StoredProcedure;
                       cmdAddInsertDetailS.Parameters.Add("E_INTRVW_MSTR_ID", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.NextId;
                       cmdAddInsertDetailS.ExecuteNonQuery();

                   }
                   //insert to  ASSESSMENT DETAILS table
                   foreach (clsEntityLayer_Exit_Intrvw_Process_List objDetailS in objEntityExitIntrvwProcessList)
                   {
                       string strQueryInsertDetailS = "EXIT_INTRVW_PROCESS.SP_INS_QUESTIONS_DTLS";
                       using (OracleCommand cmdAddInsertDetailS = new OracleCommand(strQueryInsertDetailS, con))
                       {

                           cmdAddInsertDetailS.Transaction = tran;
                           cmdAddInsertDetailS.CommandType = CommandType.StoredProcedure;
                           cmdAddInsertDetailS.Parameters.Add("E_INTRVW_MSTR_ID", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.NextId;
                           cmdAddInsertDetailS.Parameters.Add("E_INTRVW_ANSWER", OracleDbType.Varchar2).Value = objDetailS.Ques;
                           cmdAddInsertDetailS.Parameters.Add("E_EXTINTRVQT_ID", OracleDbType.Int32).Value = objDetailS.QuesId;
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
    
       
       public DataTable ReadAnswers(clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess)
       {
           string strQueryReadDesg = "EXIT_INTRVW_PROCESS.SP_READ_ANSWER";
           using (OracleCommand cmdReadDesg = new OracleCommand())
           {
               cmdReadDesg.CommandText = strQueryReadDesg;
               cmdReadDesg.CommandType = CommandType.StoredProcedure;
               cmdReadDesg.Parameters.Add("P_DESGID", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.DesgId;
               cmdReadDesg.Parameters.Add("P_USRID", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.EmpId;
               cmdReadDesg.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCust = new DataTable();
               dtCust = clsDataLayer.ExecuteReader(cmdReadDesg);
               return dtCust;
           }
       }
       public DataTable ReadMstrId(clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess)
       {
           string strQueryReadDesg = "EXIT_INTRVW_PROCESS.SP_READ_MSTR_ID";
           using (OracleCommand cmdReadDesg = new OracleCommand())
           {
               cmdReadDesg.CommandText = strQueryReadDesg;
               cmdReadDesg.CommandType = CommandType.StoredProcedure;
               cmdReadDesg.Parameters.Add("E_INTRVW_MSTR_ID", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.NextId;
               cmdReadDesg.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCust = new DataTable();
               dtCust = clsDataLayer.ExecuteReader(cmdReadDesg);
               return dtCust;
           }
       }

       public DataTable ReadBySearch(clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess)
       {
           string strQueryReadPayGrd = "EXIT_INTRVW_PROCESS.SP_READ_BYSEARCH";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;

           cmdReadJob.Parameters.Add("J_DIV_ID", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.DesgId;
           cmdReadJob.Parameters.Add("J_EMPID", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.EmpId;
           cmdReadJob.Parameters.Add("J_SEARCHSTS", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.SearchSts;
           cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.OrgId;
           cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.CorpId;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }
       //Read the employee id
       public DataTable ReadUserId(clsEntityLayer_Exit_Intrvw_Process objEntityExitIntrvwProcess)
       {
           string strQueryUserId = "EXIT_INTRVW_PROCESS.SP_READ_USER_ID";
           using (OracleCommand cmdReadUserId = new OracleCommand())
           {
               cmdReadUserId.CommandText = strQueryUserId;
               cmdReadUserId.CommandType = CommandType.StoredProcedure;
               cmdReadUserId.Parameters.Add("USER_ID", OracleDbType.Int32).Value = objEntityExitIntrvwProcess.EmpId;
               cmdReadUserId.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCust = new DataTable();
               dtCust = clsDataLayer.ExecuteReader(cmdReadUserId);
               return dtCust;
           }
       }
    }
}
