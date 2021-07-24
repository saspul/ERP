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
   public  class clsDataLayerOnBoardingPartialProcess
    {
       public DataTable ReadReqrmtLoad(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
       {
           string strQueryReadPayGrd = "ONBOARDING_PARTIAL_PROCESS.SP_READ_REQRMNT_LOAD";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPartialProcess.Organisation_Id;
           cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPartialProcess.CorpOffice_Id;
           cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPartialProcess.User_Id;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }
       public DataTable ReadAssignedProcessList(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
       {
           string strQueryReadPayGrd = "ONBOARDING_PARTIAL_PROCESS.SP_READ_ASGND_CANDLIST";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPartialProcess.Organisation_Id;
           cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPartialProcess.CorpOffice_Id;
           cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPartialProcess.User_Id;
           if (objEntityPartialProcess.AsgndDate != DateTime.MinValue)
           {
               cmdReadJob.Parameters.Add("P_ASGND_DATE", OracleDbType.Date).Value = objEntityPartialProcess.AsgndDate;
           }
           else
           {
               cmdReadJob.Parameters.Add("P_ASGND_DATE", OracleDbType.Date).Value = null;
           }
           if (objEntityPartialProcess.ToDate != DateTime.MinValue)
           {
               cmdReadJob.Parameters.Add("P_TO_DATE", OracleDbType.Date).Value = objEntityPartialProcess.ToDate;
           }
           else
           {
               cmdReadJob.Parameters.Add("P_TO_DATE", OracleDbType.Date).Value = null;
           }
           if (objEntityPartialProcess.ReqrmntId != 0)
           {
               cmdReadJob.Parameters.Add("P_RQRMNTID", OracleDbType.Int32).Value = objEntityPartialProcess.ReqrmntId;
           }
           else
           {
               cmdReadJob.Parameters.Add("P_RQRMNTID", OracleDbType.Int32).Value = null;
           }
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }
       public DataTable ReadEmpInfoById(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
       {
           string strQueryReadPayGrd = "ONBOARDING_PARTIAL_PROCESS.SP_READ_CAND_INFO";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPartialProcess.CandId;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }
       public DataTable ReadEmpPrtclrInfoById(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
       {
           string strQueryReadPayGrd = "ONBOARDING_PARTIAL_PROCESS.SP_READ_CAND_PRTCLRINFO";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPartialProcess.CandId;
           cmdReadJob.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityPartialProcess.OnbrdDtlId;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }
       public void addVisa(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
       {
           string strQueryReadById = "ONBOARDING_PARTIAL_PROCESS.SP_UPD_VISA";
           using (OracleCommand cmdReadById = new OracleCommand())
           {
               OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
               con.Open();
               cmdReadById.Connection = con;
               cmdReadById.CommandText = strQueryReadById;
               cmdReadById.CommandType = CommandType.StoredProcedure;

               cmdReadById.Parameters.Add("P_ONBRDID", OracleDbType.Int32).Value = objEntityPartialProcess.ReqrmntId;
               cmdReadById.Parameters.Add("P_ONBRD_DTLID", OracleDbType.Int32).Value = objEntityPartialProcess.CorpOffice_Id;
               cmdReadById.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPartialProcess.User_Id;
               cmdReadById.Parameters.Add("P_USERDATE", OracleDbType.Date).Value = objEntityPartialProcess.AsgndDate;


               cmdReadById.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPartialProcess.OnbrdDtlId;
               cmdReadById.Parameters.Add("P_STS", OracleDbType.Int32).Value = objEntityPartialProcess.StatusId;
               if (objEntityPartialProcess.date != DateTime.MinValue)
               {
                   cmdReadById.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPartialProcess.date;
               }
               else
               {
                   cmdReadById.Parameters.Add("P_DATE", OracleDbType.Date).Value = null;
               }
               cmdReadById.Parameters.Add("P_ONBRDDTL_ACT_FILENAME", OracleDbType.Varchar2).Value = objEntityPartialProcess.ActFileName;
               cmdReadById.Parameters.Add("P_ONBRDDTL_FILENAME", OracleDbType.Varchar2).Value = objEntityPartialProcess.FileName;

      
               cmdReadById.ExecuteNonQuery();
           }
       }
       public void addFlight(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
       {
           string strQueryReadById = "ONBOARDING_PARTIAL_PROCESS.SP_UPD_FLIGHT";
           using (OracleCommand cmdReadById = new OracleCommand())
           {
               OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
               con.Open();
               cmdReadById.Connection = con;
               cmdReadById.CommandText = strQueryReadById;
               cmdReadById.CommandType = CommandType.StoredProcedure;
               cmdReadById.Parameters.Add("P_ONBRDID", OracleDbType.Int32).Value = objEntityPartialProcess.ReqrmntId;
               cmdReadById.Parameters.Add("P_ONBRD_DTLID", OracleDbType.Int32).Value = objEntityPartialProcess.CorpOffice_Id;
               cmdReadById.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPartialProcess.User_Id;
               cmdReadById.Parameters.Add("P_USERDATE", OracleDbType.Date).Value = objEntityPartialProcess.AsgndDate;

               cmdReadById.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPartialProcess.OnbrdDtlId;
               cmdReadById.Parameters.Add("P_STS", OracleDbType.Int32).Value = objEntityPartialProcess.StatusId;
               if (objEntityPartialProcess.date != DateTime.MinValue)
               {
                   cmdReadById.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPartialProcess.date;
               }
               else
               {
                   cmdReadById.Parameters.Add("P_DATE", OracleDbType.Date).Value = null;
               }
               cmdReadById.Parameters.Add("P_ONBRDDTL_ACT_FILENAME", OracleDbType.Varchar2).Value = objEntityPartialProcess.ActFileName;
               cmdReadById.Parameters.Add("P_ONBRDDTL_FILENAME", OracleDbType.Varchar2).Value = objEntityPartialProcess.FileName;

               cmdReadById.ExecuteNonQuery();
           }
       }
       public void addRoom(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
       {
           string strQueryReadById = "ONBOARDING_PARTIAL_PROCESS.SP_UPD_ROOM";
           using (OracleCommand cmdReadById = new OracleCommand())
           {
               OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
               con.Open();
               cmdReadById.Connection = con;
               cmdReadById.CommandText = strQueryReadById;
               cmdReadById.CommandType = CommandType.StoredProcedure;

               cmdReadById.Parameters.Add("P_ONBRDID", OracleDbType.Int32).Value = objEntityPartialProcess.ReqrmntId;
               cmdReadById.Parameters.Add("P_ONBRD_DTLID", OracleDbType.Int32).Value = objEntityPartialProcess.CorpOffice_Id;
               cmdReadById.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPartialProcess.User_Id;
               cmdReadById.Parameters.Add("P_USERDATE", OracleDbType.Date).Value = objEntityPartialProcess.AsgndDate;

               cmdReadById.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPartialProcess.OnbrdDtlId;
               cmdReadById.Parameters.Add("P_STS", OracleDbType.Int32).Value = objEntityPartialProcess.StatusId;
               if (objEntityPartialProcess.date != DateTime.MinValue)
               {
                   cmdReadById.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPartialProcess.date;
               }
               else
               {
                   cmdReadById.Parameters.Add("P_DATE", OracleDbType.Date).Value = null;
               }
               cmdReadById.ExecuteNonQuery();
           }
       }

       public void CloseVisa(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
       {
           string strQueryReadById = "ONBOARDING_PARTIAL_PROCESS.SP_CLOSE_VISA";
           using (OracleCommand cmdReadById = new OracleCommand())
           {
               OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
               con.Open();
               cmdReadById.Connection = con;
               cmdReadById.CommandText = strQueryReadById;
               cmdReadById.CommandType = CommandType.StoredProcedure;

               cmdReadById.Parameters.Add("P_ONBRDID", OracleDbType.Int32).Value = objEntityPartialProcess.ReqrmntId;
               cmdReadById.Parameters.Add("P_ONBRD_DTLID", OracleDbType.Int32).Value = objEntityPartialProcess.CorpOffice_Id;
               cmdReadById.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPartialProcess.User_Id;
             

               cmdReadById.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPartialProcess.OnbrdDtlId;
               cmdReadById.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPartialProcess.date;
               cmdReadById.ExecuteNonQuery();
           }
       }
       public void CloseFlight(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
       {
           string strQueryReadById = "ONBOARDING_PARTIAL_PROCESS.SP_CLOSE_FLIGHT";
           using (OracleCommand cmdReadById = new OracleCommand())
           {
               OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
               con.Open();
               cmdReadById.Connection = con;
               cmdReadById.CommandText = strQueryReadById;
               cmdReadById.CommandType = CommandType.StoredProcedure;

               cmdReadById.Parameters.Add("P_ONBRDID", OracleDbType.Int32).Value = objEntityPartialProcess.ReqrmntId;
               cmdReadById.Parameters.Add("P_ONBRD_DTLID", OracleDbType.Int32).Value = objEntityPartialProcess.CorpOffice_Id;
               cmdReadById.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPartialProcess.User_Id;

               cmdReadById.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPartialProcess.OnbrdDtlId;
               cmdReadById.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPartialProcess.date;
               cmdReadById.ExecuteNonQuery();
           }
       }
       public void CloseRoom(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
       {
           string strQueryReadById = "ONBOARDING_PARTIAL_PROCESS.SP_CLOSE_ROOM";
           using (OracleCommand cmdReadById = new OracleCommand())
           {
               OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
               con.Open();
               cmdReadById.Connection = con;
               cmdReadById.CommandText = strQueryReadById;
               cmdReadById.CommandType = CommandType.StoredProcedure;

               cmdReadById.Parameters.Add("P_ONBRDID", OracleDbType.Int32).Value = objEntityPartialProcess.ReqrmntId;
               cmdReadById.Parameters.Add("P_ONBRD_DTLID", OracleDbType.Int32).Value = objEntityPartialProcess.CorpOffice_Id;
               cmdReadById.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPartialProcess.User_Id;

               cmdReadById.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPartialProcess.OnbrdDtlId;
               cmdReadById.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPartialProcess.date;
               cmdReadById.ExecuteNonQuery();
           }
       }
       public void CloseAirpt(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
       {
           string strQueryReadById = "ONBOARDING_PARTIAL_PROCESS.SP_CLOSE_AIRPT";
           using (OracleCommand cmdReadById = new OracleCommand())
           {
               OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
               con.Open();
               cmdReadById.Connection = con;
               cmdReadById.CommandText = strQueryReadById;
               cmdReadById.CommandType = CommandType.StoredProcedure;

               cmdReadById.Parameters.Add("P_ONBRDID", OracleDbType.Int32).Value = objEntityPartialProcess.ReqrmntId;
               cmdReadById.Parameters.Add("P_ONBRD_DTLID", OracleDbType.Int32).Value = objEntityPartialProcess.CorpOffice_Id;
               cmdReadById.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPartialProcess.User_Id;

               cmdReadById.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPartialProcess.OnbrdDtlId;
               cmdReadById.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPartialProcess.date;
               cmdReadById.ExecuteNonQuery();
           }
       }

       public void finishVisaStatus(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
       {
           string strQueryReadById = "ONBOARDING_PARTIAL_PROCESS.SP_FINISH_VISA_STATUS";
           using (OracleCommand cmdReadById = new OracleCommand())
           {
               OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
               con.Open();
               cmdReadById.Connection = con;
               cmdReadById.CommandText = strQueryReadById;
               cmdReadById.CommandType = CommandType.StoredProcedure;
               cmdReadById.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPartialProcess.OnbrdDtlId;
              
               cmdReadById.ExecuteNonQuery();
           }
       }
       public void finishVisa(clsEntityOnBoardingPartialProcess objEntityPartialProcess, string visadtlID, string visaID)
       {
           string strQueryReadById = "ONBOARDING_PARTIAL_PROCESS.SP_FINISH_VISA";
           using (OracleCommand cmdReadById = new OracleCommand())
           {
               OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
               con.Open();
               cmdReadById.Connection = con;
               cmdReadById.CommandText = strQueryReadById;
               cmdReadById.CommandType = CommandType.StoredProcedure;
               cmdReadById.Parameters.Add("VISAID", OracleDbType.Int32).Value = Convert.ToInt32(visaID);
               cmdReadById.Parameters.Add("VISA_DTLID", OracleDbType.Int32).Value = Convert.ToInt32(visadtlID);
               cmdReadById.Parameters.Add("P_ONBRDID", OracleDbType.Int32).Value = objEntityPartialProcess.ReqrmntId;
               cmdReadById.Parameters.Add("P_ONBRD_DTLID", OracleDbType.Int32).Value = objEntityPartialProcess.CorpOffice_Id;
               cmdReadById.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPartialProcess.User_Id;

               cmdReadById.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPartialProcess.OnbrdDtlId;
               cmdReadById.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPartialProcess.date;
               cmdReadById.ExecuteNonQuery();
           }
       }
       public void finishFlight(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
       {
           string strQueryReadById = "ONBOARDING_PARTIAL_PROCESS.SP_FINISH_FLIGHT";
           using (OracleCommand cmdReadById = new OracleCommand())
           {
               OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
               con.Open();
               cmdReadById.Connection = con;
               cmdReadById.CommandText = strQueryReadById;
               cmdReadById.CommandType = CommandType.StoredProcedure;

               cmdReadById.Parameters.Add("P_ONBRDID", OracleDbType.Int32).Value = objEntityPartialProcess.ReqrmntId;
               cmdReadById.Parameters.Add("P_ONBRD_DTLID", OracleDbType.Int32).Value = objEntityPartialProcess.CorpOffice_Id;
               cmdReadById.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPartialProcess.User_Id;

               cmdReadById.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPartialProcess.OnbrdDtlId;
               cmdReadById.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPartialProcess.date;
               cmdReadById.ExecuteNonQuery();
           }
       }
       public void finishRoom(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
       {
           string strQueryReadById = "ONBOARDING_PARTIAL_PROCESS.SP_FINISH_ROOM";
           using (OracleCommand cmdReadById = new OracleCommand())
           {
               OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
               con.Open();
               cmdReadById.Connection = con;
               cmdReadById.CommandText = strQueryReadById;
               cmdReadById.CommandType = CommandType.StoredProcedure;

               cmdReadById.Parameters.Add("P_ONBRDID", OracleDbType.Int32).Value = objEntityPartialProcess.ReqrmntId;
               cmdReadById.Parameters.Add("P_ONBRD_DTLID", OracleDbType.Int32).Value = objEntityPartialProcess.CorpOffice_Id;
               cmdReadById.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPartialProcess.User_Id;

               cmdReadById.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPartialProcess.OnbrdDtlId;
               cmdReadById.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPartialProcess.date;
               cmdReadById.ExecuteNonQuery();
           }
       }
       public void finishAirpt(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
       {
           string strQueryReadById = "ONBOARDING_PARTIAL_PROCESS.SP_FINISH_AIRPT";
           using (OracleCommand cmdReadById = new OracleCommand())
           {
               OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
               con.Open();
               cmdReadById.Connection = con;
               cmdReadById.CommandText = strQueryReadById;
               cmdReadById.CommandType = CommandType.StoredProcedure;

               cmdReadById.Parameters.Add("P_ONBRDID", OracleDbType.Int32).Value = objEntityPartialProcess.ReqrmntId;
               cmdReadById.Parameters.Add("P_ONBRD_DTLID", OracleDbType.Int32).Value = objEntityPartialProcess.CorpOffice_Id;
               cmdReadById.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPartialProcess.User_Id;

               cmdReadById.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPartialProcess.OnbrdDtlId;
               cmdReadById.Parameters.Add("P_DATE", OracleDbType.Date).Value = objEntityPartialProcess.date;
               cmdReadById.ExecuteNonQuery();
           }
       }

       public DataTable ReadAsgndEmpPartclr(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
       {
           string strQueryReadPayGrd = "ONBOARDING_PARTIAL_PROCESS.SP_READ_ASGNDEMP_PRTCLRINFO";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_DTLID", OracleDbType.Int32).Value = objEntityPartialProcess.OnbrdDtlId;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }

       public DataTable checkFinishOrClsed(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
       {
           string strQueryReadPayGrd = "ONBOARDING_PARTIAL_PROCESS.SP_CHECK_FINSH_CLS";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
         
           cmdReadJob.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPartialProcess.OnbrdDtlId;
           cmdReadJob.Parameters.Add("P_PRTCLR_ID", OracleDbType.Int32).Value = objEntityPartialProcess.StatusId;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }
       public DataTable ReadVisaQuota(clsEntityOnBoardingPartialProcess objEntityPartialProcess)
       {
           string strQueryReadPayGrd = "ONBOARDING_PARTIAL_PROCESS.SP_READ_VISA_QUOTA";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPartialProcess.Organisation_Id;
           cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPartialProcess.CorpOffice_Id;
           cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPartialProcess.User_Id;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }
       public DataTable ReadVisaQuota(clsEntityOnBoardingPartialProcess objEntityPartialProcess, int intvisatyp, int intNationId)
       {
           string strQueryReadPayGrd = "ONBOARDING_PARTIAL_PROCESS.SP_READ_VISA_QUOTA_BY_CHECKING";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("VISATYPE_ID", OracleDbType.Int32).Value = intvisatyp;
           cmdReadJob.Parameters.Add("NATION_ID", OracleDbType.Int32).Value = intNationId;
           cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPartialProcess.Organisation_Id;
           cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityPartialProcess.CorpOffice_Id;
           cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityPartialProcess.User_Id;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }

       public DataTable ReadVisaDetails(string VisaqtID,string CntryNm)
       {
           string strQueryReadPayGrd = "ONBOARDING_PARTIAL_PROCESS.SP_READ_VISA_DETAILS";
           OracleCommand cmdReadJob = new OracleCommand();
           cmdReadJob.CommandText = strQueryReadPayGrd;
           cmdReadJob.CommandType = CommandType.StoredProcedure;
           cmdReadJob.Parameters.Add("P_ID", OracleDbType.Varchar2).Value = VisaqtID;
           cmdReadJob.Parameters.Add("C_NAM", OracleDbType.Varchar2).Value = CntryNm;
           cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
           DataTable dtCategory = new DataTable();
           dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
           return dtCategory;
       }
    }
}
