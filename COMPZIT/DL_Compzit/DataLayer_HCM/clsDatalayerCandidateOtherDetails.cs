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
    public class clsDatalayerCandidateOtherDetails
    {
        //Method for fetch country master table from database.
        public DataTable readCountry()
        {
            string strQueryReadCountry = "CORPORATE_OFFICE.SP_READ_COUNTRY";
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
        //Method for fetch religion master table from database.
        public DataTable ReadReligion()
        {
            string strQueryReadCountry = "PERSONAL_DETAILS.SP_READ_RELIGION";
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryReadCountry;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;
                cmdReadCountry.Parameters.Add("R_RELIGION", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = clsDataLayer.SelectDataTable(cmdReadCountry);
                return dt;
            }
        }
        //Method for fetch blood group master table from database.
        public DataTable ReadBloodgrp()
        {
            string strQueryReadCountry = "PERSONAL_DETAILS.SP_READ_BLDGRP";
            using (OracleCommand cmdReadCountry = new OracleCommand())
            {
                cmdReadCountry.CommandText = strQueryReadCountry;
                cmdReadCountry.CommandType = CommandType.StoredProcedure;
                cmdReadCountry.Parameters.Add("R_BLDGRP", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                DataTable dt = new DataTable();
                dt = clsDataLayer.SelectDataTable(cmdReadCountry);
                return dt;
            }
        }
        public void insertCandidateDtls(clsEntityCandidateOtherDetails objEntityCandidateDtls, List<clsEntityStaffOtherSub> objEntityStaffOtherDetilsSub)
        {
             OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                  
            string strQueryAddCandidateDtls = "STAFF_OTHER_DETAILS.SP_INS_STAFF_OTHER_DTLS";
            using (OracleCommand cmdAddCandidateDtls = new OracleCommand())
            {
                cmdAddCandidateDtls.Transaction = tran;
                cmdAddCandidateDtls.Connection = con;
                cmdAddCandidateDtls.CommandText = strQueryAddCandidateDtls;
                cmdAddCandidateDtls.CommandType = CommandType.StoredProcedure;
                cmdAddCandidateDtls.Parameters.Add("O_CANDID", OracleDbType.Int32).Value = objEntityCandidateDtls.CandId;
                if (objEntityCandidateDtls.Dob == DateTime.MinValue)
                {
                    cmdAddCandidateDtls.Parameters.Add("O_DOB", OracleDbType.Date).Value = null;
                }
                else
                {
                    cmdAddCandidateDtls.Parameters.Add("O_DOB", OracleDbType.Date).Value = objEntityCandidateDtls.Dob;
                }
                cmdAddCandidateDtls.Parameters.Add("O_BLDGRPID", OracleDbType.Int32).Value = objEntityCandidateDtls.BloodGroupId;
                if (objEntityCandidateDtls.SpOcu == null)
                {
                    cmdAddCandidateDtls.Parameters.Add("O_SPOCU", OracleDbType.Varchar2).Value = null;
                }
                else
                {
                    cmdAddCandidateDtls.Parameters.Add("O_SPOCU", OracleDbType.Varchar2).Value = objEntityCandidateDtls.SpOcu;
                }

                cmdAddCandidateDtls.Parameters.Add("O_ILLNESSTS", OracleDbType.Int32).Value = objEntityCandidateDtls.illnesstatus;

                if (objEntityCandidateDtls.IllnesDetails == null)
                {
                    cmdAddCandidateDtls.Parameters.Add("O_ILLNESYES", OracleDbType.Varchar2).Value = null;
                }
                else
                {
                    cmdAddCandidateDtls.Parameters.Add("O_ILLNESYES", OracleDbType.Varchar2).Value = objEntityCandidateDtls.IllnesDetails;
                }

                cmdAddCandidateDtls.Parameters.Add("O_APLIEDBFRSTS", OracleDbType.Int32).Value = objEntityCandidateDtls.AppliedBfrSts;

                if (objEntityCandidateDtls.AppliedBfrDtls == null)
                {
                    cmdAddCandidateDtls.Parameters.Add("O_APLIEDBFRYES", OracleDbType.Varchar2).Value = null;
                }
                else
                {
                    cmdAddCandidateDtls.Parameters.Add("O_APLIEDBFRYES", OracleDbType.Varchar2).Value = objEntityCandidateDtls.AppliedBfrDtls;
                }

                cmdAddCandidateDtls.Parameters.Add("O_RELATIVESTS", OracleDbType.Int32).Value = objEntityCandidateDtls.Relationstats;

                if (objEntityCandidateDtls.Document == null)
                {
                    cmdAddCandidateDtls.Parameters.Add("O_DOCUMENT", OracleDbType.Varchar2).Value = null;
                }
                else
                {
                    cmdAddCandidateDtls.Parameters.Add("O_DOCUMENT", OracleDbType.Varchar2).Value = objEntityCandidateDtls.Document;
                }

                cmdAddCandidateDtls.Parameters.Add("O_ORGID", OracleDbType.Int32).Value = objEntityCandidateDtls.UserOrgId;
                cmdAddCandidateDtls.Parameters.Add("O_CORPRTID", OracleDbType.Int32).Value = objEntityCandidateDtls.CrprtId;
                cmdAddCandidateDtls.Parameters.Add("O_INSUSRID", OracleDbType.Int32).Value = objEntityCandidateDtls.InsUserId;
                cmdAddCandidateDtls.Parameters.Add("O_INSDATE", OracleDbType.Date).Value = objEntityCandidateDtls.InsUserDate;
                cmdAddCandidateDtls.Parameters.Add("O_USERID", OracleDbType.Int32).Value = objEntityCandidateDtls.UserID;
                if (objEntityCandidateDtls.Document == null)
                {
                    cmdAddCandidateDtls.Parameters.Add("O_A_NAME", OracleDbType.Varchar2).Value = null;
                }
                else
                {
                    cmdAddCandidateDtls.Parameters.Add("O_A_NAME", OracleDbType.Varchar2).Value = objEntityCandidateDtls.Name1;
                }               
              
                if (objEntityCandidateDtls.Document == null)
                {
                    cmdAddCandidateDtls.Parameters.Add("O_A_ADDR", OracleDbType.Varchar2).Value = null;
                }
                else
                {
                    cmdAddCandidateDtls.Parameters.Add("O_A_ADDR", OracleDbType.Varchar2).Value = objEntityCandidateDtls.Address1;
                }
                if (objEntityCandidateDtls.Document == null)
                {
                    cmdAddCandidateDtls.Parameters.Add("O_A_OCCUPATION", OracleDbType.Varchar2).Value = null;
                }
                else
                {
                    cmdAddCandidateDtls.Parameters.Add("O_A_OCCUPATION", OracleDbType.Varchar2).Value = objEntityCandidateDtls.Occupation1;
                }
                if (objEntityCandidateDtls.Document == null)
                {
                    cmdAddCandidateDtls.Parameters.Add("O_A_PHN", OracleDbType.Varchar2).Value = null;
                }
                else
                {
                    cmdAddCandidateDtls.Parameters.Add("O_A_PHN", OracleDbType.Varchar2).Value = objEntityCandidateDtls.Phonenumber1;
                }
                if (objEntityCandidateDtls.Document == null)
                {
                    cmdAddCandidateDtls.Parameters.Add("O_B_NAME", OracleDbType.Varchar2).Value = null;
                }
                else
                {
                    cmdAddCandidateDtls.Parameters.Add("O_B_NAME", OracleDbType.Varchar2).Value = objEntityCandidateDtls.Name2;
                }
                if (objEntityCandidateDtls.Document == null)
                {
                    cmdAddCandidateDtls.Parameters.Add("O_B_ADDR", OracleDbType.Varchar2).Value = null;
                }
                else
                {
                    cmdAddCandidateDtls.Parameters.Add("O_B_ADDR", OracleDbType.Varchar2).Value = objEntityCandidateDtls.Address2; ;
                }
                if (objEntityCandidateDtls.Document == null)
                {
                    cmdAddCandidateDtls.Parameters.Add("O_B_OCCUPATION", OracleDbType.Varchar2).Value = null;
                }
                else
                {
                    cmdAddCandidateDtls.Parameters.Add("O_B_OCCUPATION", OracleDbType.Varchar2).Value = objEntityCandidateDtls.Occupation2;
                }
                if (objEntityCandidateDtls.Document == null)
                {
                    cmdAddCandidateDtls.Parameters.Add("O_B_PHN", OracleDbType.Varchar2).Value = null;
                }
                else
                {
                    cmdAddCandidateDtls.Parameters.Add("O_B_PHN", OracleDbType.Varchar2).Value = objEntityCandidateDtls.Phonenumber2;
                }
               
                    cmdAddCandidateDtls.Parameters.Add("O_SECURSTS", OracleDbType.Int32).Value = objEntityCandidateDtls.SecurSts;

                    if (objEntityCandidateDtls.JoiningDate == null)
                    {
                        cmdAddCandidateDtls.Parameters.Add("O_JOINDATE", OracleDbType.Date).Value = null;
                    }
                    else
                    {
                        cmdAddCandidateDtls.Parameters.Add("O_JOINDATE", OracleDbType.Date).Value = objEntityCandidateDtls.JoiningDate;
                    }
                    cmdAddCandidateDtls.Parameters.Add("O_DOC_NAME", OracleDbType.Varchar2).Value = objEntityCandidateDtls.ImigDocName;
 
                //clsDataLayer.ExecuteNonQuery(cmdAddCandidateDtls);
                    cmdAddCandidateDtls.ExecuteNonQuery();
            }

            string strQueryInsertCandidateOtherDtl = "STAFF_OTHER_DETAILS.SP_INSERT_STAFF_OTHER_DTL_SUB";
            foreach (clsEntityStaffOtherSub objIntCatDtl in objEntityStaffOtherDetilsSub)
            {
                using (OracleCommand cmdInsertCandidateOtherDetails = new OracleCommand())
                {
                    cmdInsertCandidateOtherDetails.Transaction = tran;
                    cmdInsertCandidateOtherDetails.Connection = con;
                    cmdInsertCandidateOtherDetails.CommandText = strQueryInsertCandidateOtherDtl;
                    cmdInsertCandidateOtherDetails.CommandType = CommandType.StoredProcedure;
                    cmdInsertCandidateOtherDetails.Parameters.Add("O_CND_ID", OracleDbType.Int32).Value = objEntityCandidateDtls.CandId;
                    cmdInsertCandidateOtherDetails.Parameters.Add("O_WKR_DTL_FILE_NAME", OracleDbType.Varchar2).Value = objIntCatDtl.OtherDocuFileName;
                    cmdInsertCandidateOtherDetails.Parameters.Add("O_WKR_DTL_ACT_NAME", OracleDbType.Varchar2).Value = objIntCatDtl.OtherDocuActualName;
                    cmdInsertCandidateOtherDetails.Parameters.Add("O_CORPID", OracleDbType.Int32).Value = objEntityCandidateDtls.CrprtId;
                    cmdInsertCandidateOtherDetails.ExecuteNonQuery();
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



        public DataTable ReadStaffOtherSubByID(clsEntityCandidateOtherDetails objEntityCandidateDtls)
        {
            string strQueryReadPayGrd = "STAFF_OTHER_DETAILS.SP_READ_STAFF_OTHER_SUB_BYID";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("O_WORKER_ID", OracleDbType.Int32).Value = objEntityCandidateDtls.CandId; ;
            cmdReadJob.Parameters.Add("O_DETAIL", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }








        public void updatePersonalDtls(clsEntityCandidateOtherDetails objEntityCandidateDtls, List<clsEntityStaffOtherSub> objEntityStaffOtherDetilsSub ,List<clsEntityStaffOtherSub> objEntityStaffOtherDeleteSub)
        {
             OracleTransaction tran;
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();
                try
                {
                    string strQueryAddCandidateDtls = "STAFF_OTHER_DETAILS.SP_UPD_STAFF_OTHER_DTLS";
            using (OracleCommand cmdAddCandidateDtls = new OracleCommand())
            {   
                 cmdAddCandidateDtls.Transaction = tran;
                        cmdAddCandidateDtls.Connection = con;
                cmdAddCandidateDtls.CommandText = strQueryAddCandidateDtls;
                cmdAddCandidateDtls.CommandType = CommandType.StoredProcedure;
                cmdAddCandidateDtls.Parameters.Add("O_CANDID", OracleDbType.Int32).Value = objEntityCandidateDtls.CandId;
                if (objEntityCandidateDtls.Dob == DateTime.MinValue)
                {
                    cmdAddCandidateDtls.Parameters.Add("O_DOB", OracleDbType.Date).Value = null;
                }
                else
                {
                    cmdAddCandidateDtls.Parameters.Add("O_DOB", OracleDbType.Date).Value = objEntityCandidateDtls.Dob;
                }
                cmdAddCandidateDtls.Parameters.Add("O_BLDGRPID", OracleDbType.Int32).Value = objEntityCandidateDtls.BloodGroupId;
                if (objEntityCandidateDtls.SpOcu == null)
                {
                    cmdAddCandidateDtls.Parameters.Add("O_SPOCU", OracleDbType.Varchar2).Value = null;
                }
                else
                {
                    cmdAddCandidateDtls.Parameters.Add("O_SPOCU", OracleDbType.Varchar2).Value = objEntityCandidateDtls.SpOcu;
                }

                cmdAddCandidateDtls.Parameters.Add("O_ILLNESSTS", OracleDbType.Int32).Value = objEntityCandidateDtls.illnesstatus;

                if (objEntityCandidateDtls.IllnesDetails == null)
                {
                    cmdAddCandidateDtls.Parameters.Add("O_ILLNESYES", OracleDbType.Varchar2).Value = null;
                }
                else
                {
                    cmdAddCandidateDtls.Parameters.Add("O_ILLNESYES", OracleDbType.Varchar2).Value = objEntityCandidateDtls.IllnesDetails;
                }

                cmdAddCandidateDtls.Parameters.Add("O_APLIEDBFRSTS", OracleDbType.Int32).Value = objEntityCandidateDtls.AppliedBfrSts;

                if (objEntityCandidateDtls.AppliedBfrDtls == null)
                {
                    cmdAddCandidateDtls.Parameters.Add("O_APLIEDBFRYES", OracleDbType.Varchar2).Value = null;
                }
                else
                {
                    cmdAddCandidateDtls.Parameters.Add("O_APLIEDBFRYES", OracleDbType.Varchar2).Value = objEntityCandidateDtls.AppliedBfrDtls;
                }

                cmdAddCandidateDtls.Parameters.Add("O_RELATIVESTS", OracleDbType.Int32).Value = objEntityCandidateDtls.Relationstats;

                if (objEntityCandidateDtls.Document == null)
                {
                    cmdAddCandidateDtls.Parameters.Add("O_DOCUMENT", OracleDbType.Varchar2).Value = null;
                }
                else
                {
                    cmdAddCandidateDtls.Parameters.Add("O_DOCUMENT", OracleDbType.Varchar2).Value = objEntityCandidateDtls.Document;
                }

                cmdAddCandidateDtls.Parameters.Add("O_ORGID", OracleDbType.Int32).Value = objEntityCandidateDtls.UserOrgId;
                cmdAddCandidateDtls.Parameters.Add("O_CORPRTID", OracleDbType.Int32).Value = objEntityCandidateDtls.CrprtId;
                cmdAddCandidateDtls.Parameters.Add("O_INSUSRID", OracleDbType.Int32).Value = objEntityCandidateDtls.InsUserId;
                cmdAddCandidateDtls.Parameters.Add("O_INSDATE", OracleDbType.Date).Value = objEntityCandidateDtls.InsUserDate;
                cmdAddCandidateDtls.Parameters.Add("O_USERID", OracleDbType.Int32).Value = objEntityCandidateDtls.UserID;
                if (objEntityCandidateDtls.Document == null)
                {
                    cmdAddCandidateDtls.Parameters.Add("O_A_NAME", OracleDbType.Varchar2).Value = null;
                }
                else
                {
                    cmdAddCandidateDtls.Parameters.Add("O_A_NAME", OracleDbType.Varchar2).Value = objEntityCandidateDtls.Name1;
                }

                if (objEntityCandidateDtls.Document == null)
                {
                    cmdAddCandidateDtls.Parameters.Add("O_A_ADDR", OracleDbType.Varchar2).Value = null;
                }
                else
                {
                    cmdAddCandidateDtls.Parameters.Add("O_A_ADDR", OracleDbType.Varchar2).Value = objEntityCandidateDtls.Address1;
                }
                if (objEntityCandidateDtls.Document == null)
                {
                    cmdAddCandidateDtls.Parameters.Add("O_A_OCCUPATION", OracleDbType.Varchar2).Value = null;
                }
                else
                {
                    cmdAddCandidateDtls.Parameters.Add("O_A_OCCUPATION", OracleDbType.Varchar2).Value = objEntityCandidateDtls.Occupation1;
                }
                if (objEntityCandidateDtls.Document == null)
                {
                    cmdAddCandidateDtls.Parameters.Add("O_A_PHN", OracleDbType.Varchar2).Value = null;
                }
                else
                {
                    cmdAddCandidateDtls.Parameters.Add("O_A_PHN", OracleDbType.Varchar2).Value = objEntityCandidateDtls.Phonenumber1;
                }
                if (objEntityCandidateDtls.Document == null)
                {
                    cmdAddCandidateDtls.Parameters.Add("O_B_NAME", OracleDbType.Varchar2).Value = null;
                }
                else
                {
                    cmdAddCandidateDtls.Parameters.Add("O_B_NAME", OracleDbType.Varchar2).Value = objEntityCandidateDtls.Name2;
                }
                if (objEntityCandidateDtls.Document == null)
                {
                    cmdAddCandidateDtls.Parameters.Add("O_B_ADDR", OracleDbType.Varchar2).Value = null;
                }
                else
                {
                    cmdAddCandidateDtls.Parameters.Add("O_B_ADDR", OracleDbType.Varchar2).Value = objEntityCandidateDtls.Address2; ;
                }
                if (objEntityCandidateDtls.Document == null)
                {
                    cmdAddCandidateDtls.Parameters.Add("O_B_OCCUPATION", OracleDbType.Varchar2).Value = null;
                }
                else
                {
                    cmdAddCandidateDtls.Parameters.Add("O_B_OCCUPATION", OracleDbType.Varchar2).Value = objEntityCandidateDtls.Occupation2;
                }
                if (objEntityCandidateDtls.Document == null)
                {
                    cmdAddCandidateDtls.Parameters.Add("O_B_PHN", OracleDbType.Varchar2).Value = null;
                }
                else
                {
                    cmdAddCandidateDtls.Parameters.Add("O_B_PHN", OracleDbType.Varchar2).Value = objEntityCandidateDtls.Phonenumber2;
                }

                cmdAddCandidateDtls.Parameters.Add("O_SECURSTS", OracleDbType.Int32).Value = objEntityCandidateDtls.SecurSts;

                if (objEntityCandidateDtls.JoiningDate == null)
                {
                    cmdAddCandidateDtls.Parameters.Add("O_JOINDATE", OracleDbType.Varchar2).Value = null;
                }
                else
                {
                    cmdAddCandidateDtls.Parameters.Add("O_JOINDATE", OracleDbType.Date).Value = objEntityCandidateDtls.JoiningDate;
                }
                cmdAddCandidateDtls.Parameters.Add("O_DOC_NAME", OracleDbType.Varchar2).Value = objEntityCandidateDtls.ImigDocName;
               
                clsDataLayer.ExecuteNonQuery(cmdAddCandidateDtls);

            }
            string strQueryInsertCandidateOtherDtl = "STAFF_OTHER_DETAILS.SP_INSERT_STAFF_OTHER_DTL_SUB";
            foreach (clsEntityStaffOtherSub objIntCatDtl in objEntityStaffOtherDetilsSub)
                    {
                        using (OracleCommand cmdInsertCandidateOtherDetails = new OracleCommand())
                        {
                            cmdInsertCandidateOtherDetails.Transaction = tran;
                    cmdInsertCandidateOtherDetails.Connection = con;
                    cmdInsertCandidateOtherDetails.CommandText = strQueryInsertCandidateOtherDtl;
                    cmdInsertCandidateOtherDetails.CommandType = CommandType.StoredProcedure;
                    cmdInsertCandidateOtherDetails.Parameters.Add("O_CND_ID", OracleDbType.Int32).Value = objEntityCandidateDtls.CandId;
                    cmdInsertCandidateOtherDetails.Parameters.Add("O_WKR_DTL_FILE_NAME", OracleDbType.Varchar2).Value = objIntCatDtl.OtherDocuFileName;
                    cmdInsertCandidateOtherDetails.Parameters.Add("O_WKR_DTL_ACT_NAME", OracleDbType.Varchar2).Value = objIntCatDtl.OtherDocuActualName;
                    cmdInsertCandidateOtherDetails.Parameters.Add("O_CORPID", OracleDbType.Int32).Value = objEntityCandidateDtls.CrprtId;
                    cmdInsertCandidateOtherDetails.ExecuteNonQuery();
                        }
                    }
            string strQueryDeleteCandidateWorkerDtl = "STAFF_OTHER_DETAILS.SP_DELETE_STAFF_OTHER_SUB";
            foreach (clsEntityStaffOtherSub objIntCatDtl in objEntityStaffOtherDeleteSub)
                    {
                        using (OracleCommand cmdUpdateCandidateOtherDtl = new OracleCommand())
                        {
                            cmdUpdateCandidateOtherDtl.Transaction = tran;
                            cmdUpdateCandidateOtherDtl.Connection = con;
                            cmdUpdateCandidateOtherDtl.CommandText = strQueryDeleteCandidateWorkerDtl;
                            cmdUpdateCandidateOtherDtl.CommandType = CommandType.StoredProcedure;
                            cmdUpdateCandidateOtherDtl.Parameters.Add("O_WKR_DTL_ID", OracleDbType.Int32).Value = objIntCatDtl.WorkerDetailID;
                            cmdUpdateCandidateOtherDtl.ExecuteNonQuery();
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
       




        public DataTable ReadPersnlDtlsById(clsEntityCandidateOtherDetails objEntityCandidateDtls)
        {
            string strQueryReadDtls = "STAFF_OTHER_DETAILS.SP_READ_STAFF_OTHER_DTLS";
            using (OracleCommand cmdReadDtls = new OracleCommand())
            {
                cmdReadDtls.CommandText = strQueryReadDtls;
                cmdReadDtls.CommandType = CommandType.StoredProcedure;
                cmdReadDtls.Parameters.Add("C_ORGID", OracleDbType.Int32).Value = objEntityCandidateDtls.UserOrgId;
                cmdReadDtls.Parameters.Add("C_CORPID", OracleDbType.Int32).Value = objEntityCandidateDtls.CrprtId;
                cmdReadDtls.Parameters.Add("C_USERID", OracleDbType.Int32).Value = objEntityCandidateDtls.UserID;
                cmdReadDtls.Parameters.Add("C_CANDID", OracleDbType.Int32).Value = objEntityCandidateDtls.CandId;
                cmdReadDtls.Parameters.Add("C_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
        
                DataTable dt = new DataTable();
                dt = clsDataLayer.SelectDataTable(cmdReadDtls);
                return dt;
            }
        }
        public string CheckPerDtlAddedOrNot(string strId)
        {

            string strQueryChecK = "PERSONAL_DETAILS.SP_CHECK_PER_DTL_COUNT";
            OracleCommand cmdCheck = new OracleCommand();
            cmdCheck.CommandText = strQueryChecK;
            cmdCheck.CommandType = CommandType.StoredProcedure;
              cmdCheck.Parameters.Add("C_CANDID", OracleDbType.Int32).Value = Convert.ToInt32(strId);
            cmdCheck.Parameters.Add("P_COUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheck);
            string strReturn = cmdCheck.Parameters["P_COUNT"].Value.ToString();
            cmdCheck.Dispose();
            return strReturn;
        }


        public string checkEmpId(clsEntityPersonalDtls objEntityPersonalDtls)
        {

            string strQueryCheckCorp = "PERSONAL_DETAILS.SP_CHECK_EMPID";
            OracleCommand cmdCheckCorp = new OracleCommand();
            cmdCheckCorp.CommandText = strQueryCheckCorp;
            cmdCheckCorp.CommandType = CommandType.StoredProcedure;
            cmdCheckCorp.Parameters.Add("P_ID", OracleDbType.Int32).Value = objEntityPersonalDtls.EmpUserId;
            cmdCheckCorp.Parameters.Add("P_CORPRTID", OracleDbType.Int32).Value = objEntityPersonalDtls.Corporate_id;
            cmdCheckCorp.Parameters.Add("P_ORGID", OracleDbType.Int32).Value = objEntityPersonalDtls.Organisation_id;
            cmdCheckCorp.Parameters.Add("P_EMPID", OracleDbType.Varchar2).Value = objEntityPersonalDtls.EmployeeId;
            cmdCheckCorp.Parameters.Add("P_ORG", OracleDbType.Int32).Direction = ParameterDirection.Output;
            clsDataLayer.ExecuteScalar(ref cmdCheckCorp);
            string strReturn = cmdCheckCorp.Parameters["P_ORG"].Value.ToString();
            cmdCheckCorp.Dispose();
            return strReturn;
        }
    }
}
