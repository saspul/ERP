using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using EL_Compzit.EntityLayer_HCM;

namespace DL_Compzit.DataLayer_HCM
{
    //Data Layer for Qualification:Work Experience
    public class clsDataLayerStaffWorkExperience
    {
        public void insertWorkExp(clsEntityLayerStaffWorkExperience objEntityWorkExperience)
        {
            string strQueryAddPersnlDtls = "STAFF_QUALIFICATION.SP_INSERT_STAFF_WRK_EXP";
            using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
            {
                cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
                cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;

                cmdAddPersnlDtls.Parameters.Add("S_CAND_ID", OracleDbType.Int32).Value = objEntityWorkExperience.CandidateID;

                //evm-0023
                if (objEntityWorkExperience.WrkExpYears != 0)
                {
                    cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_EXP_YR", OracleDbType.Decimal).Value = objEntityWorkExperience.WrkExpYears;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_EXP_YR", OracleDbType.Decimal).Value = null;
                }
                if (objEntityWorkExperience.WrkGCCExpYears != 0)
                {
                    cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_GCC_EXP", OracleDbType.Decimal).Value = objEntityWorkExperience.WrkGCCExpYears;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_GCC_EXP", OracleDbType.Decimal).Value = null;
                }//evm-0023
                cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_NAME_LST_EMP", OracleDbType.Varchar2).Value = objEntityWorkExperience.WrkEmpName;
                cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_ADDR_LST_EMP", OracleDbType.Varchar2).Value = objEntityWorkExperience.WrkAddress;
                if (objEntityWorkExperience.LastWrkJoiningDate != DateTime.MinValue)
                {
                    cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_DT_JOINING", OracleDbType.Date).Value = objEntityWorkExperience.LastWrkJoiningDate;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_DT_JOINING", OracleDbType.Date).Value = null;
                }
                if (objEntityWorkExperience.LastWrkLeavingDate != DateTime.MinValue)
                {
                    cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_DT_LEAVING", OracleDbType.Date).Value = objEntityWorkExperience.LastWrkLeavingDate;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_DT_LEAVING", OracleDbType.Date).Value = null;
                }
                cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_DSGN", OracleDbType.Varchar2).Value = objEntityWorkExperience.Designation;
                //evm-0023
                if (objEntityWorkExperience.StrSalary != "")
                {
                    cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_SALARY", OracleDbType.Varchar2).Value = objEntityWorkExperience.StrSalary;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_SALARY", OracleDbType.Varchar2).Value = null;
                } //evm-0023
                cmdAddPersnlDtls.Parameters.Add("S_ORG_ID", OracleDbType.Int32).Value = objEntityWorkExperience.Organisation_id;
                cmdAddPersnlDtls.Parameters.Add("S_CORPRT_ID", OracleDbType.Int32).Value = objEntityWorkExperience.Corporate_id;
                cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_INS_USR_ID", OracleDbType.Int32).Value = objEntityWorkExperience.User_id;
                cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_INS_DATE", OracleDbType.Date).Value = objEntityWorkExperience.Date;

                clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
            }
        }
        public void updateWorkExp(clsEntityLayerStaffWorkExperience objEntityWorkExperience)
        {
            string strQueryAddPersnlDtls = "STAFF_QUALIFICATION.SP_UPDATE_STAFF_WRK_EXP";
            using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
            {
                cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
                cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
                cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_EXP_ID", OracleDbType.Int32).Value = objEntityWorkExperience.WorkExpDtl_id;
                cmdAddPersnlDtls.Parameters.Add("S_CAND_ID", OracleDbType.Int32).Value = objEntityWorkExperience.CandidateID;
                if (objEntityWorkExperience.WrkExpYears != -1)
                {
                    cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_EXP_YR", OracleDbType.Decimal).Value = objEntityWorkExperience.WrkExpYears;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_EXP_YR", OracleDbType.Decimal).Value = DBNull.Value;
                }

                if (objEntityWorkExperience.WrkGCCExpYears != -1)
                {
                    cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_GCC_EXP", OracleDbType.Decimal).Value = objEntityWorkExperience.WrkGCCExpYears;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_GCC_EXP", OracleDbType.Decimal).Value = DBNull.Value;
                }


                cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_NAME_LST_EMP", OracleDbType.Varchar2).Value = objEntityWorkExperience.WrkEmpName;
                cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_ADDR_LST_EMP", OracleDbType.Varchar2).Value = objEntityWorkExperience.WrkAddress;

                if (objEntityWorkExperience.LastWrkJoiningDate != DateTime.MinValue)
                {
                    cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_DT_JOINING", OracleDbType.Date).Value = objEntityWorkExperience.LastWrkJoiningDate;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_DT_JOINING", OracleDbType.Date).Value = null;
                }
                if (objEntityWorkExperience.LastWrkLeavingDate != DateTime.MinValue)
                {
                    cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_DT_LEAVING", OracleDbType.Date).Value = objEntityWorkExperience.LastWrkLeavingDate;
                }
                else
                {
                    cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_DT_LEAVING", OracleDbType.Date).Value = null;
                }
                cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_DSGN", OracleDbType.Varchar2).Value = objEntityWorkExperience.Designation;
                cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_SALARY", OracleDbType.Varchar2).Value = objEntityWorkExperience.StrSalary;
                cmdAddPersnlDtls.Parameters.Add("S_ORG_ID", OracleDbType.Int32).Value = objEntityWorkExperience.Organisation_id;
                cmdAddPersnlDtls.Parameters.Add("S_CORPRT_ID", OracleDbType.Int32).Value = objEntityWorkExperience.Corporate_id;
                cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_UPD_USR_ID", OracleDbType.Int32).Value = objEntityWorkExperience.User_id;
                cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_UPD_DATE", OracleDbType.Date).Value = objEntityWorkExperience.Date;
                clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
            }
        }
        public DataTable readWrkExpList(clsEntityLayerStaffWorkExperience objEntityWorkExperience)
        {
            string strQueryReadCountry = "STAFF_QUALIFICATION.SP_READ_STAFF_WRK_EXP";
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryReadCountry;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;

                cmdReadCountry.Parameters.Add("S_CAND_ID", OracleDbType.Int32).Value = objEntityWorkExperience.CandidateID;
                cmdReadCountry.Parameters.Add("S_ORG_ID", OracleDbType.Int32).Value = objEntityWorkExperience.Organisation_id;
                cmdReadCountry.Parameters.Add("S_CORPRT_ID", OracleDbType.Int32).Value = objEntityWorkExperience.Corporate_id;
                cmdReadCountry.Parameters.Add("S_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCountry = new DataTable();
                dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
                return dtCountry;
            }
        }
        public DataTable ReadWrkExpDtlById(clsEntityLayerStaffWorkExperience objEntityWorkExperience)
        {
            string strQueryReadCountry = "STAFF_QUALIFICATION.SP_READ_STAFF_WRK_EXP_BYID";
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryReadCountry;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;

                cmdReadCountry.Parameters.Add("S_STAFF_WRK_EXP_ID", OracleDbType.Int32).Value = objEntityWorkExperience.WorkExpDtl_id;
                cmdReadCountry.Parameters.Add("S_CAND_ID", OracleDbType.Int32).Value = objEntityWorkExperience.CandidateID;
                cmdReadCountry.Parameters.Add("S_ORG_ID", OracleDbType.Int32).Value = objEntityWorkExperience.Organisation_id;
                cmdReadCountry.Parameters.Add("S_CORPRT_ID", OracleDbType.Int32).Value = objEntityWorkExperience.Corporate_id;
                cmdReadCountry.Parameters.Add("S_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCountry = new DataTable();
                dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
                return dtCountry;
            }
        }
        public void DeleteWrkExpDtl(clsEntityLayerStaffWorkExperience objEntityWorkExperience)
        {
            string strQueryAddPersnlDtls = "STAFF_QUALIFICATION.SP_DELETE_STAFF_WRK_EXP";
            using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
            {
                cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
                cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
                cmdAddPersnlDtls.Parameters.Add("S_STAFF_WRK_EXP_ID", OracleDbType.Int32).Value = objEntityWorkExperience.WorkExpDtl_id;
                cmdAddPersnlDtls.Parameters.Add("S_CAND_ID", OracleDbType.Int32).Value = objEntityWorkExperience.CandidateID;
                cmdAddPersnlDtls.Parameters.Add("S_ORG_ID", OracleDbType.Int32).Value = objEntityWorkExperience.Organisation_id;
                cmdAddPersnlDtls.Parameters.Add("S_CORPRT_ID", OracleDbType.Int32).Value = objEntityWorkExperience.Corporate_id;
                clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
            }
        }
    }
    //Data Layer for Qualification:Education
    public class clsDataLayerStaffEducation
    {
        public DataTable ReadEduLvl(clsEntityLayerStaffEducation objEntityEducation)
        {
            string strQueryReadQualCourse = "STAFF_QUALIFICATION.SP_READ_COURSE";
            using (OracleCommand cmdReadQualCourse = new OracleCommand())
            {
                cmdReadQualCourse.CommandText = strQueryReadQualCourse;
                cmdReadQualCourse.CommandType = CommandType.StoredProcedure;
                cmdReadQualCourse.Parameters.Add("S_QUAL_TYPEID", OracleDbType.Int32).Value = objEntityEducation.CandidateID;
                cmdReadQualCourse.Parameters.Add("S_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtQualCourse = new DataTable();
                dtQualCourse = clsDataLayer.SelectDataTable(cmdReadQualCourse);
                return dtQualCourse;
            }
        }
        public void insertEducation(clsEntityLayerStaffEducation objEntityEducation)
        {
            string strQueryAddEduDtls = "STAFF_QUALIFICATION.SP_INSERT_STAFF_EDUCATION_DTLS";
            using (OracleCommand cmdAddEduDtls = new OracleCommand())
            {
                cmdAddEduDtls.CommandText = strQueryAddEduDtls;
                cmdAddEduDtls.CommandType = CommandType.StoredProcedure;
                cmdAddEduDtls.Parameters.Add("S_CAND_ID", OracleDbType.Int32).Value = objEntityEducation.CandidateID;
                cmdAddEduDtls.Parameters.Add("S_COURSE_ID", OracleDbType.Int32).Value = objEntityEducation.CourseID;
                cmdAddEduDtls.Parameters.Add("S_QUAL_INST", OracleDbType.Varchar2).Value = objEntityEducation.Institution;
                if (objEntityEducation.PassingYear != DateTime.MinValue)
                {
                    cmdAddEduDtls.Parameters.Add("S_QUAL_PASSING_YR", OracleDbType.Date).Value = objEntityEducation.PassingYear;
                }
                else
                {
                    cmdAddEduDtls.Parameters.Add("S_QUAL_PASSING_YR", OracleDbType.Date).Value = null;
                }
                if (objEntityEducation.Degree != null)
                {
                    cmdAddEduDtls.Parameters.Add("S_QUAL_DEGREE", OracleDbType.Varchar2).Value = objEntityEducation.Degree;
                }
                else
                {
                    cmdAddEduDtls.Parameters.Add("S_QUAL_DEGREE", OracleDbType.Varchar2).Value = null;
                }
                if (objEntityEducation.Specialization != null)
                {
                    cmdAddEduDtls.Parameters.Add("S_QUAL_SPEC", OracleDbType.Varchar2).Value = objEntityEducation.Specialization;
                }
                else
                {
                    cmdAddEduDtls.Parameters.Add("S_QUAL_SPEC", OracleDbType.Varchar2).Value = null;
                }
                if (objEntityEducation.Percentage != 0)
                {
                    cmdAddEduDtls.Parameters.Add("S_QUAL_PRCTG", OracleDbType.Decimal).Value = objEntityEducation.Percentage;
                }
                else
                {
                    cmdAddEduDtls.Parameters.Add("S_QUAL_PRCTG", OracleDbType.Decimal).Value = null;
                }
                cmdAddEduDtls.Parameters.Add("E_ORGID", OracleDbType.Int32).Value = objEntityEducation.Organisation_id;
                cmdAddEduDtls.Parameters.Add("E_CORPRTID", OracleDbType.Int32).Value = objEntityEducation.Corporate_id;
                cmdAddEduDtls.Parameters.Add("S_QUAL_INS_USR_ID", OracleDbType.Int32).Value = objEntityEducation.User_id;
                cmdAddEduDtls.Parameters.Add("S_QUAL_INS_DATE", OracleDbType.Date).Value = objEntityEducation.Date;

                clsDataLayer.ExecuteNonQuery(cmdAddEduDtls);
            }
        }
        public void updateEducation(clsEntityLayerStaffEducation objEntityEducation)
        {
            string strQueryAddEduDtls = "STAFF_QUALIFICATION.SP_UPDATE_STAFF_EDUCATION_DTLS";
            using (OracleCommand cmdAddEduDtls = new OracleCommand())
            {
                cmdAddEduDtls.CommandText = strQueryAddEduDtls;
                cmdAddEduDtls.CommandType = CommandType.StoredProcedure;
                cmdAddEduDtls.Parameters.Add("S_CAND_ID", OracleDbType.Int32).Value = objEntityEducation.CandidateID;
                cmdAddEduDtls.Parameters.Add("S_QUAL_COURSE_ID", OracleDbType.Int32).Value = objEntityEducation.CourseID;
                cmdAddEduDtls.Parameters.Add("S_QUAL_INST", OracleDbType.Varchar2).Value = objEntityEducation.Institution;
                if (objEntityEducation.PassingYear != DateTime.MinValue)
                {
                    cmdAddEduDtls.Parameters.Add("S_QUAL_PASSING_YR", OracleDbType.Date).Value = objEntityEducation.PassingYear;
                }
                else
                {
                    cmdAddEduDtls.Parameters.Add("S_QUAL_PASSING_YR", OracleDbType.Date).Value = null;
                }
                if (objEntityEducation.Degree != null)
                {
                    cmdAddEduDtls.Parameters.Add("S_QUAL_DEGREE", OracleDbType.Varchar2).Value = objEntityEducation.Degree;
                }
                else
                {
                    cmdAddEduDtls.Parameters.Add("S_QUAL_DEGREE", OracleDbType.Varchar2).Value = null;
                }
                if (objEntityEducation.Specialization != null)
                {
                    cmdAddEduDtls.Parameters.Add("S_QUAL_SPEC", OracleDbType.Varchar2).Value = objEntityEducation.Specialization;
                }
                else
                {
                    cmdAddEduDtls.Parameters.Add("S_QUAL_SPEC", OracleDbType.Varchar2).Value = null;
                }
                if (objEntityEducation.Percentage != 0)
                {
                    cmdAddEduDtls.Parameters.Add("S_QUAL_PRCTG", OracleDbType.Decimal).Value = objEntityEducation.Percentage;
                }
                else
                {
                    cmdAddEduDtls.Parameters.Add("S_QUAL_PRCTG", OracleDbType.Decimal).Value = null;
                }
                cmdAddEduDtls.Parameters.Add("S_ORG_ID", OracleDbType.Int32).Value = objEntityEducation.Organisation_id;
                cmdAddEduDtls.Parameters.Add("S_CORPRT_ID", OracleDbType.Int32).Value = objEntityEducation.Corporate_id;

                cmdAddEduDtls.Parameters.Add("S_STAFF_QUAL_ID", OracleDbType.Int32).Value = objEntityEducation.EductnDtl_Id;
                clsDataLayer.ExecuteNonQuery(cmdAddEduDtls);
            }
        }
        public DataTable readEduList(clsEntityLayerStaffEducation objEntityEducation)
        {
            string strQueryReadEduList = "STAFF_QUALIFICATION.SP_READ_STAFF_EDUCATION_DTLS";
            using (OracleCommand cmdReadEduList = new OracleCommand())
            {
                cmdReadEduList.CommandText = strQueryReadEduList;
                cmdReadEduList.CommandType = CommandType.StoredProcedure;
                cmdReadEduList.Parameters.Add("S_CAND_ID", OracleDbType.Int32).Value = objEntityEducation.CandidateID;
                cmdReadEduList.Parameters.Add("S_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtEduList = new DataTable();
                dtEduList = clsDataLayer.SelectDataTable(cmdReadEduList);
                return dtEduList;
            }
        }

        public DataTable ReadEduDtlById(clsEntityLayerStaffEducation objEntityEducation)
        {
            string strQueryReadCountry = "STAFF_QUALIFICATION.SP_READ_STAFF_EDU_DTLS_BYID";
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryReadCountry;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;
                cmdReadCountry.Parameters.Add("S_CAND_ID", OracleDbType.Int32).Value = objEntityEducation.CandidateID;
                cmdReadCountry.Parameters.Add("S_STAFF_QUAL_ID", OracleDbType.Int32).Value = objEntityEducation.EductnDtl_Id;
                cmdReadCountry.Parameters.Add("S_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCountry = new DataTable();
                dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
                return dtCountry;
            }
        }
        public void deleteEduById(clsEntityLayerStaffEducation objEntityEducation)
        {
            string strQueryAddPersnlDtls = "STAFF_QUALIFICATION.SP_DELETE_STAFF_EDUCATION_DTLS";
            using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
            {
                cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
                cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
                cmdAddPersnlDtls.Parameters.Add("S_STAFF_QUAL_ID", OracleDbType.Int32).Value = objEntityEducation.EductnDtl_Id;
                cmdAddPersnlDtls.Parameters.Add("S_CAND_ID", OracleDbType.Int32).Value = objEntityEducation.CandidateID;
                clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
            }
        }


    }
    
    //Data Layer for Qualification:Language
    public class clsDataLayerStaffLanguage
    {
        public DataTable ReadLanguage()
        {
            string strQueryReadCountry = "STAFF_QUALIFICATION.SP_LANG_LOAD";
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
        public void insertLanguageDtl(clsEntityLayerStaffLanguage objEntityLanguage)
        {
            string strQueryAddPersnlDtls = "STAFF_QUALIFICATION.SP_INSERT_STAFF_LANGUAGE_DTLS";
            using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
            {
                cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
                cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
                cmdAddPersnlDtls.Parameters.Add("S_CAND_ID", OracleDbType.Int32).Value = objEntityLanguage.CandidateID;
                cmdAddPersnlDtls.Parameters.Add("S_STAFF_LANG_KNOWN", OracleDbType.Int32).Value = objEntityLanguage.LanguageId;
                cmdAddPersnlDtls.Parameters.Add("S_STAFF_LANG_READ", OracleDbType.Int32).Value = objEntityLanguage.LangRead;
                cmdAddPersnlDtls.Parameters.Add("S_STAFF_LANG_WRITE", OracleDbType.Int32).Value = objEntityLanguage.LangWrite;
                cmdAddPersnlDtls.Parameters.Add("S_STAFF_LANG_SPEAK", OracleDbType.Int32).Value = objEntityLanguage.LangSpeak;
                cmdAddPersnlDtls.Parameters.Add("S_STAFF_LANGMOTHER_TONGUE", OracleDbType.Varchar2).Value = objEntityLanguage.MotherTongue;
                cmdAddPersnlDtls.Parameters.Add("S_CORPRT_ID", OracleDbType.Int32).Value = objEntityLanguage.Corporate_id;
                clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
            }
        }
        public void updateLanguageDtl(clsEntityLayerStaffLanguage objEntityLanguage)
        {
            string strQueryAddPersnlDtls = "STAFF_QUALIFICATION.SP_UPDATE_STAFF_LANGUAGE_DTLS";
            using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
            {

                cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
                cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
                cmdAddPersnlDtls.Parameters.Add("S_CAND_ID", OracleDbType.Int32).Value = objEntityLanguage.CandidateID;
                cmdAddPersnlDtls.Parameters.Add("S_STAFF_LANG_ID", OracleDbType.Int32).Value = objEntityLanguage.LangdtlId;
                cmdAddPersnlDtls.Parameters.Add("S_STAFF_LANG_KNOWN", OracleDbType.Int32).Value = objEntityLanguage.LanguageId;
                cmdAddPersnlDtls.Parameters.Add("S_STAFF_LANG_READ", OracleDbType.Int32).Value = objEntityLanguage.LangRead;
                cmdAddPersnlDtls.Parameters.Add("S_STAFF_LANG_WRITE", OracleDbType.Int32).Value = objEntityLanguage.LangWrite;
                cmdAddPersnlDtls.Parameters.Add("S_STAFF_LANG_SPEAK", OracleDbType.Int32).Value = objEntityLanguage.LangSpeak;
                cmdAddPersnlDtls.Parameters.Add("S_STAFF_LANGMOTHER_TONGUE", OracleDbType.Varchar2).Value = objEntityLanguage.MotherTongue;
                clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
            }
        }
        public DataTable readLangList(clsEntityLayerStaffLanguage objEntityLanguage)
        {
            string strQueryReadCountry = "STAFF_QUALIFICATION.SP_READ_STAFF_LANGUAGE_DTLS";
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryReadCountry;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;
                cmdReadCountry.Parameters.Add("S_CAND_ID", OracleDbType.Int32).Value = objEntityLanguage.CandidateID;
                cmdReadCountry.Parameters.Add("S_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCountry = new DataTable();
                dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
                return dtCountry;
            }
        }
        public DataTable ReadLangDtlById(clsEntityLayerStaffLanguage objEntityLanguage)
        {
            string strQueryReadCountry = "STAFF_QUALIFICATION.SP_READ_STAFF_LANG_DTLS_BYID";
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryReadCountry;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;
                cmdReadCountry.Parameters.Add("S_CAND_ID", OracleDbType.Int32).Value = objEntityLanguage.CandidateID;
                cmdReadCountry.Parameters.Add("S_STAFF_LANG_ID", OracleDbType.Int32).Value = objEntityLanguage.LangdtlId;
                cmdReadCountry.Parameters.Add("S_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCountry = new DataTable();
                dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
                return dtCountry;
            }
        }
        public void deleteLanguageDtl(clsEntityLayerStaffLanguage objEntityLanguage)
        {
            string strQueryAddPersnlDtls = "STAFF_QUALIFICATION.SP_DELETE_STAFF_LANGUAGE_DTLS";
            using (OracleCommand cmdAddPersnlDtls = new OracleCommand())
            {
                cmdAddPersnlDtls.CommandText = strQueryAddPersnlDtls;
                cmdAddPersnlDtls.CommandType = CommandType.StoredProcedure;
                cmdAddPersnlDtls.Parameters.Add("S_STAFF_LANG_ID", OracleDbType.Int32).Value = objEntityLanguage.LangdtlId;
                cmdAddPersnlDtls.Parameters.Add("S_CAND_ID", OracleDbType.Int32).Value = objEntityLanguage.CandidateID;
                clsDataLayer.ExecuteNonQuery(cmdAddPersnlDtls);
            }
        }

    }
}
