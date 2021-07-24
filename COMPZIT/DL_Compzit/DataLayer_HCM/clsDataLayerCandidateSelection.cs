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
    public class clsDataLayerCandidateSelection
    {
        public DataTable ReadAprvdManPwrReqstList(clsEntityCandidateSelection objEntityCandidateSel)
        {
            string strQueryReadPayGrd = "CANDIDATE_SELECTION.SP_READ_MAN_PWRRQST_LIST";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;

            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityCandidateSel.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCandidateSel.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityCandidateSel.User_Id;
            cmdReadJob.Parameters.Add("P_DIVID", OracleDbType.Int32).Value = objEntityCandidateSel.DivId;
            cmdReadJob.Parameters.Add("P_DEPID", OracleDbType.Int32).Value = objEntityCandidateSel.Deprt_Id;
            cmdReadJob.Parameters.Add("P_PRJCTID", OracleDbType.Int32).Value = objEntityCandidateSel.PrjctId;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadDivision(clsEntityCandidateSelection objEntityCandidateSel)
        {
            string strQueryReadPayGrd = "CANDIDATE_SELECTION.SP_READ_DIVISION";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityCandidateSel.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCandidateSel.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityCandidateSel.User_Id;
            cmdReadJob.Parameters.Add("P_DEPTID", OracleDbType.Int32).Value = objEntityCandidateSel.Deprt_Id;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadDepartment(clsEntityCandidateSelection objEntityCandidateSel)
        {
            string strQueryReadPayGrd = "CANDIDATE_SELECTION.SP_READ_DEPRTMNT";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityCandidateSel.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCandidateSel.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityCandidateSel.User_Id;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadConsultancies(clsEntityCandidateSelection objEntityCandidateSel)
        {
            string strQueryReadPayGrd = "CANDIDATE_SELECTION.SP_READ_CONSULTANCIES";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityCandidateSel.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCandidateSel.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityCandidateSel.User_Id;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadEmployee(clsEntityCandidateSelection objEntityCandidateSel)
        {
            string strQueryReadPrjct = "CANDIDATE_SELECTION.SP_READ_EMPLOYEE";
            OracleCommand cmdReadPrjct = new OracleCommand();
            cmdReadPrjct.CommandText = strQueryReadPrjct;
            cmdReadPrjct.CommandType = CommandType.StoredProcedure;
            cmdReadPrjct.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCandidateSel.Organisation_Id;
            cmdReadPrjct.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCandidateSel.CorpOffice_Id;
            cmdReadPrjct.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPrjct);
            return dtCategory;
        }
        public DataTable ReadProject(clsEntityCandidateSelection objEntityCandidateSel)
        {
            string strQueryReadPrjct = "CANDIDATE_SELECTION.SP_READ_PROJECT";
            OracleCommand cmdReadPrjct = new OracleCommand();
            cmdReadPrjct.CommandText = strQueryReadPrjct;
            cmdReadPrjct.CommandType = CommandType.StoredProcedure;
            cmdReadPrjct.Parameters.Add("J_DIVID", OracleDbType.Int32).Value = objEntityCandidateSel.DivId;
            cmdReadPrjct.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityCandidateSel.Organisation_Id;
            cmdReadPrjct.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityCandidateSel.CorpOffice_Id;
            cmdReadPrjct.Parameters.Add("J_USERID", OracleDbType.Int32).Value = objEntityCandidateSel.User_Id;
            cmdReadPrjct.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPrjct);
            return dtCategory;
        }
        public DataTable ReadManPwrReqstById(clsEntityCandidateSelection objEntityCandidateSel)
        {
            string strQueryReadPayGrd = "CANDIDATE_SELECTION.SP_READ_MAN_PWRRQST_BY_ID";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_RQSTID", OracleDbType.Int32).Value = objEntityCandidateSel.ManPwrRqstId;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityCandidateSel.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityCandidateSel.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadinterviewTemList(clsEntityCandidateSelection objEntityTemp)
        {
            string strQueryReadPayGrd = "CANDIDATE_SELECTION.SP_READ_INTERV_TEM";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityTemp.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityTemp.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityTemp.User_Id;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        //Method for fetch country master table from database.
        public DataTable ReadCountry()
        {
            string strQueryReadCountry = "CANDIDATE_SELECTION.SP_READ_COUNTRY";
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryReadCountry;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;
                cmdReadCountry.Parameters.Add("C_CNTRYTABLE", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCountry = new DataTable();
                dtCountry = clsDataLayer.SelectDataTable(cmdReadCountry);
                return dtCountry;
            }
        }
        public void InsertCandidateSel(clsEntityCandidateSelection objEntityTemp, List<clsEntityCandSelectionDtl> objCandSelectionDtl)
        {
            //clsDataLayer objDatatLayer = new clsDataLayer();
            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryInsertDsgn = "CANDIDATE_SELECTION.SP_INS_CANDIDATE_MASTER";
                    using (OracleCommand cmdInsertInterviewCat = new OracleCommand())
                    {
                        //clsEntityCommon objEntCommon = new clsEntityCommon();
                        //objEntCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CANDIDATE_SELECTION);
                        //objEntCommon.CorporateID = objEntityTemp.CorpOffice_Id;
                        //string strNextNum = objDatatLayer.ReadNextNumberWeb(objEntCommon, tran, con);
                        //objEntityTemp.CandidateSelectionId = Convert.ToInt32(strNextNum);

                        cmdInsertInterviewCat.Transaction = tran;
                        cmdInsertInterviewCat.Connection = con;
                        cmdInsertInterviewCat.CommandText = strQueryInsertDsgn;
                        cmdInsertInterviewCat.CommandType = CommandType.StoredProcedure;
                        cmdInsertInterviewCat.Parameters.Add("C_CAND_MSTRID", OracleDbType.Int32).Value = objEntityTemp.CandidateSelectionId;
                        cmdInsertInterviewCat.Parameters.Add("C_MNPRQST_ID", OracleDbType.Int32).Value = objEntityTemp.ManPwrRqstId;
                        cmdInsertInterviewCat.Parameters.Add("C_INVTEM_ID", OracleDbType.Int32).Value = objEntityTemp.IntervTemplateId;
                        cmdInsertInterviewCat.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityTemp.CorpOffice_Id;
                        cmdInsertInterviewCat.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityTemp.Organisation_Id;
                        cmdInsertInterviewCat.Parameters.Add("C_CAND_MSTR_INS_USR_ID", OracleDbType.Int32).Value = objEntityTemp.User_Id;
                        cmdInsertInterviewCat.Parameters.Add("C_CAND_MSTR_INS_DATE", OracleDbType.Date).Value = objEntityTemp.J_Date;
                        cmdInsertInterviewCat.ExecuteNonQuery();
                    }


                    string strQueryInsertInterviewCatDtl = "CANDIDATE_SELECTION.SP_INS_CANDIDATE_DTLS";
                    foreach (clsEntityCandSelectionDtl objCandSelDtl in objCandSelectionDtl)
                    {
                        using (OracleCommand cmdInsertInterviewCatDtl = new OracleCommand())
                        {
                            cmdInsertInterviewCatDtl.Transaction = tran;
                            cmdInsertInterviewCatDtl.Connection = con;
                            cmdInsertInterviewCatDtl.CommandText = strQueryInsertInterviewCatDtl;
                            cmdInsertInterviewCatDtl.CommandType = CommandType.StoredProcedure;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_MSTRID", OracleDbType.Int32).Value = objEntityTemp.CandidateSelectionId;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_MSTR_TYPE", OracleDbType.Int32).Value = objCandSelDtl.ResumeType;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_NAME", OracleDbType.Varchar2).Value = objCandSelDtl.Candidatename;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_LOC", OracleDbType.Varchar2).Value = objCandSelDtl.Location;
                            if (objCandSelDtl.CountryId == 0)
                            {
                                cmdInsertInterviewCatDtl.Parameters.Add("C_CNTRY_ID", OracleDbType.Int32).Value = null;

                            }
                            else
                            {
                                cmdInsertInterviewCatDtl.Parameters.Add("C_CNTRY_ID", OracleDbType.Int32).Value = objCandSelDtl.CountryId;

                            }
                            if (objCandSelDtl.RefType != 0)
                                cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_REF", OracleDbType.Int32).Value = objCandSelDtl.RefType;
                            else

                                cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_REF", OracleDbType.Int32).Value = null;
                          
                            if (objCandSelDtl.ConsultId!=0)
                                cmdInsertInterviewCatDtl.Parameters.Add("C_CONSLT", OracleDbType.Int32).Value = objCandSelDtl.ConsultId;
                            else
                                cmdInsertInterviewCatDtl.Parameters.Add("C_CONSLT", OracleDbType.Int32).Value = null;

                            if (objCandSelDtl.DivisionId != 0)
                                cmdInsertInterviewCatDtl.Parameters.Add("C_DIV", OracleDbType.Int32).Value = objCandSelDtl.DivisionId;
                            else
                                cmdInsertInterviewCatDtl.Parameters.Add("C_DIV", OracleDbType.Int32).Value = null;

                            if (objCandSelDtl.DepartId != 0)
                                cmdInsertInterviewCatDtl.Parameters.Add("C_DEPT", OracleDbType.Int32).Value = objCandSelDtl.DepartId;
                            else
                                cmdInsertInterviewCatDtl.Parameters.Add("C_DEPT", OracleDbType.Int32).Value = null;

                            if (objCandSelDtl.EmpId != 0)
                                cmdInsertInterviewCatDtl.Parameters.Add("C_EMP", OracleDbType.Int32).Value = objCandSelDtl.EmpId;
                            else
                                cmdInsertInterviewCatDtl.Parameters.Add("C_EMP", OracleDbType.Int32).Value = null;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_SKPINTR", OracleDbType.Int32).Value = objCandSelDtl.SkipIntrw;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_VISA", OracleDbType.Int32).Value = objCandSelDtl.Visa;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_LICENSE", OracleDbType.Int32).Value = objCandSelDtl.License;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_PASSPORTNO", OracleDbType.Varchar2).Value = objCandSelDtl.Passport;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_RESUMENAME", OracleDbType.Varchar2).Value = objCandSelDtl.FileName;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_ACT_RESUMENAME", OracleDbType.Varchar2).Value = objCandSelDtl.ActFileName;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_EMAIL", OracleDbType.Varchar2).Value = objCandSelDtl.Email;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityTemp.CorpOffice_Id;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_MOBILENO", OracleDbType.Varchar2).Value = objCandSelDtl.MobileNo;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_GENDER", OracleDbType.Int32).Value = objCandSelDtl.Gender;
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
        //Update candidate selection
        public void UpdateCandidateSel(clsEntityCandidateSelection objEntityTemp, List<clsEntityCandSelectionDtl> objEntityCandSelDtlINSERTList, List<clsEntityCandSelectionDtl> objEntityCandSelDtlUPDATEList, List<clsEntityCandSelectionDtl> objEntityCandSelDtlDELETEList)
        {

            OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryInsertDsgn = "CANDIDATE_SELECTION.SP_UPD_CANDIDATE_MASTER";
                    using (OracleCommand cmdInsertInterviewCat = new OracleCommand())
                    {
                        cmdInsertInterviewCat.Transaction = tran;
                        cmdInsertInterviewCat.Connection = con;
                        cmdInsertInterviewCat.CommandText = strQueryInsertDsgn;
                        cmdInsertInterviewCat.CommandType = CommandType.StoredProcedure;
                        cmdInsertInterviewCat.Parameters.Add("C_CAND_MSTRID", OracleDbType.Int32).Value = objEntityTemp.CandidateSelectionId;
                        cmdInsertInterviewCat.Parameters.Add("C_MNPRQST_ID", OracleDbType.Int32).Value = objEntityTemp.ManPwrRqstId;
                        cmdInsertInterviewCat.Parameters.Add("C_INVTEM_ID", OracleDbType.Int32).Value = objEntityTemp.IntervTemplateId;
                        cmdInsertInterviewCat.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityTemp.CorpOffice_Id;
                        cmdInsertInterviewCat.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityTemp.Organisation_Id;
                        cmdInsertInterviewCat.Parameters.Add("C_CAND_MSTR_INS_USR_ID", OracleDbType.Int32).Value = objEntityTemp.User_Id;
                        cmdInsertInterviewCat.Parameters.Add("C_CAND_MSTR_INS_DATE", OracleDbType.Date).Value = objEntityTemp.J_Date;
                        cmdInsertInterviewCat.ExecuteNonQuery();
                    }


                    string strQueryInsertInterviewCatDtl = "CANDIDATE_SELECTION.SP_INS_CANDIDATE_DTLS";
                    foreach (clsEntityCandSelectionDtl objCandSelDtl in objEntityCandSelDtlINSERTList)
                    {
                        using (OracleCommand cmdInsertInterviewCatDtl = new OracleCommand())
                        {
                            cmdInsertInterviewCatDtl.Transaction = tran;
                            cmdInsertInterviewCatDtl.Connection = con;
                            cmdInsertInterviewCatDtl.CommandText = strQueryInsertInterviewCatDtl;
                            cmdInsertInterviewCatDtl.CommandType = CommandType.StoredProcedure;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_MSTRID", OracleDbType.Int32).Value = objEntityTemp.CandidateSelectionId;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_MSTR_TYPE", OracleDbType.Int32).Value = objCandSelDtl.ResumeType;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_NAME", OracleDbType.Varchar2).Value = objCandSelDtl.Candidatename;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_LOC", OracleDbType.Varchar2).Value = objCandSelDtl.Location;
                            if (objCandSelDtl.CountryId == 0)
                            {
                                cmdInsertInterviewCatDtl.Parameters.Add("C_CNTRY_ID", OracleDbType.Int32).Value = null;

                            }
                            else
                            {
                                cmdInsertInterviewCatDtl.Parameters.Add("C_CNTRY_ID", OracleDbType.Int32).Value = objCandSelDtl.CountryId;

                            }
                            if (objCandSelDtl.RefType != 0)
                                cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_REF", OracleDbType.Int32).Value = objCandSelDtl.RefType;
                            else

                                cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_REF", OracleDbType.Int32).Value = null;
                          
                            if (objCandSelDtl.ConsultId != 0)
                                cmdInsertInterviewCatDtl.Parameters.Add("C_CONSLT", OracleDbType.Int32).Value = objCandSelDtl.ConsultId;
                            else
                                cmdInsertInterviewCatDtl.Parameters.Add("C_CONSLT", OracleDbType.Int32).Value = null;

                            if (objCandSelDtl.DivisionId != 0)
                                cmdInsertInterviewCatDtl.Parameters.Add("C_DIV", OracleDbType.Int32).Value = objCandSelDtl.DivisionId;
                            else
                                cmdInsertInterviewCatDtl.Parameters.Add("C_DIV", OracleDbType.Int32).Value = null;

                            if (objCandSelDtl.DepartId != 0)
                                cmdInsertInterviewCatDtl.Parameters.Add("C_DEPT", OracleDbType.Int32).Value = objCandSelDtl.DepartId;
                            else
                                cmdInsertInterviewCatDtl.Parameters.Add("C_DEPT", OracleDbType.Int32).Value = null;

                            if (objCandSelDtl.EmpId != 0)
                                cmdInsertInterviewCatDtl.Parameters.Add("C_EMP", OracleDbType.Int32).Value = objCandSelDtl.EmpId;
                            else
                                cmdInsertInterviewCatDtl.Parameters.Add("C_EMP", OracleDbType.Int32).Value = null;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_SKPINTR", OracleDbType.Int32).Value = objCandSelDtl.SkipIntrw;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_VISA", OracleDbType.Int32).Value = objCandSelDtl.Visa;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_LICENSE", OracleDbType.Int32).Value = objCandSelDtl.License;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_PASSPORTNO", OracleDbType.Varchar2).Value = objCandSelDtl.Passport;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_RESUMENAME", OracleDbType.Varchar2).Value = objCandSelDtl.FileName;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_ACT_RESUMENAME", OracleDbType.Varchar2).Value = objCandSelDtl.ActFileName;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_EMAIL", OracleDbType.Varchar2).Value = objCandSelDtl.Email;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityTemp.CorpOffice_Id;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_MOBILENO", OracleDbType.Varchar2).Value = objCandSelDtl.MobileNo;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_GENDER", OracleDbType.Int32).Value = objCandSelDtl.Gender;
                            cmdInsertInterviewCatDtl.ExecuteNonQuery();
                        }
                    }
                    string strQueryUpdateInterviewCatDtl = "CANDIDATE_SELECTION.SP_UPD_CANDIDATE_DTLS";
                    foreach (clsEntityCandSelectionDtl objCandSelDtl in objEntityCandSelDtlUPDATEList)
                    {
                        using (OracleCommand cmdInsertInterviewCatDtl = new OracleCommand())
                        {
                            cmdInsertInterviewCatDtl.Transaction = tran;
                            cmdInsertInterviewCatDtl.Connection = con;
                            cmdInsertInterviewCatDtl.CommandText = strQueryUpdateInterviewCatDtl;
                            cmdInsertInterviewCatDtl.CommandType = CommandType.StoredProcedure;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_ID", OracleDbType.Int32).Value = objCandSelDtl.CandDtlId;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_MSTRID", OracleDbType.Int32).Value = objEntityTemp.CandidateSelectionId;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_MSTR_TYPE", OracleDbType.Int32).Value = objCandSelDtl.ResumeType;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_NAME", OracleDbType.Varchar2).Value = objCandSelDtl.Candidatename;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_LOC", OracleDbType.Varchar2).Value = objCandSelDtl.Location;
                            if (objCandSelDtl.CountryId == 0)
                            {
                                cmdInsertInterviewCatDtl.Parameters.Add("C_CNTRY_ID", OracleDbType.Int32).Value = null;

                            }
                            else
                            {
                                cmdInsertInterviewCatDtl.Parameters.Add("C_CNTRY_ID", OracleDbType.Int32).Value = objCandSelDtl.CountryId;

                            }
                            if (objCandSelDtl.RefType != 0)
                                cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_REF", OracleDbType.Int32).Value = objCandSelDtl.RefType;
                            else

                                cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_REF", OracleDbType.Int32).Value = null;

                            if (objCandSelDtl.ConsultId != 0)
                                cmdInsertInterviewCatDtl.Parameters.Add("C_CONSLT", OracleDbType.Int32).Value = objCandSelDtl.ConsultId;
                            else
                                cmdInsertInterviewCatDtl.Parameters.Add("C_CONSLT", OracleDbType.Int32).Value = null;

                            if (objCandSelDtl.DivisionId != 0)
                                cmdInsertInterviewCatDtl.Parameters.Add("C_DIV", OracleDbType.Int32).Value = objCandSelDtl.DivisionId;
                            else
                                cmdInsertInterviewCatDtl.Parameters.Add("C_DIV", OracleDbType.Int32).Value = null;

                            if (objCandSelDtl.DepartId != 0)
                                cmdInsertInterviewCatDtl.Parameters.Add("C_DEPT", OracleDbType.Int32).Value = objCandSelDtl.DepartId;
                            else
                                cmdInsertInterviewCatDtl.Parameters.Add("C_DEPT", OracleDbType.Int32).Value = null;

                            if (objCandSelDtl.EmpId != 0)
                                cmdInsertInterviewCatDtl.Parameters.Add("C_EMP", OracleDbType.Int32).Value = objCandSelDtl.EmpId;
                            else
                                cmdInsertInterviewCatDtl.Parameters.Add("C_EMP", OracleDbType.Int32).Value = null;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_SKPINTR", OracleDbType.Int32).Value = objCandSelDtl.SkipIntrw;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_VISA", OracleDbType.Int32).Value = objCandSelDtl.Visa;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_LICENSE", OracleDbType.Int32).Value = objCandSelDtl.License;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_PASSPORTNO", OracleDbType.Varchar2).Value = objCandSelDtl.Passport;
                            //cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_RESUMENAME", OracleDbType.Varchar2).Value = objCandSelDtl.FileName;
                            //cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_ACT_RESUMENAME", OracleDbType.Varchar2).Value = objCandSelDtl.ActFileName;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_EMAIL", OracleDbType.Varchar2).Value = objCandSelDtl.Email;
                            //cmdInsertInterviewCatDtl.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityTemp.CorpOffice_Id;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_MOBILENO", OracleDbType.Varchar2).Value = objCandSelDtl.MobileNo;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_GENDER", OracleDbType.Int32).Value = objCandSelDtl.Gender;
                            cmdInsertInterviewCatDtl.ExecuteNonQuery();
                        }
                    }
                    string strQueryDeleteInterviewCatDtl = "CANDIDATE_SELECTION.SP_DEL_CANDIDATE_DTLS";
                    foreach (clsEntityCandSelectionDtl objCandSelDtl in objEntityCandSelDtlDELETEList)
                    {
                        using (OracleCommand cmdInsertInterviewCatDtl = new OracleCommand())
                        {
                            cmdInsertInterviewCatDtl.Transaction = tran;
                            cmdInsertInterviewCatDtl.Connection = con;
                            cmdInsertInterviewCatDtl.CommandText = strQueryDeleteInterviewCatDtl;
                            cmdInsertInterviewCatDtl.CommandType = CommandType.StoredProcedure;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_ID", OracleDbType.Int32).Value = objCandSelDtl.CandDtlId;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CAND_MSTRID", OracleDbType.Int32).Value = objEntityTemp.CandidateSelectionId;
                            cmdInsertInterviewCatDtl.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityTemp.CorpOffice_Id;
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
        public DataTable ReadCandidateListByID(clsEntityCandidateSelection objEntityTemp)
        {
            string strQueryReadCountry = "CANDIDATE_SELECTION.SP_READ_CANDIDATE";
            using (OracleCommand cmdReadCandidateList = new OracleCommand())
            {
                cmdReadCandidateList.CommandText = strQueryReadCountry;
                cmdReadCandidateList.CommandType = CommandType.StoredProcedure;
                cmdReadCandidateList.Parameters.Add("C_MNPRQST_ID", OracleDbType.Int32).Value = objEntityTemp.ManPwrRqstId;
                cmdReadCandidateList.Parameters.Add("C_CAND_MSTR_TYPE", OracleDbType.Int32).Value = objEntityTemp.MstrResumeType;
                cmdReadCandidateList.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityTemp.CorpOffice_Id;
                cmdReadCandidateList.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityTemp.Organisation_Id;
                cmdReadCandidateList.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCand = new DataTable();
                dtCand = clsDataLayer.SelectDataTable(cmdReadCandidateList);
                return dtCand;
            }
        }
        // THIS PROCEDURE IS TO CHECK MAN POWER REQUEST ID IS USED OR NOT IN INTERVIEW PANEL
        public string CheckInterviewPanel(clsEntityCandidateSelection clsEntityCandidateSelection)
        {
            string strQueryCheckInterviewPanel = "CANDIDATE_SELECTION.SP_CHECK_INTRVIEW_PANEL";
            OracleCommand cmdCheckInterviewPanel = new OracleCommand();
            cmdCheckInterviewPanel.CommandText = strQueryCheckInterviewPanel;
            cmdCheckInterviewPanel.CommandType = CommandType.StoredProcedure;
            cmdCheckInterviewPanel.Parameters.Add("C_MNPRQST_ID", OracleDbType.Varchar2).Value = clsEntityCandidateSelection.ManPwrRqstId;
            cmdCheckInterviewPanel.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = clsEntityCandidateSelection.Organisation_Id;
            cmdCheckInterviewPanel.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = clsEntityCandidateSelection.CorpOffice_Id;
            cmdCheckInterviewPanel.Parameters.Add("C_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckInterviewPanel);
            string strReturn = cmdCheckInterviewPanel.Parameters["C_COUNT"].Value.ToString();
            cmdCheckInterviewPanel.Dispose();
            return strReturn;

        }
        public DataTable ReadNoDelCandidateList(clsEntityCandidateSelection objEntityTemp)
        {
            string strQueryReadCountry = "CANDIDATE_SELECTION.SP_READ_NO_DEL_CANDIDATE";
            using (OracleCommand cmdReadCandidateList = new OracleCommand())
            {
                cmdReadCandidateList.CommandText = strQueryReadCountry;
                cmdReadCandidateList.CommandType = CommandType.StoredProcedure;
                cmdReadCandidateList.Parameters.Add("C_MNPRQST_ID", OracleDbType.Int32).Value = objEntityTemp.ManPwrRqstId;
                cmdReadCandidateList.Parameters.Add("C_CORPRT_ID", OracleDbType.Int32).Value = objEntityTemp.CorpOffice_Id;
                cmdReadCandidateList.Parameters.Add("C_ORG_ID", OracleDbType.Int32).Value = objEntityTemp.Organisation_Id;
                cmdReadCandidateList.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dtCand = new DataTable();
                dtCand = clsDataLayer.SelectDataTable(cmdReadCandidateList);
                return dtCand;
            }
        }
    }
}
