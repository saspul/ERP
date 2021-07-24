using EL_Compzit.EntityLayer_HCM;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL_Compzit;
using EL_Compzit;

namespace DL_Compzit.DataLayer_HCM
{
   public class clsDataLayer_JobNotification
    {
       public DataTable ReadDivision(clsEntityLayer_JobNotification objEntityjob)
        {
            string strQueryReadPayGrd = "JOB_NOTIFICATION.SP_READ_DIVISION";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityjob.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityjob.User_Id;
            cmdReadJob.Parameters.Add("P_DEPTID", OracleDbType.Int32).Value = objEntityjob.Deprt_Id;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
       public DataTable ReadDepartment(clsEntityLayer_JobNotification objEntityjob)
        {
            string strQueryReadPayGrd = "JOB_NOTIFICATION.SP_READ_DEPRTMNT";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityjob.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityjob.User_Id;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
       public DataTable ReadDesignation(clsEntityLayer_JobNotification objEntityjob)
        {
            string strQueryReadPayGrd = "JOB_NOTIFICATION.SP_READ_DESGNTN";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityjob.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityjob.User_Id;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
       public DataTable ReadConsultancies(clsEntityLayer_JobNotification objEntityjob)
        {
            string strQueryReadPayGrd = "JOB_NOTIFICATION.SP_READ_CONSULTANCIES";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityjob.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityjob.User_Id;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
       public DataTable ReadProject(clsEntityLayer_JobNotification objEntityjob)
       {
           string strQueryReadPrjct = "JOB_NOTIFICATION.SP_READ_PROJECT";
           OracleCommand cmdReadPrjct = new OracleCommand();
           cmdReadPrjct.CommandText = strQueryReadPrjct;
           cmdReadPrjct.CommandType = CommandType.StoredProcedure;
           cmdReadPrjct.Parameters.Add("J_DIVID", OracleDbType.Int32).Value = objEntityjob.DivId;
           cmdReadPrjct.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityjob.Organisation_Id;
           cmdReadPrjct.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
           cmdReadPrjct.Parameters.Add("J_USERID", OracleDbType.Int32).Value = objEntityjob.User_Id;
           cmdReadPrjct.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadPrjct);
           return dtCategory;
       }
       public DataTable ReadEmployee(clsEntityLayer_JobNotification objEntityjob)
       {
           string strQueryReadPrjct = "JOB_NOTIFICATION.SP_READ_EMPLOYEE";
           OracleCommand cmdReadPrjct = new OracleCommand();
           cmdReadPrjct.CommandText = strQueryReadPrjct;
           cmdReadPrjct.CommandType = CommandType.StoredProcedure;
           cmdReadPrjct.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityjob.Organisation_Id;
           cmdReadPrjct.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
           cmdReadPrjct.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadPrjct);
           return dtCategory;
       }

       public DataTable ReadAprvdManPwrReqstList(clsEntityLayer_JobNotification objEntityjob)
        {
            string strQueryReadPayGrd = "JOB_NOTIFICATION.SP_READ_MAN_PWRRQST_LIST";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;

            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityjob.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityjob.User_Id;
            cmdReadJob.Parameters.Add("P_DIVID", OracleDbType.Int32).Value = objEntityjob.DivId;
            cmdReadJob.Parameters.Add("P_DEPID", OracleDbType.Int32).Value = objEntityjob.Deprt_Id;
            cmdReadJob.Parameters.Add("P_PRJCTID", OracleDbType.Int32).Value = objEntityjob.PrjctId;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
       public DataTable ReadManPwrReqstById(clsEntityLayer_JobNotification objEntityjob)
       {
           string strQueryReadPayGrd = "JOB_NOTIFICATION.SP_READ_MAN_PWRRQST_BY_ID";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_RQSTID", OracleDbType.Int32).Value = objEntityjob.ManPwrRqstId;
           cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityjob.Organisation_Id;
           cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }

       public DataTable ReadEmployeeById(clsEntityLayer_JobNotification objEntityjob)
       {
           string strQueryReadPayGrd = "JOB_NOTIFICATION.SP_READ_EMPLOYEE_BY_ID";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityjob.User_Id;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }

       public DataTable ReadDivisionById(clsEntityLayer_JobNotification objEntityjob)
       {
           string strQueryReadPayGrd = "JOB_NOTIFICATION.SP_READ_DIVISION_BY_ID";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_DIVID", OracleDbType.Int32).Value = objEntityjob.DivId;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }

       public DataTable ReadConsultancyById(clsEntityLayer_JobNotification objEntityjob)
       {
           string strQueryReadPayGrd = "JOB_NOTIFICATION.SP_READ_CONSULT_BY_ID";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_CONSID", OracleDbType.Int32).Value = objEntityjob.ConsltId;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }

       public DataTable ReadDepartmntById(clsEntityLayer_JobNotification objEntityjob)
       {
           string strQueryReadPayGrd = "JOB_NOTIFICATION.SP_READ_DPRTMNT_BY_ID";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_DEPID", OracleDbType.Int32).Value = objEntityjob.Deprt_Id;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }

       public DataTable ReadFromMailDetails(clsEntityLayer_JobNotification objEntityjob)
       {
           string strQueryReadFromMail = "COMMON.SP_FETCH_FROM_MAIL";
           OracleCommand cmdReadFromMail = new OracleCommand();
           cmdReadFromMail.CommandText = strQueryReadFromMail;
           cmdReadFromMail.CommandType = CommandType.StoredProcedure;
           cmdReadFromMail.Parameters.Add("C_USER_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
           cmdReadFromMail.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtReadFromMail = new DataTable();
           dtReadFromMail = clsDataLayer.ExecuteReader(cmdReadFromMail);
           return dtReadFromMail;
       }
       public DataTable CheckIsInserted(clsEntityLayer_JobNotification objEntityjob)
       {
           string strQueryReadCount = "JOB_NOTIFICATION.SP_IS_INSERTED";
           OracleCommand cmdReadCount = new OracleCommand();
           cmdReadCount.CommandText = strQueryReadCount;
           cmdReadCount.CommandType = CommandType.StoredProcedure;
           cmdReadCount.Parameters.Add("P_RQSTID", OracleDbType.Int32).Value = objEntityjob.ManPwrRqstId;
           cmdReadCount.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtReadCount = new DataTable();
           dtReadCount = clsDataLayer.ExecuteReader(cmdReadCount);
           return dtReadCount;
       }
       public DataTable ReadJobNotifyById(clsEntityLayer_JobNotification objEntityjob)
       {
           string strQueryReadCount = "JOB_NOTIFICATION.SP_READ_NOTIFY_BY_ID";
           OracleCommand cmdReadCount = new OracleCommand();
           cmdReadCount.CommandText = strQueryReadCount;
           cmdReadCount.CommandType = CommandType.StoredProcedure;
           cmdReadCount.Parameters.Add("P_RQSTID", OracleDbType.Int32).Value = objEntityjob.ManPwrRqstId;
           cmdReadCount.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtReadCount = new DataTable();
           dtReadCount = clsDataLayer.ExecuteReader(cmdReadCount);
           return dtReadCount;
       }
       public DataTable ReadJobNotifyCnsltById(clsEntityLayer_JobNotification objEntityjob)
       {
           string strQueryReadCount = "JOB_NOTIFICATION.SP_READ_NOTIFY_CNSLT_BY_ID";
           OracleCommand cmdReadCount = new OracleCommand();
           cmdReadCount.CommandText = strQueryReadCount;
           cmdReadCount.CommandType = CommandType.StoredProcedure;
           cmdReadCount.Parameters.Add("P_NOTFYTID", OracleDbType.Int32).Value = objEntityjob.JObNotifyId;
           cmdReadCount.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtReadCount = new DataTable();
           dtReadCount = clsDataLayer.ExecuteReader(cmdReadCount);
           return dtReadCount;
       }
       public DataTable ReadJobNotifyDivById(clsEntityLayer_JobNotification objEntityjob)
       {
           string strQueryReadCount = "JOB_NOTIFICATION.SP_READ_NOTIFY_DIV_BY_ID";
           OracleCommand cmdReadCount = new OracleCommand();
           cmdReadCount.CommandText = strQueryReadCount;
           cmdReadCount.CommandType = CommandType.StoredProcedure;
           cmdReadCount.Parameters.Add("P_NOTFYTID", OracleDbType.Int32).Value = objEntityjob.JObNotifyId;
           cmdReadCount.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtReadCount = new DataTable();
           dtReadCount = clsDataLayer.ExecuteReader(cmdReadCount);
           return dtReadCount;
       }
       public DataTable ReadJobNotifyDepById(clsEntityLayer_JobNotification objEntityjob)
       {
           string strQueryReadCount = "JOB_NOTIFICATION.SP_READ_NOTIFY_DEP_BY_ID";
           OracleCommand cmdReadCount = new OracleCommand();
           cmdReadCount.CommandText = strQueryReadCount;
           cmdReadCount.CommandType = CommandType.StoredProcedure;
           cmdReadCount.Parameters.Add("P_NOTFYTID", OracleDbType.Int32).Value = objEntityjob.JObNotifyId;
           cmdReadCount.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtReadCount = new DataTable();
           dtReadCount = clsDataLayer.ExecuteReader(cmdReadCount);
           return dtReadCount;
       }
       public DataTable ReadJobNotifyEmpById(clsEntityLayer_JobNotification objEntityjob)
       {
           string strQueryReadCount = "JOB_NOTIFICATION.SP_READ_NOTIFY_EMP_BY_ID";
           OracleCommand cmdReadCount = new OracleCommand();
           cmdReadCount.CommandText = strQueryReadCount;
           cmdReadCount.CommandType = CommandType.StoredProcedure;
           cmdReadCount.Parameters.Add("P_NOTFYTID", OracleDbType.Int32).Value = objEntityjob.JObNotifyId;
           cmdReadCount.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtReadCount = new DataTable();
           dtReadCount = clsDataLayer.ExecuteReader(cmdReadCount);
           return dtReadCount;
       }
       public void AddNotificationDetail(clsEntityLayer_JobNotification objEntityjob, List<clsEntityConsultDetail> objEntityConsultData, List<clsEntityDivisionDetail> objEntityDivisionData, List<clsEntityDepartmentDetail> objEntityDepartData, List<clsEntityEmployeeDetail> objEntityEmployData)
       {
           OracleTransaction tran;
           using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
           {
               con.Open();
               tran = con.BeginTransaction();
               try
               {
                   string strQueryAddNotify = "JOB_NOTIFICATION.SP_INS_NOTIFY_DETAIL";
                   using (OracleCommand cmdAddNotFy = new OracleCommand(strQueryAddNotify, con))
                   {
                       cmdAddNotFy.CommandType = CommandType.StoredProcedure;

                       //generate next value
                       clsDataLayer objDataLayer = new clsDataLayer();
                       clsEntityCommon objCommon = new clsEntityCommon();
                       objCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.JOB_NOTIFICATION);
                       objCommon.CorporateID = objEntityjob.CorpOffice_Id;
                       string strNextValue = objDataLayer.ReadNextNumberWebForUI(objCommon);
                       objEntityjob.JObNotifyId = Convert.ToInt32(strNextValue);
                       cmdAddNotFy.Parameters.Add("P_NOTFYTID", OracleDbType.Int32).Value = objEntityjob.JObNotifyId;
                       cmdAddNotFy.Parameters.Add("P_RQSTID", OracleDbType.Int32).Value = objEntityjob.ManPwrRqstId;
                       cmdAddNotFy.Parameters.Add("P_INTROFCID", OracleDbType.Int32).Value = objEntityjob.IfInterOfc;
                       cmdAddNotFy.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityjob.Organisation_Id;
                       cmdAddNotFy.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
                       cmdAddNotFy.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityjob.User_Id;
                       clsDataLayer.ExecuteNonQuery(cmdAddNotFy);
                   }

                   foreach (clsEntityConsultDetail objConsult in objEntityConsultData)
                   {
                       string strQueryAddNotifyConsult = "JOB_NOTIFICATION.SP_INS_NOTIFY_CNSLT_DETAIL";
                       using (OracleCommand cmdAddNotFyCnslt = new OracleCommand(strQueryAddNotifyConsult, con))
                       {
                           cmdAddNotFyCnslt.CommandType = CommandType.StoredProcedure;


                           cmdAddNotFyCnslt.Parameters.Add("P_NOTFYTID", OracleDbType.Int32).Value = objEntityjob.JObNotifyId;
                           cmdAddNotFyCnslt.Parameters.Add("P_RQSTID", OracleDbType.Int32).Value = objEntityjob.ManPwrRqstId;
                           cmdAddNotFyCnslt.Parameters.Add("P_CONSLTID", OracleDbType.Int32).Value = objConsult.ConsultId;
                           cmdAddNotFyCnslt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
                           clsDataLayer.ExecuteNonQuery(cmdAddNotFyCnslt);
                       }
                   }

                   foreach (clsEntityDivisionDetail objDivision in objEntityDivisionData)
                   {
                       string strQueryAddNotifyConsult = "JOB_NOTIFICATION.SP_INS_NOTIFY_DIV_DETAIL";
                       using (OracleCommand cmdAddNotFyCnslt = new OracleCommand(strQueryAddNotifyConsult, con))
                       {
                           cmdAddNotFyCnslt.CommandType = CommandType.StoredProcedure;


                           cmdAddNotFyCnslt.Parameters.Add("P_NOTFYTID", OracleDbType.Int32).Value = objEntityjob.JObNotifyId;
                           cmdAddNotFyCnslt.Parameters.Add("P_RQSTID", OracleDbType.Int32).Value = objEntityjob.ManPwrRqstId;
                           cmdAddNotFyCnslt.Parameters.Add("P_DIVID", OracleDbType.Int32).Value = objDivision.DivisionId;
                           cmdAddNotFyCnslt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
                           clsDataLayer.ExecuteNonQuery(cmdAddNotFyCnslt);
                       }
                   }

                   foreach (clsEntityDepartmentDetail objDepart in objEntityDepartData)
                   {
                       string strQueryAddNotifyConsult = "JOB_NOTIFICATION.SP_INS_NOTIFY_DEP_DETAIL";
                       using (OracleCommand cmdAddNotFyCnslt = new OracleCommand(strQueryAddNotifyConsult, con))
                       {
                           cmdAddNotFyCnslt.CommandType = CommandType.StoredProcedure;

                           cmdAddNotFyCnslt.Parameters.Add("P_NOTFYTID", OracleDbType.Int32).Value = objEntityjob.JObNotifyId;
                           cmdAddNotFyCnslt.Parameters.Add("P_RQSTID", OracleDbType.Int32).Value = objEntityjob.ManPwrRqstId;
                           cmdAddNotFyCnslt.Parameters.Add("P_DEPID", OracleDbType.Int32).Value = objDepart.DepartmentId;
                           cmdAddNotFyCnslt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
                           clsDataLayer.ExecuteNonQuery(cmdAddNotFyCnslt);
                       }
                   }

                   foreach (clsEntityEmployeeDetail objEmp in objEntityEmployData)
                   {
                       string strQueryAddNotifyConsult = "JOB_NOTIFICATION.SP_INS_NOTIFY_EMP_DETAIL";
                       using (OracleCommand cmdAddNotFyEmp = new OracleCommand(strQueryAddNotifyConsult, con))
                       {
                           cmdAddNotFyEmp.CommandType = CommandType.StoredProcedure;

                           cmdAddNotFyEmp.Parameters.Add("P_NOTFYTID", OracleDbType.Int32).Value = objEntityjob.JObNotifyId;
                           cmdAddNotFyEmp.Parameters.Add("P_RQSTID", OracleDbType.Int32).Value = objEntityjob.ManPwrRqstId;
                           cmdAddNotFyEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEmp.EmpId;
                           cmdAddNotFyEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
                           clsDataLayer.ExecuteNonQuery(cmdAddNotFyEmp);
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


       public void UpdateNotificationDetail(clsEntityLayer_JobNotification objEntityjob, List<clsEntityConsultDetail> objEntityConsultData, List<clsEntityDivisionDetail> objEntityDivisionData, List<clsEntityDepartmentDetail> objEntityDepartData, List<clsEntityEmployeeDetail> objEntityEmployData)
       {
           OracleTransaction tran;
           using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
           {
               con.Open();
               tran = con.BeginTransaction();
               try
               {
                   string strQueryAddNotify = "JOB_NOTIFICATION.SP_UPD_NOTIFY_DETAIL";
                   using (OracleCommand cmdAddNotFy = new OracleCommand(strQueryAddNotify, con))
                   {
                       cmdAddNotFy.CommandType = CommandType.StoredProcedure;

                       cmdAddNotFy.Parameters.Add("P_NOTFYTID", OracleDbType.Int32).Value = objEntityjob.JObNotifyId;
                       cmdAddNotFy.Parameters.Add("P_INTROFCID", OracleDbType.Int32).Value = objEntityjob.IfInterOfc;
                       cmdAddNotFy.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityjob.User_Id;
                       cmdAddNotFy.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityjob.J_Date;
                       clsDataLayer.ExecuteNonQuery(cmdAddNotFy);
                   }

                   string strQueryDeleteNotify = "JOB_NOTIFICATION.SP_DELETE_NOTIFY_DETAIL";
                   using (OracleCommand cmdAddNotFy = new OracleCommand(strQueryDeleteNotify, con))
                   {
                       cmdAddNotFy.CommandType = CommandType.StoredProcedure;

                       cmdAddNotFy.Parameters.Add("P_NOTFYTID", OracleDbType.Int32).Value = objEntityjob.JObNotifyId;
                       clsDataLayer.ExecuteNonQuery(cmdAddNotFy);
                   }

                   foreach (clsEntityConsultDetail objConsult in objEntityConsultData)
                   {
                       string strQueryAddNotifyConsult = "JOB_NOTIFICATION.SP_INS_NOTIFY_CNSLT_DETAIL";
                       using (OracleCommand cmdAddNotFyCnslt = new OracleCommand(strQueryAddNotifyConsult, con))
                       {
                           cmdAddNotFyCnslt.CommandType = CommandType.StoredProcedure;

                           cmdAddNotFyCnslt.Parameters.Add("P_NOTFYTID", OracleDbType.Int32).Value = objEntityjob.JObNotifyId;
                           cmdAddNotFyCnslt.Parameters.Add("P_RQSTID", OracleDbType.Int32).Value = objEntityjob.ManPwrRqstId;
                           cmdAddNotFyCnslt.Parameters.Add("P_CONSLTID", OracleDbType.Int32).Value = objConsult.ConsultId;
                           cmdAddNotFyCnslt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
                           clsDataLayer.ExecuteNonQuery(cmdAddNotFyCnslt);
                       }
                   }

                   foreach (clsEntityDivisionDetail objDivision in objEntityDivisionData)
                   {
                       string strQueryAddNotifyDiv = "JOB_NOTIFICATION.SP_INS_NOTIFY_DIV_DETAIL";
                       using (OracleCommand cmdAddNotFyCnslt = new OracleCommand(strQueryAddNotifyDiv, con))
                       {
                           cmdAddNotFyCnslt.CommandType = CommandType.StoredProcedure;


                           cmdAddNotFyCnslt.Parameters.Add("P_NOTFYTID", OracleDbType.Int32).Value = objEntityjob.JObNotifyId;
                           cmdAddNotFyCnslt.Parameters.Add("P_RQSTID", OracleDbType.Int32).Value = objEntityjob.ManPwrRqstId;
                           cmdAddNotFyCnslt.Parameters.Add("P_DIVID", OracleDbType.Int32).Value = objDivision.DivisionId;
                           cmdAddNotFyCnslt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
                           clsDataLayer.ExecuteNonQuery(cmdAddNotFyCnslt);
                       }
                   }

                   foreach (clsEntityDepartmentDetail objDepart in objEntityDepartData)
                   {
                       string strQueryAddNotifyDep = "JOB_NOTIFICATION.SP_INS_NOTIFY_DEP_DETAIL";
                       using (OracleCommand cmdAddNotFyCnslt = new OracleCommand(strQueryAddNotifyDep, con))
                       {
                           cmdAddNotFyCnslt.CommandType = CommandType.StoredProcedure;

                           cmdAddNotFyCnslt.Parameters.Add("P_NOTFYTID", OracleDbType.Int32).Value = objEntityjob.JObNotifyId;
                           cmdAddNotFyCnslt.Parameters.Add("P_RQSTID", OracleDbType.Int32).Value = objEntityjob.ManPwrRqstId;
                           cmdAddNotFyCnslt.Parameters.Add("P_DEPID", OracleDbType.Int32).Value = objDepart.DepartmentId;
                           cmdAddNotFyCnslt.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
                           clsDataLayer.ExecuteNonQuery(cmdAddNotFyCnslt);
                       }
                   }

                   foreach (clsEntityEmployeeDetail objEmp in objEntityEmployData)
                   {
                       string strQueryAddNotifyEmp = "JOB_NOTIFICATION.SP_INS_NOTIFY_EMP_DETAIL";
                       using (OracleCommand cmdAddNotFyEmp = new OracleCommand(strQueryAddNotifyEmp, con))
                       {
                           cmdAddNotFyEmp.CommandType = CommandType.StoredProcedure;

                           cmdAddNotFyEmp.Parameters.Add("P_NOTFYTID", OracleDbType.Int32).Value = objEntityjob.JObNotifyId;
                           cmdAddNotFyEmp.Parameters.Add("P_RQSTID", OracleDbType.Int32).Value = objEntityjob.ManPwrRqstId;
                           cmdAddNotFyEmp.Parameters.Add("P_EMPID", OracleDbType.Int32).Value = objEmp.EmpId;
                           cmdAddNotFyEmp.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityjob.CorpOffice_Id;
                           clsDataLayer.ExecuteNonQuery(cmdAddNotFyEmp);
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
    }
}
