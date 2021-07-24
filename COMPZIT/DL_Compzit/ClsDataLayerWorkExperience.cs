using System;
using System.Data;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EL_Compzit;

namespace DL_Compzit
{
   //Data Layer for Qualification:Work Experience
   public class ClsDataLayerWorkExperience
    {
       public void insertWorkExp(ClsEntityLayerWorkExperience objEntityWorkExperience)
       {
           string strQueryAddPersnlDtls = "EMPLOYEE_QUALIFICATION.SP_INS_WRKEXP_DETAILS";
           using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
           {
               cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
               cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
               cmdAddPersnlDtls.Parameters.Add("WE_EMPUSRID", OracleDbType.Int32).Value = objEntityWorkExperience.EmpUser_id;
               cmdAddPersnlDtls.Parameters.Add("WE_CMPNY", OracleDbType.Varchar2).Value = objEntityWorkExperience.CompanyName;
               cmdAddPersnlDtls.Parameters.Add("WE_JOBTL", OracleDbType.Varchar2).Value = objEntityWorkExperience.JobTitle;
               if (objEntityWorkExperience.FromDate != DateTime.MinValue)
               {
                   cmdAddPersnlDtls.Parameters.Add("WE_FROM", OracleDbType.Date).Value = objEntityWorkExperience.FromDate;
               }
               else
               {
                   cmdAddPersnlDtls.Parameters.Add("WE_FROM", OracleDbType.Date).Value = null;
               }
               if (objEntityWorkExperience.ToDate != DateTime.MinValue)
               {
                   cmdAddPersnlDtls.Parameters.Add("WE_TO", OracleDbType.Date).Value = objEntityWorkExperience.ToDate;
               }
               else
               {
                   cmdAddPersnlDtls.Parameters.Add("WE_TO", OracleDbType.Date).Value = null;
               }
               cmdAddPersnlDtls.Parameters.Add("WE_CMNT", OracleDbType.Varchar2).Value = objEntityWorkExperience.Comment;
               cmdAddPersnlDtls.Parameters.Add("WE_FNAME", OracleDbType.Varchar2).Value = objEntityWorkExperience.Fname;
               cmdAddPersnlDtls.Parameters.Add("WE_ACTFNAME", OracleDbType.Varchar2).Value = objEntityWorkExperience.ActFname;
               cmdAddPersnlDtls.Parameters.Add("WE_REFCHKID", OracleDbType.Int32).Value = objEntityWorkExperience.Refcheck_id;
               cmdAddPersnlDtls.Parameters.Add("WE_REFNAME", OracleDbType.Varchar2).Value = objEntityWorkExperience.RefName;
               cmdAddPersnlDtls.Parameters.Add("WE_REFDESG", OracleDbType.Varchar2).Value = objEntityWorkExperience.RefDesgntn;
               cmdAddPersnlDtls.Parameters.Add("WE_INSUSRID", OracleDbType.Int32).Value = objEntityWorkExperience.User_id;
               cmdAddPersnlDtls.Parameters.Add("WE_INSDATE", OracleDbType.Date).Value = objEntityWorkExperience.Date;
               cmdAddPersnlDtls.Parameters.Add("WE_CORPRTID", OracleDbType.Int32).Value = objEntityWorkExperience.Corporate_id;
               cmdAddPersnlDtls.Parameters.Add("WE_ORGID", OracleDbType.Int32).Value = objEntityWorkExperience.Organisation_id;
               clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
           }
           //string strQueryAddLeaveType = "USER_REGISTERATION.SP_RD_LV_TYPE_EXPERIENCE";
           //using (OracleCommand cmdAddLeaveType = new OracleCommand())
           //{
           //    cmdAddLeaveType.CommandText = strQueryAddLeaveType;
           //    cmdAddLeaveType.CommandType = CommandType.StoredProcedure;
           //    cmdAddLeaveType.Parameters.Add("D_EXP_ID", OracleDbType.Int32).Value = objEntityWorkExperience.WorkExpDtl_id;
           //    cmdAddLeaveType.Parameters.Add("D_ORG_ID", OracleDbType.Int32).Value = objEntityWorkExperience.Organisation_id;
           //    cmdAddLeaveType.Parameters.Add("D_CORP_ID", OracleDbType.Int32).Value = objEntityWorkExperience.Corporate_id;
           //    cmdAddLeaveType.Parameters.Add("D_USR_ID", OracleDbType.Int32).Value = objEntityWorkExperience.EmpUser_id;
           //    clsDataLayer.ExecuteNonQuery(cmdAddLeaveType);
           //}


       }
       public void updateWorkExp(ClsEntityLayerWorkExperience objEntityWorkExperience)
       {
           string strQueryAddPersnlDtls = "EMPLOYEE_QUALIFICATION.SP_UPD_WRKEXP_DETAILS";
           using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
           {
               cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
               cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
               cmdAddPersnlDtls.Parameters.Add("WE_WRKEXPID", OracleDbType.Int32).Value = objEntityWorkExperience.WorkExpDtl_id;
               cmdAddPersnlDtls.Parameters.Add("WE_CMPNY", OracleDbType.Varchar2).Value = objEntityWorkExperience.CompanyName;
               cmdAddPersnlDtls.Parameters.Add("WE_JOBTL", OracleDbType.Varchar2).Value = objEntityWorkExperience.JobTitle;
               if (objEntityWorkExperience.FromDate != DateTime.MinValue)
               {
                   cmdAddPersnlDtls.Parameters.Add("WE_FROM", OracleDbType.Date).Value = objEntityWorkExperience.FromDate;
               }
               else
               {
                   cmdAddPersnlDtls.Parameters.Add("WE_FROM", OracleDbType.Date).Value = null;
               }
               if (objEntityWorkExperience.ToDate != DateTime.MinValue)
               {
                   cmdAddPersnlDtls.Parameters.Add("WE_TO", OracleDbType.Date).Value = objEntityWorkExperience.ToDate;
               }
               else
               {
                   cmdAddPersnlDtls.Parameters.Add("WE_TO", OracleDbType.Date).Value = null;
               }
               cmdAddPersnlDtls.Parameters.Add("WE_CMNT", OracleDbType.Varchar2).Value = objEntityWorkExperience.Comment;
               cmdAddPersnlDtls.Parameters.Add("WE_FNAME", OracleDbType.Varchar2).Value = objEntityWorkExperience.Fname;
               cmdAddPersnlDtls.Parameters.Add("WE_ACTFNAME", OracleDbType.Varchar2).Value = objEntityWorkExperience.ActFname;
               cmdAddPersnlDtls.Parameters.Add("WE_REFCHKID", OracleDbType.Int32).Value = objEntityWorkExperience.Refcheck_id;
               cmdAddPersnlDtls.Parameters.Add("WE_REFNAME", OracleDbType.Varchar2).Value = objEntityWorkExperience.RefName;
               cmdAddPersnlDtls.Parameters.Add("WE_REFDESG", OracleDbType.Varchar2).Value = objEntityWorkExperience.RefDesgntn;
               cmdAddPersnlDtls.Parameters.Add("WE_UPDUSRID", OracleDbType.Int32).Value = objEntityWorkExperience.User_id;
               cmdAddPersnlDtls.Parameters.Add("WE_UPDDATE", OracleDbType.Date).Value = objEntityWorkExperience.Date;
               clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
           }
       }
       public DataTable readWrkExpList(ClsEntityLayerWorkExperience objEntityWorkExperience)
       {
           string strQueryReadCountry = "EMPLOYEE_QUALIFICATION.SP_READ_WRKEXP_LIST";
           using (OracleCommand cmdReadCountry = new OracleCommand())
           {
               cmdReadCountry.CommandText = strQueryReadCountry;
               cmdReadCountry.CommandType = CommandType.StoredProcedure;
               cmdReadCountry.Parameters.Add("WE_EMPID", OracleDbType.Int32).Value = objEntityWorkExperience.EmpUser_id;
               cmdReadCountry.Parameters.Add("WE_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCountry = new DataTable();
               dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
               return dtCountry;
           }
       }
       public DataTable ReadWrkExpDtlById(ClsEntityLayerWorkExperience objEntityWorkExperience)
       {
           string strQueryReadCountry = "EMPLOYEE_QUALIFICATION.SP_READ_WRKEXP_DTL_BYID";
           using (OracleCommand cmdReadCountry = new OracleCommand())
           {
               cmdReadCountry.CommandText = strQueryReadCountry;
               cmdReadCountry.CommandType = CommandType.StoredProcedure;
               cmdReadCountry.Parameters.Add("WE_WRKEXP_ID", OracleDbType.Int32).Value = objEntityWorkExperience.WorkExpDtl_id;
               cmdReadCountry.Parameters.Add("WE_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCountry = new DataTable();
               dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
               return dtCountry;
           }
       }
       public void DeleteWrkExpDtl(ClsEntityLayerWorkExperience objEntityWorkExperience)
       {
           string strQueryAddPersnlDtls = "EMPLOYEE_QUALIFICATION.SP_DELE_WRKEXP_DETAILS";
           using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
           {
               cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
               cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
               cmdAddPersnlDtls.Parameters.Add("WE_ID", OracleDbType.Int32).Value = objEntityWorkExperience.WorkExpDtl_id;
               clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
           }
       }
    }
   //Data Layer for Qualification:Education
   public class ClsDataLayerEducation
   {
       public DataTable ReadEduLvl()
       {
           string strQueryReadCountry = "EMPLOYEE_QUALIFICATION.SP_EDULVL_LOAD";
           using (OracleCommand cmdReadCountry = new OracleCommand())
           {
               cmdReadCountry.CommandText = strQueryReadCountry;
               cmdReadCountry.CommandType = CommandType.StoredProcedure;
               cmdReadCountry.Parameters.Add("E_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCountry = new DataTable();
               dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
               return dtCountry;
           }
       }
       public void insertEducation(ClsEntityLayerEducation objEntityEducation)
       {
           string strQueryAddPersnlDtls = "EMPLOYEE_QUALIFICATION.SP_INS_EDUCTN_DETAILS";
           using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
           {
               cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
               cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
               cmdAddPersnlDtls.Parameters.Add("E_EMPUSRID", OracleDbType.Int32).Value = objEntityEducation.EmpUser_id;
               cmdAddPersnlDtls.Parameters.Add("E_LVLID", OracleDbType.Int32).Value = objEntityEducation.EduLevelId;
               cmdAddPersnlDtls.Parameters.Add("E_INSTI", OracleDbType.Varchar2).Value = objEntityEducation.Institute;
               cmdAddPersnlDtls.Parameters.Add("E_MJRSPE", OracleDbType.Varchar2).Value = objEntityEducation.MajorSpec;
               if (objEntityEducation.Year != 0)
               {
                   cmdAddPersnlDtls.Parameters.Add("E_YEAR", OracleDbType.Int32).Value = objEntityEducation.Year;
               }
               else
               {
                   cmdAddPersnlDtls.Parameters.Add("E_YEAR", OracleDbType.Int32).Value = null;
               }
               if (objEntityEducation.GPAscore != 0)
               {
                   cmdAddPersnlDtls.Parameters.Add("E_SCORE", OracleDbType.Decimal).Value = objEntityEducation.GPAscore;
               }
               else{
                   cmdAddPersnlDtls.Parameters.Add("E_SCORE", OracleDbType.Decimal).Value = null;
               }
               cmdAddPersnlDtls.Parameters.Add("E_FNAME", OracleDbType.Varchar2).Value = objEntityEducation.Fname;
               cmdAddPersnlDtls.Parameters.Add("E_ACTFNAME", OracleDbType.Varchar2).Value = objEntityEducation.ActFname;
               if (objEntityEducation.StartDate != DateTime.MinValue)
               {
                   cmdAddPersnlDtls.Parameters.Add("E_STRT_DATE", OracleDbType.Date).Value = objEntityEducation.StartDate;
               }
               else
               {
                   cmdAddPersnlDtls.Parameters.Add("E_STRT_DATE", OracleDbType.Date).Value = null;
               }
               if (objEntityEducation.EndDate != DateTime.MinValue)
               {
                   cmdAddPersnlDtls.Parameters.Add("E_END_DATE", OracleDbType.Date).Value = objEntityEducation.EndDate;
               }
               else
               {
                   cmdAddPersnlDtls.Parameters.Add("E_END_DATE", OracleDbType.Date).Value = null;
               }
               cmdAddPersnlDtls.Parameters.Add("E_INSUSRID", OracleDbType.Int32).Value = objEntityEducation.User_id;
               cmdAddPersnlDtls.Parameters.Add("E_INSDATE", OracleDbType.Date).Value = objEntityEducation.Date;
               cmdAddPersnlDtls.Parameters.Add("E_CORPRTID", OracleDbType.Int32).Value = objEntityEducation.Corporate_id;
               cmdAddPersnlDtls.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityEducation.Organisation_id;
               clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
           }
       }
       public void updateEducation(ClsEntityLayerEducation objEntityEducation)
       {
           string strQueryAddPersnlDtls = "EMPLOYEE_QUALIFICATION.SP_UPD_EDUCTN_DETAILS";
           using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
           {
               cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
               cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
               cmdAddPersnlDtls.Parameters.Add("E_EDUDTLID", OracleDbType.Int32).Value = objEntityEducation.EductnDtl_Id;
               cmdAddPersnlDtls.Parameters.Add("E_LVLID", OracleDbType.Int32).Value = objEntityEducation.EduLevelId;
               cmdAddPersnlDtls.Parameters.Add("E_INSTI", OracleDbType.Varchar2).Value = objEntityEducation.Institute;
               cmdAddPersnlDtls.Parameters.Add("E_MJRSPE", OracleDbType.Varchar2).Value = objEntityEducation.MajorSpec;
               if (objEntityEducation.Year != 0)
               {
                   cmdAddPersnlDtls.Parameters.Add("E_YEAR", OracleDbType.Int32).Value = objEntityEducation.Year;
               }
               else
               {
                   cmdAddPersnlDtls.Parameters.Add("E_YEAR", OracleDbType.Int32).Value = null;
               }
               if (objEntityEducation.GPAscore != 0)
               {
                   cmdAddPersnlDtls.Parameters.Add("E_SCORE", OracleDbType.Decimal).Value = objEntityEducation.GPAscore;
               }
               else
               {
                   cmdAddPersnlDtls.Parameters.Add("E_SCORE", OracleDbType.Decimal).Value = null;
               }
               cmdAddPersnlDtls.Parameters.Add("E_FNAME", OracleDbType.Varchar2).Value = objEntityEducation.Fname;
               cmdAddPersnlDtls.Parameters.Add("E_ACTFNAME", OracleDbType.Varchar2).Value = objEntityEducation.ActFname;
               if (objEntityEducation.StartDate != DateTime.MinValue)
               {
                   cmdAddPersnlDtls.Parameters.Add("E_STRT_DATE", OracleDbType.Date).Value = objEntityEducation.StartDate;
               }
               else
               {
                   cmdAddPersnlDtls.Parameters.Add("E_STRT_DATE", OracleDbType.Date).Value = null;
               }
               if (objEntityEducation.EndDate != DateTime.MinValue)
               {
                   cmdAddPersnlDtls.Parameters.Add("E_END_DATE", OracleDbType.Date).Value = objEntityEducation.EndDate;
               }
               else
               {
                   cmdAddPersnlDtls.Parameters.Add("E_END_DATE", OracleDbType.Date).Value = null;
               }
               cmdAddPersnlDtls.Parameters.Add("E_UPDUSRID", OracleDbType.Int32).Value = objEntityEducation.User_id;
               cmdAddPersnlDtls.Parameters.Add("E_UPDDATE", OracleDbType.Date).Value = objEntityEducation.Date;
               clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
           }
       }
       public DataTable readEduList(ClsEntityLayerEducation objEntityEducation)
       {
           string strQueryReadCountry = "EMPLOYEE_QUALIFICATION.SP_READ_EDUCTN_LIST";
           using (OracleCommand cmdReadCountry = new OracleCommand())
           {
               cmdReadCountry.CommandText = strQueryReadCountry;
               cmdReadCountry.CommandType = CommandType.StoredProcedure;
               cmdReadCountry.Parameters.Add("E_EMPID", OracleDbType.Int32).Value = objEntityEducation.EmpUser_id;
               cmdReadCountry.Parameters.Add("E_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCountry = new DataTable();
               dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
               return dtCountry;
           }
       }

       public DataTable ReadEduDtlById(ClsEntityLayerEducation objEntityEducation)
       {
           string strQueryReadCountry = "EMPLOYEE_QUALIFICATION.SP_READ_EDU_DTL_BYID";
           using (OracleCommand cmdReadCountry = new OracleCommand())
           {
               cmdReadCountry.CommandText = strQueryReadCountry;
               cmdReadCountry.CommandType = CommandType.StoredProcedure;
               cmdReadCountry.Parameters.Add("E_ID", OracleDbType.Int32).Value = objEntityEducation.EductnDtl_Id;
               cmdReadCountry.Parameters.Add("E_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCountry = new DataTable();
               dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
               return dtCountry;
           }
       }
       public void deleteEduById(ClsEntityLayerEducation objEntityEducation)
       {
           string strQueryAddPersnlDtls = "EMPLOYEE_QUALIFICATION.SP_DELE_EDU_DETAILS";
           using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
           {
               cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
               cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
               cmdAddPersnlDtls.Parameters.Add("E_ID", OracleDbType.Int32).Value = objEntityEducation.EductnDtl_Id;
               clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
           }
       }


   }
   //Data Layer for Qualification:Skills And certifications
   public class ClsDataLayerSkillCertfcn
   {

       public DataTable ReadSkillDropdown()
       {
           string strQueryReadCountry = "EMPLOYEE_QUALIFICATION.SP_SKILL_LOAD";
           using (OracleCommand cmdReadCountry = new OracleCommand())
           {
               cmdReadCountry.CommandText = strQueryReadCountry;
               cmdReadCountry.CommandType = CommandType.StoredProcedure;
               cmdReadCountry.Parameters.Add("SC_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCountry = new DataTable();
               dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
               return dtCountry;
           }
       }
       public void insertSkillCertfcn(ClsEntityLayerSkillCertifcn objEntitySkillCertfcn)
       {
           string strQueryAddPersnlDtls = "EMPLOYEE_QUALIFICATION.SP_INS_SKLCER_DETAILS";
           using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
           {
               cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
               cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
               cmdAddPersnlDtls.Parameters.Add("SC_EMPUSRID", OracleDbType.Int32).Value = objEntitySkillCertfcn.EmpUser_id;
               cmdAddPersnlDtls.Parameters.Add("SC_CBX_SKCERID", OracleDbType.Int32).Value = objEntitySkillCertfcn.cbxSklCerId;
               if (objEntitySkillCertfcn.SkillId != 0)
               {
                   cmdAddPersnlDtls.Parameters.Add("SC_SKLID", OracleDbType.Int32).Value = objEntitySkillCertfcn.SkillId;
               }
               else
               {
                   cmdAddPersnlDtls.Parameters.Add("SC_SKLID", OracleDbType.Int32).Value  = null;
               }
               cmdAddPersnlDtls.Parameters.Add("SC_CER", OracleDbType.Varchar2).Value = objEntitySkillCertfcn.Certfcn;
               if (objEntitySkillCertfcn.year != 0)
               {
                   cmdAddPersnlDtls.Parameters.Add("SC_YEAR", OracleDbType.Int32).Value = objEntitySkillCertfcn.year;
               }
               else
               {
                   cmdAddPersnlDtls.Parameters.Add("SC_YEAR", OracleDbType.Int32).Value = null;
               }
               cmdAddPersnlDtls.Parameters.Add("SC_CMNT", OracleDbType.Varchar2).Value = objEntitySkillCertfcn.Comment;
               cmdAddPersnlDtls.Parameters.Add("SC_FNAME", OracleDbType.Varchar2).Value = objEntitySkillCertfcn.Fname;
               cmdAddPersnlDtls.Parameters.Add("SC_ACTFNAME", OracleDbType.Varchar2).Value = objEntitySkillCertfcn.ActFname;
               cmdAddPersnlDtls.Parameters.Add("SC_INSUSRID", OracleDbType.Int32).Value = objEntitySkillCertfcn.User_id;
               cmdAddPersnlDtls.Parameters.Add("SC_INSDATE", OracleDbType.Date).Value = objEntitySkillCertfcn.Date;
               cmdAddPersnlDtls.Parameters.Add("SC_CORPRTID", OracleDbType.Int32).Value = objEntitySkillCertfcn.Corporate_id;
               cmdAddPersnlDtls.Parameters.Add("SC_ORGID", OracleDbType.Int32).Value = objEntitySkillCertfcn.Organisation_id;
               clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
           }
       }
       public void updateSkillCertfcn(ClsEntityLayerSkillCertifcn objEntitySkillCertfcn)
       {
           string strQueryAddPersnlDtls = "EMPLOYEE_QUALIFICATION.SP_UPD_SKLCER_DETAILS";
           using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
           {
               cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
               cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
               cmdAddPersnlDtls.Parameters.Add("SC_SKCER_ID", OracleDbType.Int32).Value = objEntitySkillCertfcn.SklCerfnDtlId;
               cmdAddPersnlDtls.Parameters.Add("SC_CBX_SKCERID", OracleDbType.Int32).Value = objEntitySkillCertfcn.cbxSklCerId;
               if (objEntitySkillCertfcn.SkillId != 0)
               {
                   cmdAddPersnlDtls.Parameters.Add("SC_SKLID", OracleDbType.Int32).Value = objEntitySkillCertfcn.SkillId;
               }
               else
               {
                   cmdAddPersnlDtls.Parameters.Add("SC_SKLID", OracleDbType.Int32).Value = null;
               }
               cmdAddPersnlDtls.Parameters.Add("SC_CER", OracleDbType.Varchar2).Value = objEntitySkillCertfcn.Certfcn;
               if (objEntitySkillCertfcn.year != 0)
               {
                   cmdAddPersnlDtls.Parameters.Add("SC_YEAR", OracleDbType.Int32).Value = objEntitySkillCertfcn.year;
               }
               else
               {
                   cmdAddPersnlDtls.Parameters.Add("SC_YEAR", OracleDbType.Int32).Value = null;
               }
               cmdAddPersnlDtls.Parameters.Add("SC_CMNT", OracleDbType.Varchar2).Value = objEntitySkillCertfcn.Comment;
               cmdAddPersnlDtls.Parameters.Add("SC_FNAME", OracleDbType.Varchar2).Value = objEntitySkillCertfcn.Fname;
               cmdAddPersnlDtls.Parameters.Add("SC_ACTFNAME", OracleDbType.Varchar2).Value = objEntitySkillCertfcn.ActFname;
               cmdAddPersnlDtls.Parameters.Add("SC_UPDUSRID", OracleDbType.Int32).Value = objEntitySkillCertfcn.User_id;
               cmdAddPersnlDtls.Parameters.Add("SC_UPDDATE", OracleDbType.Date).Value = objEntitySkillCertfcn.Date;
               clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
           }
       }
       public DataTable readSklCerList(ClsEntityLayerSkillCertifcn objEntitySkillCertfcn)
       {
           string strQueryReadCountry = "EMPLOYEE_QUALIFICATION.SP_SKLCER_LIST";
           using (OracleCommand cmdReadCountry = new OracleCommand())
           {
               cmdReadCountry.CommandText = strQueryReadCountry;
               cmdReadCountry.CommandType = CommandType.StoredProcedure;
               cmdReadCountry.Parameters.Add("SC_EMPUSRID", OracleDbType.Int32).Value = objEntitySkillCertfcn.EmpUser_id;
               cmdReadCountry.Parameters.Add("SC_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCountry = new DataTable();
               dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
               return dtCountry;
           }
       }

       public DataTable ReadSklCerDtlById(ClsEntityLayerSkillCertifcn objEntitySkillCertfcn)
       {
           string strQueryReadCountry = "EMPLOYEE_QUALIFICATION.SP_SKLCER_BYID";
           using (OracleCommand cmdReadCountry = new OracleCommand())
           {
               cmdReadCountry.CommandText = strQueryReadCountry;
               cmdReadCountry.CommandType = CommandType.StoredProcedure;
               cmdReadCountry.Parameters.Add("SC_ID", OracleDbType.Int32).Value = objEntitySkillCertfcn.SklCerfnDtlId;
               cmdReadCountry.Parameters.Add("SC_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCountry = new DataTable();
               dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
               return dtCountry;
           }
       }
       public void DeleSkillCertfcn(ClsEntityLayerSkillCertifcn objEntitySkillCertfcn)
       {
           string strQueryAddPersnlDtls = "EMPLOYEE_QUALIFICATION.SP_DELE_SKLCER_DETAILS";
           using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
           {
               cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
               cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
               cmdAddPersnlDtls.Parameters.Add("SC_ID", OracleDbType.Int32).Value = objEntitySkillCertfcn.SklCerfnDtlId;
               clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
           }
       }
   }
   //Data Layer for Qualification:Language
   public class ClsDataLayerLanguage
   {
       public DataTable ReadLanguage()
       {
           string strQueryReadCountry = "EMPLOYEE_QUALIFICATION.SP_LANG_LOAD";
           using (OracleCommand cmdReadCountry = new OracleCommand())
           {
               cmdReadCountry.CommandText = strQueryReadCountry;
               cmdReadCountry.CommandType = CommandType.StoredProcedure;
               cmdReadCountry.Parameters.Add("L_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCountry = new DataTable();
               dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
               return dtCountry;
           }
       }
       public void insertLanguageDtl(ClsEntityLayerLanguage objEntityLanguage)
       {
           string strQueryAddPersnlDtls = "EMPLOYEE_QUALIFICATION.SP_INS_LANG_DETAILS";
           using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
           {
               cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
               cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
               cmdAddPersnlDtls.Parameters.Add("L_EMPUSRID", OracleDbType.Int32).Value = objEntityLanguage.EmpUser_id;
               cmdAddPersnlDtls.Parameters.Add("L_LANGID", OracleDbType.Int32).Value = objEntityLanguage.LanguageId;
               cmdAddPersnlDtls.Parameters.Add("L_LANGWRT_ID", OracleDbType.Int32).Value = objEntityLanguage.LangWriteId;
               cmdAddPersnlDtls.Parameters.Add("L_LANGRED_ID", OracleDbType.Int32).Value = objEntityLanguage.LangReadId;
               cmdAddPersnlDtls.Parameters.Add("L_LANGSPK_ID", OracleDbType.Int32).Value = objEntityLanguage.LangSpeakId;
               cmdAddPersnlDtls.Parameters.Add("L_FLNCYLVL_ID", OracleDbType.Int32).Value = objEntityLanguage.FlncyLvlId;
               cmdAddPersnlDtls.Parameters.Add("L_CMNT", OracleDbType.Varchar2).Value = objEntityLanguage.Comment;
               cmdAddPersnlDtls.Parameters.Add("L_INSUSRID", OracleDbType.Int32).Value = objEntityLanguage.User_id;
               cmdAddPersnlDtls.Parameters.Add("L_INSDATE", OracleDbType.Date).Value = objEntityLanguage.Date;
               cmdAddPersnlDtls.Parameters.Add("L_CORPRTID", OracleDbType.Int32).Value = objEntityLanguage.Corporate_id;
               cmdAddPersnlDtls.Parameters.Add("L_ORGID", OracleDbType.Int32).Value = objEntityLanguage.Organisation_id;
               clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
           }
       }
       public void updateLanguageDtl(ClsEntityLayerLanguage objEntityLanguage)
       {
           string strQueryAddPersnlDtls = "EMPLOYEE_QUALIFICATION.SP_UPD_LANG_DETAILS";
           using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
           {
               cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
               cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
               cmdAddPersnlDtls.Parameters.Add("L_LANGDTLID", OracleDbType.Int32).Value = objEntityLanguage.LangdtlId;
               cmdAddPersnlDtls.Parameters.Add("L_LANGID", OracleDbType.Int32).Value = objEntityLanguage.LanguageId;
               cmdAddPersnlDtls.Parameters.Add("L_LANGWRT_ID", OracleDbType.Int32).Value = objEntityLanguage.LangWriteId;
               cmdAddPersnlDtls.Parameters.Add("L_LANGRED_ID", OracleDbType.Int32).Value = objEntityLanguage.LangReadId;
               cmdAddPersnlDtls.Parameters.Add("L_LANGSPK_ID", OracleDbType.Int32).Value = objEntityLanguage.LangSpeakId;
               cmdAddPersnlDtls.Parameters.Add("L_FLNCYLVL_ID", OracleDbType.Int32).Value = objEntityLanguage.FlncyLvlId;
               cmdAddPersnlDtls.Parameters.Add("L_CMNT", OracleDbType.Varchar2).Value = objEntityLanguage.Comment;
               cmdAddPersnlDtls.Parameters.Add("L_UPDUSRID", OracleDbType.Int32).Value = objEntityLanguage.User_id;
               cmdAddPersnlDtls.Parameters.Add("L_UPDDATE", OracleDbType.Date).Value = objEntityLanguage.Date;
               clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
           }
       }
       public DataTable readLangList(ClsEntityLayerLanguage objEntityLanguage)
       {
           string strQueryReadCountry = "EMPLOYEE_QUALIFICATION.SP_LANG_LIST";
           using (OracleCommand cmdReadCountry = new OracleCommand())
           {
               cmdReadCountry.CommandText = strQueryReadCountry;
               cmdReadCountry.CommandType = CommandType.StoredProcedure;
               cmdReadCountry.Parameters.Add("L_EMPUSRID", OracleDbType.Int32).Value = objEntityLanguage.EmpUser_id;
               cmdReadCountry.Parameters.Add("L_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCountry = new DataTable();
               dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
               return dtCountry;
           }
       }
       public DataTable ReadLangDtlById(ClsEntityLayerLanguage objEntityLanguage)
       {
           string strQueryReadCountry = "EMPLOYEE_QUALIFICATION.SP_LANGDTLS_BYID";
           using (OracleCommand cmdReadCountry = new OracleCommand())
           {
               cmdReadCountry.CommandText = strQueryReadCountry;
               cmdReadCountry.CommandType = CommandType.StoredProcedure;
               cmdReadCountry.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLanguage.LangdtlId;
               cmdReadCountry.Parameters.Add("L_DTL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
               DataTable dtCountry = new DataTable();
               dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
               return dtCountry;
           }
       }
       public void deleteLanguageDtl(ClsEntityLayerLanguage objEntityLanguage)
       {
           string strQueryAddPersnlDtls = "EMPLOYEE_QUALIFICATION.SP_DELE_LANG_DETAILS";
           using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
           {
               cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
               cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
               cmdAddPersnlDtls.Parameters.Add("L_ID", OracleDbType.Int32).Value = objEntityLanguage.LangdtlId;
               clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
           }
       }

   }
}
