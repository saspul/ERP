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
     public class clsData_Job_Description_Master
    {
         public DataTable ReadDivision(clsEntity_Job_Description_Master objEntityjob)
         {
             string strQueryReadPayGrd = "JOB_DESCRPTN_MSTR.SP_READ_DIVISION";
             OracleCommand cmdReadJob = new OracleCommand();
             cmdReadJob.CommandText = strQueryReadPayGrd;
             cmdReadJob.CommandType = CommandType.StoredProcedure;
             //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
             cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityjob.Organisation_Id;
             cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
             cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityjob.User_Id;
             cmdReadJob.Parameters.Add("P_DEPTID", OracleDbType.Int32).Value = objEntityjob.Deprt_Id;
             cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
             DataTable dtCategory = new DataTable();
             dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
             return dtCategory;
         }
         public DataTable ReadDepartment(clsEntity_Job_Description_Master objEntityjob)
         {
             string strQueryReadPayGrd = "JOB_DESCRPTN_MSTR.SP_READ_DEPRTMNT";
             OracleCommand cmdReadJob = new OracleCommand();
             cmdReadJob.CommandText = strQueryReadPayGrd;
             cmdReadJob.CommandType = CommandType.StoredProcedure;
             //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
             cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityjob.Organisation_Id;
             cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
             cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityjob.User_Id;
             cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
             DataTable dtCategory = new DataTable();
             dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
             return dtCategory;
         }
         public DataTable ReadPayGrade(clsEntity_Job_Description_Master objEntityjob)
         {
             string strQueryReadPayGrd = "JOB_DESCRPTN_MSTR.SP_READ_PAYGRADE";
             OracleCommand cmdReadJob = new OracleCommand();
             cmdReadJob.CommandText = strQueryReadPayGrd;
             cmdReadJob.CommandType = CommandType.StoredProcedure;
             //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
             cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityjob.Organisation_Id;
             cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
             cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityjob.User_Id;
             cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
             DataTable dtCategory = new DataTable();
             dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
             return dtCategory;
         }

         public DataTable ReadDesignation(clsEntity_Job_Description_Master objEntityjob)
         {
             string strQueryReadPayGrd = "JOB_DESCRPTN_MSTR.SP_READ_DESGNTN";
             OracleCommand cmdReadJob = new OracleCommand();
             cmdReadJob.CommandText = strQueryReadPayGrd;
             cmdReadJob.CommandType = CommandType.StoredProcedure;
             //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
             cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityjob.Organisation_Id;
             cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
             cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityjob.User_Id;
             cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
             DataTable dtCategory = new DataTable();
             dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
             return dtCategory;
         }
         public DataTable ReadDesignationReport(clsEntity_Job_Description_Master objEntityjob)
         {
             string strQueryReadPayGrd = "JOB_DESCRPTN_MSTR.SP_READ_DESGNTN_REPORT";
             OracleCommand cmdReadJob = new OracleCommand();
             cmdReadJob.CommandText = strQueryReadPayGrd;
             cmdReadJob.CommandType = CommandType.StoredProcedure;
             //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
             cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityjob.Organisation_Id;
             cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
             cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityjob.User_Id;
             cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
             DataTable dtCategory = new DataTable();
             dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
             return dtCategory;
         }
         public void AddJobDescptn(clsEntity_Job_Description_Master objEntityjob)
         {
             string strQueryReadPayGrd = "JOB_DESCRPTN_MSTR.SP_INSERT_JOBDES";
             using (OracleCommand cmdReadPayGrd = new OracleCommand())
             {
                 cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                 cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                 if (objEntityjob.DivId != 0)
                     cmdReadPayGrd.Parameters.Add("J_DIV_ID", OracleDbType.Int32).Value = objEntityjob.DivId;
                 else
                     cmdReadPayGrd.Parameters.Add("J_DIV_ID", OracleDbType.Int32).Value = null;
                 if (objEntityjob.Deprt_Id != 0)
                     cmdReadPayGrd.Parameters.Add("J_DEPRTID", OracleDbType.Int32).Value = objEntityjob.Deprt_Id;
                 else
                     cmdReadPayGrd.Parameters.Add("J_DEPRTID", OracleDbType.Int32).Value = null;
                 cmdReadPayGrd.Parameters.Add("J_DESGID", OracleDbType.Int32).Value = objEntityjob.DesgId;
                 cmdReadPayGrd.Parameters.Add("J_PAYGRDID", OracleDbType.Int32).Value = objEntityjob.PayGradeId;
                 cmdReadPayGrd.Parameters.Add("J_POSTYPID", OracleDbType.Int32).Value = objEntityjob.PostnTyp;
                  cmdReadPayGrd.Parameters.Add("J_REPRT_DESGID", OracleDbType.Int32).Value = objEntityjob.PostnRprtDesgId;


                   cmdReadPayGrd.Parameters.Add("J_SUMMRY", OracleDbType.Varchar2).Value = objEntityjob.SummryPostn;
                   if (objEntityjob.DesiredQual != "")
                       cmdReadPayGrd.Parameters.Add("J_QUALFCTN", OracleDbType.Varchar2).Value = objEntityjob.DesiredQual;
                   else
                       cmdReadPayGrd.Parameters.Add("J_QUALFCTN", OracleDbType.Varchar2).Value = null;
                   cmdReadPayGrd.Parameters.Add("J_SKILLS", OracleDbType.Varchar2).Value = objEntityjob.MandtrySkls;
                   if (objEntityjob.Education != "")
                       cmdReadPayGrd.Parameters.Add("J_EDUCATION", OracleDbType.Varchar2).Value = objEntityjob.Education;
                   else
                       cmdReadPayGrd.Parameters.Add("J_EDUCATION", OracleDbType.Varchar2).Value = null;
                   if (objEntityjob.CertfcnTraing != "")
                       cmdReadPayGrd.Parameters.Add("J_TRAING", OracleDbType.Varchar2).Value = objEntityjob.CertfcnTraing;
                   else
                       cmdReadPayGrd.Parameters.Add("J_TRAING", OracleDbType.Varchar2).Value = null;
                   cmdReadPayGrd.Parameters.Add("J_RESPBLTY", OracleDbType.Varchar2).Value=objEntityjob.JobRspblty;
                   cmdReadPayGrd.Parameters.Add("J_MINEXP", OracleDbType.Int32).Value = objEntityjob.MinExprnce;           
                  cmdReadPayGrd.Parameters.Add("J_USERID", OracleDbType.Int32).Value = objEntityjob.User_Id;
                  cmdReadPayGrd.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityjob.Organisation_Id;
                  cmdReadPayGrd.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
                

                 clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
             }
         }

         public void CancelJobDesrp(clsEntity_Job_Description_Master objEntityjob)
         {
             string strQueryReadPayGrd = "JOB_DESCRPTN_MSTR.SP_CANCELJOB";
             using (OracleCommand cmdReadPayGrd = new OracleCommand())
             {
                 cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                 cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                 cmdReadPayGrd.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityjob.JobDescrpId;
                 cmdReadPayGrd.Parameters.Add("J_RESN", OracleDbType.Varchar2).Value = objEntityjob.Cancel_Reason;
                 cmdReadPayGrd.Parameters.Add("J_DATE", OracleDbType.Date).Value = objEntityjob.D_Date;
                 cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityjob.User_Id;
                 cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityjob.Organisation_Id;
                 cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;

                 clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
             }

         }
         public DataTable ReadJobDesList(clsEntity_Job_Description_Master objEntityjob)
         {
             string strQueryReadPayGrd = "JOB_DESCRPTN_MSTR.SP_READ_JOBLIST";
             OracleCommand cmdReadJob = new OracleCommand();
             cmdReadJob.CommandText = strQueryReadPayGrd;
             cmdReadJob.CommandType = CommandType.StoredProcedure;
         
             cmdReadJob.Parameters.Add("J_DIV_ID", OracleDbType.Int32).Value = objEntityjob.DivId;
             cmdReadJob.Parameters.Add("J_DEPRTID", OracleDbType.Int32).Value = objEntityjob.Deprt_Id;
             cmdReadJob.Parameters.Add("J_CANCELSTS", OracleDbType.Int32).Value = objEntityjob.Cancel_Status;
             cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityjob.Organisation_Id;
             cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
             cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityjob.User_Id;
             cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
             DataTable dtCategory = new DataTable();
             dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
             return dtCategory;
         }

         public DataTable ReadJobDescrpnById(clsEntity_Job_Description_Master objEntityjob)
         {
             string strQueryReadPayGrd = "JOB_DESCRPTN_MSTR.SP_READ_JOB_BYID";
             OracleCommand cmdReadJob = new OracleCommand();
             cmdReadJob.CommandText = strQueryReadPayGrd;
             cmdReadJob.CommandType = CommandType.StoredProcedure;

             cmdReadJob.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityjob.JobDescrpId;
             cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityjob.Organisation_Id;
             cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
             cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityjob.User_Id;
             cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
             DataTable dtCategory = new DataTable();
             dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
             return dtCategory;
         }

         public void UpdateJobDescptn(clsEntity_Job_Description_Master objEntityjob)
         {
             string strQueryReadPayGrd = "JOB_DESCRPTN_MSTR.SP_UPDATEJOB";
             using (OracleCommand cmdReadPayGrd = new OracleCommand())
             {
                 cmdReadPayGrd.CommandText = strQueryReadPayGrd;
                 cmdReadPayGrd.CommandType = CommandType.StoredProcedure;
                 cmdReadPayGrd.Parameters.Add("J_ID", OracleDbType.Int32).Value = objEntityjob.JobDescrpId;
                 if (objEntityjob.DivId != 0)
                     cmdReadPayGrd.Parameters.Add("J_DIV_ID", OracleDbType.Int32).Value = objEntityjob.DivId;
                 else
                     cmdReadPayGrd.Parameters.Add("J_DIV_ID", OracleDbType.Int32).Value = null;
                 if (objEntityjob.Deprt_Id != 0)
                     cmdReadPayGrd.Parameters.Add("J_DEPRTID", OracleDbType.Int32).Value = objEntityjob.Deprt_Id;
                 else
                     cmdReadPayGrd.Parameters.Add("J_DEPRTID", OracleDbType.Int32).Value = null;
               //  cmdReadPayGrd.Parameters.Add("J_DESGID", OracleDbType.Int32).Value = objEntityjob.DesgId;
                 cmdReadPayGrd.Parameters.Add("J_PAYGRDID", OracleDbType.Int32).Value = objEntityjob.PayGradeId;
                 cmdReadPayGrd.Parameters.Add("J_POSTYPID", OracleDbType.Int32).Value = objEntityjob.PostnTyp;
                 cmdReadPayGrd.Parameters.Add("J_REPRT_DESGID", OracleDbType.Int32).Value = objEntityjob.PostnRprtDesgId;


                 cmdReadPayGrd.Parameters.Add("J_SUMMRY", OracleDbType.Varchar2).Value = objEntityjob.SummryPostn;
                 if (objEntityjob.DesiredQual != "")
                     cmdReadPayGrd.Parameters.Add("J_QUALFCTN", OracleDbType.Varchar2).Value = objEntityjob.DesiredQual;
                 else
                     cmdReadPayGrd.Parameters.Add("J_QUALFCTN", OracleDbType.Varchar2).Value = null;
                 cmdReadPayGrd.Parameters.Add("J_SKILLS", OracleDbType.Varchar2).Value = objEntityjob.MandtrySkls;
                 if (objEntityjob.Education != "")
                     cmdReadPayGrd.Parameters.Add("J_EDUCATION", OracleDbType.Varchar2).Value = objEntityjob.Education;
                 else
                     cmdReadPayGrd.Parameters.Add("J_EDUCATION", OracleDbType.Varchar2).Value = null;
                 if (objEntityjob.CertfcnTraing != "")
                     cmdReadPayGrd.Parameters.Add("J_TRAING", OracleDbType.Varchar2).Value = objEntityjob.CertfcnTraing;
                 else
                     cmdReadPayGrd.Parameters.Add("J_TRAING", OracleDbType.Varchar2).Value = null;
                 cmdReadPayGrd.Parameters.Add("J_RESPBLTY", OracleDbType.Varchar2).Value = objEntityjob.JobRspblty;
                 cmdReadPayGrd.Parameters.Add("J_MINEXP", OracleDbType.Int32).Value = objEntityjob.MinExprnce;
                 cmdReadPayGrd.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityjob.D_Date;
                 cmdReadPayGrd.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityjob.User_Id;
                 cmdReadPayGrd.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityjob.Organisation_Id;
                 cmdReadPayGrd.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;

                 clsDataLayer.ExecuteNonQuery(cmdReadPayGrd);
             }

         }
    }
}
