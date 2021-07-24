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
    public class clsDataLayerRequirementAllocationcs
    {
        public DataTable ReadDivision(clsEntityRequirementAllocation objEntityReqrmntAlctn)
        {
            string strQueryReadPayGrd = "REQUIREMENT_ALLOCATION.SP_READ_DIVISION";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadJob.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.Organisation_Id;
            cmdReadJob.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.CorpOffice_Id;
            cmdReadJob.Parameters.Add("R_USERID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.User_Id;
            cmdReadJob.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadDepartment(clsEntityRequirementAllocation objEntityReqrmntAlctn)
        {
            string strQueryReadPayGrd = "REQUIREMENT_ALLOCATION.SP_READ_DEPRTMNT";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadJob.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.Organisation_Id;
            cmdReadJob.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.CorpOffice_Id;
            cmdReadJob.Parameters.Add("R_USERID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.User_Id;
            cmdReadJob.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadProject(clsEntityRequirementAllocation objEntityReqrmntAlctn)
        {
            string strQueryReadPayGrd = "REQUIREMENT_ALLOCATION.SP_READ_PROJECT";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadJob.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.Organisation_Id;
            cmdReadJob.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.CorpOffice_Id;
            cmdReadJob.Parameters.Add("R_USERID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.User_Id;
            cmdReadJob.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadEmployeeList(clsEntityRequirementAllocation objEntityReqrmntAlctn)
        {
            string strQueryReadPayGrd = "REQUIREMENT_ALLOCATION.SP_READ_EMPLOYEE";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            //cmdReadBankGuarnt.Parameters.Add("B_USERID", OracleDbType.Int32).Value = objEntityBnkGuarnte.User_Id;
            cmdReadJob.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.Organisation_Id;
            cmdReadJob.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.CorpOffice_Id;
            cmdReadJob.Parameters.Add("R_USERID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.User_Id;
            cmdReadJob.Parameters.Add("R_SELFALCT_STS", OracleDbType.Int32).Value = objEntityReqrmntAlctn.SelfAlctnSts;
            cmdReadJob.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public DataTable ReadRequirementList(clsEntityRequirementAllocation objEntityReqrmntAlctn)
        {
            string strQueryReadPayGrd = "REQUIREMENT_ALLOCATION.SP_READ_REQRMNTLIST";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;

            cmdReadJob.Parameters.Add("R_DIV_ID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.DivId;
            cmdReadJob.Parameters.Add("R_DEPRTID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.Deprt_Id;
            cmdReadJob.Parameters.Add("R_PRJCTID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.PrjctId;
            cmdReadJob.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.Organisation_Id;
            cmdReadJob.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.CorpOffice_Id;
            cmdReadJob.Parameters.Add("R_USERID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.User_Id;
            cmdReadJob.Parameters.Add("R_STATUS", OracleDbType.Int32).Value = objEntityReqrmntAlctn.ReqrmntAlctnDtl_Id;
            cmdReadJob.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }
        public void insertReqrmntAlctnDtls(clsEntityRequirementAllocation objEntityReqrmntAlctn, string[] strarrRqrmntIds, string[] strarrRqrmntReIds)
        {
            clsDataLayer objDatatLayer = new clsDataLayer();
            string strQueryInsertJobShdl = "REQUIREMENT_ALLOCATION.SP_INSERT_RQMNTALCT_MSTR";
            OracleTransaction tran;
            //insert to main register table
            using (OracleConnection con = new OracleConnection(clsDataLayer.GetConnectionString()))
            {
                con.Open();
                tran = con.BeginTransaction();

                try
                {

                    using (OracleCommand cmdInsertJobSchdlng = new OracleCommand(strQueryInsertJobShdl, con))
                    {
                        cmdInsertJobSchdlng.Transaction = tran;
                        cmdInsertJobSchdlng.CommandType = CommandType.StoredProcedure;
                        cmdInsertJobSchdlng.Parameters.Add("R_ID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.ReqrmntAlctn_Id;
                        cmdInsertJobSchdlng.Parameters.Add("R_EMPID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.Employee_Id;
                        cmdInsertJobSchdlng.Parameters.Add("R_ORGID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.Organisation_Id;
                        cmdInsertJobSchdlng.Parameters.Add("R_CORPID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.CorpOffice_Id;
                        cmdInsertJobSchdlng.Parameters.Add("R_INSUSERID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.User_Id;
                        cmdInsertJobSchdlng.Parameters.Add("R_INSDATE", OracleDbType.Date).Value = objEntityReqrmntAlctn.D_Date;
                        cmdInsertJobSchdlng.ExecuteNonQuery();

                    }
                   
                   
                    foreach (string strDtlId in strarrRqrmntIds)
                    {
                        if (strDtlId != "" && strDtlId != null)
                        {
                            int intDtlId = Convert.ToInt32(strDtlId);

                            string strQueryCancelDetail = "REQUIREMENT_ALLOCATION.SP_INSERT_RQMNTALCT_DTL";
                            using (OracleCommand cmdCancelDetail = new OracleCommand(strQueryCancelDetail, con))
                            {
                                cmdCancelDetail.Transaction = tran;
                                cmdCancelDetail.CommandType = CommandType.StoredProcedure;
                                cmdCancelDetail.Parameters.Add("R_ID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.ReqrmntAlctn_Id;
                                cmdCancelDetail.Parameters.Add("R_DTLID", OracleDbType.Int32).Value = intDtlId;
                                cmdCancelDetail.ExecuteNonQuery();
                            }
                        }
                    }

                    foreach (string strDtlId in strarrRqrmntReIds)
                    {
                        if (strDtlId != "" && strDtlId != null)
                        {
                            int intDtlId = Convert.ToInt32(strDtlId);

                            string strQueryCancelDetail = "REQUIREMENT_ALLOCATION.SP_UPDATE_RQMNTALCT_DTL";
                            using (OracleCommand cmdCancelDetail = new OracleCommand(strQueryCancelDetail, con))
                            {
                                cmdCancelDetail.Transaction = tran;
                                cmdCancelDetail.CommandType = CommandType.StoredProcedure;
                                cmdCancelDetail.Parameters.Add("R_ID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.ReqrmntAlctn_Id;
                                cmdCancelDetail.Parameters.Add("R_DTLID", OracleDbType.Int32).Value = intDtlId;
                                cmdCancelDetail.ExecuteNonQuery();
                            }
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


        public DataTable ChkRqrmntAlcted(clsEntityRequirementAllocation objEntityReqrmntAlctn)
        {
            string strQueryReadPayGrd = "REQUIREMENT_ALLOCATION.SP_READ_RQMNTCHK";
            OracleCommand cmdReadJob = new OracleCommand();
            cmdReadJob.CommandText = strQueryReadPayGrd;
            cmdReadJob.CommandType = CommandType.StoredProcedure;
            cmdReadJob.Parameters.Add("R_RQMNTID", OracleDbType.Int32).Value = objEntityReqrmntAlctn.Reqrmnt_Id;
            cmdReadJob.Parameters.Add("R_OUT", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            DataTable dtCategory = new DataTable();
            dtCategory = clsDataLayer.ExecuteReader(cmdReadJob);
            return dtCategory;
        }

    }
}
