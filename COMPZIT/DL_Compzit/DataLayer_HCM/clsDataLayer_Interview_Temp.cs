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
   public class clsDataLayer_Interview_Temp
    {

       public DataTable ReadDivision(clsEntity_Interview_Temp objEntityTemp)
         {
             string strQueryReadPayGrd = "INTERVIEW_TEMPLATE.SP_READ_SHEDL_TYP";
             OracleCommand cmdReadJob = new OracleCommand();
             cmdReadJob.CommandText = strQueryReadPayGrd;
             cmdReadJob.CommandType = CommandType.StoredProcedure;
             //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
             cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
             DataTable dtCategory = new DataTable();
             dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
             return dtCategory;
         }

       public DataTable ReadCatagoryTypLoad(clsEntity_Interview_Temp objEntityTemp)
       {
           string strQueryReadPayGrd = "INTERVIEW_TEMPLATE.SP_READ_CATGRY_LOAD";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityTemp.Organisation_Id;
           cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityTemp.CorpOffice_Id;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }

       public int Insert_Interv_Templates(clsEntity_Interview_Temp objEntityTemp, List<clsEntityInterviewShedule> objEntityIntervShedule)
       {
           clsDataLayer objDatatLayer = new clsDataLayer();
           string strQueryReadPayGrd = "INTERVIEW_TEMPLATE.SP_INSERT_INTERVW_TEMPLATE";
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
                       objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.WATER_BILLING);
                       objEntCommon.CorporateID = objEntityTemp.CorpOffice_Id;
                       string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                       objEntityTemp.NextTempId = Convert.ToInt32(strNextNum);

                       cmdInsertWtrFilng.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityTemp.NextTempId;
                       cmdInsertWtrFilng.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntityTemp.TemplateNme;
                       cmdInsertWtrFilng.Parameters.Add("P_VALIDATE_STS ", OracleDbType.Int32).Value = objEntityTemp.ValidateSts;
                       cmdInsertWtrFilng.Parameters.Add("P_TEMP_STS ", OracleDbType.Int32).Value = objEntityTemp.TempSts;
                       cmdInsertWtrFilng.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityTemp.Organisation_Id;
                       cmdInsertWtrFilng.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityTemp.CorpOffice_Id;
                       cmdInsertWtrFilng.Parameters.Add("P_INSUSERID", OracleDbType.Int32).Value = objEntityTemp.User_Id;
                       cmdInsertWtrFilng.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityTemp.D_Date;

                       cmdInsertWtrFilng.ExecuteNonQuery();

                   }
                   //insert to  Detail table
                   foreach (clsEntityInterviewShedule objDetail in objEntityIntervShedule)
                   {

                       string strQueryInsertDetail = "INTERVIEW_TEMPLATE.SP_INSERT_INTRVW_SHEDULE_DTLS";
                       using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                       {
                           cmdAddInsertDetail.Transaction = tran;
                           cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                           cmdAddInsertDetail.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityTemp.NextTempId;
                           cmdAddInsertDetail.Parameters.Add("P_SHEDL_NAME", OracleDbType.Varchar2).Value = objDetail.sheduleNme;
                           cmdAddInsertDetail.Parameters.Add("P_CATG_ID", OracleDbType.Int32).Value = objDetail.CatagryId;
                           cmdAddInsertDetail.Parameters.Add("P_TYP_ID", OracleDbType.Int32).Value = objDetail.ShdlTypId;
                           cmdAddInsertDetail.Parameters.Add("P_SCORESTS", OracleDbType.Int32).Value = objDetail.ScoreStsstatus;

                           cmdAddInsertDetail.Parameters.Add("P_CORP", OracleDbType.Int32).Value = objEntityTemp.CorpOffice_Id;
                           cmdAddInsertDetail.ExecuteNonQuery();
                       }
                   }

                   tran.Commit();
                   return objEntityTemp.NextTempId;
               }

               catch (Exception e)
               {
                   tran.Rollback();
                   throw e;

               }

           }
       }

       public void CancelinterviewTem(clsEntity_Interview_Temp objEntityTemp)
         {
             string strQueryReadPayGrd = "INTERVIEW_TEMPLATE.SP_CANCELINTRVW_TEM";
             using (OracleCommand cmdReadPayGrd = new OracleCommand())
             {
                 cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                 cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                 cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityTemp.NextTempId;
                 cmdReadPayGrd.Parameters.Add("P_RESN", OracleDbType.Varchar2).Value = objEntityTemp.Cancel_Reason;
                 cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityTemp.D_Date;
                 cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityTemp.User_Id;
                 cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityTemp.Organisation_Id;
                 cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityTemp.CorpOffice_Id;

                 clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
             }

         }

       public DataTable ReadinterviewTemList(clsEntity_Interview_Temp objEntityTemp)
         {
             string strQueryReadPayGrd = "INTERVIEW_TEMPLATE.SP_READ_INTERV_TEMLIST";
             OracleCommand cmdReadJob = new OracleCommand();
             cmdReadJob.CommandText = strQueryReadPayGrd;
             cmdReadJob.CommandType = CommandType.StoredProcedure;
             cmdReadJob.Parameters.Add("P_CANCELSTS", OracleDbType.Int32).Value = objEntityTemp.Cancel_Status;
             cmdReadJob.Parameters.Add("P_STS", OracleDbType.Int32).Value = objEntityTemp.TempSts;
             cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityTemp.Organisation_Id;
             cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityTemp.CorpOffice_Id;
             cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityTemp.User_Id;
             cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
             DataTable dtCategory = new DataTable();
             dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
             return dtCategory;
         }
       public void ChangeRequestStatus(clsEntity_Interview_Temp objEntityTemp)
       {
           string strQueryReadPayGrd = "INTERVIEW_TEMPLATE.SP_UPDATE_STS";
           using (OracleCommand cmdReadPayGrd = new OracleCommand())
           {
               cmdReadPayGrd.CommandText = strQueryReadPayGrd;
               cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
               cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityTemp.NextTempId;
               cmdReadPayGrd.Parameters.Add("P_STS", OracleDbType.Int32).Value = objEntityTemp.TempSts;
               cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityTemp.User_Id;
               cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityTemp.Organisation_Id;
               cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityTemp.CorpOffice_Id;

               clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
           }

       }
       public DataTable ReadIntervwTemDetails(clsEntity_Interview_Temp objEntityTemp)
       {
           string strQueryReadPayGrd = "INTERVIEW_TEMPLATE.SP_READ_INTERV_TEMBYID";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityTemp.NextTempId;
           cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityTemp.Organisation_Id;
           cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityTemp.CorpOffice_Id;
          // cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityTemp.User_Id;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }
       public DataTable ReadIntervwTemDetailsTxt(clsEntity_Interview_Temp objEntityTemp)
       {
           string strQueryReadPayGrd = "INTERVIEW_TEMPLATE.SP_READ_INTERV_TEMBYID_TXT";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityTemp.NextTempId;
           cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityTemp.Organisation_Id;
           cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityTemp.CorpOffice_Id;
          // cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityTemp.User_Id;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }
       

       public void Update_Interv_Templates(clsEntity_Interview_Temp objEntityTemp, List<clsEntityInterviewShedule> objEntityIntervSheduleIns, List<clsEntityInterviewShedule> objEntityIntervSheduleUpd, string[] strarrCancldtlIds)
       {
           clsDataLayer objDatatLayer = new clsDataLayer();
           string strQueryReadPayGrd = "INTERVIEW_TEMPLATE.SP_UPDATE_INTERVW_TEMPLATE";
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
                       objEntCommon.CorporateID = objEntityTemp.CorpOffice_Id;
                      // string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                      // objEntityTemp.NextTempId = Convert.ToInt32(strNextNum);

                       cmdInsertWtrFilng.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityTemp.NextTempId;
                       cmdInsertWtrFilng.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntityTemp.TemplateNme;
                       cmdInsertWtrFilng.Parameters.Add("P_VALIDATE_STS ", OracleDbType.Int32).Value = objEntityTemp.ValidateSts;
                       cmdInsertWtrFilng.Parameters.Add("P_TEMP_STS ", OracleDbType.Int32).Value = objEntityTemp.TempSts;
                       cmdInsertWtrFilng.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityTemp.Organisation_Id;
                       cmdInsertWtrFilng.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityTemp.CorpOffice_Id;
                       cmdInsertWtrFilng.Parameters.Add("P_INSUSERID", OracleDbType.Int32).Value = objEntityTemp.User_Id;
                       cmdInsertWtrFilng.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityTemp.D_Date;

                       cmdInsertWtrFilng.ExecuteNonQuery();

                   }
                   //insert to  Detail table
                   foreach (clsEntityInterviewShedule objDetail in objEntityIntervSheduleIns)
                   {

                       string strQueryInsertDetail = "INTERVIEW_TEMPLATE.SP_INSERT_INTRVW_SHEDULE_DTLS";
                       using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                       {
                           cmdAddInsertDetail.Transaction = tran;
                           cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                           cmdAddInsertDetail.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityTemp.NextTempId;
                           cmdAddInsertDetail.Parameters.Add("P_SHEDL_NAME", OracleDbType.Varchar2).Value = objDetail.sheduleNme;
                           cmdAddInsertDetail.Parameters.Add("P_CATG_ID", OracleDbType.Int32).Value = objDetail.CatagryId;
                           cmdAddInsertDetail.Parameters.Add("P_TYP_ID", OracleDbType.Int32).Value = objDetail.ShdlTypId;
                           cmdAddInsertDetail.Parameters.Add("P_SCORESTS", OracleDbType.Int32).Value = objDetail.ScoreStsstatus;

                           cmdAddInsertDetail.Parameters.Add("P_CORP", OracleDbType.Int32).Value = objEntityTemp.CorpOffice_Id;
                           cmdAddInsertDetail.ExecuteNonQuery();
                       }
                   }

                   //update to  Detail table
                   foreach (clsEntityInterviewShedule objDetail in objEntityIntervSheduleUpd)
                   {

                       string strQueryInsertDetail = "INTERVIEW_TEMPLATE.SP_UPDATE_INTRVW_SHEDULE_DTLS";
                       using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                       {
                           cmdAddInsertDetail.Transaction = tran;
                           cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                           cmdAddInsertDetail.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityTemp.NextTempId;
                           cmdAddInsertDetail.Parameters.Add("P_DETAIL_ID", OracleDbType.Int32).Value = objDetail.ShedulId;
                           cmdAddInsertDetail.Parameters.Add("P_SHEDL_NAME", OracleDbType.Varchar2).Value = objDetail.sheduleNme;
                           cmdAddInsertDetail.Parameters.Add("P_CATG_ID", OracleDbType.Int32).Value = objDetail.CatagryId;
                           cmdAddInsertDetail.Parameters.Add("P_TYP_ID", OracleDbType.Int32).Value = objDetail.ShdlTypId;
                           cmdAddInsertDetail.Parameters.Add("P_SCORESTS", OracleDbType.Int32).Value = objDetail.ScoreStsstatus;

                           cmdAddInsertDetail.Parameters.Add("P_CORP", OracleDbType.Int32).Value = objEntityTemp.CorpOffice_Id;
                           cmdAddInsertDetail.ExecuteNonQuery();
                       }
                   }

                   //Cancel the rows that have been cancelled when editing in Detail table
                   foreach (string strDtlId in strarrCancldtlIds)
                   {
                       if (strDtlId != "" && strDtlId != null)
                       {
                           int intDtlId = Convert.ToInt32(strDtlId);

                           string strQueryCancelDetail = "INTERVIEW_TEMPLATE.SP_CANCEL_INTRVW_SHEDULE_DTL";
                           using (OracleCommand cmdCancelDetail = new OracleCommand(strQueryCancelDetail, con))
                           {
                               cmdCancelDetail.Transaction = tran;

                               cmdCancelDetail.CommandType = CommandType.StoredProcedure;
                               cmdCancelDetail.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityTemp.NextTempId;
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



       public string DuplCheckIntervwTem(clsEntity_Interview_Temp objEntityTemp)
        {
            string strQueryReadPayGrd = "INTERVIEW_TEMPLATE.SP_INTERVWTEM_DUPNAME_CHK";
            OracleCommand cmdReadPayGrd = new OracleCommand();
            cmdReadPayGrd.CommandText = strQueryReadPayGrd;
            cmdReadPayGrd.CommandType = CommandType.StoredProcedure;

            cmdReadPayGrd.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityTemp.NextTempId;
            cmdReadPayGrd.Parameters.Add("P_NAME", OracleDbType.Varchar2).Value = objEntityTemp.TemplateNme;
            cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityTemp.Organisation_Id;
            cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityTemp.CorpOffice_Id;

            cmdReadPayGrd.Parameters.Add("P_OUT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdReadPayGrd);
            string strReturn = cmdReadPayGrd.Parameters["P_OUT"].Value.ToString();
            cmdReadPayGrd.Dispose();
            return strReturn;

          
        }
    }
}
