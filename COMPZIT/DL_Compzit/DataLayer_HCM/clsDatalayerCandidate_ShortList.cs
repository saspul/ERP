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
    public class clsDatalayerCandidate_ShortList
    {
        public DataTable ReadDivision(clsEntityLayer_Candidate_ShortList objEntityShortlist)
        {
            string strQueryReadPayGrd = "CANDIDATE_SHORTLIST.SP_READ_DIVISION";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityShortlist.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityShortlist.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityShortlist.User_Id;
            cmdReadJob.Parameters.Add("P_DEPTID", OracleDbType.Int32).Value = objEntityShortlist.Deprt_Id;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadDepartment(clsEntityLayer_Candidate_ShortList objEntityShortlist)
        {
            string strQueryReadPayGrd = "CANDIDATE_SHORTLIST.SP_READ_DEPRTMNT";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityShortlist.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityShortlist.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityShortlist.User_Id;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadDesignation(clsEntityLayer_Candidate_ShortList objEntityShortlist)
        {
            string strQueryReadPayGrd = "CANDIDATE_SHORTLIST.SP_READ_DESGNTN";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityShortlist.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityShortlist.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityShortlist.User_Id;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadConsultancies(clsEntityLayer_Candidate_ShortList objEntityShortlist)
        {
            string strQueryReadPayGrd = "CANDIDATE_SHORTLIST.SP_READ_CONSULTANCIES";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityShortlist.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityShortlist.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityShortlist.User_Id;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadProject(clsEntityLayer_Candidate_ShortList objEntityShortlist)
        {
            string strQueryReadPrjct = "CANDIDATE_SHORTLIST.SP_READ_PROJECT";
            OracleCommand cmdReadPrjct = new OracleCommand();
            cmdReadPrjct.CommandText = strQueryReadPrjct;
            cmdReadPrjct.CommandType = CommandType.StoredProcedure;
            cmdReadPrjct.Parameters.Add("J_DIVID", OracleDbType.Int32).Value = objEntityShortlist.DivId;
            cmdReadPrjct.Parameters.Add("J_ORGID", OracleDbType.Int32).Value = objEntityShortlist.Organisation_Id;
            cmdReadPrjct.Parameters.Add("J_CORPID", OracleDbType.Int32).Value = objEntityShortlist.CorpOffice_Id;
            cmdReadPrjct.Parameters.Add("J_USERID", OracleDbType.Int32).Value = objEntityShortlist.User_Id;
            cmdReadPrjct.Parameters.Add("J_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadPrjct);
            return dtCategory;
        }

        public DataTable ReadAprvdManPwrReqstList(clsEntityLayer_Candidate_ShortList objEntityShortlist)
        {
            string strQueryReadPayGrd = "CANDIDATE_SHORTLIST.SP_READ_MAN_PWRRQST_LIST";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;

            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityShortlist.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityShortlist.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_USERID", OracleDbType.Int32).Value = objEntityShortlist.User_Id;
            cmdReadJob.Parameters.Add("P_DIVID", OracleDbType.Int32).Value = objEntityShortlist.DivId;
            cmdReadJob.Parameters.Add("P_DEPID", OracleDbType.Int32).Value = objEntityShortlist.Deprt_Id;
            cmdReadJob.Parameters.Add("P_PRJCTID", OracleDbType.Int32).Value = objEntityShortlist.PrjctId;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadAprvdManPwrReqstListByid(clsEntityLayer_Candidate_ShortList objEntityShortlist)
        {
            string strQueryReadPayGrd = "CANDIDATE_SHORTLIST.SP_READ_MAN_PWRRQST_BY_ID";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("P_RQSTID", OracleDbType.Int32).Value = objEntityShortlist.ReqstID;
            cmdReadJob.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityShortlist.Organisation_Id;
            cmdReadJob.Parameters.Add("P_CORPID", OracleDbType.Int32).Value = objEntityShortlist.CorpOffice_Id;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadCandidates(clsEntityLayer_Candidate_ShortList objEntityShortlist)
        {
            string strQueryReadPayGrd = "CANDIDATE_SHORTLIST.SP_READ_CANDIDATE";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
             cmdReadJob.Parameters.Add("C_MNPRQST_ID", OracleDbType.Int32).Value = objEntityShortlist.ReqstID;
             cmdReadJob.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public void AddShortList(clsEntityLayer_Candidate_ShortList objEntityShortlist, List<ShortListedCandiate> objlistShortList)
        {
            //fetching next value
            OracleTransaction tran;


            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();

                tran = con.BeginTransaction();

                try
                {


                    string strQueryAddManpowerRqrmnt = "CANDIDATE_SHORTLIST.SP_INSERT_CANDIDATE_SHORTLIST";
                    using (OracleCommand cmdAddManpowerRqrmnt = new OracleCommand(strQueryAddManpowerRqrmnt, con))
                    {

                        cmdAddManpowerRqrmnt.CommandType = CommandType.StoredProcedure;
                        //generate next val
                        clsDataLayer objDataLayer = new clsDataLayer();
                        clsEntityCommon objCommon = new clsEntityCommon();
                        //   objCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.ManpowerRqrmnt);
                        objCommon.CorporateID = objEntityShortlist.CorpOffice_Id;


                        cmdAddManpowerRqrmnt.Parameters.Add("C_CAND_SHRTLIST_ID", OracleDbType.Int32).Value = objEntityShortlist.ShortlistMasterId;

                        cmdAddManpowerRqrmnt.Parameters.Add("C_MNPRQST_ID", OracleDbType.Int32).Value = objEntityShortlist.ReqstID;



                        cmdAddManpowerRqrmnt.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityShortlist.CorpOffice_Id;




                        cmdAddManpowerRqrmnt.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityShortlist.Organisation_Id;

                        cmdAddManpowerRqrmnt.Parameters.Add("C_USR_ID", OracleDbType.Int32).Value = objEntityShortlist.User_Id;

                        cmdAddManpowerRqrmnt.Parameters.Add("C_DATE", OracleDbType.Date).Value = objEntityShortlist.ShorltistDate;

                        cmdAddManpowerRqrmnt.Parameters.Add("C_STATUS", OracleDbType.Int32).Value = objEntityShortlist.Confirmstatus;







                         cmdAddManpowerRqrmnt.ExecuteNonQuery();
                    }

                       foreach (ShortListedCandiate objShortlist in objlistShortList)
                         {
                             string strQueryInsertDetail = "CANDIDATE_SHORTLIST.SP_INSERT_SHORTLIST_DETAILS";
                            using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                            {
                                cmdAddInsertDetail.Transaction = tran;
                                cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                                cmdAddInsertDetail.Parameters.Add("C_CAND_MSTRID", OracleDbType.Int32).Value = objShortlist.CandidateId;
                                cmdAddInsertDetail.Parameters.Add("C_CAND_SHRTLIST_ID", OracleDbType.Int32).Value = objEntityShortlist.ShortlistMasterId;

                                cmdAddInsertDetail.ExecuteNonQuery();
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
        //Method for Updating ManpowerRqrmnt Details
        //public void UpdateShortList(clsEntityShortList objEntityShortList)
        //{
        //    OracleTransaction tran;
        //    using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
        //    {
        //        con.Open();

        //        //generate next value
        //        tran = con.BeginTransaction();

        //        try
        //        {

        //            string strQueryAddManpowerRqrmnt = "MANPOWER_REQUIREMENT.SP_UPDATE_MANPOWER_REQUIREMENT";
        //            using (OracleCommand cmdAddManpowerRqrmnt = new OracleCommand(strQueryAddManpowerRqrmnt, con))
        //            {

        //                cmdAddManpowerRqrmnt.CommandType = CommandType.StoredProcedure;
        //                //generate next value
        //                clsDataLayer objDataLayer = new clsDataLayer();
        //                clsEntityCommon objCommon = new clsEntityCommon();
        //                //   objCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.ManpowerRqrmnt);
        //                objCommon.CorporateID = objEntityManpowerRqrmnt.CorpId;

        //                cmdAddManpowerRqrmnt.Transaction = tran;

        //                cmdAddManpowerRqrmnt.Parameters.Add("M_MNPRQST_ID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.RequestId;


        //                cmdAddManpowerRqrmnt.Parameters.Add("M_MNPRQST_DATE", OracleDbType.Date).Value = objEntityManpowerRqrmnt.RequestDate;
        //                cmdAddManpowerRqrmnt.Parameters.Add("M_MNPRQRD_DATE", OracleDbType.Date).Value = objEntityManpowerRqrmnt.RequestDate1;

        //                cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_RESOURCENUM", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.No_Resources;



        //                cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_REFNUM", OracleDbType.Varchar2).Value = objEntityManpowerRqrmnt.Reference_Number;


        //                if (objEntityManpowerRqrmnt.DesignationId == 0)
        //                {

        //                    cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_DESIGID", OracleDbType.Int32).Value = null;
        //                }
        //                else
        //                {

        //                    cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_DESIGID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.DesignationId;


        //                }

        //                if (objEntityManpowerRqrmnt.DivisionId == 0)
        //                {

        //                    cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_DIVID", OracleDbType.Int32).Value = null;
        //                }
        //                else
        //                {

        //                    cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_DIVID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.DivisionId;


        //                }
        //                if (objEntityManpowerRqrmnt.Derpartment == 0)
        //                {

        //                    cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_DEPID", OracleDbType.Int32).Value = null;
        //                }
        //                else
        //                {

        //                    cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_DEPID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.Derpartment;


        //                }
        //                if (objEntityManpowerRqrmnt.Project == 0)
        //                {

        //                    cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_PROJID", OracleDbType.Int32).Value = null;
        //                }
        //                else
        //                {

        //                    cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_PROJID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.Project;


        //                }
        //                cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_EXPERIENCE", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.ExperienceRqrd;
        //                cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_RECRUTRSN", OracleDbType.Varchar2).Value = objEntityManpowerRqrmnt.RecruitReason;

        //                if (objEntityManpowerRqrmnt.PaygradeId == 0)
        //                {

        //                    cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_PAYGRDID", OracleDbType.Int32).Value = null;
        //                }
        //                else
        //                {

        //                    cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_PAYGRDID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.PaygradeId;


        //                }
        //                cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_OTHRBENEFITS", OracleDbType.Varchar2).Value = objEntityManpowerRqrmnt.OtherBenefits;
        //                cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_COMMENTS", OracleDbType.Varchar2).Value = objEntityManpowerRqrmnt.Comments;
        //                if (objEntityManpowerRqrmnt.Identer == 0)
        //                {

        //                    cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_IDENTER_ID", OracleDbType.Int32).Value = null;
        //                }
        //                else
        //                {

        //                    cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_IDENTER_ID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.Identer;


        //                }



        //                cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_UPD_USR_ID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.UserId;



        //                cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_UPD_DATE", OracleDbType.Date).Value = objEntityManpowerRqrmnt.RequestDate;



        //                cmdAddManpowerRqrmnt.Parameters.Add("M_MNP_PROCESS_STATUS", OracleDbType.Varchar2).Value = objEntityManpowerRqrmnt.Application_Status;

        //                cmdAddManpowerRqrmnt.Parameters.Add("M_STATUS", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.Cancel_Status;

        //                cmdAddManpowerRqrmnt.ExecuteNonQuery();
        //            }
        //            for (int i = 0; i < objEntityManpowerRqrmnt.PrefCountry_id.Count(); i++)
        //            {
        //                if (objEntityManpowerRqrmnt.PrefCountry_id[i] != 0)
        //                {
        //                    string strQueryInsertDetail = "MANPOWER_REQUIREMENT.SP_INSERT_PREF_NTNLTY";
        //                    using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
        //                    {
        //                        cmdAddInsertDetail.Transaction = tran;
        //                        cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
        //                        cmdAddInsertDetail.Parameters.Add("M_PREF_CNTRY_ID", OracleDbType.Int32).Value = objEntityManpowerRqrmnt.PrefCountry_id[i];
        //                        cmdAddInsertDetail.Parameters.Add("M_MNPRQST_ID", OracleDbType.Varchar2).Value = objEntityManpowerRqrmnt.PrefferedMastrID;

        //                        cmdAddInsertDetail.ExecuteNonQuery();
        //                    }

        //                }
        //            }

        //            tran.Commit();
        //        }

        //        catch (Exception e)
        //        {
        //            tran.Rollback();
        //            throw e;
        //        }

        //    }

        //}

        public void UpdateShortlist(clsEntityLayer_Candidate_ShortList objEntityShortlist,List<ShortListedCandiate> objlistShortList)
        {
            string strQueryReadImmigrationById = "CANDIDATE_SHORTLIST.SP_DELETE_SHORTLIST_DETAILS";
            using (OracleCommand cmdReadImmigrationById = new OracleCommand())
            {
                OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
                con.Open();
                cmdReadImmigrationById.Connection = con;


                cmdReadImmigrationById.CommandText = strQueryReadImmigrationById;
                cmdReadImmigrationById.CommandType = CommandType.StoredProcedure;
                  cmdReadImmigrationById.Parameters.Add("C_CAND_SHRTLIST_ID", OracleDbType.Int32).Value = objEntityShortlist.ShortlistMasterId;
              
                cmdReadImmigrationById.ExecuteNonQuery();
            }

            foreach (ShortListedCandiate objShortlist in objlistShortList)
            {
                string strQueryInsertDetail = "CANDIDATE_SHORTLIST.SP_UPDATE_SHORTLIST_DETAILS";
                OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
                con.Open();
                using (OracleCommand cmdAddInsertDetail = new OracleCommand(strQueryInsertDetail, con))
                {
                    

                    cmdAddInsertDetail.CommandType = CommandType.StoredProcedure;
                    cmdAddInsertDetail.Parameters.Add("C_CAND_MSTRID", OracleDbType.Int32).Value = objShortlist.CandidateId;
                    cmdAddInsertDetail.Parameters.Add("C_CAND_SHRTLIST_ID", OracleDbType.Int32).Value = objEntityShortlist.ShortlistMasterId;

                    cmdAddInsertDetail.ExecuteNonQuery();
                }
            }
          
        }

        public void ChangeStatus(clsEntityLayer_Candidate_ShortList objEntityShortlist)
        {
            string strQueryReadImmigrationById = "CANDIDATE_SHORTLIST.SP_CHANGE_STATUS";
            using (OracleCommand cmdReadImmigrationById = new OracleCommand())
            {
                OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
                con.Open();
                cmdReadImmigrationById.Connection = con;


                cmdReadImmigrationById.CommandText = strQueryReadImmigrationById;
                cmdReadImmigrationById.CommandType = CommandType.StoredProcedure;
                cmdReadImmigrationById.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityShortlist.Organisation_Id;
                cmdReadImmigrationById.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityShortlist.CorpOffice_Id;
                cmdReadImmigrationById.Parameters.Add("C_CAND_SHRTLIST_ID", OracleDbType.Int32).Value = objEntityShortlist.ShortlistMasterId;
                cmdReadImmigrationById.Parameters.Add("C_CAND_UPD_USR_ID", OracleDbType.Int32).Value = objEntityShortlist.User_Id;
                cmdReadImmigrationById.Parameters.Add("C_CAND_UPD_DATE", OracleDbType.Date).Value = objEntityShortlist.ShorltistDate;

                cmdReadImmigrationById.Parameters.Add("C_CAND_CNFRM_STATUS", OracleDbType.Int32).Value = objEntityShortlist.Confirmstatus;

                cmdReadImmigrationById.ExecuteNonQuery();
            }
        }

        public DataTable ReadSelected_Candidates(clsEntityLayer_Candidate_ShortList objEntityShortlist)
        {
            string strQueryReadPayGrd = "CANDIDATE_SHORTLIST.SP_GET_SHORT_LISTED_CAND";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;

            cmdReadJob.Parameters.Add("C_MNPRQST_ID", OracleDbType.Int32).Value = objEntityShortlist.ReqstID;
            cmdReadJob.Parameters.Add("P_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public void ConfirmEntries(clsEntityLayer_Candidate_ShortList objEntityShortlist)
        {
            string strQueryReadImmigrationById = "CANDIDATE_SHORTLIST.SP_CNFRM_STATUS";
            using (OracleCommand cmdReadImmigrationById = new OracleCommand())
            {
                OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
                con.Open();
                cmdReadImmigrationById.Connection = con;


                cmdReadImmigrationById.CommandText = strQueryReadImmigrationById;
                cmdReadImmigrationById.CommandType = CommandType.StoredProcedure;

                cmdReadImmigrationById.Parameters.Add("C_CAND_SHRTLIST_ID", OracleDbType.Int32).Value = objEntityShortlist.ShortlistMasterId;

                cmdReadImmigrationById.Parameters.Add("C_CAND_CNFRM_STATUS", OracleDbType.Int32).Value = objEntityShortlist.Confirmstatus;

                cmdReadImmigrationById.ExecuteNonQuery();
            }
        }
        public void ConfirmCandidateId(clsEntityLayer_Candidate_ShortList objEntityShortlist)
        {
            string strQueryReadImmigrationById = "CANDIDATE_SHORTLIST.SP_CNFRM_CAND_STATUS";
            using (OracleCommand cmdReadImmigrationById = new OracleCommand())
            {
                OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString());
                con.Open();
                cmdReadImmigrationById.Connection = con;


                cmdReadImmigrationById.CommandText = strQueryReadImmigrationById;
                cmdReadImmigrationById.CommandType = CommandType.StoredProcedure;

                cmdReadImmigrationById.Parameters.Add("C_CAND_ID", OracleDbType.Int32).Value = objEntityShortlist.ShortlistDetailId;

                cmdReadImmigrationById.Parameters.Add("C_CAND_CNFRM_STATUS", OracleDbType.Int32).Value = objEntityShortlist.Confirmstatus;

                cmdReadImmigrationById.ExecuteNonQuery();
            }
        }
    }
}
